/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-11-14
 * Time: 22:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using Solarium.Utils;

namespace Solarium.Controller
{
	/// <summary>
	/// Description of CoilControl.
	/// </summary>
	public partial class CoilControl : UserControl
	{
		private bool readOnly = false;
		
		private ModbusSlave ms = null;
		public ModbusSlave Ms {
			get { return ms; }
			set { ms = value; 
				RefreshColiValue();
			}
		}
		private ushort regAddress = 0;
		
		private bool coilValue = false;
		public bool CoilValue {
			get { return coilValue; }
			set { coilValue = value; }
		}
		
//		private bool isChanged = false;
//		public bool IsChanged {
//			get { return isChanged; }
//		}
		
		/// <summary>
		/// Kontrolka 'cewki' slave'a
		/// </summary>
		/// <param name="ms">zainicjalizowany slave</param>
		/// <param name="label">etykietka</param>
		/// <param name="regAddress">adres rejestru</param>
		/// <param name="readOnly"></param>
		public CoilControl(ModbusSlave ms, String label, ushort regAddress, bool readOnly)
		{
			this.ms = ms;
			this.regAddress = regAddress;
			this.readOnly = readOnly;
			InitializeComponent();
			label1.Text = label;
			
			if(readOnly) {
				buttonWriteFalse.Visible = false;
				buttonWriteTrue.Visible = false;
			} else {
				buttonWriteTrue.Click += delegate {
					try{
						ms.ModbusNetwork.ModbusMaster.WriteSingleCoil((byte)ms.DeviceId, regAddress, true);
					}catch(IOException) {
						ms.ModbusNetwork.InitializeModbusMaster();
					}catch(Exception ex){
						DialogUtils.ShowError(ms.ModbusNetwork.Mf, 
						                      "Wystapil blad przy zapisie danych!", 
						                      ex);
					}
					RefreshColiValue();
				};
				
				buttonWriteFalse.Click += delegate {
					try{
						ms.ModbusNetwork.ModbusMaster.WriteSingleCoil((byte)ms.DeviceId, regAddress, false);
					}catch(IOException) {
						ms.ModbusNetwork.InitializeModbusMaster();
					}catch(Exception ex){
						DialogUtils.ShowError(ms.ModbusNetwork.Mf, 
						                      "Wystapil blad przy zapisie danych!", 
						                      ex);
					}
					RefreshColiValue();
				};
			}
			
			RefreshColiValue();
			
			ToolTip tt = new ToolTip();
			tt.SetToolTip(this, String.Format("Coil address: 0x{0:x4}",regAddress));
			foreach(Control c in this.Controls) {
				tt.SetToolTip(c, String.Format("Coil address: 0x{0:x4}",regAddress));
			}
		}
		
		/// <summary>
		/// Odswieza wartosc wykonujac operacje przypisana do zdarzenia 
		/// RefreshValue
		/// </summary>
		public void RefreshColiValue() {
			try{
				if(ms != null) {
					coilValue = ms.ModbusNetwork.ModbusMaster.ReadCoils((byte)ms.DeviceId, regAddress, 1)[0];
					tbValue.Text = coilValue.ToString();
					tbValue.BackColor = coilValue ? Color.Green : Color.Red;
				}
			}catch(IOException) {
				ms.ModbusNetwork.InitializeModbusMaster();
			}catch(Exception ex){
				DialogUtils.ShowError(ms.ModbusNetwork.Mf, 
				                      "Wystapil blad przy odswiezaniu danych!", 
				                      ex);
			}
		}
	}
}
