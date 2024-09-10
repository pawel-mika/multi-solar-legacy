/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-11-27
 * Time: 19:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

using Solarium;
using Solarium.Controller;
using Solarium.Frame;

using Modbus.Device;

namespace ModbusPlugin
{
	/// <summary>
	/// Description of NetworkScanForm.
	/// </summary>
	public partial class NetworkScanForm : Form
	{
		private IMainFrame mf = null;
		private PluginMainForm pmf = null;
		private int maxSlaveDevices = 8;
		private Thread scanThread = null;
		
		delegate void ModbusSlaveParamDelegate(Solarium.Controller.ModbusSlave val);
		delegate void IntParamDelegate(int val);
		delegate void StringParamDelegate(string val);
		delegate void CloseScanFormDelegate();
		
		public NetworkScanForm()
		{
			InitializeComponent();
		}

		public NetworkScanForm(PluginMainForm mainForm, IMainFrame mf)
		{
			this.mf = mf;
			this.pmf = mainForm;
			InitializeComponent();
			maxSlaveDevices = mf.Network.MaximumSlaveCount;
			progressBar1.Maximum = maxSlaveDevices;
			mf.MFStatusStrip.ProgressBar.Maximum = maxSlaveDevices;
			
			scanThread = new Thread(new ParameterizedThreadStart( Scan ));
			scanThread.Start();

			//this.Close();
		}
		
		public void Scan(object o){
			if (mf.Network.ModbusMaster!=null) {
				IModbusSerialMaster mMaster = null;
				mMaster = mf.Network.ModbusMaster;
				mMaster.Transport.Retries = 1;
				
				for (int i = 1; i <= maxSlaveDevices; i++){
					try{
						//pingujemy poprzez odczytanie czy slave jest wlaczony/wylaczony
//						mMaster.ReadCoils((byte)i, 0x0002, 1);
//						addDeviceId(i.ToString());
						//jeśli właczony to tworzymy jego obiekt i dodajemy do listy...
						Solarium.Controller.ModbusSlave ms = ModbusNetwork.GetConfiguredModbusSlave(mf, i);
						//jesli sie właczy bez timeoutexception to ok
						ms.Power = true;
						addModbusSlave(ms);
					}catch (TimeoutException){
						//timeuot exception - czyli nie ma takiego urzedzenia...
					}
					updateProgressInfo(i);
				}
				updateProgressInfo(-1);
				CloseScanForm();
			}
		}

		#region _cross_thread_invokers

		public void updateProgressInfo(int val){
			if (this.InvokeRequired){
				this.BeginInvoke(new IntParamDelegate(updateProgressInfo), new object[]{val});
				return;
			}
			if(val>=0){
				progressBar1.Value = val;
				label1.Text = string.Format("Pinging {0} of {1}", val, maxSlaveDevices);
				mf.MFStatusStrip.ProgressBar.Value = val;
				mf.MFStatusStrip.ProgressMessage.Text = string.Format("Pinging device id: {0}", val);
			}else{
				label1.Text = "";
				mf.MFStatusStrip.ProgressBar.Value = 0;
				mf.MFStatusStrip.ProgressMessage.Text = ".";
			}
		}
		
		public void addDeviceId(string val){
			if (pmf.CbSlave.InvokeRequired){
				pmf.CbSlave.BeginInvoke(new StringParamDelegate(addDeviceId), new object[]{val});
				return;
			}
			pmf.CbSlave.Items.Add(val);
		}
		
		public void addModbusSlave(Solarium.Controller.ModbusSlave ms)
		{
			if (pmf.CbSlave.InvokeRequired)
			{
				pmf.CbSlave.BeginInvoke(new ModbusSlaveParamDelegate(addModbusSlave), new object[]{ms});
				return;
			}
			pmf.CbSlave.Items.Add(ms);
		}
		
		public void CloseScanForm(){
			if(this.InvokeRequired){
				this.BeginInvoke(new CloseScanFormDelegate(CloseScanForm));
				return;
			}
			if(pmf.CbSlave.Items.Count>0){
				pmf.CbSlave.SelectedIndex = 0;
			}
			this.Dispose();
		}

		#endregion

	}
}
