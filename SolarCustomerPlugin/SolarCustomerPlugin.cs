/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-03
 * Time: 14:53
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

using SolarCustomerPlugin.Gui;

namespace SolarCustomerPlugin
{
	/// <summary>
	/// Description of SolarCustomerPlugin.
	/// </summary>
	public class SolarCustomerPlugin : BasePlugin
	{
		private string pluginName = "SolarCustomerPlugin";
		private string pluginDesc = "Description of SolarCustomerPlugin";
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
			pluginConfigElement.MenuEntry = "SolarCustomerPlugin";
			pluginConfigElement.ToolbarImage = "./images/toolbar/Customer.png";
		}

		public override void Activate()
		{
			SCPMainForm dialog = new SCPMainForm(mf);
			dialog.Show();
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
