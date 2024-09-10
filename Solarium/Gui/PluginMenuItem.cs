﻿/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-15
 * Time: 19:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;

using Solarium.Plugin;

namespace Solarium.Gui
{
	/// <summary>
	/// Description of PluginMenuItem.
	/// </summary>
	public class PluginMenuItem : ToolStripMenuItem
	{
		BasePlugin plugin = null;
		
		public BasePlugin Plugin {
			get { return plugin; }
			set { plugin = value; }
		}
		
		public PluginMenuItem(BasePlugin plugin)
		{
			this.plugin = plugin;
		}
	}
}
