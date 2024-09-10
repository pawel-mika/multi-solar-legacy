/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-11-15
 * Time: 15:50
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
	/// Description of SCommStatusControl.
	/// </summary>
	public partial class SCommStatusControl : UserControl
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
		
		public SCommStatusControl(IMainFrame mf, ModbusSlave ms)
		{
			this.mf = mf;
			this.ms = ms;
			
			InitializeComponent();

			int shift = 0;
			
			HoldingRegisterControl pc = new HoldingRegisterControl(ms, "Good CRC", 
			                                                        ModbusSlave.ADDR_BUS_MSG_CNT, 
			                                                        HoldingRegisterControl.ValueType.INT, 
			                                                        true);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;
			
			pc = new HoldingRegisterControl(ms, "Bad CRC", 
                                            ModbusSlave.ADDR_BUS_COM_ERR,
                                            HoldingRegisterControl.ValueType.INT, 
                                            true);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;

			pc = new HoldingRegisterControl(ms, "Exceptions", 
                                            ModbusSlave.ADDR_EXC_ERR_CNT,
                                            HoldingRegisterControl.ValueType.INT, 
                                            true);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;
			
			pc = new HoldingRegisterControl(ms, "Message count", 
                                            ModbusSlave.ADDR_SLV_MSG_CNT,
                                            HoldingRegisterControl.ValueType.INT, 
                                            true);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;
			
			pc = new HoldingRegisterControl(ms, "No response count", 
                                            ModbusSlave.ADDR_NO_RESP_CNT,
                                            HoldingRegisterControl.ValueType.INT, 
                                            true);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;
			
			pc = new HoldingRegisterControl(ms, "Broadcast", 
                                            ModbusSlave.ADDR_NEG_ACK_CNT,
                                            HoldingRegisterControl.ValueType.INT, 
                                            true);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;
			
			pc = new HoldingRegisterControl(ms, "Busy exceptions", 
                                            ModbusSlave.ADDR_SLV_BUSY_CNT,
                                            HoldingRegisterControl.ValueType.INT, 
                                            true);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;
			
			pc = new HoldingRegisterControl(ms, "Overrun", 
                                            ModbusSlave.ADDR_BUS_CH_OVR_CNT,
                                            HoldingRegisterControl.ValueType.INT, 
                                            true);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;
			
			pc = new HoldingRegisterControl(ms, "Frame too long", 
                                            ModbusSlave.ADDR_FRAME_ERR_OVR,
                                            HoldingRegisterControl.ValueType.INT, 
                                            true);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;
			
			pc = new HoldingRegisterControl(ms, "Char space > 1.5", 
                                            ModbusSlave.ADDR_FRAME_ERR_T15,
                                            HoldingRegisterControl.ValueType.INT, 
                                            true);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;
			
			pc = new HoldingRegisterControl(ms, "Char space > 3.5", 
                                            ModbusSlave.ADDR_FRAME_ERR_T35,
                                            HoldingRegisterControl.ValueType.INT, 
                                            true);
			pc.Location = new Point(0, shift);
			pc.Width = this.Width;
			pc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(pc);
			shift += pc.Height;

			this.Height = shift;
		}
	}
}
