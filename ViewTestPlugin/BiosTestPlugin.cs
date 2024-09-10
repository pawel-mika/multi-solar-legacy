/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-15
 * Time: 17:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Solarium;
using Solarium.Frame;
using Solarium.Plugin;
using Solarium.Settings;

namespace ViewTestPlugin
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class BiosTestPlugin : BaseViewPlugin
	{
		private Control pluginView = null;
		
		public override System.Windows.Forms.Control View {
			get { return pluginView; }
		}
		
		public override string Name {
			get { return "BiosTestPlugin"; }
		}
		
		public override string Description {
			get { return "Plugin testujący biosa, operacje tworzenia/modyfikowania/usuwania obiektow/elementów."; }
		}
		
		public override string Author {
			get { return "Pablo"; }
		}
		
		public override string Version {
			get { return "0.1a"; }
		}
		
		public override void Initialize(Solarium.Frame.IMainFrame mf)
		{
			base.Initialize(mf);
			
			pluginConfigElement.Type = this.GetType().Name;
			pluginConfigElement.Menu = "Debug";
			pluginConfigElement.Submenu = "";
			pluginConfigElement.MenuEntry = "Bios test plugin";
			pluginConfigElement.ToolbarImage = "./images/toolbar/Bios.png";
		}
		
		public override void Activate()
		{
			pluginView = new ViewTestPluginView(mf);
		}
		
		public override void Unactivate()
		{
			throw new NotImplementedException();
		}
		
		public override void Dispose()
		{
			pluginView = null;
		}
	}
}
