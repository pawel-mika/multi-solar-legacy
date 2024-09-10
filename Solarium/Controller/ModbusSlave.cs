/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-03-02
 * Time: 20:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Configuration;
using System.IO;

using Solarium.Controller;
using Solarium.Settings;

namespace Solarium.Controller
{
	/// <summary>
	/// Description of ModbusSlave.
	/// </summary>
	public class ModbusSlave
	{
		private ModbusNetwork modbusNetwork = null;
		public ModbusNetwork ModbusNetwork {
			get { return modbusNetwork; }
		}
		
		private ModbusSlaveElement modbusSlaveConfigElement = null;
		public ModbusSlaveElement ModbusSlaveConfigElement {
			get { return modbusSlaveConfigElement; }
		}
		
		private int deviceId = 0;
		public int DeviceId {
			get { return deviceId; }
		}
		
		private bool autoSlaveControl = false;
		public bool AutoSlaveControl {
			get { return autoSlaveControl; }
		}
		
		private int slaveTickLength = 12;	//1 cykl zegara w slave = 12 ms;
		
		//adresy rejestrów i bitów do wpisu w polu ADRES w ramce MODBUS
		public static ushort ADDR_MST_TIME_OUT	=	0x0000;	//czas bez syg. MASTER do PWR_ON=0 
		public static ushort ADDR_LED_BLINK_TIME=	0x0001;	//czas wygaszenia LED-ów
		public static ushort ADDR_LED_FLASH_TIME=	0x0002; //czas błyśnięcia LED TX i RX
		public static ushort ADDR_ERR_TIME_OUT	=	0x0003; //czas mruga.ERR LED od ost. excep.
		public static ushort ADDR_FILTER_TIME	=	0x0004;	//stała czas.filtru KEY i REL(mon)
		public static ushort ADDR_SECURITY_CODE	=	0x0005;	//tu zapisz 0x001234 a po ID skasuj
		public static ushort ADDR_SLAVE_ID		=	0x0006;	//do zapisu! wartość bajt Hi=Lo
		public static ushort ADDR_FREE_WORD1	=	0x0007;	//dana word z funkcją Autosave
		public static ushort ADDR_FREE_WORD2	=	0x0008;	//dana word z funkcją Autosave
		//end blok EEPROM autosave
		public static ushort ADDR_EEPROM_ADR	=	0x0009;	//adr w EEPROM do odczytu/zapisu
		public static ushort ADDR_EEPROM_DATA	=	0x000A;	//dana do zapisu w EEPROMIE
		public static ushort ADDR_BUS_MSG_CNT	=	0x000B;	//il. rozpoznanych ramek z CRC ok
		public static ushort ADDR_BUS_COM_ERR	=	0x000C;	//il. ramek z błędnym CRC
		public static ushort ADDR_EXC_ERR_CNT	=	0x000D;	//il. Exception errors+bcst errors
		public static ushort ADDR_SLV_MSG_CNT	=	0x000E;	//il.r. z naszym ID + bcst
		public static ushort ADDR_NO_RESP_CNT	=	0x000F;	//il.r. bez odpowiedzi=il.bcst
		public static ushort ADDR_NEG_ACK_CNT	=	0x0010;	//il. ramek broadcast
		public static ushort ADDR_SLV_BUSY_CNT	=	0x0011;	//il. odp. z Exception=06 (BUSY)
		public static ushort ADDR_BUS_CH_OVR_CNT=	0x0012;	//il. wystąpień błedu OVERRUN rs-a
		public static ushort ADDR_FRAME_ERR_OVR	=	0x0013;	//il. błędów za długa ramka
		public static ushort ADDR_FRAME_ERR_T15	=	0x0014;	//il. błędów odstęp > 1.5 znaku
		public static ushort ADDR_FRAME_ERR_T35	=	0x0015;	//il. błędów odstęp > 3.5 znaku
//		public static ushort ADDR_FREE_WORD3	=	0x0016;	//dana word bez funkcji Autosave
		public static ushort ADDR_KEY_TIMER		=	0x0016;	//czas trzymania info o wciskanych klawiszach
		public static ushort ADDR_EN_HARD_RESET	=	0x0017;	//ustawić 0xF55F, reset za 20ms
		//UWAGA! tablica moze mieć adres max 0x17 ( 24 x word czyli 0..23 czyli 0x17 max )

		//'cewki' - 2 pierwsze są niestetyczne, gdyz ewentualnie zamieniamy je miejscami w wypadku gdy jest taka potrzeba
		//tzn. do starowania lozkiem trzeba je zamienic
		public ushort COIL_ADDR_RELAY_0			=	0x0000;	//stan przekaznika RED kabel. Zapis mozliwy tylko gdy PWR_ON=1
		public ushort COIL_ADDR_RELAY_1			=	0x0001;	//stan przekaznika YELLOW kabel. Zapis mozliwy tylko gdy PWR_ON=1
		public static ushort COIL_ADDR_POWER	=	0x0002;	//=1 moduł SLAVE ON, zasilanie modułu zewn. wyłaczone, REL RD i YL jako OUT,
															//=0 Tylko Monitoring, zasilanie modułu zewm. właczone REL RD i YL jako READ ONLY INPUT
		//blok chroniony bitem ext_led
		public static ushort COIL_ADDR_LED_RX	=	0x0003;	//stan ON/OFF diody Led RX (odbiór)
		public static ushort COIL_ADDR_LED_TX	=	0x0004;	//stan ON/OFF diody Led TX (transmisja)
		public static ushort COIL_ADDR_LED_ERR	=	0x0005;	//stan ON/OFF diody Led ERROR po RST =0 czyli OFF
		public static ushort COIL_ADDR_BLINK_RX	=	0x0006;	//stan Blink (mruganie) ON/OFF diody Led RX (odbiór), po RST=0 czyli OFF
		public static ushort COIL_ADDR_BLINK_TX	=	0x0007;	//stan Blink (mruganie) ON/OFF diody Led TX (transmisja), po RST=0 czyli OFF
		public static ushort COIL_ADDR_BLINK_ERR=	0x0008;	//stan Blink (mruganie) ON/OFF diody Led ERROR, po RST=0 czyli OFF
		//blok end
		public static ushort COIL_ADDR_EXT_LED	=	0x0009;	//Ledy sa sterowalne z zewnątrz tylko dla EXT_LED=1, ale po RST =0 czyli OFF,
															//mozna je wykorzystać do identyfikacji tego jednego wsród wielu sterowników w sieci

		// BIT INPUTS READ ONLY, ZEWN Msb adresu Hi 0x10 czyli 16 bit 0x10** gdzie ** to adres poniżej, wynik 0=OFF, 1=ON
		public ushort BIT_ADDR_KEY_1		=	0x1000 + 0x0000;		//stan klawisza 1 (1= wciśnięty)
		public ushort BIT_ADDR_KEY_2		=	0x1000 + 0x0001;		//stan klawisza 2 (1= wciśnięty)
		public static ushort BIT_ADDR_EE_DONE	=	0x1000 + 0x0002;	//1-zapis do EEPROM zakończony, stan funkcji EEPROM Autosave i wpisu do EEPROM,ten bit po RST=1
		
		//sekwencje włączania/wyłaczania przekazników 1 i 2 przyciskami 1 i 2
		public static ushort RELAY_1_ON_OFF_SEQ = 0x0102;
		public static ushort RELAY_2_ON_OFF_SEQ = 0x0304;
		
		public static ushort RELAY_1_ON_SEQ = 0x0100;
		public static ushort RELAY_1_OFF_SEQ = 0x0002;
		public static ushort RELAY_2_ON_SEQ = 0x0300;
		public static ushort RELAY_2_OFF_SEQ = 0x0004;
		
		public static int xx_xx = 0x00;
		public static int ON_xx = 0x01;
		public static int OF_xx = 0x02;
		public static int xx_ON = 0x03;
		public static int xx_OF	= 0x04;
		public static int ON_ON = 0x05;
		public static int ON_OF = 0x06;
		public static int OF_ON = 0x07;
		public static int OF_OF = 0x08;
				
		public ModbusSlave()
		{
		}

		/// <summary>
		/// <para>Klasa odzwierciedlająca operacje mozliwe do wykonania na slave'ie.</para>
		/// 
		/// <para>Przykładowy wpis z pliku konfiguracyjnego dla pojedyńczego modułu slave:</para>
		/// 
		/// <code>
		/// <ModbusSlave id="2" heatingRelay="0" coolingRelay="1" startButton="4096" stopButton="4097" keyFilterTime="100" keyHoldTime="7500" />
		/// </code>
		/// </summary>
		/// <param name="modbusNetwork"></param>
		/// <param name="config"></param>
		public ModbusSlave(ModbusNetwork modbusNetwork, ModbusSlaveElement config)
		{
			this.modbusNetwork = modbusNetwork;
			this.modbusSlaveConfigElement = config;
			this.deviceId = config.Id;
			
			if(config.HeatingRelay>=0 && config.HeatingRelay<=1){
				this.COIL_ADDR_RELAY_0 = (ushort)config.HeatingRelay;
			}else{
				throw new ConfigurationErrorsException(string.Format("Bad slave id={0} heating relay addres={1}", config.Id, config.HeatingRelay));
			}
			
			if(config.CoolingRelay>=0 && config.CoolingRelay<=1){
				this.COIL_ADDR_RELAY_1 = (ushort)config.CoolingRelay;
			}else{
				throw new ConfigurationErrorsException(string.Format("Bad slave id={0} cooling relay addres={1}", config.Id, config.CoolingRelay));
			}
			
			if((config.StartButton>=0x1000 && config.StartButton<=0x1001) ||
			  (config.StartButton>=0x0000 && config.StartButton<=0x0001)){
				this.BIT_ADDR_KEY_1 = (ushort)config.StartButton;
			}else{
				throw new ConfigurationErrorsException(string.Format("Bad slave id={0} start button addres={1}", config.Id, config.StartButton));
			}
			
			if((config.StopButton>=0x1000 && config.StopButton<=0x1001) ||
			   (config.StopButton>=0x0000 && config.StopButton<=0x0001)){
				this.BIT_ADDR_KEY_2 = (ushort)config.StopButton;
			}else{
				throw new ConfigurationErrorsException(string.Format("Bad slave id={0} stop button addres={1}", config.Id, config.StopButton));
			}
			
			//mamy konfiguracje automatycznego sterowania
			if(BIT_ADDR_KEY_1 < 0x1000 && BIT_ADDR_KEY_2 < 0x1000) {
				autoSlaveControl = true;
			} else if((BIT_ADDR_KEY_1 < 0x1000 && BIT_ADDR_KEY_2 >= 0x1000) ||
			          (BIT_ADDR_KEY_1 >= 0x1000 && BIT_ADDR_KEY_2 < 0x1000)) {
				throw new ConfigurationErrorsException(string.Format("Bad autoSlaveControl values {0} and {1}", BIT_ADDR_KEY_1, BIT_ADDR_KEY_2));
			}
			
			//właczamy nasze urządzonko
			//jesli niepodlaczone - to timeout exception i lecimy dalej
			PowerOn();

			//konfigurujemy urzadzenie danymi z pliku konf.
			KeyFilterTime = config.KeyFilterTime;
			KeyHoldTime = config.KeyHoldTime;
			
			//dla pewnosci wyłaczamy na starcie reakcje na batona w łózku
			DisableButtonsReaction();
		}
		
		/// <summary>
		/// Czas w milisekundach na filtr nacisniecia przycisku, czyli jak długo
		/// trzeba go naciskać aby slave stawierdził ze to było wciśnięcie
		/// a nie tylko zakłócenia na linii slave-button.
		/// </summary>
		public int KeyFilterTime 
		{
			get 
			{
				try {
					#if (DEBUG)
					log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
					#endif
					return modbusNetwork.ModbusMaster.ReadHoldingRegisters((byte)deviceId, ADDR_FILTER_TIME, 1)[0] * slaveTickLength;
				} catch (IOException) {
					modbusNetwork.InitializeModbusMaster();
					return modbusNetwork.ModbusMaster.ReadHoldingRegisters((byte)deviceId, ADDR_FILTER_TIME, 1)[0] * slaveTickLength;
				} catch (Exception) {
					return -1;
				}
			}
			set 
			{
				try {
					#if (DEBUG)
					log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
					#endif
					ushort cv = (ushort)(value / slaveTickLength);
					modbusNetwork.ModbusMaster.WriteSingleRegister((byte)deviceId, ADDR_FILTER_TIME, cv);
				} catch (IOException) {
					modbusNetwork.InitializeModbusMaster();
				} catch (Exception) {
					
				}
			}
		}
		
		/// <summary>
		/// Czas w milisekundach na podtrzymanie informacji o stanie wcisniecia 
		/// przycisku. Domyslnie - 7500ms - czyli po wcisnieciu slave będzie pamiętał
		/// ten stan przez 7.5sek lub do pierwszego odczytu.
		/// </summary>
		public int KeyHoldTime
		{
			get 
			{
				try {
					#if (DEBUG)
					log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
					#endif
					return modbusNetwork.ModbusMaster.ReadHoldingRegisters((byte)deviceId, ADDR_KEY_TIMER, 1)[0] * slaveTickLength;
				} catch (IOException) {
					modbusNetwork.InitializeModbusMaster();	
					return modbusNetwork.ModbusMaster.ReadHoldingRegisters((byte)deviceId, ADDR_KEY_TIMER, 1)[0] * slaveTickLength;
				} catch (Exception) {
					return -1;
				}
			}
			set 
			{
				try {
					#if (DEBUG)
					log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
					#endif
					ushort cv = (ushort)(value / slaveTickLength);
					modbusNetwork.ModbusMaster.WriteSingleRegister((byte)deviceId, ADDR_KEY_TIMER, cv);
				} catch (IOException) {
					modbusNetwork.InitializeModbusMaster();
				} catch (Exception) {
					
				}
			}
		}
		
		/// <summary>
		/// Stan zasilania urządzania. Jesli właczymy - odcinane jest zasialnie 
		/// puszki na scianie przyłączonej do zasilacza z przekaźnikami. Po wyłaczeniu
		/// slave'a włączamy z powrotem puszke na ścianie. nie przechwytujemy tutaj 
		/// timeoutexception. Tylko IOException jest przechwytywany i probojemy 
		/// w wypadku jedo wystapnienia zainicjalizować mastera znow.
		/// </summary>
		public bool Power
		{
			get
			{
				try {
					#if (DEBUG)
					log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
					#endif
					return modbusNetwork.ModbusMaster.ReadCoils((byte)deviceId, COIL_ADDR_POWER, 1)[0];
				} catch (IOException) {
					modbusNetwork.InitializeModbusMaster();
					return modbusNetwork.ModbusMaster.ReadCoils((byte)deviceId, COIL_ADDR_POWER, 1)[0];
				}
			}
			set
			{
				try{
					#if (DEBUG)
					log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
					#endif
					modbusNetwork.ModbusMaster.WriteSingleCoil((byte)deviceId, COIL_ADDR_POWER, value);
				} catch (IOException) {
					modbusNetwork.InitializeModbusMaster();
					modbusNetwork.ModbusMaster.WriteSingleCoil((byte)deviceId, COIL_ADDR_POWER, value);
				}
			}
		}
		
		/// <summary>
		/// Czas po jakim urządzenie slave automatycznie się wyłączy jeśli przez
		/// ten okres nie dostanie żadnej komendy. To chyba na wypadek zawieszenia 
		/// sie aplikacji...
		/// </summary>
		public int PowerOffTimeout
		{
			get 
			{
				try {
					#if (DEBUG)
					log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
					#endif
					return modbusNetwork.ModbusMaster.ReadHoldingRegisters((byte)deviceId, ADDR_MST_TIME_OUT, 1)[0] * slaveTickLength;
				} catch (IOException) {
					modbusNetwork.InitializeModbusMaster();
					return modbusNetwork.ModbusMaster.ReadHoldingRegisters((byte)deviceId, ADDR_MST_TIME_OUT, 1)[0] * slaveTickLength;
				} catch (Exception) {
					return -1;
				}
			}
			set 
			{
				try {
					#if (DEBUG)
					log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
					#endif
					ushort cv = (ushort)(value / slaveTickLength);
					modbusNetwork.ModbusMaster.WriteSingleRegister((byte)deviceId, ADDR_MST_TIME_OUT, cv);
				} catch (IOException) {
					modbusNetwork.InitializeModbusMaster();
				} catch (Exception) {
					
				}
			}
		}
		
		/// <summary>
		/// Włącz slave'a.
		/// raczej krytyczne i nie powinnismy tuaj timeoutow przetwarzac tylko 
		/// kladziemy sie grzecznie na plecy i kwiczymy jak małe świnki kwii kwii
		/// </summary>
		public void PowerOn(){
//			modbusNetwork.ModbusMaster.WriteSingleCoil((byte)deviceId, COIL_ADDR_POWER, true);
			#if (DEBUG)
			log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
			#endif
			Power = true;
		}
		
		/// <summary>
		/// Wyłącz slave'a + wyłacz obydwa przekaźniki.
		/// </summary>
		public void PowerOff(){
			try{
				#if (DEBUG)
				log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
				#endif
//				modbusNetwork.ModbusMaster.WriteSingleCoil((byte)deviceId, COIL_ADDR_RELAY_0, false);
//				modbusNetwork.ModbusMaster.WriteSingleCoil((byte)deviceId, COIL_ADDR_RELAY_1, false);
//				modbusNetwork.ModbusMaster.WriteSingleCoil((byte)deviceId, COIL_ADDR_POWER, false);
				DisableButtonsReaction();
				Power = false;
			} catch (IOException) {
				modbusNetwork.InitializeModbusMaster();
//				PowerOff();		//tak nie mozna bo moze sie zapetlic w nieskonczonosc!!
			} catch (TimeoutException) {
				#if (DEBUG)
				log4net.LogManager.GetLogger("ModbusSlave").Info("Timeout exception przy wyłączaniu urządzenia.");
				#endif
			}
		}
		
		/// <summary>
		/// Czy zasilanie slave'a jest właczone?
		/// (raczej krytyczne i nie powinnismy tuaj timeoutow przetwarzac tylko kladziemy sie na plecy...)?
		/// </summary>
		/// <returns></returns>
		public bool IsPowerOn() {
			#if (DEBUG)
			log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
			#endif
//			return modbusNetwork.ModbusMaster.ReadCoils((byte)deviceId, COIL_ADDR_POWER, 1)[0];
			return Power;
		}
		
		/// <summary>
		/// Grzanie - przekaźnik 0 (jego adres jest konfigurowany w pliku jako relay0)
		/// </summary>
		public bool Heating{
			get
			{
				#if (DEBUG)
				log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
				#endif
				return Relay0;
			}
			set
			{
				#if (DEBUG)
				log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
				#endif
				//wywołujemy w taki sposob gdyz wołane metory sprawdzają
				//czy zasilanie wlaczone i ew. exception rzucają
				if(value == true)
				{
					HeatingOn();
				}
				else
				{
					HeatingOff();
				}
			}
		}
		
		/// <summary>
		/// Chłodzenie - przekaźnik 1 (jego adres jest konfigurowany w pliku jako relay1)
		/// </summary>
		public bool Cooling{
			get
			{
				#if (DEBUG)
				log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
				#endif
				return Relay1;
			}
			set
			{
				#if (DEBUG)
				log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
				#endif
				//wywołujemy w taki sposob gdyz wołane metory sprawdzają
				//czy zasilanie wlaczone i ew. exception rzucają
				if(value == true)
				{
					CoolingOn();
				}
				else
				{
					CoolingOff();
				}
			}
		}
		
		/// <summary>
		/// Włacz opalanie (przekaznik opalania konfigurowany w pliku konfiguracyjnym)
		/// </summary>
		public void HeatingOn() {
			#if (DEBUG)
			log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
			#endif
			if(IsPowerOn())
			{
				Relay0 = true;
			}
			else
			{
				throw new SlaveDeviceException("Can't turn heating on when the device is powered off!");
			}
		}
		
		/// <summary>
		/// Wyłącz opalanie
		/// </summary>
		public void HeatingOff() {
			#if (DEBUG)
			log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
			#endif
			if(IsPowerOn())
			{
				Relay0 = false;
			}
			else
			{
				throw new SlaveDeviceException("Can't turn heating off when the device is powered off!");
			}

		}
		
		/// <summary>
		/// Włącz chłodzenie.
		/// </summary>
		public void CoolingOn() {
			#if (DEBUG)
			log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
			#endif
			if(IsPowerOn())
			{
				Relay1 = true;
			}
			else
			{
				throw new SlaveDeviceException("Can't turn cooling on when the device is powered off!");
			}
		}
		

		
		/// <summary>
		/// Wyłącz chłodzenie.
		/// </summary>
		public void CoolingOff() {
			#if (DEBUG)
			log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
			#endif
			if(IsPowerOn())
			{
				Relay1 = false;
			}
			else
			{
				throw new SlaveDeviceException("Can't turn cooling off when the device is powered off!");
			}
		}

		/// <summary>
		/// Zwraca stan przycisku START. Przycisk ten jest konfigurowany dynamicznie
		/// na podstawie danych w konfigu. Jesli był wcisniety kasuje jego stan 
		/// po odczycie.
		/// </summary>
		/// <returns></returns>
		public bool IsStartButtonPressed() {
			#if (DEBUG)
			log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
			#endif
			bool b = false;
			try{
				b =  modbusNetwork.ModbusMaster.ReadInputs((byte)deviceId, BIT_ADDR_KEY_1, 1)[0];
			} catch (IOException) {
				modbusNetwork.InitializeModbusMaster();
				return b;
			} catch (TimeoutException) {
				return b;
			} catch (Exception) {
				return b;
			}
			return b;
		}
		
		/// <summary>
		/// Zwraca stan przycisku STOP. Przycisk ten jest konfigurowany dynamicznie
		/// na podstawie danych w konfigu. Jesli był wcisniety kasuje jego stan 
		/// po odczycie.
		/// </summary>
		/// <returns></returns>
		public bool IsStopButtonPressed() {
			#if (DEBUG)
			log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
			#endif
			bool b = false;
			try{
				b =  modbusNetwork.ModbusMaster.ReadInputs((byte)deviceId, BIT_ADDR_KEY_2, 1)[0];
			} catch (IOException) {
				modbusNetwork.InitializeModbusMaster();
				return b;
			} catch (TimeoutException) {
				return b;
			} catch (Exception) {	//np zdazylo sie jakies IOException :/kurwa!
				return b;
			}
			return b;
		}
		
		/// <summary>
		/// Bierz dwa przyciski od razu. 
		/// </summary>
		/// <returns>[0] - start, [1] - stop...</returns>
		public bool[] GetButtonsState() {
			throw new NotImplementedException();
		}
		
		/// <summary>
		/// Odblokuj automatyczną reakcję slave'a na przycisk start aby uruchomić
		/// opalanie bez udziału komputera...
		/// </summary>
		public void EnableHeatingStartReaction() {
			#if (DEBUG)
			log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
			#endif
			try{
				if(BIT_ADDR_KEY_1 == 0x0000) {
					if(COIL_ADDR_RELAY_0 == 0) {
						modbusNetwork.ModbusMaster.WriteSingleRegister((byte)deviceId, ADDR_FREE_WORD1, RELAY_1_ON_SEQ);
					} else if(COIL_ADDR_RELAY_0 == 1) {
						modbusNetwork.ModbusMaster.WriteSingleRegister((byte)deviceId, ADDR_FREE_WORD1, RELAY_2_ON_SEQ);
					}
				} else if(BIT_ADDR_KEY_1 == 0x0001) {
					if(COIL_ADDR_RELAY_0 == 0) {
						modbusNetwork.ModbusMaster.WriteSingleRegister((byte)deviceId, ADDR_FREE_WORD2, RELAY_1_ON_SEQ);
					} else if(COIL_ADDR_RELAY_0 == 1) {
						modbusNetwork.ModbusMaster.WriteSingleRegister((byte)deviceId, ADDR_FREE_WORD2, RELAY_2_ON_SEQ);
					}
				}
			} catch (IOException) {
				modbusNetwork.InitializeModbusMaster();
			}catch(TimeoutException ) {
				
			}
		}

		/// <summary>
		/// Czy jest aktywna prawidłowa reakcja na button START?
		/// </summary>
		/// <returns></returns>
		public bool IsHeatingStartReactionActive() {
			#if (DEBUG)
			log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
			#endif
			try {
				if(BIT_ADDR_KEY_1 == 0x0000) {
					if(COIL_ADDR_RELAY_0 == 0) {
						return modbusNetwork.ModbusMaster.ReadHoldingRegisters((byte)deviceId, ADDR_FREE_WORD1, 1)[0] == RELAY_1_ON_SEQ;
					} else if(COIL_ADDR_RELAY_0 == 1) {
						return modbusNetwork.ModbusMaster.ReadHoldingRegisters((byte)deviceId, ADDR_FREE_WORD1, 1)[0] == RELAY_2_ON_SEQ;
					}
				} else if(BIT_ADDR_KEY_1 == 0x0001) {
					if(COIL_ADDR_RELAY_0 == 0) {
						return modbusNetwork.ModbusMaster.ReadHoldingRegisters((byte)deviceId, ADDR_FREE_WORD2, 1)[0] == RELAY_1_ON_SEQ;
					} else if(COIL_ADDR_RELAY_0 == 1) {
						return modbusNetwork.ModbusMaster.ReadHoldingRegisters((byte)deviceId, ADDR_FREE_WORD2, 1)[0] == RELAY_2_ON_SEQ;
					}
				}
			} catch (IOException) {
				modbusNetwork.InitializeModbusMaster();
			}catch(TimeoutException ) {
				
			}
			return false;
		}
		
		/// <summary>
		/// Odblokuj automatyczną reakcję slave'a na przycisk stop aby umożliwić
		/// wyłączenie opalania bez udziału komputera.
		/// </summary>
		public void EnableHeatingStopReaction() {
			#if (DEBUG)
			log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
			#endif
			try{
				if(BIT_ADDR_KEY_2 == 0x0000) {
					if(COIL_ADDR_RELAY_0 == 0) {
						modbusNetwork.ModbusMaster.WriteSingleRegister((byte)deviceId, ADDR_FREE_WORD1, RELAY_1_OFF_SEQ);
					} else if(COIL_ADDR_RELAY_0 == 1) {
						modbusNetwork.ModbusMaster.WriteSingleRegister((byte)deviceId, ADDR_FREE_WORD1, RELAY_2_OFF_SEQ);
					}
				} else if(BIT_ADDR_KEY_2 == 0x0001) {
					if(COIL_ADDR_RELAY_0 == 0) {
						modbusNetwork.ModbusMaster.WriteSingleRegister((byte)deviceId, ADDR_FREE_WORD2, RELAY_1_OFF_SEQ);
					} else if(COIL_ADDR_RELAY_0 == 1) {
						modbusNetwork.ModbusMaster.WriteSingleRegister((byte)deviceId, ADDR_FREE_WORD2, RELAY_2_OFF_SEQ);
					}
				}
			} catch (IOException) {
				modbusNetwork.InitializeModbusMaster();
			}catch(TimeoutException ) {
				
			}
		}
		
		/// <summary>
		/// czy jest aktywna reakcja na button stop? 
		/// </summary>
		/// <returns></returns>
		public bool IsHeatingStopReactionActive() {
			#if (DEBUG)
			log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
			#endif
			try{
				if(BIT_ADDR_KEY_2 == 0x0000) {
					if(COIL_ADDR_RELAY_0 == 0) {
						return modbusNetwork.ModbusMaster.ReadHoldingRegisters((byte)deviceId, ADDR_FREE_WORD1, 1)[0] == RELAY_1_OFF_SEQ;
					} else if(COIL_ADDR_RELAY_0 == 1) {
						return modbusNetwork.ModbusMaster.ReadHoldingRegisters((byte)deviceId, ADDR_FREE_WORD1, 1)[0] == RELAY_2_OFF_SEQ;
					}
				} else if(BIT_ADDR_KEY_2 == 0x0001) {
					if(COIL_ADDR_RELAY_0 == 0) {
						return modbusNetwork.ModbusMaster.ReadHoldingRegisters((byte)deviceId, ADDR_FREE_WORD2, 1)[0] == RELAY_1_OFF_SEQ;
					} else if(COIL_ADDR_RELAY_0 == 1) {
						return modbusNetwork.ModbusMaster.ReadHoldingRegisters((byte)deviceId, ADDR_FREE_WORD2, 1)[0] == RELAY_2_OFF_SEQ;
					}
				}
			} catch (IOException) {
				modbusNetwork.InitializeModbusMaster();
			}catch(TimeoutException ) {
				
			}
			return false;
		}
		
		/// <summary>
		/// Zablokuj hardwareową reakcję na przyciski wciskane przez usera, czyli
		/// wyczyść konfigurację reakcji w rejestrach konfiguracyjnych.
		/// </summary>
		public void DisableButtonsReaction() {
			#if (DEBUG)
			log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
			#endif
			try{
				modbusNetwork.ModbusMaster.WriteSingleRegister((byte)deviceId, ADDR_FREE_WORD1, 0x0000);
				modbusNetwork.ModbusMaster.WriteSingleRegister((byte)deviceId, ADDR_FREE_WORD2, 0x0000);
			} catch (InvalidOperationException) {
				modbusNetwork.InitializeModbusMaster();
			} catch (IOException) {
				modbusNetwork.InitializeModbusMaster();
			} catch(TimeoutException) {
				
			}
		}
		
		public override string ToString()
		{
			return String.Format("SlaveID: {0}", deviceId);
		}		
		
		#region _private_methods

		/// <summary>
		/// Przekaźnik 0 - jego adres jest konfigurowany w pliku konfiguracyjnym XML
		/// całej aplikacji w odpowiedniej sekcji.
		/// </summary>
		private bool Relay0 {
			get
			{
				#if (DEBUG)
				log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
				#endif
				try{
					return modbusNetwork.ModbusMaster.ReadCoils((byte)deviceId, COIL_ADDR_RELAY_0, 1)[0];
				} catch (IOException) {
					modbusNetwork.InitializeModbusMaster();
				} catch (TimeoutException) {
					
				}
				return false;
			}
			set
			{
				#if (DEBUG)
				log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
				#endif
				try{
					modbusNetwork.ModbusMaster.WriteSingleCoil((byte)deviceId, COIL_ADDR_RELAY_0, value);
				} catch (IOException) {
					modbusNetwork.InitializeModbusMaster();
				} catch (TimeoutException) {
					
				}
			}
		}

		/// <summary>
		/// Przekaźnik 1 - jego adres jest konfigurowany w pliku konfiguracyjnym XML
		/// całej aplikacji w odpowiedniej sekcji.
		/// </summary>
		private bool Relay1 {
			get
			{
				#if (DEBUG)
				log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
				#endif
				try{
					return modbusNetwork.ModbusMaster.ReadCoils((byte)deviceId, COIL_ADDR_RELAY_1, 1)[0];
				} catch (IOException) {
					modbusNetwork.InitializeModbusMaster();
				} catch (TimeoutException) {
					
				}
				return false;
			}
			set
			{
				#if (DEBUG)
				log4net.LogManager.GetLogger(this.GetType().FullName).Info(System.Reflection.MethodBase.GetCurrentMethod().ToString());
				#endif
				try{
					modbusNetwork.ModbusMaster.WriteSingleCoil((byte)deviceId, COIL_ADDR_RELAY_1, value);
				} catch (IOException) {
					modbusNetwork.InitializeModbusMaster();
				} catch (TimeoutException) {
					
				}
			}
		}

		#endregion
	}
}
