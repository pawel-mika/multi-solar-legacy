/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-12-01
 * Time: 23:27
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
using Solarium.Frame;
using Solarium.Plugin;
using Solarium.Settings;
using Solarium.Utils;

namespace RescanNetworkPlugin
{
	/// <summary>
	/// Description of RescanNetworkPlugin.
	/// </summary>
	public class RescanNetworkPlugin : BasePlugin
	{
		private string pluginName = "RescanNetworkPlugin";
		private string pluginDesc = "Description of RescanNetworkPlugin";
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
			pluginConfigElement.MenuEntry = "RescanNetworkPlugin";
			pluginConfigElement.ToolbarImage = "./images/toolbar/rescan.png";
		}

		public override void Activate()
		{
			try {
				mf.Network.RescanNetwork();
			} catch (Exception ex) {
				DialogUtils.ShowError(mf, "Error while scanning...",
				                      new Exception(string.Format("Class: {0}\nMethod: {1}",
                                      this.GetType().FullName,
                                      System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                      ex));
			}
		}

		public override void Unactivate()
		{
			//throw new NotImplementedException();
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}		
	}
	
}
