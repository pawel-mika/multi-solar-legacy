/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-11
 * Time: 23:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Collections.Generic;

using Solarium.Db;
using Solarium.Frame;
using Solarium.Controller;
using Solarium.Plugin;
using Solarium.Gui;

namespace Solarium.Config
{
	/// <summary>
	/// One of main classes. It supposed to be initialized after main frame's GUI is created
	/// before all other classes. It reads the config file if it exist (if not it tries to
	/// generate default).
	/// 
	/// PRZESTARZAŁA! teraz korzystamy z system.configuration. aplikacja startuje z AppLauncher
	/// odpalanego z solarium main forma
	/// </summary>
	[Obsolete]
	public class Configuration
	{
		private IMainFrame mf = null;
		
		private string cfgLocation = null;
		
//		private XmlReader xmlReader = null;
//		private XmlWriter xmlWriter = null;
		
		private XmlDocument xmlConfig = null;
		private XmlElement xmlCfgRootNode = null;
		
		public Configuration(IMainFrame mf)
		{
//			this.mf = mf;
//		
//			//set config location
//			Assembly asm = Assembly.GetExecutingAssembly ();
//			cfgLocation = String.Format ("{0}.config.xml", asm.Location);
//			
//			if(!openConfig()){
//				//no config found, so create one
//				createEmptyConfigRoot();
//				
//				mf.MainFrameUI.SplashForm.TotalItems = 3;	//3 object for the moment to create...
//				mf.MainFrameUI.SplashForm.Status = "Initialising database connection...";
//				
//				//and next initialize main objects in
//				//their default states
////				mf.Database = new DataBase(mf);
////				createConfigNode(mf.Database,xmlCfgRootNode);
////				mf.Database.connect();
////				mf.MainFrameUI.SplashForm.DoneItems += 1;
//				
//				tryToLogin();
//				
//				//przed załadowaniem pluginow powinnismy jeszcze najpierw
//				//zalogowac usera i na podstawie jego uprawnien (normal/admin/inny)
//				//załadowac tylko te wtyczki które są dla niego przeznaczone
//				
//				mf.MainFrameUI.SplashForm.Status = "Loading plugins...";
//				mf.PluginHost = new PluginHost(mf);
//				//create configs for configurable plugins 
//				foreach(IPlugin p in mf.PluginHost.Plugins){
//					if(p is IConfigurable){
//						createConfigNode((IConfigurable)p,xmlCfgRootNode);
//					}
//				}
//				mf.MainFrameUI.ViewManager = new ViewManager(mf);
//				mf.MainFrameUI.SplashForm.DoneItems += 1;
//				
//				mf.MainFrameUI.SplashForm.Status = "Starting network...";
//				//mf.Network = new Network(true);
//				mf.Network = new Network(mf);
//				createConfigNode(mf.Network,xmlCfgRootNode);
//				mf.MainFrameUI.SplashForm.DoneItems += 1;
//				
//				XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
//				xmlWriterSettings.Indent = true;
//				xmlWriterSettings.NewLineChars = Environment.NewLine;
//	
//				using (xmlWriter = XmlWriter.Create(cfgLocation,xmlWriterSettings)){
//					xmlConfig.Save(xmlWriter);
//				} 
//			}else{
//				//set to true if new plugin nodes added...
//				bool configModified = false;
//					
//				//open config and initialize mainframe main objects
//				using(xmlReader = XmlTextReader.Create(cfgLocation)){
//					xmlConfig = new System.Xml.XmlDocument();
//					xmlConfig.Load (xmlReader);
//					
//					xmlCfgRootNode = xmlConfig["SolariumAppConfig"];
//					
//					mf.MainFrameUI.SplashForm.TotalItems = 3;	//3 object for the moment to create...
//					mf.MainFrameUI.SplashForm.Status = "Initialising database connection...";
////					mf.Database = new DataBase(mf);
////					mf.Database.setConfig(getConfigNode(mf.Database));
////					mf.Database.connect();
////					mf.MainFrameUI.SplashForm.DoneItems += 1;
//					
//					tryToLogin();
//					
//					mf.MainFrameUI.SplashForm.Status = "Loading plugins...";
//					mf.PluginHost = new PluginHost(mf);
//					//read (or create) configs for configurable plugins 
//					foreach(IPlugin p in mf.PluginHost.Plugins){
//						if(p is IConfigurable){
//							Dictionary<string, object> d = getConfigNode((IConfigurable)p);
//							if(d.Count>0){
//								((IConfigurable)p).setConfig(getConfigNode((IConfigurable)p));
//							}else{
//								createConfigNode((IConfigurable)p,xmlCfgRootNode);
//								configModified = true;
//							}
//						}
//					}					
//					mf.MainFrameUI.ViewManager = new ViewManager(mf);
//					mf.MainFrameUI.SplashForm.DoneItems += 1;
//
//					mf.MainFrameUI.SplashForm.Status = "Starting network...";
//					//mf.Network = new Network(true);
//					mf.Network = new Network(mf);
//					mf.Network.setConfig(getConfigNode(mf.Network));
//					mf.MainFrameUI.SplashForm.DoneItems += 1;
//					
//				}
//				
//				//write modified config if necesary
//				if(configModified){
//					XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
//					xmlWriterSettings.Indent = true;
//					xmlWriterSettings.NewLineChars = Environment.NewLine;
//
//					using (xmlWriter = XmlWriter.Create(cfgLocation,xmlWriterSettings)){
//						xmlConfig.Save(xmlWriter);
//					} 						
//				}
//			}
		}
		
		private void tryToLogin(){
			LoginForm lf = new LoginForm(mf);
			lf.ShowDialog();
		}
		
		/// <summary>
		/// Try to open config file
		/// </summary>
		/// <returns></returns>
		private bool openConfig()
		{
			FileInfo fi = new FileInfo(cfgLocation);
			if (!fi.Exists){
				return false;
				//throw new Exception ("Missing config file");
			}else{
				return true;
			}
		}
		/// <summary>
		/// Create empty config document with a default root node (SolariumAppConfig)
		/// </summary>
		private void createEmptyConfigRoot()
		{
			xmlConfig = new System.Xml.XmlDocument();
			xmlConfig.PreserveWhitespace = true;
			
			XmlDeclaration xmlDeclaration = xmlConfig.CreateXmlDeclaration("1.0","utf-8",null); 
			
			// Create the root element - solariumAppConfig
			xmlCfgRootNode  = xmlConfig.CreateElement("SolariumAppConfig");
			xmlConfig.InsertBefore(xmlDeclaration, xmlConfig.DocumentElement); 
			xmlConfig.AppendChild(xmlCfgRootNode);
		}
		/// <summary>
		/// Create config node od a specified parameter IConfigurable class in
		/// specified parent xmlelement node
		/// </summary>
		/// <param name="ic"></param>
		/// <param name="parent"></param>
//		private void createConfigNode(IConfigurable ic, XmlElement parent)
//		{
//			XmlElement cfgNode = xmlConfig.CreateElement(ic.GetType().Name);
//			foreach(string s in ic.getConfig().Keys){
//				XmlElement e = xmlConfig.CreateElement(s);
//				e.SetAttribute("type",ic.getConfig()[s].GetType().ToString());
//				XmlText t = xmlConfig.CreateTextNode(ic.getConfig()[s].ToString());
//				cfgNode.AppendChild(e);
//				e.AppendChild(t);
//			}
//			parent.AppendChild(cfgNode);
//		}
//		/// <summary>
//		/// Get a config node from xml configuration document
//		/// </summary>
//		/// <param name="ic">Class that implements IConfigurable</param>
//		/// <returns></returns>
//		private Dictionary<string, object> getConfigNode(IConfigurable ic)
//		{
//			Dictionary<string, object> cfg = new Dictionary<string, object>();
//			if(xmlConfig!=null && xmlConfig["SolariumAppConfig"][ic.GetType().Name]!=null){
//				foreach (XmlNode node in xmlConfig["SolariumAppConfig"][ic.GetType().Name]){
//					string s = node.Attributes["type"].Value;
//					Type type = Type.GetType(s);
//					cfg.Add(node.Name, Convert.ChangeType(node.InnerText,type));
//				}
//			}
//			return cfg;
//		}
	}
}
