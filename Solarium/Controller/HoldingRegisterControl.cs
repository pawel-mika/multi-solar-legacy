/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-11-12
 * Time: 20:27
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
	/// Description of ModbusPropertyControl.
	/// </summary>
	public partial class HoldingRegisterControl : UserControl
	{
		private ValueType rv = ValueType.INT;
		
		public enum ValueType {
			TIME,
			HEX,
			INT
		}
		
		private ModbusSlave ms = null;
		public ModbusSlave Ms {
			get { return ms; }
			set { ms = value; 
				RefreshRegisterValue();
			}
		}
		private ushort regAddress = 0;
		
		private ushort registerValue = 0;
		public ushort RegisterValue {
			get { return registerValue; }
			set { registerValue = value; }
		}
		
		private bool isChanged = false;
		public bool IsChanged {
			get { return isChanged; }
		}
		
		private ushort cycleTime = 1;
		
		/// <summary>
		/// Kontrolka rejestru slave'a
		/// </summary>
		/// <param name="ms">zainicjalizowany slave</param>
		/// <param name="label">etykietka</param>
		/// <param name="regAddress">adres rejestru</param>
		/// <param name="timeControl">czy to kontrolka czasu?</param>
		/// <param name="readOnly"></param>
		public HoldingRegisterControl(ModbusSlave ms, String label, ushort regAddress, ValueType rv, bool readOnly)
		{
			this.ms = ms;
			this.regAddress = regAddress;
			this.rv = rv;
			InitializeComponent();
			label1.Text = label;
			//jesli to jest kotrolka dla czasu to bedziemy mnozyc
			//wartosc * 12
			cycleTime = rv == ValueType.TIME ? (ushort)12 : (ushort)1;
			
			if(readOnly) {
//				label1.Width += buttonWrite.Width;
//				buttonWrite.Width = 0;
				buttonWrite.Visible = false;
			} else {
				buttonWrite.Click += delegate {
					try{
						ms.ModbusNetwork.ModbusMaster.WriteSingleRegister((byte)ms.DeviceId, regAddress, (ushort)(registerValue / cycleTime));
					}catch(IOException) {
						ms.ModbusNetwork.InitializeModbusMaster();
					}catch(Exception ex){
						DialogUtils.ShowError(ms.ModbusNetwork.Mf, 
						                      "Wystąpił błąd przy zapisie danych!", 
						                      ex);
					}
					RefreshRegisterValue();
				};
			}
			
			RefreshRegisterValue();
			
			ToolTip tt = new ToolTip();
			tt.SetToolTip(this, String.Format("Register address: 0x{0:x4}",regAddress));
			foreach(Control c in this.Controls) {
				tt.SetToolTip(c, String.Format("Register address: 0x{0:x4}",regAddress));
			}
		}
		
		/// <summary>
		/// Odświeża wartość wykonując operację przypisaną do zdarzenia 
		/// RefreshValue
		/// </summary>
		public void RefreshRegisterValue() {
			try{
				if(ms != null) {
					registerValue = (ushort)(ms.ModbusNetwork.ModbusMaster.ReadHoldingRegisters((byte)ms.DeviceId, regAddress, 1)[0] * cycleTime);
					if(rv == ValueType.INT || rv == ValueType.TIME) {
						tbValue.Text = registerValue.ToString();
					} else if(rv == ValueType.HEX) {
						tbValue.Text = String.Format("0x{0:x4}", registerValue);
					}
				}
			}catch(IOException) {
				ms.ModbusNetwork.InitializeModbusMaster();
			}catch(Exception ex){
				DialogUtils.ShowError(ms.ModbusNetwork.Mf, 
				                      "Wystąpił błąd przy odświeżaniu danych!", 
				                      ex);
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TbValueTextChanged(object sender, EventArgs e)
		{
			tbValue.BackColor = Color.White;
			try{
				if(tbValue.Text != null && tbValue.Text.Length>0){
					object o = null;
					if(rv == ValueType.INT || rv == ValueType.TIME) {
						o = Convert.ChangeType(tbValue.Text, typeof(ushort));
					} else if(rv == ValueType.HEX) {
						o = Convert.ToUInt16(tbValue.Text, 16);
						o = Convert.ChangeType(o, typeof(ushort));
					}
					if(!o.ToString().Equals(registerValue)){
						registerValue = (ushort)o;
						isChanged = true;
					}
				}
			}catch(Exception){
				tbValue.BackColor = Color.Red;
			}
		}
	}
}
