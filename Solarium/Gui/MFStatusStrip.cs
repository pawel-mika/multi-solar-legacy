/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-12
 * Time: 10:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Solarium.Gui
{
	/// <summary>
	/// Description of MFStatusStrip.
	/// </summary>
	public class MFStatusStrip : StatusStrip, IMFStatusStrip
	{
		private ToolStripStatusLabel TSLStatusMessage = new ToolStripStatusLabel(".");
		private ToolStripStatusLabel TSLRequestMessage = new ToolStripStatusLabel(".");
		private ToolStripStatusLabel TSLProgressMessage = new ToolStripStatusLabel(".");
		private ToolStripStatusLabel TSLFreeMessage = new ToolStripStatusLabel(".");
		private ToolStripProgressBar TSLProgressBar = new ToolStripProgressBar();
		
		
		public MFStatusStrip() : base()
		{
			TSLStatusMessage.BorderSides = ToolStripStatusLabelBorderSides.All;
			TSLStatusMessage.BorderStyle = Border3DStyle.Flat;
			TSLRequestMessage.BorderSides = ToolStripStatusLabelBorderSides.All;
			TSLRequestMessage.BorderStyle = Border3DStyle.Flat;
			TSLProgressMessage.BorderSides = ToolStripStatusLabelBorderSides.All;
			TSLProgressMessage.BorderStyle = Border3DStyle.Flat;
			TSLFreeMessage.BorderSides = ToolStripStatusLabelBorderSides.All;
			TSLFreeMessage.BorderStyle = Border3DStyle.Flat;
			TSLFreeMessage.TextAlign = ContentAlignment.MiddleLeft;
			TSLFreeMessage.Spring = true;
			TSLProgressBar.Width = 100;
			TSLProgressBar.Maximum = 100;
			this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			               this.TSLStatusMessage,
			               this.TSLRequestMessage,
			               this.TSLProgressBar,
			               this.TSLProgressMessage,
			               this.TSLFreeMessage});
		}
		
		public ToolStripStatusLabel StatusMessage {
			get {
				return TSLStatusMessage;
			}
			set {
				TSLStatusMessage = value;
				base.Update();
			}
		}
		
		public ToolStripStatusLabel RequestMessage {
			get {
				return TSLRequestMessage;
			}
			set {
				TSLRequestMessage = value;
				base.Update();
			}
		}
		
		public ToolStripStatusLabel ProgressMessage {
			get {
				return TSLProgressMessage;
			}
			set {
				TSLProgressMessage = value;
				base.Update();
			}
		}
		
		public ToolStripProgressBar ProgressBar {
			get {
				return TSLProgressBar;
			}
			set {
				TSLProgressBar = value;
			}
		}
		
		public ToolStripStatusLabel FreeMessage {
			get {
				return TSLFreeMessage;
			}
			set {
				TSLFreeMessage = value;
				base.Update();
			}
		}
	}
}
