/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-14
 * Time: 12:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

using Solarium;
using Solarium.Frame;
using Solarium.Settings;

namespace Solarium.Plugin
{
	/// <summary>
	/// This is the base plugin class.
	/// This type of plugin does not contain a view
	/// inside main frame, but there's no contraindication
	/// to open own form(s).
	/// </summary>
	[CatchPluginContext]
	public abstract class BasePlugin : ContextBoundObject
	{
		protected IMainFrame mf = null;
		protected PluginConfigElement pluginConfigElement = new PluginConfigElement();
	
		public abstract string Name {get;}
		public abstract string Description {get;}
		public abstract string Author {get;}
		public virtual string Version {
			get {
				System.Version buildVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
				DateTime buildDate = new DateTime(2000,1,1).AddDays(buildVersion.Build).AddSeconds(buildVersion.Revision * 2);
				return string.Format("{0} ({1})", buildVersion, buildDate);
			}
		}
		
		/// <summary>
		/// Called when plugin is being loaded
		/// </summary>
		/// <param name="mf"></param>
		//[CatchMethodAttribute] - w sumie te s¹ niepotrzebne raczej gdy¿ [catchplugincontext] za³atwia ca³a wtykie:))
		public virtual void Initialize(IMainFrame mf) {
			this.mf = mf;
		}
		
		/// <summary>
		/// Called when user select (activates) plugin from menu od toolstrip or so...
		/// </summary>
		//[CatchMethodAttribute]
		public virtual void Activate(){
		}
		
		/// <summary>
		/// Called when plugin is unactivated (eg. user closed plugin tab)
		/// </summary>
		//[CatchMethodAttribute]
		public virtual void Unactivate() {
			mf.PluginHost.UnactivatePlugin(this);
		}
		
		/// <summary>
		/// Called whed application is closing, so inform the plugin to get lost;)
		/// </summary>
		//[CatchMethodAttribute]
		public virtual void Dispose(){
		}
		
		/// <summary>
		/// Plugin's configuration element property
		/// </summary>
		//[CatchMethodAttribute]
		public virtual PluginConfigElement PluginConfigElement {
			get{
				return this.pluginConfigElement;
			}
			set{
				this.pluginConfigElement = value;
			}
		}
	}
}
