/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-14
 * Time: 08:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Solarium.Plugin
{
	public delegate void PluginEventHandler ( object sender, PluginEventArgs e );
	
	public class PluginEventArgs : EventArgs
	{
		private BasePlugin plugin = null;
		public BasePlugin Plugin {
			get { return plugin; }
			set { plugin = value; }
		}
		
		public PluginEventArgs(BasePlugin plugin)
		{
			this.plugin = plugin;
		}
	}
}
