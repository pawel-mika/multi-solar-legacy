/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-07
 * Time: 23:57
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
	/// Description of SlaveDeviceControl.
	/// </summary>
	public partial class SlaveDeviceControl : DOATransparentLabel, ISlaveDeviceControl
	{
		private IMainFrame mf = null;
		private ModbusNetwork network = null;

		public const int BED_NOT_READY		=	0;
		public const int BED_READY			=	1;
		public const int BED_WAITING		=	2;
		public const int BED_HEATING		=	3;
		public const int BED_CLEANING		=	4;
		public const int BED_COOLING		=	5;
		
		private const int DEVICE_STATUS_REQUEST_TIME = 300;//(int)0.3 * 1000; // 1 sek
		
		private ModbusSlaveElement modbusSlaveConfig = null;
		
		private ModbusSlave modbusSlave = null;
		
		private int bedStatus = 1;
		public int BedStatus {
			get { return bedStatus; }
		}
		
		private int deviceId = 0;
		public int DeviceId {
			get { return deviceId; }
			set { deviceId = value; }
		}
		
		//TODO: powiazac na obsługe z obiektu.komponentu bazy!!
		private string deviceName = "";
		public string DeviceName {
			get { 
				return dbEngine.MainComponent.FieldFilled("name")?dbEngine.MainComponent.GetString("name"):null; 
			}
			set { 
				try {
					if(!deviceName.Equals(value)){
						deviceName = value;
						tb_devName.Text = deviceName;
						ChangeSet cs = dbEngine.MainComponent.GetChangeSet();
						cs.AddChange("name", deviceName);
						mf.Database.Bios.ModifyComponent(cs);
					}
				} catch (BiosException) {
					DialogUtils.ShowError(mf, "Bląd", "Wystąpił błąd podczas zapisu nazwy do bazy!");
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
		
		
//		private float rounding = 16f;
//		private float outline = 0.1f;
		
		/// <summary>
		/// TODO:
		/// Przerzucic te czasy do konfigów poszczegolnych łózek - kazde zeby miało swoje czasy,
		/// dodac w preferencjach konfigurowanie łózek kazdego z osobna (czasy, typy (załaczanie
		/// przekazników))
		/// </summary>
		private TimeSpan waitingTime = TimesSettings.GetSection(ConfigurationUserLevel.None).WaitingTime;
		public TimeSpan WaitingTime {
			get { return waitingTime; }
			set { waitingTime = value; }
		}
		
		private TimeSpan coolingTime = TimesSettings.GetSection(ConfigurationUserLevel.None).CoolingTime;
		public TimeSpan CoolingTime {
			get { return coolingTime; }
			set { coolingTime = value; }
		}

		private TimeSpan cleaningTime = TimesSettings.GetSection(ConfigurationUserLevel.None).CleaningTime;
		public TimeSpan CleaningTime {
			get { return cleaningTime; }
			set { cleaningTime = value; }
		}
		
		private TimeSpan heatingTime = TimeSpan.Parse("00:00:00");
		public TimeSpan HeatingTime {
			get { return heatingTime; }
			set {
				heatingTime = value;
				setupDevice();
			}
		}
		
		/// <summary>
		/// The actual real timer value.
		/// </summary>
		private TimeSpan actualTimer = TimeSpan.Parse("00:00:00");
		public TimeSpan ActualTimer {
			get { return actualTimer; }
			set {
				actualTimer = value;
				l_time.Text = actualTimer.ToString();
			}
		}

		#region _Events

		/// <summary>
		/// Fired whenever status has changed
		/// </summary>
		public event SlaveDeviceControlEventHandler StatusChanged;
		protected virtual void FireStatusChanged(SlaveDeviceControlEvent e){
			if(PropertyChanged!=null){
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

		/// <summary>
		/// Kontrolka slave'a (łózka).
		/// Odpowiada za wszystkie na nim operacje itp...
		/// 
		/// TODO:
		/// Docelowo przeniesc wszystkie metody wywołan slave'a do klasy solarium.controller.modbusslave
		/// utworzyc sobie tutaj obiekcik tej klasy z paramtertem konfiga i wszystkie odwołania robic z niej
		/// </summary>
		/// <param name="mf"></param>
		/// <param name="network"></param>
		/// <param name="deviceNo"></param>
		public SlaveDeviceControl(IMainFrame mf, ModbusNetwork network, int deviceNo){
			InitializeComponent();
			this.mf = mf;
			this.network = network;
			this.deviceId = deviceNo;
			
			PostInit();
			
			GetSlaveDbData();

			AddEventHandlers();
		}
		
		/// <summary>
		/// Kontrolka slave'a (łózka).
		/// Odpowiada za wszystkie na nim operacje itp...
		/// 
		/// TODO:
		/// Docelowo przeniesc wszystkie metody wywołan slave'a do klasy solarium.controller.modbusslave
		/// utworzyc sobie tutaj obiekcik tej klasy z paramtertem konfiga i wszystkie odwołania robic z niej
		/// </summary>
		/// <param name="mf"></param>
		/// <param name="deviceNo"></param>
		public SlaveDeviceControl(IMainFrame mf, int deviceNo){
			InitializeComponent();
			this.mf = mf;
			this.network = mf.Network;
			this.deviceId = deviceNo;
			
			PostInit();
			
			GetSlaveDbData();

			AddEventHandlers();
		}
		
		private void PostInit(){
			tb_devId.Text = deviceId.ToString();

			//labelka z czasem grzania...
			l_time.Text = heatingTime.ToString();
			
			//właczamy urzadzenie przy tworzeniu kontrolki, odlacza sie oryginalna puszka sterujaca
			network.ModbusMaster.WriteSingleCoil((byte)deviceId, ModbusSlave.COIL_ADDR_POWER, true);

			// deviceTimer
			deviceTimer = new System.Windows.Forms.Timer(this.components);
			deviceTimer.Interval = 1000;
			deviceTimer.Tick += new EventHandler(deviceTimerTick);

			//nowy timerek dla operacji czekania na baton start/stop
			//ale narazie cos nie chce działac wiec to wykomentujemy i tyle...
			operationTimer = new System.Timers.Timer();
			operationTimer.Elapsed += new ElapsedEventHandler(operationTimerTick);
			operationTimer.Interval = DEVICE_STATUS_REQUEST_TIME;
			
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
			
			//dla pewnosci wyłaczamy na starcie reakcje na batona w łózku
			modbusSlave.DisableButtonsReaction();
		}
		
		private void AddEventHandlers(){
			//usunięcie tego handlera w pliku SlaveDeviceControl.Designer.cs metoda Dispose()!!
			mf.Database.Bios.ObjectModified+=new BiosEventHandler(HandleObjectModified);
		}
		
		private void HandleObjectModified(object source, BiosEvent be){
			if(dbEngine != null && be.AffectedObjectId.Oid == dbEngine.Oid.Oid && be.AffectedObjectId.Otype == dbEngine.Oid.Otype){
				dbEngine = be.AffectedObject;
				tb_devName.Text = dbEngine.MainComponent.GetString("name");
			} else if(be.AffectedObjectId.Oid == dbControl.Oid.Oid && be.AffectedObjectId.Otype == dbControl.Oid.Otype){
				dbControl = be.AffectedObject;
			}
		}
		
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
					tb_devName.Text = dbEngine.MainComponent.GetString("name");
				}
			}catch(Exception ex){
				DialogUtils.ShowError(mf, new Exception(string.Format("Class: {0}\nMethod: {1}",
                                  this.GetType().FullName,
                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                  ex));
			}
		}
		
		#region _button methods

		void B_startPauseClick(object sender, EventArgs e)
		{
			switch(bedStatus){
				case BED_NOT_READY:
					break;
				case BED_READY:
					if(deviceTimer.Enabled){
						pauseFry();
					}else{
						startFry();
					}
					break;
				case BED_WAITING:
					if(deviceTimer.Enabled){
						WaitingTimeout();
					}else{
						startProcessTimer();
						BedWaiting();
					}
					break;
				case BED_HEATING:
					if(deviceTimer.Enabled){
						pauseFry();
					}else{
						startFry();
					}
					break;
				case BED_CLEANING:
					if(deviceTimer.Enabled){
						CleaningTimeout(true);
					}else{
						CleaningTimeout(true);
					}
					break;
				case BED_COOLING:
					if(deviceTimer.Enabled){
						CoolingTimeout();
					}else{
						CoolingTimeout();
					}
					break;
				default:
					break;
			}
		}

		void B_stopClick(object sender, EventArgs e)
		{
			if(deviceTimer.Enabled) {
				stopFry(true);
			}
		}

		#endregion
		
		#region _timers callbacks

		/// <summary>
		/// Callback glownego timera sterujacego przebiegiem calego
		/// procesu opalania (start->oczekiwanie->opalanie->chlodzenie->czyszczenie->gotowy)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void deviceTimerTick(object sender, EventArgs e)
		{
			if((actualTimer.CompareTo(new TimeSpan(0,0,0)) == 0 && bedStatus == BED_HEATING) || 
//			   (bedStatus == BED_HEATING && ModbusSlaveStopButtonStatus() )){
			   (bedStatus == BED_HEATING && !ModbusSlaveHeatingStatus() )){
				HeatingTimeout();
			}else if((actualTimer.CompareTo(new TimeSpan(0,0,0)) == 0 && bedStatus == BED_WAITING) || 
//			         (bedStatus == BED_WAITING && ModbusSlaveStartButtonStatus())){
			         (bedStatus == BED_WAITING && ModbusSlaveHeatingStatus() )){
				WaitingTimeout();
			}else if(actualTimer.CompareTo(new TimeSpan(0,0,0)) == 0 && bedStatus == BED_COOLING){
				CoolingTimeout();
			}else if(actualTimer.CompareTo(new TimeSpan(0,0,0)) == 0 && bedStatus == BED_CLEANING){
				CleaningTimeout(false);
			}else if(actualTimer.CompareTo(new TimeSpan(0,1,0)) <= 0){
				actualTimer = actualTimer.Subtract(new TimeSpan(0,0,1));
				l_time.Text = actualTimer.ToString();
				l_time.BackColor = Color.LightCoral;
			}else{
				actualTimer = actualTimer.Subtract(new TimeSpan(0,0,1));
				l_time.Text = actualTimer.ToString();
			}

			FireTimerTicked(new SlaveDeviceControlEvent(this));
		}
		
		/// <summary>
		/// Callback sprawdzajacy dziobniecie przycisku start/stop
		/// przez kurczaka na roznie poprzez odczytanie statusu
		/// odpowiedniego przekaznika (tak chyba bedzie działać)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void operationTimerTick(object sender, EventArgs e)
		{
//			if(bedStatus == BED_WAITING){
//				if(ModbusSlaveStartButtonStatus()){
//					WaitingTimeout();
//				}
//			}else if(bedStatus == BED_HEATING){
//				if(ModbusSlaveStopButtonStatus()){
//					HeatingTimeout();
//				}
//			}
		}

		#endregion

		#region _private_methods
		
		private void startProcessTimer(){
			deviceTimer.Start();
			l_time.BackColor = Color.LightGreen;
		}
		
		/// <summary>
		/// Some setup after setting time of heating
		/// </summary>
		private void setupDevice(){
			ActualTimer = waitingTime;
			l_time.Text = actualTimer.ToString();
			lHeatingTime.Text = string.Format("Heating time: {0}", HeatingTime.ToString());
			BedWaiting();
		}
		
		private void startFry()
		{
			//dodac trajkacze na wypadek gdy urzadzenie wyłaczone itp...
			deviceTimer.Start();
			l_time.BackColor = Color.LightGreen;
			ModbusSlaveHeatingOn();
			
			FireTimerStarted(new SlaveDeviceControlEvent(this));
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="byUser">If 'stop' is clicked by user set this to true</param>
		private void stopFry(bool byUser)
		{
			DialogResult result = DialogResult.OK;
			if(byUser && bedStatus == BED_HEATING){
				result = DialogUtils.ShowOkCancel(network.Mf, "Pytanie", "Czy na pewno przerwać proces opalania?");
			}
			if(result == DialogResult.OK && bedStatus == BED_HEATING){
				HeatingTimeout();
			
				if(!byUser){
					FireCountdownEnded(new SlaveDeviceControlEvent(this));
				}else{
					FireTimerStopped(new SlaveDeviceControlEvent(this));
				}
			} else {
				
			}
		}
		
		private void pauseFry()
		{
			deviceTimer.Stop();
			l_time.BackColor = Color.Orange;
			ModbusSlaveHeatingOff();
			
			FireTimerPaused(new SlaveDeviceControlEvent(this));
		}
		
		private void nextState(){
			if(bedStatus == BED_WAITING){
				WaitingTimeout();
			} else if(bedStatus == BED_COOLING){
				CoolingTimeout();
			}
		}
		
		#region _states timeout methods

		private void WaitingTimeout(){
			ActualTimer = heatingTime;
			BedFrying();
			startFry();
		}
		
		private void HeatingTimeout(){
			ActualTimer = coolingTime;
			//stopFry(false);
			ModbusSlaveHeatingOff();
			//status po wyłaczeniu... bo tam sprawdzamy status;)
			BedCooling();
			ModbusSlaveFanOn();
		}
		
		/// <summary>
		/// If user clicked 'clean' button - timer stop, else - countdown with '-' after timeout...
		/// </summary>
		/// <param name="clean"></param>
		private void CleaningTimeout(bool clean){
			if(clean){
				BedReady();
				deviceTimer.Stop();
				l_time.BackColor = Color.AliceBlue;
				ActualTimer = TimeSpan.Parse("00:00:00");
				lHeatingTime.Text = string.Format("Heating time: {0}", TimeSpan.Parse("00:00:00").ToString());
			}else{
				ActualTimer = TimeSpan.Parse("-00:00:01");
			}
		}
		
		private void CoolingTimeout(){
			ActualTimer = cleaningTime;
			BedCleaning();
			ModbusSlaveFanOff();
		}

		#endregion
		
		#region _modbus private methods

		/// <summary>
		/// 
		/// </summary>
		private void ModbusSlaveHeatingOn(){
			try{
				lock(network.ModbusMaster){
					network.ModbusMaster.WriteSingleCoil((byte)deviceId, modbusSlave.COIL_ADDR_RELAY_0, true);
				}
			}catch(Exception ex){
				DialogUtils.ShowError(network.Mf, "ModbusSlaveHeatingOn\r\nWystąpił problem w komunikacji ze sterownikiem łóżka!", ex);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void ModbusSlaveHeatingOff(){
			try {
				lock(network.ModbusMaster){
					network.ModbusMaster.WriteSingleCoil((byte)deviceId, modbusSlave.COIL_ADDR_RELAY_0, false);
				}
			} catch (Exception ex) {
				DialogUtils.ShowError(network.Mf, "ModbusSlaveHeatingOff\r\nWystąpił problem w komunikacji ze sterownikiem łóżka!", ex);
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void ModbusSlaveFanOn(){
			try{
				lock(network.ModbusMaster){
					network.ModbusMaster.WriteSingleCoil((byte)deviceId, modbusSlave.COIL_ADDR_RELAY_1, true);
				}
			} catch (Exception ex) {
				DialogUtils.ShowError(network.Mf, "ModbusSlaveFanOn\r\nWystąpił problem w komunikacji ze sterownikiem łóżka!", ex);
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void ModbusSlaveFanOff(){
			try{
				lock(network.ModbusMaster){
					network.ModbusMaster.WriteSingleCoil((byte)deviceId, modbusSlave.COIL_ADDR_RELAY_1, false);
				}
			} catch (Exception ex) {
				DialogUtils.ShowError(network.Mf, "ModbusSlaveFanOff\r\nWystąpił problem w komunikacji ze sterownikiem łóżka!", ex);
			}
		}
		
		/// <summary>
		/// Pobierz status przekaznika lamp
		/// </summary>
		/// <returns></returns>
		private bool ModbusSlaveHeatingStatus(){
			try{
				lock(network.ModbusMaster){
					bool[] coils = network.ModbusMaster.ReadCoils((byte)deviceId, modbusSlave.COIL_ADDR_RELAY_0, 1);
					return coils[0];
				}
			} catch (Exception ex) {
				DialogUtils.ShowError(network.Mf, "ModbusSlaveHeatingStatus\r\nWystąpił problem w komunikacji ze sterownikiem łóżka!", ex);
			}
			return false;
		}

		/// <summary>
		/// Pobierz status przekaznika chlodzenia
		/// </summary>
		/// <returns></returns>
		private bool ModbusSlaveFanStatus(){
			try{
				lock(network.ModbusMaster){
					bool[] coils = network.ModbusMaster.ReadCoils((byte)deviceId, modbusSlave.COIL_ADDR_RELAY_1, 1);
					return coils[0];
				}
			} catch (Exception ex) {
				DialogUtils.ShowError(network.Mf, "ModbusSlaveFanStatus\r\nWystąpił problem w komunikacji ze sterownikiem łóżka!", ex);
			}
			return false;
		}

		/// <summary>
		/// Pobierz status przycisku start
		/// </summary>
		/// <returns></returns>
		private bool ModbusSlaveStartButtonStatus(){
			try{
				lock(network.ModbusMaster){
//					bool[] coils = network.ModbusMaster.ReadInputs((byte)deviceId, modbusSlave.BIT_ADDR_KEY_1, 1);
//					network.Mf.MFStatusStrip.FreeMessage.Text = string.Format("Start button: {0}", coils[0]);
//					return coils[0];
					
					bool[] tmp = network.ModbusMaster.ReadInputs((byte)deviceId, modbusSlave.BIT_ADDR_KEY_1, 1);
					network.Mf.MFStatusStrip.FreeMessage.Text = string.Format("Start button: {0}", tmp[0]);
					return tmp[0];
				}
			} catch (Exception ex) {
				DialogUtils.ShowError(network.Mf, "ModbusSlaveStartButtonStatus\r\nWystąpił problem w komunikacji ze sterownikiem łóżka!", ex);
			}
			return false;
		}

		/// <summary>
		/// Pobierz status przycisku stop
		/// </summary>
		/// <returns></returns>
		private bool ModbusSlaveStopButtonStatus(){
			try{
				lock(network.ModbusMaster){
//					bool[] coils = network.ModbusMaster.ReadInputs((byte)deviceId, modbusSlave.BIT_ADDR_KEY_2, 1);
//					network.Mf.MFStatusStrip.FreeMessage.Text = string.Format("Stop button: {0}", coils[0]);
//					return coils[0];
					
					bool[] tmp = network.ModbusMaster.ReadInputs((byte)deviceId, modbusSlave.BIT_ADDR_KEY_2, 1);
					network.Mf.MFStatusStrip.FreeMessage.Text = string.Format("Stop button: {0}", tmp[0]);
					return tmp[0];
					
//					//maly hack... albo lozka nie wysylaja "STOP" albo co... takze trzeba status stopy
//					//sprawdzac poprzez stan przekaznika opalania...
//					bool[] coils = network.ModbusMaster.ReadCoils((byte)deviceId, modbusSlave.COIL_ADDR_RELAY_0, 1);
//					network.Mf.MFStatusStrip.FreeMessage.Text = string.Format("Stop button: {0}", coils[0]);
//					return coils[0];
				}
			} catch (Exception ex) {
				DialogUtils.ShowError(network.Mf, "ModbusSlaveStopButtonStatus\r\nWystąpił problem w komunikacji ze sterownikiem łóżka!", ex);
			}
			return false;
		}

		#endregion
		
		#endregion
		
		#region _bed_states_methods

		/// <summary>
		/// Set status:
		/// Bed is ready and waiting for operations / clients...
		/// </summary>
		private void BedReady(){
			bedStatus = BED_READY;
			
			b_startPause.Enabled = false;
			b_startPause.Text = "start/pause";
			b_stop.Enabled = false;

			l_status.Text = "ready";
			FireStatusChanged(new SlaveDeviceControlEvent(this));
		}
		
		/// <summary>
		/// Set status:
		/// Bed is waiting for the client after he paid for his visit
		/// </summary>
		private void BedWaiting(){
			bedStatus = BED_WAITING;
			
			if(deviceTimer.Enabled){
				b_startPause.Enabled = true;
				b_startPause.Text = "next>>";
				b_stop.Enabled = false;
				//wlacz timer oczekiwania na baton start/stop w lozku
				operationTimer.Start();
				//ustaw reakcje SPRZETOWA SLAVE'a na przyciski
				modbusSlave.EnableHeatingStartReaction();
			}else{
				b_startPause.Enabled = true;
				b_startPause.Text = "start";
				b_stop.Enabled = false;
			}
			
			l_status.Text = "waiting";
			FireStatusChanged(new SlaveDeviceControlEvent(this));
		}

		/// <summary>
		/// Set status:
		/// Bed is frying its customer:)
		/// </summary>
		private void BedFrying(){
			bedStatus = BED_HEATING;

			b_startPause.Enabled = true;
			b_startPause.Text = "start/pause";
			b_stop.Enabled = true;

			l_status.Text = "heating";
			FireStatusChanged(new SlaveDeviceControlEvent(this));
		}
		
		/// <summary>
		/// Set status:
		/// Bed is cooling after frying session
		/// </summary>
		private void BedCooling(){
			bedStatus = BED_COOLING;
			
			b_startPause.Enabled = true;
			b_startPause.Text = "next>>";
			b_stop.Enabled = false;

			//wylacz timer oczekiwania na baton start/stop w lozku
			operationTimer.Stop();
			
			//wyłacz reakcje SPRZETOWA SLAVE'a na przyciski
			modbusSlave.DisableButtonsReaction();
			
			l_status.Text = "cooling";
			FireStatusChanged(new SlaveDeviceControlEvent(this));
		}
		
		/// <summary>
		/// Set status:
		/// Bed is being cleaned by solarium staff
		/// </summary>
		private void BedCleaning(){
			bedStatus = BED_CLEANING;

			b_startPause.Enabled = true;
			b_startPause.Text = "clean!";
			b_stop.Enabled = false;

			l_status.Text = "cleaning";
			FireStatusChanged(new SlaveDeviceControlEvent(this));
		}
		
		/// <summary>
		/// Set status:
		/// Bed is not ready for any operation
		/// </summary>
		private void BedNotReady(){
			bedStatus = BED_NOT_READY;
			l_status.Text = "not ready";
			FireStatusChanged(new SlaveDeviceControlEvent(this));
		}
		
		#endregion
		
		#region unused_for_the_moment

//		protected override void OnPaint(PaintEventArgs e)
//		{
//			Rectangle rect = this.ClientRectangle;
//
//			SmoothingMode sm = e.Graphics.SmoothingMode;
//		    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
//
		////			rect.X++;
		////			rect.Y++;
		////			rect.Width -= 2;
		////			rect.Height -=2;
//
//		    using (GraphicsPath bb = roundCorners(e.Graphics, rect, rounding, Color.Transparent, outline))
//		    {
//		        using (LinearGradientBrush lgb = new LinearGradientBrush(rect,Color.LightSteelBlue,Color.DarkTurquoise,90,true))
//		        {
//		            e.Graphics.FillPath(lgb, bb);
//		        }
//		    }
//		    e.Graphics.SmoothingMode = sm;
//		}
//
//		protected GraphicsPath roundCorners(Graphics g, Rectangle rect, float radius, Color bColor, float bWidth)
//		{
//			GraphicsPath gPath = new GraphicsPath();
//			try
//			{
//				int x = rect.X,
//					y = rect.Y,
//					w = rect.Width,
//					h = rect.Height;
//
//			    if (radius > 0)
//			    {
//			        if (radius > h) { radius = h; };                           			//Rounded
//			        if (radius > w) { radius = w; };                           			//Rounded
//			        gPath.AddArc(x, y, radius, radius, 180, 90);                		//Upper left corner
//			        gPath.AddArc(x + w - radius, y, radius, radius, 270, 90);        	//Upper right corner
//			        gPath.AddArc(x + w - radius, y + h - radius, radius, radius, 0, 90);  	//Lower right corner
//			        gPath.AddArc(x, y + h - radius, radius, radius, 90, 90);         	//Lower left corner
//			        gPath.CloseFigure();
//			    }
//			    else
//			    {
//			        gPath.AddRectangle(rect);
//			    }
//			}
//			catch(Exception ex)
//			{
//		    	throw new Exception("DrawRoundedCornersException: " + ex.Message);
//			}
//			return gPath;
//		}

		#endregion
		
		void SetNameToolStripMenuItemClick(object sender, EventArgs e)
		{
			tb_devName.Enabled = true;
		}
		
		void tb_nameTab(object sender, EventArgs e)
		{
			tb_devName.Enabled = false;
			DeviceName = tb_devName.Text;
			tb_devName.Text = deviceName;
			
			FirePropertyChanged(new SlaveDeviceControlEvent(this));
		}
		
		/// <summary>
		/// Get the status string according to given const int status
		/// </summary>
		/// <param name="status"></param>
		/// <returns></returns>
		public string GetBedStatus(int status){
			if(status == SlaveDeviceControl.BED_READY){
				return "ready";
			} else if(status == SlaveDeviceControl.BED_WAITING){
				return "waiting";
			} else if(status == SlaveDeviceControl.BED_HEATING){
				return "heating";
			} else if(status == SlaveDeviceControl.BED_CLEANING){
				return "cleaning";
			} else if(status == SlaveDeviceControl.BED_COOLING){
				return "cooling";
			} else if(status == SlaveDeviceControl.BED_NOT_READY){
				return "not ready";
			}
			return "undefined";
		}
		
		public void setNormalFont(Font font){
			tb_devName.Font = font;
			l_status.Font = font;
		}
		
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
			if(operationTimer.Enabled){
				operationTimer.Stop();
			}
			if(network.ModbusMaster!=null || modbusSlave!=null){
				modbusSlave.DisableButtonsReaction();
				modbusSlave.PowerOff();
//				network.ModbusMaster.WriteSingleCoil((byte)deviceId, modbusSlave.COIL_ADDR_RELAY_0, false);
//				network.ModbusMaster.WriteSingleCoil((byte)deviceId, modbusSlave.COIL_ADDR_RELAY_1, false);
//				network.ModbusMaster.WriteSingleCoil((byte)deviceId, ModbusSlave.COIL_ADDR_POWER, false);
			}
		}
		
		
		public TimeSpan CurrentTimerValue {
			get {
				return TimeSpan.Parse(l_time.Text);
			}
		}
		
		public BedState CurrentState {
			get {
				throw new NotImplementedException();
			}
		}
		
		public RcObject CurrentClient {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
	}
}
