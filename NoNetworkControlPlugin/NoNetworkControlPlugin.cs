/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-09-29
 * Time: 20:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;
using System.Collections.Generic;

///
/// Dodaj referencje do execa / projektu Solarium (np.: kliknij prawym na folderze projektu w
/// drzewku rozwiazania, opcja: dodaj referencje, zakladka projekty - wybierz solarium:)
///
using Solarium;
using Solarium.Plugin;
using Solarium.Settings;
using Solarium.Frame;

namespace NoNetworkControlPlugin
{
	/// <summary>
	/// Description of NoNetworkControlPlugin.
	/// </summary>
	public class NoNetworkControlPlugin : BasePlugin
	{
		private string pluginName = "NoNetworkControlPlugin";
		private string pluginDesc = "Description of NoNetworkControlPlugin";
		private string pluginAuth = "Pablo";
		private string pluginVer = "0.1";

		public override string Name {
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
			pluginConfigElement.Menu = "Plugins";
			pluginConfigElement.Submenu = "";
			pluginConfigElement.MenuEntry = "NoNetworkControlPlugin";
			//pluginConfigElement.ToolbarImage = "./images/toolbar/PluginImage.png";
			//pluginConfigElement.MenuSeparator = "before or after";
		}

		public override void Activate()
		{
			throw new NotImplementedException();
		}

		public override void Unactivate()
		{
			throw new NotImplementedException();
		}

		public override void Dispose()
		{
			throw new NotImplementedException();
		}		
	}
	
}
