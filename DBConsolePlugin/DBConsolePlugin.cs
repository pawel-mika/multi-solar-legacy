/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-20
 * Time: 14:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;
using System.Collections.Generic;

using Solarium;
using Solarium.Config;
using Solarium.Frame;
using Solarium.Plugin;
using Solarium.Settings;
using Solarium.Db;
using Solarium.Utils;

namespace DBConsolePlugin
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class DBConsolePlugin : BaseViewPlugin
	{
		private DBConsoleView pluginView = null;
		
		public override System.Windows.Forms.Control View {
			get {
				return pluginView;
			}
		}
		
		public override string Name {
			get {
				return "DBConsole";
			}
		}
		
		public override string Description {
			get {
				return "Debug database console plugin";
			}
		}
		
		public override string Author {
			get {
				return "Pablo";
			}
		}
		
//		public override string Version {
//			get {
//				return "0.0.1a";
//			}
//		}
		
		public override void Initialize(IMainFrame mf)
		{
			base.Initialize(mf);
			
			pluginConfigElement.Type = this.GetType().Name;
			pluginConfigElement.Menu = "Debug";
			pluginConfigElement.Submenu = "";
			pluginConfigElement.MenuEntry = "Database console";
			pluginConfigElement.ToolbarImage = "./images/toolbar/DBConsole.png";
		}
		
		public override void Activate()
		{
			pluginView = new DBConsoleView(mf);
		}
		
		public override void Unactivate()
		{
		}
		
		public override void Dispose()
		{
		}
	}
}
