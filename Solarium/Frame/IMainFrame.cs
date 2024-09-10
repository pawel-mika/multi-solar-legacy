/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-12
 * Time: 18:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Resources;

using Solarium.Config;
using Solarium.Controller;
using Solarium.Db;
using Solarium.Gui;
using Solarium.Plugin;
using Solarium.Settings;

namespace Solarium.Frame
{
	/// <summary>
	/// Description of MainFrame.
	/// </summary>
	public interface IMainFrame
	{
		/// <summary>
		/// Event generated whenever preferences has changed.
		/// </summary>
		event PrefsChangedEventHandler PrefsChanged;
		
//		/// <summary>
//		/// Event generated when bios is sucessfully initialized.
//		/// </summary>
//		event MainFrameEventHandler BiosInitializationComplete;
		
		/// <summary>
		/// Main frame from where we can access whole the mess;)
		/// </summary>
		SolariumMainForm MainFrameUI{
			get;
		}
		
		/// <summary>
		/// Main frame's status strip
		/// </summary>
		MFStatusStrip MFStatusStrip{
			get;
			set;
		}
		
		/// <summary>
		/// View manager responsible for...??
		/// </summary>
		ViewManager ViewManager {
			get;
			set;
		}
		
		/// <summary>
		/// This is a Modbus network
		/// </summary>
		ModbusNetwork Network {
			get;
			set;
		}
		
		/// <summary>
		/// Database access + some other DB cool stuff
		/// </summary>
		DataBase Database {
			get;
			set;
		}
		
		/// <summary>
		/// A host for our plugins
		/// </summary>
		PluginHost PluginHost {
			get;
			set;
		}
		
		/// <summary>
		/// Resource manager - use for languages
		/// </summary>
		ResourceManager MFResourceManager{
			get;
		}
		
		/// <summary>
		/// Application settings 
		/// </summary>
		ApplicationSettings ApplicationSettings{
			get;
		}
	}
}
