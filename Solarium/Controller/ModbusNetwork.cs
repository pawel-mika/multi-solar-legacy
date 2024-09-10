/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-08-07
 * Time: 23:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Configuration;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.IO;

using FtdAdapter;

using Modbus;
using Modbus.Data;
using Modbus.Device;
using Modbus.IO;

using Solarium.Controls;
using Solarium.Config;
using Solarium.Frame;
using Solarium.Utils;
using Solarium.Settings;
using Solarium.Bios;

namespace Solarium.Controller
{
	/// <summary>
	/// Modbus network is an integral part of solarium application.
	/// It's closely integrated with MutanaFramework but perhaps
	/// it would be better to move it into separate plugin?
	/// In that case - any other plugin depending on modbus
	/// devices should first check if modbus plugin is loaded/available.
	/// </summary>
	public partial class ModbusNetwork : SynchronizationContext, IModbusNetwork
	{
		private IMainFrame mf = null;
		public IMainFrame Mf {
			get { return mf; }
		}

		private LinkedList<ISlaveDeviceControl> slaveDevices = null;
		public LinkedList<ISlaveDeviceControl> SlaveDevices {
			get { return slaveDevices; }
		}

		private FtdUsbPort ftdUsbPort = null;
		
		private Semaphore mSemaphore = new Semaphore(1,1);
		private ReaderWriterLock rwLock = new ReaderWriterLock();

		private IModbusSerialMaster modbusMaster = null;
		public IModbusSerialMaster ModbusMaster {
			get {
				//ciekawe czy ten semafor rzeczywiscie cos daje...?:|
//				mSemaphore.WaitOne(200,true);
				return modbusMaster; 
//				mSemaphore.Release();
				
//				rwLock.AcquireWriterLock(Timeout.Infinite);
//				try
//				{
//					mf.MainFrameUI.Logger.Info(string.Format("Thread:{0} starts getting the ModbusMaster", Thread.CurrentThread.GetHashCode()));
//					Thread.Sleep(250);
//					mf.MainFrameUI.Logger.Info(string.Format("Thread:{0} got the ModbusMaster", Thread.CurrentThread.GetHashCode()));
//				}
//				finally
//				{
//					//Release the lock.
//					rwLock.ReleaseWriterLock();
//				}
//				return modbusMaster;
				
//				Monitor.Enter(modbusMaster);
//				return modbusMaster;
//				Monitor.Exit(modbusMaster);
			}
		}
		
		private Thread slavePingThread = null;
		
		private System.Timers.Timer slavePingTimer = null;
		public System.Timers.Timer SlavePingTimer {
			get { return slavePingTimer; }
		}
		
		/// <summary>
		/// Max slave devices we can handle in app...
		/// </summary>
		private const int MAX_SLAVE_COUNT = 8;
		public int MaximumSlaveCount {
			get { return MAX_SLAVE_COUNT; }
		}
		
		delegate void SDCParamDelegate(SlaveDeviceControl sdc);
		delegate void IntParamDelegate(int val);

		/// <summary>
		/// Obiekt sieci modbus, który odpowiada za komunikacje ze sterownikami łózek.
		/// </summary>
		public ModbusNetwork(IMainFrame mf)
		{
			this.mf = mf;
			DiscoverModbusNetwork();
			
			if(modbusMaster != null){
				int time = ModbusNetworkSettings.GetSection(ConfigurationUserLevel.None).ScanningThreadInterval;
				//StartSlavePingTimer(time);
				StartSlaveAlivePingTimer(time);
				ModbusNetworkSettings.GetSection(ConfigurationUserLevel.None).Save();
			}
		}
		
		#region private methods
		
		/// <summary>
		///	a moze dodać reagowanie na brak/>1 liczby urzadzen MASTER? jakies okienko czy cos...?
		/// </summary>
		private void DiscoverModbusNetwork()
		{
			slaveDevices = new LinkedList<ISlaveDeviceControl>();
			try {
				InitializeModbusMaster();
				if(modbusMaster != null){
					//discover devices...
					for (int i = 1; i < MAX_SLAVE_COUNT; i++){
						ISlaveDeviceControl sdc = null;
						try{
							sdc = new BedControl(mf, this, i);
						}catch(TimeoutException){
						}
						if(sdc!=null){
							slaveDevices.AddLast(sdc);
						}
					}
				}
			} catch (DllNotFoundException de){
				Utils.DialogUtils.ShowError(mf, "Error: required dll not found", de);
			} catch (Exception ex) {
				Utils.DialogUtils.ShowError(mf, "Error while discovering solarium bed network",
				                            new Exception(string.Format("Class: {0}\nMethod: {1}",
                                                  this.GetType().FullName,
                                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                                  ex));
			} finally {

			}
		}
		
		/// <summary>
		/// Utworz urzadzenie modbus master. Jesli cos nie tak to wyrzuci exceptiona wiec łapać!
		/// </summary>
		public void InitializeModbusMaster() 
		{
			int deviceCount = FtdAdapter.FtdUsbPort.GetDeviceCount();
			
			if(ftdUsbPort != null && ftdUsbPort.IsOpen) {
				ftdUsbPort.Close();
			}

			if(deviceCount == 1) {
				ftdUsbPort = new FtdUsbPort();
				#if (DEBUG)
				log4net.LogManager.GetLogger("Network").Info(String.Format("Master information: {0}", FormatFTDDeviceInfo(FtdAdapter.FtdUsbPort.GetDeviceInfo(0))));
				#endif
				// configure usb port
				ftdUsbPort.BaudRate = 19200;
				ftdUsbPort.DataBits = 8;
				ftdUsbPort.Parity = FtdParity.None;
				ftdUsbPort.StopBits = FtdStopBits.One;
				ftdUsbPort.ReadTimeout = 250; 			//250ms timeout
				ftdUsbPort.WriteTimeout = 250;
				ftdUsbPort.OpenByIndex(0);
				// create modbus master
				modbusMaster = ModbusSerialMaster.CreateRtu(ftdUsbPort);
				modbusMaster.Transport.Retries = 4;		//nie za kozacko??
				
				#if (DEBUG)
				log4net.LogManager.GetLogger("Network").Info("Modbus master device initialization complete.");
				#endif
			} else if(deviceCount == 0){
//				DialogUtils.ShowInfo(mf, "Uwaga!", "Uruchomienie aplikacji bez podłączonego modułu Master\r\n" +
//				                     "może skutkować nieprzewidzianym działaniem!");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="fdi"></param>
		/// <returns></returns>
		private String FormatFTDDeviceInfo(FtdDeviceInfo fdi) 
		{
			String s = "" + Environment.NewLine;
			s += "Description: " + fdi.Description + Environment.NewLine;
			s += "Flags: " + fdi.Flags + Environment.NewLine;
			s += "Id: " + fdi.Id + Environment.NewLine;
			s += "Location id: " + fdi.LocationId + Environment.NewLine;
			s += "Product id: " + fdi.ProductId + Environment.NewLine;
			s += "Serial no: " + fdi.SerialNumber + Environment.NewLine;
			s += "Type: " + fdi.Type + Environment.NewLine;
			s += "Vendor id: " + fdi.VendorId;// + Environment.NewLine;
			return s;
		}
		
		/// <summary>
		/// Callback for the ping timer
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void slavePingCallback(object sender, EventArgs e){
			if(slavePingThread==null){
				RescanNetwork();
			}else if(slavePingThread!=null && !slavePingThread.IsAlive){
				RescanNetwork();
			}else if(slavePingThread!=null && slavePingThread.IsAlive){
				//nic nie robimy bo jestesmy juz zajeci skanowaniem...
			}
		}
		
		private void slaveAlivePingCallback(object sender, EventArgs e){
			if(slavePingThread==null){
				CheckAliveDevices();
			}else if(slavePingThread!=null && !slavePingThread.IsAlive){
				CheckAliveDevices();
			}else if(slavePingThread!=null && slavePingThread.IsAlive){
				//nic nie robimy bo jestesmy juz zajeci skanowaniem...
			}
		}

		#endregion
		
		#region public methods
		
		public void StopSlavePingTimer(){
			if(this.slavePingThread != null && this.slavePingThread.IsAlive){
				this.slavePingThread.Interrupt();
				this.slavePingThread.Abort();
			}
		}

		/// <summary>
		/// run a timer that every N seconds will run a thread that will scan 
		/// network for any slaves changes (connected/disconnected)
		/// </summary>
		/// <param name="interval"></param>
		public void StartSlavePingTimer(int interval){
			slavePingTimer = new System.Timers.Timer();
			slavePingTimer.Interval = interval*1000;
			slavePingTimer.Elapsed += new ElapsedEventHandler( slavePingCallback );
			slavePingTimer.Start();
		}
		
		/// <summary>
		/// run a timer that every N seconds will run a thread that will scan 
		/// network for any slaves changes (connected/disconnected)
		/// </summary>
		/// <param name="interval"></param>
		public void StartSlaveAlivePingTimer(int interval){
			slavePingTimer = new System.Timers.Timer();
			slavePingTimer.Interval = interval*1000;
			slavePingTimer.Elapsed += new ElapsedEventHandler( slaveAlivePingCallback );
			slavePingTimer.Start();
		}

		/// <summary>
		/// One-time network rescan through a thread
		/// </summary>
		public void RescanNetwork(){
			slavePingThread = new Thread(new ParameterizedThreadStart( slaveScan ));
			slavePingThread.Start();
		}

		/// <summary>
		/// One-time network rescan through a thread
		/// </summary>
		public void CheckAliveDevices(){
			slavePingThread = new Thread(new ParameterizedThreadStart( aliveScan ));
			slavePingThread.Start();
		}
		
		/// <summary>
		/// Scan for slave changes in whole network.
		/// This supposed to be runned in a thread.
		/// </summary>
		/// <param name="o"></param>
		public void slaveScan(object o){
			#if (DEBUG)
			log4net.LogManager.GetLogger("Network").Info("Slave scan started...");
			#endif
			
			if (modbusMaster != null) {
				for (int i = 1; i < MAX_SLAVE_COUNT; i++){
					try{
						lock(modbusMaster){
							modbusMaster.ReadCoils((byte)i, 0x0002, 1);
						}
						lock(slaveDevices){
							bool foundInList = false;
							foreach(ISlaveDeviceControl sdc in slaveDevices){
								if(sdc.DeviceId == i){
									foundInList = true;
								}
							}
							if(!foundInList){
								BedControl slaveControl = new BedControl(mf, this, i);
								slaveDevices.AddLast( slaveControl );
								FireSlaveAdded(new ModbusNetworkEvent( slaveControl ) );
								//AddSlaveToPanel( slaveControl );
							}
						}
					}catch(TimeoutException){
						//if there was an timeout for a device we're currently holding - remove it
						ISlaveDeviceControl slaveControl = null;
						lock(slaveDevices){
							foreach(ISlaveDeviceControl sdc in slaveDevices){
								if(sdc.DeviceId == i){
									slaveControl = sdc;
								}
							}
						}
						if(slaveControl!=null){
							FireSlaveRemoved(new ModbusNetworkEvent( slaveControl ) );
							slaveDevices.Remove( slaveControl );
						}
					}catch(ThreadAbortException){
						//do nothing - normal exception when we're quitting the app...
					}catch(InvalidOperationException){
						#if (DEBUG)
						log4net.LogManager.GetLogger("Network").Info("InvalidOperationException - trying to reinitialize master device!");
						#endif
						InitializeModbusMaster();
						if(modbusMaster != null && ftdUsbPort.IsOpen) {
							if(o is int) {
								if(((int)o) == 1) {
									slaveScan(2);
								}
							} else if(o == null) {
								slaveScan(1);
							}
						}
					}catch(IOException){
						//chyba cos nie tak z komunikacja do mastera...
						//moze reinicjalizacja?
						//odpalamy inita max 2 razy...tzn wchodzimy spowrotem do
						//slaveScan max 2 razy..
						#if (DEBUG)
						log4net.LogManager.GetLogger("Network").Info("OIException - trying to reinitialize master device!");
						#endif
						InitializeModbusMaster();
						if(modbusMaster != null && ftdUsbPort.IsOpen) {
							if(o is int) {
								if(((int)o) == 1) {
									slaveScan(2);
								}
							} else if(o == null) {
								slaveScan(1);
							}
						}
					}catch(Exception ex){
						//any other exception - some kind of error, so handle it properly
						DialogUtils.ShowError(mf, "Error while scanning...",
						                      new Exception(string.Format("Class: {0}\nMethod: {1}",
						                                                  this.GetType().FullName,
						                                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
						                                    ex));

					}
					updateProgressInfo(i);
				}
				updateProgressInfo(-1);
			} else {
				DialogUtils.ShowInfo(mf, "Info", "Sorry but there's probably no Master device connected!");
			}
			
			#if (DEBUG)
			log4net.LogManager.GetLogger("Network").Info("Slave scan finished...");
			#endif
		}
		
		/// <summary>
		/// Callback timera skanowania 'zywych' urzadzen slave.
		/// </summary>
		/// <param name="o"></param>
		public void aliveScan(object o){
			#if (DEBUG)
			log4net.LogManager.GetLogger("Network").Info("Alive scan started...");
			#endif
			
			if (modbusMaster != null) {
				foreach(ISlaveDeviceControl s in slaveDevices){
					try{
						if(!(s.CurrentState.State == BedState.EState.WAITING) || !(s.CurrentState.State == BedState.EState.HEATING)){
							lock(modbusMaster){
								modbusMaster.ReadCoils((byte)s.DeviceId, 0x0002, 1);
							}
						}
					}catch(TimeoutException){

					}catch(InvalidOperationException){
						#if (DEBUG)
						log4net.LogManager.GetLogger("Network").Info("InvalidOperationException - trying to reinitialize master device!");
						#endif
						InitializeModbusMaster();
						if(modbusMaster != null && ftdUsbPort.IsOpen) {
							if(o is int) {
								if(((int)o) == 1) {
									aliveScan(2);
								}
							} else if(o == null) {
								aliveScan(1);
							}
						}
					}catch(ThreadAbortException){
						//do nothing - normal exception when we're quitting the app...
					}catch(IOException){
						//chyba cos nie tak z komunikacja do mastera...
						//moze reinicjalizacja?
						//odpalamy inita max 2 razy...tzn wchodzimy z powrotem do
						//aliveScan max 2 razy..
						#if (DEBUG)
						log4net.LogManager.GetLogger("Network").Info("OIException - trying to reinitialize master device!");
						#endif
						InitializeModbusMaster();
						if(modbusMaster != null && ftdUsbPort.IsOpen) {
							if(o is int) {
								if(((int)o) == 1) {
									aliveScan(2);
								}
							} else if(o == null) {
								aliveScan(1);
							}
						}
					}catch(Exception ex){
						//any other exception - some kind of error, so handle it properly
						DialogUtils.ShowError(mf, "Error while scanning for alive devices...",
						                      new Exception(string.Format("Class: {0}\nMethod: {1}",
						                                                  this.GetType().FullName,
						                                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
						                                    ex));

					}
					updateProgressInfo(s.DeviceId);
				}
				updateProgressInfo(-1);
			} else {
				DialogUtils.ShowInfo(mf, "Info", "Sorry but there's probably no Master device connected!");
			}
			#if (DEBUG)
			log4net.LogManager.GetLogger("Network").Info("Alive scan finished...");
			#endif
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="slave"></param>
		public void CriticalSlaveRemove(Solarium.Controls.ISlaveDeviceControl slave) {
			lock(slaveDevices) {
				if(slave != null){
					FireSlaveRemoved(new ModbusNetworkEvent( slave ));
					slaveDevices.Remove( slave );
					try{
						slave.DisposeDevice();
					} catch (TimeoutException) {
						
					}
				}
			}
		}
		
		/// <summary>
		/// Cross thread update status strip with information from scanning progress
		/// </summary>
		/// <param name="val"></param>
		public void updateProgressInfo(int val){
			if (mf.MFStatusStrip.InvokeRequired){
				mf.MFStatusStrip.BeginInvoke(new IntParamDelegate(updateProgressInfo), new object[]{val});
				return;
			}
			if(!mf.MFStatusStrip.Disposing || !mf.MFStatusStrip.IsDisposed){
				mf.MFStatusStrip.ProgressBar.Maximum = MAX_SLAVE_COUNT;
				if(val>=0){
					mf.MFStatusStrip.ProgressBar.Value = val;
					mf.MFStatusStrip.ProgressMessage.Text = string.Format("Pinging device id: {0}", val);
				}else{
					mf.MFStatusStrip.ProgressBar.Value = 0;
					mf.MFStatusStrip.ProgressMessage.Text = ".";
				}
			}
		}
		
		/// <summary>
		/// Slave device added
		/// </summary>
		public event ModbusNetworkEventHandler SlaveAdded;
		protected virtual void FireSlaveAdded(ModbusNetworkEvent e){
			if(SlaveAdded!=null){
				SlaveAdded(this, e);
			}
		}
		
		/// <summary>
		/// Slave device removed
		/// </summary>
		public event ModbusNetworkEventHandler SlaveRemoved;
		protected virtual void FireSlaveRemoved(ModbusNetworkEvent e){
			if(SlaveRemoved!=null){
				SlaveRemoved(this, e);
			}
		}
		
		#endregion
		
		/// <summary>
		/// Statyczna metoda do pobierania skonfiguraowanego elementu modbusSlave
		/// na postawie ID urzadzenia. Jeśli jest takie urządzenie to dostajemy
		/// je w returnie. Jeśli nie ma to bedzie mały exception...
		/// </summary>
		/// <param name="mf"></param>
		/// <param name="deviceId"></param>
		/// <returns></returns>
		public static ModbusSlave GetConfiguredModbusSlave(IMainFrame mf, int deviceId)
		{
			bool slaveInConfig = false;
			ModbusSlave modbusSlave = null;
			
			ModbusSlaveElement modbusSlaveConfig = new ModbusSlaveElement();
			ModbusNetworkSettings mns = ModbusNetworkSettings.GetSection(ConfigurationUserLevel.None);
			ModbusSlaveCollection msc = mns.Slaves;
			foreach(ModbusSlaveElement mse in msc)
			{
				if(mse.Id == deviceId)
				{
					slaveInConfig = true;
					modbusSlaveConfig = mse;
				}
			}
			
			if(slaveInConfig)
			{
				modbusSlave = new Solarium.Controller.ModbusSlave(mf.Network, modbusSlaveConfig);
			}
			else
			{
				modbusSlaveConfig = new ModbusSlaveElement();
				modbusSlaveConfig.Id = deviceId;
				msc.Add(modbusSlaveConfig);
				mns.Save();
				modbusSlave = new Solarium.Controller.ModbusSlave(mf.Network, modbusSlaveConfig);
			}
			return modbusSlave;
		}
		
//		public bool InvokeRequired {
//			get {
//				throw new NotImplementedException();
//			}
//		}
//		
//		public IAsyncResult BeginInvoke(Delegate method, object[] args)
//		{
//			throw new NotImplementedException();
//		}
//		
//		public object EndInvoke(IAsyncResult result)
//		{
//			throw new NotImplementedException();
//		}
//		
//		public object Invoke(Delegate method, object[] args)
//		{
//			throw new NotImplementedException();
//		}
	}
}
