/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-11-12
 * Time: 21:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Solarium;
using Solarium.Frame;
using Solarium.Controller;

namespace ModbusPlugin.SlaveControls
{
	/// <summary>
	/// Description of PropertiesControl.
	/// Kontrolka zawierajaca zestaw kontrolek do ustawień slave'a.
	/// </summary>
	public partial class SConfigControl : UserControl
	{
		private IMainFrame mf = null;
		private ModbusSlave ms = null;
		public ModbusSlave Ms {
			get { return ms; }
			set { ms = value;
				foreach(Control c in this.Controls) {
					if(c is HoldingRegisterControl) {
						((HoldingRegisterControl)c).Ms = ms;
					}
				}
			}
		}
		
		public SConfigControl(IMainFrame mf, ModbusSlave ms)
		{
			this.mf = mf;
			this.ms = ms;
			
			InitializeComponent();

			int shift = 0;
			
			HoldingRegisterControl pc = new HoldingRegisterControl(ms, 
			                                                       "Master t-out [ms]:",
			                                                       ModbusSlave.ADDR_MST_TIME_OUT, 
			                                                       HoldingRegisterControl.ValueType.TIME,
			                                                       false);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;
			
			pc = new HoldingRegisterControl(ms, "RX/TX blink [ms]:", 
			                                ModbusSlave.ADDR_LED_BLINK_TIME, 
			                                HoldingRegisterControl.ValueType.TIME,false);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;
			
			pc = new HoldingRegisterControl(ms, "RX/TX flash [ms]:", 
			                                ModbusSlave.ADDR_LED_FLASH_TIME, 
			                                HoldingRegisterControl.ValueType.TIME,false);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;

			pc = new HoldingRegisterControl(ms, "ERR led t-out [ms]:", 
			                                ModbusSlave.ADDR_ERR_TIME_OUT, 
			                                HoldingRegisterControl.ValueType.TIME,false);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;
			
			pc = new HoldingRegisterControl(ms, "Key filt. t-out [ms]:", 
			                                ModbusSlave.ADDR_FILTER_TIME, 
			                                HoldingRegisterControl.ValueType.TIME,false);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;
			
			pc = new HoldingRegisterControl(ms, "Key press t-out[ms]:", 
			                                ModbusSlave.ADDR_KEY_TIMER, 
			                                HoldingRegisterControl.ValueType.TIME,false);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;
			
			pc = new HoldingRegisterControl(ms, "Security code[hex]:", 
			                                ModbusSlave.ADDR_SECURITY_CODE, 
			                                HoldingRegisterControl.ValueType.HEX,false);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;
			
			pc = new HoldingRegisterControl(ms, "Slave ID [hex]:", 
			                                ModbusSlave.ADDR_SLAVE_ID, 
			                                HoldingRegisterControl.ValueType.HEX,false);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;

			pc = new HoldingRegisterControl(ms, "Key 1 conf [hex]:", 
			                                ModbusSlave.ADDR_FREE_WORD1, 
			                                HoldingRegisterControl.ValueType.HEX,false);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;
			
			pc = new HoldingRegisterControl(ms, "Key 2 conf [hex]:", 
			                                ModbusSlave.ADDR_FREE_WORD2, 
			                                HoldingRegisterControl.ValueType.HEX,false);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;
			
			this.Height = shift;
		}
	}
}
