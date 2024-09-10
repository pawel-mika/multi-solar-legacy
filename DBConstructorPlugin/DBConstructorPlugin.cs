/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-07
 * Time: 20:24
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

using DBConstructorPlugin.Gui;

namespace DBConstructorPlugin
{
	/// <summary>
	/// Description of DBConstructorPlugin.
	/// </summary>
	public class DBConstructorPlugin : BasePlugin
	{
		private string pluginName = "DBConstructorPlugin";
		private string pluginDesc = "Description of DBConstructorPlugin";
		private string pluginAuth = "Pablo";
//		private string pluginVer = "0.1";

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

//		public override string Version {
//			get {
//				return pluginVer;
//			}
//		}

		public override void Initialize(IMainFrame mf)
		{
			base.Initialize(mf);

			pluginConfigElement.Type = this.GetType().Name;
			pluginConfigElement.Menu = "Plugins";
			pluginConfigElement.Submenu = "";
			pluginConfigElement.MenuEntry = "DBConstructorPlugin";
			pluginConfigElement.ToolbarImage = "./images/toolbar/DBConstructor.png";
		}

		public override void Activate()
		{
			MainForm form = new MainForm(mf);
			form.Show();
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
