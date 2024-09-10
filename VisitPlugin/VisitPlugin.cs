/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-04-09
 * Time: 22:38
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
using Solarium.Frame;
using Solarium.Plugin;
using Solarium.Settings;

namespace VisitPlugin
{
	/// <summary>
	/// Description of VisitPlugin.
	/// </summary>
	public class VisitPlugin : BasePlugin
	{
		private string pluginName = "VisitPlugin";
		private string pluginDesc = "Description of VisitPlugin";
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
			pluginConfigElement.MenuEntry = "VisitPlugin";
			//pluginConfigElement.ToolbarImage = "./images/toolbar/PluginImage.png";
			//pluginConfigElement.MenuSeparator = "before or after";
		}

		public override void Activate()
		{
			throw new NotImplementedException();
		}

		public override void Unactivate()
		{
//			throw new NotImplementedException();
		}

		public override void Dispose()
		{
//			throw new NotImplementedException();
		}		
	}
	
}
