/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-07-22
 * Time: 22:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

using Solarium.Bios;
using Solarium.Frame;
using Solarium.Controls;
using Solarium.Controller;
using Solarium.Settings;
using Solarium.Utils;

namespace ModbusPlugin.XMLConfig
{
	/// <summary>
	/// Description of ButtonConfig.
	/// </summary>
	public partial class XMLConfig : UserControl
	{
		private IMainFrame mf = null;

		private ModbusNetworkSettings mns = ModbusNetworkSettings.GetSection(ConfigurationUserLevel.None);
		private ModbusSlaveElement modbusSlaveConfig = null;

		private int deviceId = 0;
		public int DeviceId {
			get { return deviceId; }
			set { 
				deviceId = value; 
				UpdateView();
			}
		}
		
		public XMLConfig(IMainFrame mf, int deviceId)
		{
			this.mf = mf;
			this.deviceId = deviceId;
			InitializeComponent();
			
//			this.deviceId = 2; 	//testowy fake...
			
			InitializeValues();
			
			UpdateView();
		}
		
		private void InitializeValues() {
			cbCoolingRelay.Items.Add("0");
			cbCoolingRelay.Items.Add("1");
			
			cbHeatingRelay.Items.Add("0");
			cbHeatingRelay.Items.Add("1");
			
			cbStartButtonAddress.Items.Add("0x0000");
			cbStartButtonAddress.Items.Add("0x0001");
			cbStartButtonAddress.Items.Add("0x1000");
			cbStartButtonAddress.Items.Add("0x1001");

			cbStopButtonAddress.Items.Add("0x0000");
			cbStopButtonAddress.Items.Add("0x0001");
			cbStopButtonAddress.Items.Add("0x1000");
			cbStopButtonAddress.Items.Add("0x1001");
		}
		
		private void UpdateView(){
			bool slaveInConfig = false;
		
			ModbusSlaveCollection msc = mns.Slaves;
			foreach(ModbusSlaveElement mse in msc){
				if(mse.Id == deviceId){
					slaveInConfig = true;
					modbusSlaveConfig = mse;
					break;
				}
			}
			if(slaveInConfig && modbusSlaveConfig != null) {
				cbCoolingRelay.SelectedItem = string.Format("{0}",modbusSlaveConfig.CoolingRelay);
				cbHeatingRelay.SelectedItem = string.Format("{0}",modbusSlaveConfig.HeatingRelay);
				
				cbStartButtonAddress.SelectedItem = string.Format("0x{0:X4}",modbusSlaveConfig.StartButton);
				cbStopButtonAddress.SelectedItem = string.Format("0x{0:X4}",modbusSlaveConfig.StopButton);
				
				tbKeyFilterTime.Text = modbusSlaveConfig.KeyFilterTime.ToString();
				tbKeyHoldTime.Text = modbusSlaveConfig.KeyHoldTime.ToString();
			} else {
				return;
			}
		}
		
		void BReloadClick(object sender, EventArgs e)
		{
			mns = ModbusNetworkSettings.GetSection(ConfigurationUserLevel.None);
			UpdateView();
		}
		
		void BSaveClick(object sender, EventArgs e)
		{
			try{
				modbusSlaveConfig.KeyHoldTime = Convert.ToInt32(tbKeyHoldTime.Text);
				modbusSlaveConfig.KeyFilterTime = Convert.ToInt32(tbKeyFilterTime.Text);
			}catch(FormatException){
				DialogUtils.ShowError(mf, "Błąd", "Błąd formatu danych przy konwersji!");
			}
			mns.Save();
//			ModbusSlaveCollection msc = mns.Slaves;
//			foreach(ModbusSlaveElement mse in msc){
//				if(mse.Id == deviceId){
//					modbusSlaveConfig = mse;
//					break;
//				}
//			}
		}
		
		void CbHeatingRelaySelectedIndexChanged(object sender, EventArgs e)
		{
			modbusSlaveConfig.HeatingRelay = int.Parse(cbHeatingRelay.SelectedItem.ToString());
		}
		
		void CbCoolingRelaySelectedIndexChanged(object sender, EventArgs e)
		{
			modbusSlaveConfig.CoolingRelay = int.Parse(cbCoolingRelay.SelectedItem.ToString());
		}
		
		void CbStartButtonAddressSelectedIndexChanged(object sender, EventArgs e)
		{
			modbusSlaveConfig.StartButton = int.Parse(cbStartButtonAddress.SelectedItem.ToString().Remove(0,2),System.Globalization.NumberStyles.HexNumber);
		}
		
		void CbStopButtonAddressSelectedIndexChanged(object sender, EventArgs e)
		{
			modbusSlaveConfig.StopButton = int.Parse(cbStopButtonAddress.SelectedItem.ToString().Remove(0,2),System.Globalization.NumberStyles.HexNumber);
		}
	}
}
