/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-14
 * Time: 20:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Runtime;

using Solarium.Settings;
using Solarium.Frame;

namespace Solarium.Plugin
{
	/// <summary>
	/// Class hosting all of our available plugins.
	/// </summary>
	public class PluginHost
	{
		private IMainFrame mf = null;
		private string pluginLocation = null;
		private PluginConfigSettings pluginConfigSection;
		private bool configModified = false;
		
		private LinkedList<BasePlugin> plugins = new LinkedList<BasePlugin>();
		public LinkedList<BasePlugin> Plugins{
			get {return this.plugins; }
		}
		private LinkedList<BasePlugin> activePlugins = new LinkedList<BasePlugin>();
		public LinkedList<BasePlugin> ActivePlugins {
			get { return activePlugins; }
		}

		/// <summary>
		/// Plugin host.
		/// Scans a dir {application.exe}/plugins/ for .dll(s) and try to load them as a plugin.
		/// It also holds and hosts the plugins for/to others classes.
		/// </summary>
		/// <param name="mf"></param>
		public PluginHost(IMainFrame mf)
		{
			#if (DEBUG)
			log4net.LogManager.GetLogger("PluginHost").Info("Loading plugins...");
			#endif
			
			this.mf = mf;

			//set plugins location
			Assembly asm = Assembly.GetExecutingAssembly ();
			pluginLocation = AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + "plugins";
			
			//get pluginConfigSection from config
			pluginConfigSection = PluginConfigSettings.GetSection(ConfigurationUserLevel.None);
			
			findAndLoadPlugins(pluginLocation);
			
			//if plugins were added...
			if(configModified) {
				pluginConfigSection.Save();
			}
			
			//sort plugin in list according to entries in config file
			ArrangePlugins();
		}
		
		/// <summary>
		/// Find plugins (.dll files) in specified path and try to load them
		/// </summary>
		/// <param name="Path"></param>
		public void findAndLoadPlugins(string Path)
		{
			//First empty the collection, we're reloading them all
			plugins.Clear();
			
			//szukamy pluginów (dll'ek!) i na podstawie znalezionej
			//ich ilości modyfikujemy loader progress bara
			foreach (string fileOn in Directory.GetFiles(Path))
			{
				FileInfo file = new FileInfo(fileOn);
		
				//Preliminary check, must be .dll
				if (file.Extension.Equals(".dll"))
				{
					mf.MainFrameUI.SplashForm.TotalItems += 1;
				}
			}
			
			//teraz ładujemy te wtyki...
			//Go through all the files in the plugin directory
			foreach (string fileOn in Directory.GetFiles(Path))
			{
				FileInfo file = new FileInfo(fileOn);
		
				//Preliminary check, must be .dll
				if (file.Extension.Equals(".dll"))
				{
					//Add the 'plugin'
					this.AddPlugin(file);
				}
			}
		}

		/// <summary>
		/// Try lo load/add plugin to plugin host
		/// </summary>
		/// <param name="file">Path to plugins file (dll)</param>
		private void AddPlugin(FileInfo file){
			try{
				//Create a new assembly from the plugin file we're adding..
				Assembly pluginAssembly = Assembly.LoadFrom(file.FullName);
				
				mf.MainFrameUI.SplashForm.Status = "Loading plugins... " + file.Name;
				
				//Next we'll loop through all the Types found in the assembly
				foreach (Type pluginType in pluginAssembly.GetTypes())
				{
					if (pluginType.IsPublic) //Only look at public types
					{
						if (!pluginType.IsAbstract)  //Only look at non-abstract types
						{
							if(pluginType.IsSubclassOf(typeof(Solarium.Plugin.BasePlugin)) ||
								pluginType.IsSubclassOf(typeof(Solarium.Plugin.BaseViewPlugin)))
							{
								BasePlugin Instance = (BasePlugin)Activator.CreateInstance(pluginAssembly.GetType(pluginType.ToString()));
								Instance.Initialize(mf);
								configure(Instance);
								plugins.AddLast(Instance);
							}
						} 
					}
				}
				pluginAssembly = null; //more cleanup
				mf.MainFrameUI.SplashForm.DoneItems += 1;
			} catch(BadImageFormatException ex) {
				Utils.DialogUtils.ShowError(mf, "Plugin error (not a plugin?)",
				                            new Exception(string.Format("Class: {0}\nMethod: {1}",
                                                  this.GetType().FullName,
                                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                                  ex));
			} catch(Exception ex) {
				Utils.DialogUtils.ShowError(mf, "General plugin error",
				                            new Exception(string.Format("Class: {0}\nMethod: {1}",
                                                  this.GetType().FullName,
                                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                                  ex));
			}
		}

		/// <summary>
		/// Dispose all loaded (unactivated too!) plugins in plugin host
		/// </summary>
		public void DisposeAll(){
			try {
				foreach(BasePlugin p in plugins) {
					p.Dispose();
				}
			} catch (Exception ex) {
				Utils.DialogUtils.ShowError(mf, "Error while disposing plugin",
												new Exception(string.Format("Class: {0}\nMethod: {1}",
													this.GetType().FullName,
													System.Reflection.MethodBase.GetCurrentMethod().ToString()),
													ex));
			}
		}

		/// <summary>
		/// Configure plugin from a config file if specified plugin entry exists
		/// </summary>
		/// <param name="plugin"></param>
		private void configure(BasePlugin plugin){
			bool pluginInFile = false;
		 	foreach(PluginConfigElement settingsPluginConfigElement in pluginConfigSection.Plugins){
				if(settingsPluginConfigElement.Type.CompareTo(plugin.PluginConfigElement.Type)==0){
					plugin.PluginConfigElement = settingsPluginConfigElement;
					pluginInFile = true;
				}
			}
			if (!pluginInFile) {
				pluginConfigSection.Plugins.Add(plugin.PluginConfigElement);
				configModified = true;
			}
		}

		/// <summary>
		/// Re-arrange plugins according to config file entry-order
		/// </summary>
		private void ArrangePlugins(){
			LinkedList<BasePlugin> orderedPlugins = new LinkedList<BasePlugin>();
			foreach(PluginConfigElement pce in pluginConfigSection.Plugins){
				foreach(BasePlugin p in plugins){
					if(pce.Type.Equals(p.PluginConfigElement.Type)){
						orderedPlugins.AddLast(p);
					}
				}
			}
			plugins = orderedPlugins;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="plugin"></param>
		public void ActivatePlugin(BasePlugin plugin){
			try{
				if(!activePlugins.Contains(plugin)){
					plugin.Activate();
					activePlugins.AddLast(plugin);
					FirePluginActivated(new PluginEventArgs(plugin));
				} else {
					if(plugin is BasePlugin && !(plugin is BaseViewPlugin)){
						plugin.Activate();
						FirePluginActivated(new PluginEventArgs(plugin));
					}else if(plugin is BaseViewPlugin){
						FirePluginFocused(new PluginEventArgs(plugin));
					}
				}
			}catch(Exception ex){
				Utils.DialogUtils.ShowError(mf, "Error activating plugin",
				                            new Exception(string.Format("Class: {0}\nMethod: {1}",
                                                  this.GetType().FullName,
                                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                                  ex));
			}
		}
		
		public void FocusPlugin(BasePlugin plugin){
			FirePluginFocused(new PluginEventArgs(plugin));
		}
		
		public void UnactivatePlugin(BasePlugin plugin){
			try{
				if(activePlugins.Contains(plugin)){
					plugin.Unactivate();
					//czy tan unactivate jest rzeczywiscie tutaj potrzebny?
					//(mozliwe stack overflow - moze wpaść w nieskonczoną petle)
					activePlugins.Remove(plugin);
				}
				
				
				//jesli mamy widok usinac - czy to w dispose bardziej? hgw:/
				
			}catch(Exception ex){
				Utils.DialogUtils.ShowError(mf, "Error unactivating plugin",
				                            new Exception(string.Format("Class: {0}\nMethod: {1}",
                                                  this.GetType().FullName,
                                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                                  ex));
			}
			FirePluginUnactivated(new PluginEventArgs(plugin));
		}
		/// <summary>
		/// Reload the plugin.
		/// Allow only when plugin is not in use?
		/// uwazac z tym wogole... ostroznie tutaj działac...
		/// </summary>
		public void ReloadPlugin(BasePlugin plugin){
			throw new NotImplementedException();
		}
		
		/// <summary>
		/// Unload plugin prom plugin host
		/// TODO:
		/// sprawdzić jakos czy nie jest w uzyciu i dopiero wyładować (zeby to zrobic 
		/// trzebaby zaimplementować jakies stany albo inną metode hm... moze dodać tutaj
		/// liste aktywowanych pluginów, tylko jak dbać o jej zawartość przy wychodzeniu
		/// z wtyczek które nie mają wydoku [nie są typu IViewPlugin]??)
		/// zwracać true/false w zaleznosci czy sie udało (czy nie jest w uzyciu)
		/// </summary>
		/// <param name="plugin"></param>
		/// <returns></returns>
		public bool Unload(BasePlugin plugin){
			throw new NotImplementedException();
		}
		
		#region Events
		
		public event PluginEventHandler PluginActivated;
		protected virtual void FirePluginActivated(PluginEventArgs e){
			if(PluginActivated!=null){
				PluginActivated(this, e);
			}
		}
		
		public event PluginEventHandler PluginUnactivated;
		protected virtual void FirePluginUnactivated(PluginEventArgs e){
			if(PluginUnactivated!=null){
				PluginUnactivated(this, e);
			}
		}

		public event PluginEventHandler PluginFocused;
		protected virtual void FirePluginFocused(PluginEventArgs e){
			if(PluginFocused!=null){
				PluginFocused(this, e);
			}
		}

		public event PluginEventHandler PluginLoaded;
		protected virtual void FirePluginLoaded(PluginEventArgs e){
			if(PluginLoaded!=null){
				PluginLoaded(this, e);
			}
		}
		
		public event PluginEventHandler PluginReloaded;
		protected virtual void FirePluginReloaded(PluginEventArgs e){
			if(PluginReloaded!=null){
				PluginReloaded(this, e);
			}
		}
		
		public event PluginEventHandler PluginUnloaded;
		protected virtual void FirePluginUnloaded(PluginEventArgs e){
			if(PluginUnloaded!=null){
				PluginUnloaded(this, e);
			}
		}
		
		#endregion
	}
}
