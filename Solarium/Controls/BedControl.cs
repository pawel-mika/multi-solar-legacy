/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-09-29
 * Time: 20:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Timers;

using DOALibrary;
using Glass;

using Solarium.Bios;
using Solarium.Frame;
using Solarium.Controller;
using Solarium.Settings;
using Solarium.Utils;

namespace Solarium.Controls
{
	/// <summary>
	/// Description of BedControl.
	/// </summary>
	public partial class BedControl : DOATransparentLabel, ISlaveDeviceControl
	{
		private static int CRITICAL_OPS_ATTEMPTS = 4;
		
		private IMainFrame mf = null;
		private ModbusNetwork network = null;
		
		private ModbusSlaveElement modbusSlaveConfig = null;
		private ModbusSlave modbusSlave = null;
		
		private ToolTip infoToolTip = null;
		
		//stateNotReady - stan wyjatkowy ktory w sumie nie powinien sie pojawic w momencie innym
		//niz inicjalizacja kontrolki, alt to jeszcze jest do obadania...
		private BedState stateNotReady = new BedState(BedState.EState.NOT_READY, "Nie gotowe", false, "-", false, "-", TimeSpan.Zero);
		private BedState stateReady = new BedState(BedState.EState.READY, "Gotowe", false, "Start", false, "-", TimeSpan.Zero);
		private BedState stateWaiting = new BedState(BedState.EState.WAITING, "Oczekiwanie", true, "Opalaj!", true, "Anuluj", TimesSettings.GetSection(ConfigurationUserLevel.None).WaitingTime);
		private BedState stateHeating = new BedState(BedState.EState.HEATING, "Opalanie", false, "-", true, "Anuluj", TimeSpan.Zero);	//tutaj z kontrolki opalania czas
		private BedState stateCooling = new BedState(BedState.EState.COOLING, "Chłodzenie", false, "-", true, "Anuluj", TimesSettings.GetSection(ConfigurationUserLevel.None).CoolingTime);
		private BedState stateCleaning = new BedState(BedState.EState.CLEANING, "Czyszczenie", false, "-", true, "Anuluj", TimesSettings.GetSection(ConfigurationUserLevel.None).CleaningTime);
		
		/// <summary>
		/// <para>Sekwencja stanów kontrolki.</para>
		/// <list type="bullet">
		/// <item>nie gotowe - tylko dla wyjątkowych sytuacji!</item>
		/// <item>gotowe</item>
		/// <item>oczekiwanie</item>
		/// <item>opalanie</item>
		/// <item>chłodzenie</item>
		/// <item>czyszczenie</item>
		/// </list>
		/// </summary>
		private LinkedList<BedState> stateSequence = null;
		
		/// <summary>
		/// Czas opalania dla tej kontrolki.
		/// Powiązany ze stanem opalania w sekwencji stanów.
		/// </summary>
		public TimeSpan HeatingTime {
			get { return stateHeating.StateLenght; }
			set { 
				stateHeating.StateLenght = value; 
				if(currentState.State == BedState.EState.READY)
				{
					buttonStart.Enabled = true;
					selectedTimeLabel.Text = String.Format("Czas opalania: {0}", stateHeating.StateLenght);
					selectedTimeLabel.Visible = true;
				}
			}
		}
		
		/// <summary>
		/// Aktualny stan w jakim znajduje sie kontrolka/lozko
		/// </summary>
		private BedState currentState = null;
		public BedState CurrentState {
			get { return currentState; }
		}

		/// <summary>
		/// Aktualnie wyświetlana wartość timera
		/// </summary>
		public TimeSpan CurrentTimerValue {
			get {
				return TimeSpan.Parse(timerLabel.Text);
			}
		}
		
		//Czas co jaki ma byc wysylane pytanie o stan lozka
		//w momencie kiedy oczekujemy na rozpoczecie opalania
		//(nacisniecie batonow) w ms 
		private const int STATE_WAITING_BUTTON_SCAN_INTERVAL = 1000;	//1000ms
		//pauza dlugosc
		private const int PAUSE_SCAN_INTERVAL = 30000;	//30000ms
		//i zakonczenie opalania...
		private const int STATE_HEATING_BUTTON_SCAN_INTERVAL = 5000;	//5000ms
		
		private int deviceId = 0;
		public int DeviceId {
			get { return deviceId; }
			set { deviceId = value; }
		}
		
		//TODO: powiazac na obsługe z obiektu.komponentu bazy!!
		private string deviceName = "";
		public string DeviceName {
			get { 
				return dbEngine.MainComponent.FieldFilled("name") ? dbEngine.MainComponent.GetString("name") : null; 
			}
			set { 
				try {
					if(!deviceName.Equals(value))
					{
						deviceName = value;
						nameLabel.Text = deviceName;
						ChangeSet cs = dbEngine.MainComponent.GetChangeSet();
						cs.AddChange("name", deviceName);
						mf.Database.Bios.ModifyComponent(cs);
					}
				} catch (BiosException) {
					DialogUtils.ShowError(mf, "Błąd", "Wystąpił błąd podczas zapisu nazwy urządzenia do bazy!");
				}			
			}
		}
		
		private RcObject currentClient = null;
		public RcObject CurrentClient {
			get { return currentClient; }
			set { 
				currentClient = value;
				if(currentClient != null) 
				{
					String opis = String.Format("Klient: {0} {1}", 
					                            currentClient.MainComponent.GetString("name"),
					                            currentClient.MainComponent.GetString("surname"));
					infoToolTip.SetToolTip(this, opis);
				}
				else 
				{
					infoToolTip.SetToolTip(this, "Brak klienta");
				}
				
			}
		}
		
		private RcObject dbEngine = null;
		public RcObject DbEngine {
			get { return dbEngine; }
			set { dbEngine = value; }
		}
		
		private RcObject dbControl = null;
		public RcObject DbControl {
			get { return dbControl; }
			set { dbControl = value; }
		}
		
		private LinkedList<RcObject> dbServices = null;
		public LinkedList<RcObject> DbServices {
			get { return dbServices; }
			set { dbServices = value; }
		}
		
		/// <summary>
		/// The actual real timer value.
		/// </summary>
		private TimeSpan stateTimespan = TimeSpan.Zero;
		public TimeSpan StateTimespan {
			get { return stateTimespan; }
			set {
				stateTimespan = value;
				timerLabel.Text = stateTimespan.ToString();
			}
		}

		/// <summary>
		/// Timer dla stanów. Podczas zliczania zwiększa czas w <see cref="StateTimer">StateTimer</see>
		/// </summary>
		private System.Windows.Forms.Timer stateTimer = null;
		
		/// <summary>
		/// Timer skanowania przycisków gdy kontrolka w stanie oczekiwania lub opalania!
		/// </summary>
		private System.Windows.Forms.Timer buttonScanTimer = null;
		
		/// <summary>
		/// Timer opoznienia wlaczania reakcji na batony
		/// </summary>
		private System.Windows.Forms.Timer delayButtonScanTimer = null;
		
		#region _Events

		/// <summary>
		/// Fired whenever status has changed
		/// </summary>
		public event SlaveDeviceControlEventHandler StatusChanged;
		protected virtual void FireStatusChanged(SlaveDeviceControlEvent e){
			if(StatusChanged!=null){
				StatusChanged(this, e);
			}
		}
		
		/// <summary>
		/// Fired whenever any property has changed
		/// </summary>
		public event SlaveDeviceControlEventHandler PropertyChanged;
		protected virtual void FirePropertyChanged(SlaveDeviceControlEvent e){
			if(PropertyChanged!=null){
				PropertyChanged(this, e);
			}
		}
		
		/// <summary>
		/// fired when timer is started
		/// </summary>
		public event SlaveDeviceControlEventHandler TimerStarted;
		protected virtual void FireTimerStarted(SlaveDeviceControlEvent e){
			if(TimerStarted!=null){
				TimerStarted(this, e);
			}
		}
		
		/// <summary>
		/// Fired when timer is paused by user
		/// </summary>
		public event SlaveDeviceControlEventHandler TimerPaused;
		protected virtual void FireTimerPaused(SlaveDeviceControlEvent e){
			if(TimerPaused!=null){
				TimerPaused(this, e);
			}
		}
		
		/// <summary>
		/// Fired when timer is stopped by user
		/// </summary>
		public event SlaveDeviceControlEventHandler TimerStopped;
		protected virtual void FireTimerStopped(SlaveDeviceControlEvent e){
			if(TimerStopped!=null){
				TimerStopped(this, e);
			}
		}
		
		/// <summary>
		/// Fired when countdown has ended
		/// </summary>
		public event SlaveDeviceControlEventHandler CountdownEnded;
		protected virtual void FireCountdownEnded(SlaveDeviceControlEvent e){
			if(CountdownEnded!=null){
				CountdownEnded(this, e);
			}
		}
		/// <summary>
		/// Fired whenever timer ticks
		/// </summary>
		public event SlaveDeviceControlEventHandler TimerTicked;
		protected virtual void FireTimerTicked(SlaveDeviceControlEvent e){
			if(TimerTicked!=null){
				TimerTicked(this, e);
			}
		}

		#endregion
		
		#region _constructors
				
		/// <summary>
		/// Empty dafault constructor
		/// </summary>
		public BedControl()
		{
			InitializeComponent();
		}
		
		/// <summary>
		/// Constructor for bad control
		/// </summary>
		/// <param name="mf"></param>
		/// <param name="network"></param>
		/// <param name="deviceNo"></param>
		public BedControl(IMainFrame mf, ModbusNetwork network, int deviceNo)
		{
			InitializeComponent();
			this.mf = mf;
			this.network = network;
			this.deviceId = deviceNo;
			
			AdvanceState(stateNotReady);
			
			//inicjalizacja sekwencji stanów
			InitStateSequence();
			
			//postinit
			PostInit();
			
			//pobieramy dane łózka i liste czasów itp z bazy
			GetSlaveDbData();
			
			SetupStateTimer();
			
			AdvanceState(stateReady);
		}
		
		#endregion

		#region _private_methods
		
		/// <summary>
		/// Post initialization - fill smoe data etc.
		/// </summary>
		private void PostInit(){
			try {
				//ustawiamy labelke z ID urzadzenia
				idLabel.Text = deviceId.ToString();
				
				//chowamy czas opalania - bedziemy pokazywać tylko w stanie != ready
				selectedTimeLabel.Visible = false;
				
				infoToolTip = new ToolTip();
				infoToolTip.IsBalloon = true;
				infoToolTip.ToolTipTitle = "Informacja";
				infoToolTip.SetToolTip(this, "Brak\r\nklienta");
				
				//konfiguracja
				bool slaveInConfig = false;
				modbusSlaveConfig = new ModbusSlaveElement();
				ModbusNetworkSettings mns = ModbusNetworkSettings.GetSection(ConfigurationUserLevel.None);
				ModbusSlaveCollection msc = mns.Slaves;
				foreach(ModbusSlaveElement mse in msc){
					if(mse.Id == deviceId){
						slaveInConfig = true;
						modbusSlaveConfig = mse;
					}
				}
				
				if(slaveInConfig){
					modbusSlave = new ModbusSlave(network, modbusSlaveConfig);
				}else{
					modbusSlaveConfig = new ModbusSlaveElement();
					modbusSlaveConfig.Id = deviceId;
					msc.Add(modbusSlaveConfig);
					mns.Save();
					modbusSlave = new ModbusSlave(network, modbusSlaveConfig);
				}
			} catch (BiosException be) {
				//jesli bład bazy - pokazujemy, TimeoutException puszczac dalej zeby było wiadomo
				//ze slave'a z takim ID nie ma!
				DialogUtils.ShowError(mf, be);
			}
		}
		
		/// <summary>
		/// Inicjalizacja sekwencji stanów przez jaki przechodzi kontrolka
		/// </summary>
		private void InitStateSequence()
		{
			//inicjalizujemy sekwencje stanów
			stateSequence = new LinkedList<BedState>();
			stateSequence.AddLast(stateNotReady);
			stateSequence.AddLast(stateReady);
			stateSequence.AddLast(stateWaiting);
			stateSequence.AddLast(stateHeating);
			stateSequence.AddLast(stateCooling);
			stateSequence.AddLast(stateCleaning);
		}
		
		/// <summary>
		/// Pobiera dane urządzeń z bazy lub jesli ich tam nie ma 
		/// tworzy dla nich nowe obiekty w bazie i zapisuje dane
		/// Pobiera dostepne usługi dla danego urzadzenia
		/// </summary>
		private void GetSlaveDbData(){
			try{
				bool newControl = false;//, newEngine = false;
				
				//oid 70 - control
				LinkedList<RcObject> result = mf.Database.Bios.GetObjectsWithClause(70,string.Format("slave_id={0}",deviceId));
				if(result.Count == 0){
					//brak tego slave w bazie - dodajemy nowy
					ObjectID oid = mf.Database.Bios.CreateObject(70);
					RcComponent comp = mf.Database.Bios.GetMainComponentForObject(oid);
					ChangeSet cs = comp.GetChangeSet();
					cs.AddChange("slave_id", deviceId);
					mf.Database.Bios.ModifyComponent(cs);
					dbControl = mf.Database.Bios.GetObject(oid);
					newControl = true;
				} else if(result.Count == 1) {
					//ok - znalezlismy to co chcielismy
					dbControl = result.First.Value;
				} else if(result.Count > 1) {
					//ekhem? jakis inny error!
				}
				
				//oid 40 - engine
				if(newControl) {
					//jesli stworzylismy nowego slave w bazie...
				} else {
					//jesli juz był stworzony...
					string clause = string.Format("control_oid={0} and control_otype={1}", dbControl.Oid.Oid, dbControl.Oid.Otype);
					result = mf.Database.Bios.GetObjectsWithClause(40,clause);
					if(result.Count == 0){
						//brak - to chyba tez by trzeba stworzyc...
//						ObjectID oid = mf.Database.Bios.CreateObject(40);
//						RcComponent comp = mf.Database.Bios.GetMainComponentForObject(oid);
//						ChangeSet cs = comp.GetChangeSet();
//						cs.AddChange("control_oid", dbControl.Oid.Oid);
//						cs.AddChange("control_otype", dbControl.Oid.Otype);
//						mf.Database.Bios.ModifyComponent(cs);
//						dbEngine = mf.Database.Bios.GetObject(oid);
//						newEngine = true;
					} else if(result.Count == 1) {
						//ok - znalezlismy to co chcielismy
						dbEngine = result.First.Value;
					} else if(result.Count > 1) {
						//ekhem? jakis inny error!
					}
				}
				
				//jesli jest lozko to szukamy dla niego uslug - otype: 50
				if(dbEngine!=null){
					string clause = string.Format("engine_oid={0} and engine_otype={1}",
					                              dbEngine.Oid.Oid, dbEngine.Oid.Otype);
					dbServices = mf.Database.Bios.GetObjectsWithClause(50, clause);
					nameLabel.Text = dbEngine.MainComponent.GetString("name");
				}
			}catch(Exception ex){
				DialogUtils.ShowError(mf, new Exception(string.Format("Class: {0}\nMethod: {1}",
                                  this.GetType().FullName,
                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                  ex));
			}
		}
		
		/// <summary>
		/// Ustawia odpowiednio UI oraz bebechy kontrolki dla podanego stanu
		/// </summary>
		/// <param name="state"></param>
		private void UpdateControlForState(BedState state)
		{
			buttonStart.Enabled = state.StartButtonEnabled;
			buttonStart.Text = state.StartButtonString;
			buttonStop.Enabled = state.StopButtonEnabled;
			buttonStop.Text = state.StopButtonString;
			statusLabel.Text = state.StateString;
			stateTimespan = TimeSpan.Zero;
			timerLabel.Text = stateTimespan.ToString();
//			if(!FormUtils.IsBlinking(timerLabel))
//			{
				timerLabel.BackColor = Color.Transparent;
//			}
//			
//			FormUtils.BlinkLabelBackground(statusLabel, Color.Red, Color.Transparent, 250, 2);
		}
		
		/// <summary>
		/// Przejdz do kolejnego stanu na liście sekwencji stanów.
		/// </summary>
		private void AdvanceState()
		{
			AdvanceState(null);
		}
		
		/// <summary>
		/// Przejdz do nastepnego stanu. Jesli podano parametr - przejdz do tego stanu
		/// jeśli nie podano - przejdz do nastepnego wg. kolejnosci na liscie stanów
		/// wewnatrz kontrolki.
		/// </summary>
		/// <param name="state"></param>
		private void AdvanceState(BedState state)
		{
			if(state == null) 
			{
				LinkedListNode<BedState> o = stateSequence.Find(currentState).Next;
				currentState = o == null ? stateReady : o.Value;				
			}
			else
			{
				currentState = state;
			}
			
			UpdateControlForState(currentState);
			
			//właczamy/wyłaczamy timer, pokazujemy/chowamy czas opalania
			if(currentState.StateLenght != TimeSpan.Zero && !stateTimer.Enabled /* && currentState != stateWaiting */) 
			{
				StartStateTimer();
			}
			else if(currentState == stateReady)
			{
				selectedTimeLabel.Visible = false;
				CurrentClient = null;
				modbusSlave.DisableButtonsReaction();
				StopStateTimer();
			}
			
			//właczamy/wyłaczamy przekazniki w zaleznosci od stanu
			if(currentState.State == BedState.EState.WAITING)
			{
				int att = 0;
				while(modbusSlave.IsHeatingStartReactionActive() == false && CRITICAL_OPS_ATTEMPTS > att) {
					try {
						modbusSlave.EnableHeatingStartReaction();
					} catch (TimeoutException) {
						
					}
					att++;
				}
				if(att >= CRITICAL_OPS_ATTEMPTS) {
					DialogUtils.ShowError(mf, "Błąd!",
					                      String.Format("Nie udało się włączyć reakcji urządzenia {0} ({1}) na przycisk START!", 
					                                    deviceId, DeviceName));
					AdvanceState(stateReady);
					network.CriticalSlaveRemove(this);
				}
				SetupButtonsScanTimer();
				StartButtonsScanTimer();
			}
			else if(currentState.State == BedState.EState.HEATING)
			{
				modbusSlave.DisableButtonsReaction();
//				SetupDelayButtonScanTimer();					//solar quick fix 1
//				StartDelayButtonScanTimer();					//solar quick fix 1
				int att = 0;
				while(modbusSlave.Heating == false && CRITICAL_OPS_ATTEMPTS > att) {
					try {
						modbusSlave.Heating = true;
					} catch (TimeoutException) {
						
					}
					att++;
				}
				if(att >= CRITICAL_OPS_ATTEMPTS) {
					DialogUtils.ShowError(mf, "Błąd!",
					                      String.Format("Nie udało się włączyć opalania w urządzeniu {0} ({1})", 
					                                    deviceId, DeviceName));
					AdvanceState(stateReady);
					network.CriticalSlaveRemove(this);
				}
			}
			else if(currentState.State == BedState.EState.COOLING)
			{
//				modbusSlave.DisableButtonsReaction();			//solar quick fix 1
				int att = 0;
				while(modbusSlave.Heating == true && CRITICAL_OPS_ATTEMPTS > att) {
					try {
						modbusSlave.Heating = false;
					} catch (TimeoutException) {
						
					}
					att++;
				}
				if(att >= CRITICAL_OPS_ATTEMPTS) {
					DialogUtils.ShowError(mf, "Błąd!",
					                      String.Format("Nie udało się wyłączyć opalania w urządzeniu {0} ({1})", 
					                                    deviceId, DeviceName));
					AdvanceState(stateReady);
					network.CriticalSlaveRemove(this);					
				}
				
				att = 0;
				while(modbusSlave.Cooling == false && CRITICAL_OPS_ATTEMPTS > att) {
					try{
						modbusSlave.Cooling = true;
					} catch (TimeoutException) {
					}
					att++;
				}
				if(att >= CRITICAL_OPS_ATTEMPTS) {
					DialogUtils.ShowError(mf, "Błąd!",
					                      String.Format("Nie udało się włączyć chłodzenia w urządzeniu {0} ({1})", 
					                                    deviceId, DeviceName));
					AdvanceState(stateReady);
					network.CriticalSlaveRemove(this);
				}
			}
			else if(currentState.State == BedState.EState.CLEANING)
			{
				modbusSlave.Cooling = false;
			}
			
			FireStatusChanged(new SlaveDeviceControlEvent(this));
		}
		
		#region _state_timer
		
		private void SetupStateTimer()
		{
			stateTimer = new System.Windows.Forms.Timer();
			stateTimer.Interval = 1000;
			stateTimer.Tick += new EventHandler(StateTimerTick);
		}
		
		private void StartStateTimer()
		{
			stateTimer.Start();
		}
		
		private void StopStateTimer()
		{
			stateTimer.Stop();
		}

		void StateTimerTick(object sender, EventArgs e)
		{
			if(stateTimespan.CompareTo(currentState.StateLenght) == 0) 
			{
				if(!FormUtils.IsBlinking(timerLabel))
				{
					timerLabel.BackColor = Color.Transparent;
				}
				AdvanceState();
			}
			else if(stateTimespan.CompareTo(currentState.StateLenght.Subtract(currentState.StateTimeoutWarning)) >= 0)
			{
				stateTimespan = stateTimespan.Add(new TimeSpan(0,0,1));
				timerLabel.BackColor = currentState.StateTimeoutBackground;
//				FormUtils.BlinkLabelBackground(timerLabel, 
//				                               currentState.StateTimeoutBackground, 
//				                               Color.Transparent, 
//				                               750, 
//				                               1);
			}
			else
			{
				stateTimespan = stateTimespan.Add(new TimeSpan(0,0,1));
			}

			timerLabel.Text = currentState.StateLenght.Subtract(stateTimespan).ToString();

			FireTimerTicked(new SlaveDeviceControlEvent(this));
		}
		
		#endregion
		
		#region _button_scan_timer
		
		private void SetupButtonsScanTimer()
		{
			buttonScanTimer = new System.Windows.Forms.Timer();
			//poczatkowo ustawiamy czas dla oczekiwania na rozpoczecie opalania
			//pozniej bedziemy ten czas regulowac w callbacku
			buttonScanTimer.Interval = STATE_WAITING_BUTTON_SCAN_INTERVAL;
			buttonScanTimer.Tick += new EventHandler(ButtonScanTimerTick);
		}
		
		private void StartButtonsScanTimer()
		{
			buttonScanTimer.Start();
		}
		
		private void StopButtonsScanTimer()
		{
			buttonScanTimer.Stop();
		}
		
		void ButtonScanTimerTick(object sender, EventArgs e)
		{
			if(currentState.State == BedState.EState.WAITING){
				if(modbusSlave.IsStartButtonPressed())
				{
					(sender as System.Windows.Forms.Timer).Interval = PAUSE_SCAN_INTERVAL;
//					modbusSlave.DisableButtonsReaction();
					AdvanceState();
				}
			}
			else if(currentState.State == BedState.EState.HEATING)
			{
				(sender as System.Windows.Forms.Timer).Interval = STATE_HEATING_BUTTON_SCAN_INTERVAL;
//				if(modbusSlave.IsStopButtonPressed())	//solar quick fix 1
//				{										//solar quick fix 1
//					AdvanceState();						//solar quick fix 1
//					buttonScanTimer.Stop();				//solar quick fix 1
//				}										//solar quick fix 1
			}
		}
		
		#endregion
		
		#region _button_delay_timer
		
		/// <summary>
		/// Skonfiguruj timer na delay od wykrycia wcisniecia batona 'start'.
		/// Jesli wykryto to wcisniecie to ten timer spowoduje odczekanie
		/// XX sekund przed włączeniem reakcji na button stop!
		/// </summary>
		private void SetupDelayButtonScanTimer()
		{
			delayButtonScanTimer = new System.Windows.Forms.Timer();
			//poczatkowo ustawiamy czas dla oczekiwania na rozpoczecie opalania
			//pozniej bedziemy ten czas regulowac w callbacku
			delayButtonScanTimer.Interval = 30000;
			delayButtonScanTimer.Tick += new EventHandler(DelayButtonScanTimerTick);
		}
		
		private void StartDelayButtonScanTimer()
		{
			delayButtonScanTimer.Start();
		}
		
		private void StopDelayButtonScanTimer()
		{
			delayButtonScanTimer.Stop();
		}
		
		void DelayButtonScanTimerTick(object sender, EventArgs e)
		{
			modbusSlave.EnableHeatingStopReaction();
			delayButtonScanTimer.Stop();
		}
		
		#endregion
				
		#endregion
		
		#region _button_methods
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonStartClick(object sender, EventArgs e)
		{
			//solar quick fix 1 - cala metoda
			if(currentState == stateWaiting)
			{
				DialogResult result = DialogUtils.ShowOkCancel(network.Mf, "Pytanie", "Czy na pewno rozpocząć opalanie?");
				if(result == DialogResult.OK)
				{
					AdvanceState();
				}
			} else {
				AdvanceState();
			}
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonStopClick(object sender, EventArgs e)
		{
			//jesli jestesmy w stanie czekania - pytamy czy anulować calosc
			if(currentState == stateWaiting) 
			{
				DialogResult result = DialogUtils.ShowOkCancel(network.Mf, "Pytanie", "Czy na pewno anulować?");
				if(result == DialogResult.OK)
				{
					AdvanceState(stateReady);
				}
			}
			else if(currentState == stateHeating)
			{
				DialogResult result = DialogUtils.ShowOkCancel(network.Mf, "Pytanie", "Czy na pewno przerwać proces opalania?");
				if(result == DialogResult.OK)
				{
					AdvanceState();
				}
			}
			else if(currentState == stateCooling)
			{
				AdvanceState();
			}
			else if(currentState == stateCleaning)
			{
				AdvanceState(stateReady);
			}
		}
		
		#endregion
		
		public void DisposeDevice()
		{
			this.Dispose();
		}
		
		/// <summary>
		/// When disposing control (mostly when closing application)
		/// send commands to slave device to turn off all activity.
		/// </summary>
		public new void Dispose()
		{
			base.Dispose(); 			//?? - 
			if(stateTimer.Enabled)
			{
				StopStateTimer();
			}
			if(network.ModbusMaster != null || modbusSlave != null)
			{
				modbusSlave.DisableButtonsReaction();
				modbusSlave.PowerOff();
			}
		}
	}
}
