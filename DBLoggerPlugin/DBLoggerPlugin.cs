/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-17
 * Time: 23:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

using Solarium;
using Solarium.Config;
using Solarium.Frame;
using Solarium.Plugin;
using Solarium.Settings;
using Solarium.Db;
using Solarium.Utils;

namespace DBLoggerPlugin
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class DBLoggerPlugin : BaseViewPlugin
	{
		private DBLoggerView pluginView = null;
		
		public override System.Windows.Forms.Control View {
			get {
				return pluginView;
			}
		}
		
		public override string Name {
			get {
				return "DBLogger";
			}
		}
		
		public override string Description {
			get {
				return "Debug plugin for logging\nbasic sql requests.";
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
			pluginConfigElement.MenuEntry = "Database logger";
			pluginConfigElement.ToolbarImage = "./images/toolbar/DBLogger.png";
			pluginConfigElement.Autostart = true;
		}
		
		public override void Activate()
		{
			pluginView = new DBLoggerView(mf);
			mf.Database.RequestSent += new DatabaseEventHandler(databaseEvent);
		}
		
		public override void Unactivate()
		{
			base.Unactivate();
			mf.Database.RequestSent -= databaseEvent;
		}
		
//		public override void Dispose()
//		{
//		}
		
		private void databaseEvent(object sender, DatabaseEventArgs dea) {
			pluginView.LogOnConsole(dea.Message+Environment.NewLine);
		}
	}
}
