/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-11-27
 * Time: 19:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Windows.Forms;

using Solarium;
using Solarium.Frame;
using Solarium.Plugin;
using Solarium.Settings;
using Solarium.Utils;

namespace ModbusPlugin
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class ModbusPlugin : BasePlugin
	{
		private string pluginName = "Modbus plugin";
		private string pluginDesc = "Wtyczka testowania i konfiguracji podsystemu urządzeń master/slave Modbus";
		private string pluginAuth = "Pablo (ketonal80@gmail.com)";
		private string pluginVer = "0.1";
		
		public override String Name {
			get {
				return pluginName;
			}
		}
		
		public override string Description {
			get {
				return pluginDesc;
			}
		}
		
		public override string Author {
			get {
				return pluginAuth;
			}
		}
		
		public override string Version {
			get {
				return pluginVer;
			}
		}
	
		public override void Initialize(IMainFrame mf)
		{
			base.Initialize(mf);

			pluginConfigElement.Type = this.GetType().Name;
			pluginConfigElement.Menu = "Debug";
			pluginConfigElement.Submenu = "";
			pluginConfigElement.MenuEntry = "Modbus tool";
			pluginConfigElement.ToolbarImage = "./images/toolbar/modbus.png";
		}
		
		public override void Activate()
		{
			PluginMainForm mainForm = new PluginMainForm(mf);
			mainForm.StartPosition = FormStartPosition.CenterScreen;
			mainForm.Show();
		}
		
		public override void Unactivate()
		{
			
		}
		
		public override void Dispose()
		{
			
		}
	}
}
