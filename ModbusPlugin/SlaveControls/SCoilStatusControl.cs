/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-11-14
 * Time: 22:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Solarium.Controller;
using Solarium.Frame;

namespace ModbusPlugin.SlaveControls
{
	/// <summary>
	/// Description of SCoilControl.
	/// Kontrolka grupujaca kontrolki kontroli 'cewek' ;)
	/// </summary>
	public partial class SCoilStatusControl : UserControl
	{
		private IMainFrame mf = null;
		private ModbusSlave ms = null;
		public ModbusSlave Ms {
			get { return ms; }
			set { ms = value;
				foreach(Control c in this.Controls) {
					if(c is CoilControl) {
						((CoilControl)c).Ms = ms;
					}
				}
			}
		}
		
		public SCoilStatusControl(IMainFrame mf, ModbusSlave ms)
		{
			this.mf = mf;
			this.ms = ms;
			
			InitializeComponent();

			int shift = 0;
			
			//hm.. relaye na stale dac czy z konfiga?? narazie na stale...
			CoilControl cc = new CoilControl(ms, "Relay 0", 0, false);
			cc.Location = new Point(0, shift);
			cc.Width = this.Width;
			cc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(cc);
			shift += cc.Height;
			
			cc = new CoilControl(ms, "Relay 1", 1, false);
			cc.Location = new Point(0, shift);
			cc.Width = this.Width;
			cc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(cc);
			shift += cc.Height;
			
			cc = new CoilControl(ms, "Power", ModbusSlave.COIL_ADDR_POWER, false);
			cc.Location = new Point(0, shift);
			cc.Width = this.Width;
			cc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(cc);
			shift += cc.Height;
			
			cc = new CoilControl(ms, "RX Led", ModbusSlave.COIL_ADDR_LED_RX, false);
			cc.Location = new Point(0, shift);
			cc.Width = this.Width;
			cc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(cc);
			shift += cc.Height;

			cc = new CoilControl(ms, "TX Led", ModbusSlave.COIL_ADDR_LED_TX, false);
			cc.Location = new Point(0, shift);
			cc.Width = this.Width;
			cc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(cc);
			shift += cc.Height;
			
			cc = new CoilControl(ms, "ERR Led", ModbusSlave.COIL_ADDR_LED_ERR, false);
			cc.Location = new Point(0, shift);
			cc.Width = this.Width;
			cc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(cc);
			shift += cc.Height;

			cc = new CoilControl(ms, "RX Blink", ModbusSlave.COIL_ADDR_BLINK_RX, false);
			cc.Location = new Point(0, shift);
			cc.Width = this.Width;
			cc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(cc);
			shift += cc.Height;

			cc = new CoilControl(ms, "TX Blink", ModbusSlave.COIL_ADDR_BLINK_TX, false);
			cc.Location = new Point(0, shift);
			cc.Width = this.Width;
			cc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(cc);
			shift += cc.Height;

			cc = new CoilControl(ms, "ERR Blink", ModbusSlave.COIL_ADDR_BLINK_ERR, false);
			cc.Location = new Point(0, shift);
			cc.Width = this.Width;
			cc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(cc);
			shift += cc.Height;

			cc = new CoilControl(ms, "Ext. Led Control", ModbusSlave.COIL_ADDR_EXT_LED, false);
			cc.Location = new Point(0, shift);
			cc.Width = this.Width;
			cc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(cc);
			shift += cc.Height;
			
			this.Height = shift;
		}
	}
}
