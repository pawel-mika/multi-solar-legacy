/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-12
 * Time: 10:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;

namespace Solarium.Gui
{
	/// <summary>
	/// Description of IMFStatusStrip.
	/// </summary>
	public interface IMFStatusStrip
	{
		ToolStripStatusLabel StatusMessage{
			get;
			set;
		}
		
		ToolStripStatusLabel RequestMessage{
			get;
			set;
		}
		
		ToolStripStatusLabel ProgressMessage{
			get;
			set;
		}
		
		ToolStripProgressBar ProgressBar{
			get;
			set;
		}
		
		ToolStripStatusLabel FreeMessage{
			get;
			set;
		}
	}
}
