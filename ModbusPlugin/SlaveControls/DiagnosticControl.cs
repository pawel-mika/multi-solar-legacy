/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-11-15
 * Time: 16:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

using Solarium;
using Solarium.Frame;
using Solarium.Controller;
using Solarium.Utils;

namespace ModbusPlugin.SlaveControls
{
	/// <summary>
	/// Description of DiagnosticControl.
	/// </summary>
	public partial class DiagnosticControl : UserControl
	{
		private IMainFrame mf = null;
		
		private SCoilStatusControl coilControl = null;
		private SCommStatusControl commControl = null;
		private SConfigControl confControl = null;
		
		private ModbusSlave ms = null;
		public ModbusSlave Ms {
			get { return ms; }
			set { ms = value;
				if(confControl != null) {
					confControl.Ms = ms;
				}
				if(commControl != null) {
					commControl.Ms = ms;
				}
				if(coilControl != null) {
					coilControl.Ms = ms;
				}
				
//				foreach(Control c in confControl.Controls) {
//					if(c is HoldingRegisterControl) {
//						((HoldingRegisterControl)c).RefreshRegisterValue();
//					}
//				}
//				foreach(Control c in commControl.Controls) {
//					if(c is HoldingRegisterControl) {
//						((HoldingRegisterControl)c).RefreshRegisterValue();
//					}
//				}
//				foreach(Control c in coilControl.Controls) {
//					if(c is CoilControl) {
//						((CoilControl)c).RefreshColiValue();
//					}
//				}
			}
		}
		
		public DiagnosticControl(IMainFrame mf, ModbusSlave ms)
		{
			this.mf = mf;
			this.ms = ms;
			
			InitializeComponent();
			
			Cursor.Current = Cursors.WaitCursor;
			
			Thread ct = new Thread(new ThreadStart( createControls ));
			ct.Start();
		}
		
		private void createControls() {
			
			tableLayoutPanel1.SuspendLayout();
			
			confControl = new SConfigControl(mf, ms);
			confControl.Dock = System.Windows.Forms.DockStyle.Fill;
			commControl = new SCommStatusControl(mf, ms);
			commControl.Dock = System.Windows.Forms.DockStyle.Fill;
			coilControl = new SCoilStatusControl(mf, ms);
			coilControl.Dock = System.Windows.Forms.DockStyle.Fill;
			
			FormUtils.ControlCrossThreadAddControl(tableLayoutPanel1, confControl, 0, 0);
			FormUtils.ControlCrossThreadAddControl(tableLayoutPanel1, commControl, 1, 0);
			FormUtils.ControlCrossThreadAddControl(tableLayoutPanel1, coilControl, 2, 0);
//			tableLayoutPanel1.Controls.Add(confControl, 0, 0);
//			tableLayoutPanel1.Controls.Add(commControl, 1, 0);
//			tableLayoutPanel1.Controls.Add(coilControl, 2, 0);
			
			tableLayoutPanel1.ResumeLayout(false);
			Cursor.Current = Cursors.Default;
		}
	}
}
