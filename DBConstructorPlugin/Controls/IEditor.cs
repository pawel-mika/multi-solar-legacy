/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-19
 * Time: 12:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBConstructorPlugin.Controls
{
	/// <summary>
	/// Description of Editor Interface.
	/// </summary>
	public interface IEditor
	{
		/// <summary>
		/// Items that should be displayed in plugins main window
		/// toolstrip when the control is displayed.
		/// </summary>
		LinkedList<ToolStripItem> EditorButtons{
			get;
			set;
		}
	}
}
