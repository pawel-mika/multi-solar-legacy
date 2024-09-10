/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-11-27
 * Time: 19:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

using Solarium;
using Solarium.Frame;
using Solarium.Utils;
using Solarium.Settings;

using ModbusPlugin.SlaveControls;
using ModbusPlugin.XMLConfig;
using Modbus.Device;
using Solarium.Controller;

namespace ModbusPlugin
{
	/// <summary>
	/// Description of ModbusPluginMainForm.
	/// </summary>
	public partial class PluginMainForm : Form
	{
		private IMainFrame mf = null;
		private IModbusSerialMaster mMaster = null;
		private XMLConfig.XMLConfig xmlc = null;
		private System.Windows.Forms.Timer buttonScanTimer = null;
		private Solarium.Controller.ModbusSlave modbusSlaveSelected = null;
		private DiagnosticControl diagControl = null;
		
		public ComboBox CbSlave{
			get { return cbSlave; }
		}
		
		public PluginMainForm(IMainFrame mf)
		{
			this.mf = mf;
			this.mMaster = mf.Network.ModbusMaster;
			
			InitializeComponent();
			
			if(mf.Network != null) {
				DiscoverNetwork();
			}
			
//			tp = new TabPage("test");
			diagControl = new DiagnosticControl(mf, modbusSlaveSelected);
			diagControl.Dock = DockStyle.Fill;
//			diagControl.Margin = new Padding(0);
//			diagControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
			tabControl1.TabPages[0].Controls.Clear();
			tabControl1.TabPages[0].Controls.Add(diagControl);

			//kontrolka testu obciazenia
			TabPage tp = new TabPage("Load test");
			tp.Controls.Add(new LoadTestControl(mf, this));
			tabControl1.TabPages.Add(tp);
			
			//nowa dodatkowa zakladka z konfiguracja lozko<->slave w DB
			tp = new TabPage("Engine<->Control");
			tp.Controls.Add(new Bed2Slave.Bed2SlaveControl(mf));
			tabControl1.TabPages.Add(tp);
			
			tp = new TabPage("XML config");
			xmlc = new XMLConfig.XMLConfig(mf, modbusSlaveSelected.DeviceId);
//			bc.Margin = new Padding(0);
//			bc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
			tp.Controls.Add(xmlc);
			tabControl1.TabPages.Add(tp);
		}
		
		private void DiscoverNetwork(){
			NetworkScanForm nsf = new NetworkScanForm(this, mf);
			nsf.StartPosition = FormStartPosition.CenterScreen;
			nsf.ShowDialog();
		}
		
		void BRescanClick(object sender, EventArgs e)
		{
			cbSlave.Items.Clear();
			DiscoverNetwork();
		}
		
		void OnSelectedSlaveChanged(object sender, EventArgs e)
		{
			modbusSlaveSelected = (Solarium.Controller.ModbusSlave)cbSlave.SelectedItem;

			if(xmlc!=null) {
				xmlc.DeviceId = modbusSlaveSelected.DeviceId;
			}
			if(diagControl != null) {
				diagControl.Ms = modbusSlaveSelected;
			}
		}
		
		void BHardResetClick(object sender, EventArgs e)
		{
			try{
				modbusSlaveSelected = (Solarium.Controller.ModbusSlave)cbSlave.SelectedItem;
				mMaster.WriteSingleRegister((byte)modbusSlaveSelected.DeviceId, 0x0017, 0xf55f);
				diagControl.Ms = modbusSlaveSelected;
			}catch(Exception ex){
				DialogUtils.ShowError(mf, ex);
			}
		}

		/// <summary>
		/// Pobierz status przyciskow
		/// w[0] - status startu
		/// w[1] - status stopu
		/// </summary>
		/// <returns></returns>
		private bool[] StartStopButtonScanTimer(){
			if(buttonScanTimer == null)
			{
				buttonScanTimer = new System.Windows.Forms.Timer();
				buttonScanTimer.Interval = 333; //333ms
				buttonScanTimer.Tick += new EventHandler(GetButtonInfo);
				buttonScanTimer.Start();
			}
			else if(buttonScanTimer.Enabled)
			{
				buttonScanTimer.Stop();
				tbButton1.Text = "";
				tbButton1.BackColor = Color.White;
				tbButton2.Text = "";
				tbButton2.BackColor = Color.White;
			}
			else if(!buttonScanTimer.Enabled)
			{
				buttonScanTimer.Start();
			}
			return new bool[]{false,false};
		}

		void GetButtonInfo(object sender, EventArgs a) 
		{
			try{
				bool[] tmp = new bool[2];
				tmp[0] = modbusSlaveSelected.IsStartButtonPressed();
				tmp[1] = modbusSlaveSelected.IsStopButtonPressed();

				if(tmp[0]){
					tbButton1.Text = "ON";
					tbButton1.BackColor = Color.Green;
				} else {
					tbButton1.Text = "OFF";
					tbButton1.BackColor = Color.Red;
				}
				
				if(tmp[1]){
					tbButton2.Text = "ON";
					tbButton2.BackColor = Color.Green;
				} else {
					tbButton2.Text = "OFF";
					tbButton2.BackColor = Color.Red;
				}
			} catch (Exception ex) {
				DialogUtils.ShowError(mf, "ModbusSlaveStartButtonStatus\r\nWystąpił problem w komunikacji ze sterownikiem łóżka!", ex);
			}
		}
		
		void BButtonsGetClick(object sender, EventArgs e)
		{
			StartStopButtonScanTimer();
		}

		
		void PluginMainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			Dispose(true);
		}
		
		void BGetStatusClick(object sender, EventArgs e)
		{
			diagControl.Ms = modbusSlaveSelected;
		}
	}
}
