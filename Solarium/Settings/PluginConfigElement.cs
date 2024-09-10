/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-19
 * Time: 18:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;   
using System.Configuration;

namespace Solarium.Settings
{
	/// <summary>
	/// Represents a single XML tag inside a ConfigurationSection
	/// or a ConfigurationElementCollection.
	/// </summary>
	public sealed class PluginConfigElement : ConfigurationElement
	{
		/// <summary>
		/// The attribute <c>type</c> of a <c>PluginElement</c>.
		/// Contains type name of a subject plugin.
		/// This is a required entry.
		/// </summary>
		[ConfigurationProperty("Type", IsKey = true, IsRequired = true)]
		public string Type
		{
			get { return (string)this["Type"]; }
			set { this["Type"] = value; }
		}
		/// <summary>
		/// The attribute <c>Menu</c> of a <c>PluginElement</c>.
		/// Main menu name on main menu strip where the plugin should be located.
		/// If the menu doesn't exist it will be created.
		/// This is a required entry.
		/// </summary>
		[ConfigurationProperty("Menu", DefaultValue = "Debug1", IsKey = false, IsRequired = true)]
		public string Menu
		{
			get { return (string)this["Menu"]; }
			set { this["Menu"] = value; }
		}
	
		/// <summary>
		/// The attribute <c>Submenu</c> of a <c>PluginElement</c>.
		/// Submenu for the plugin if it's necessary.
		/// This entry is optional.
		/// </summary>		
		[ConfigurationProperty("Submenu", IsKey = false, IsRequired = false)]
		public string Submenu
		{
			get { return (string)this["Submenu"]; }
			set { this["Submenu"] = value; }
		}
		
		/// <summary>
		/// The attribute <c>MenuEntry</c> of a <c>PluginElement</c>.
		/// Menu entry string for this plugin. If it's not present,
		/// plugin name will be used for the entry.
		/// This entry is optional.
		/// </summary>				
		[ConfigurationProperty("MenuEntry", IsKey = false, IsRequired = false)]
		public string MenuEntry
		{
			get { return (string)this["MenuEntry"]; }
			set { this["MenuEntry"] = value; }
		}

		/// <summary>
		/// Add a menu separator before or after current plugin menu entry.
		/// This entry is optional.
		/// </summary>				
		[ConfigurationProperty("MenuSeparator", DefaultValue = null, IsKey = false, IsRequired = false)]
		public String MenuSeparator
		{
			get { return (String)this["MenuSeparator"]; }
			set { this["MenuSeparator"] = value; }
		}
		
		/// <summary>
		/// Tells the plugin loader if plugin should be started with main application.
		/// If true, after application is initialized, the plugin is goind to be started
		/// with all others Autostart=true plugins.
		/// This entry is optional.
		/// </summary>				
		[ConfigurationProperty("Autostart", IsKey = false, IsRequired = false)]
		public bool Autostart
		{
			get { return (bool)this["Autostart"]; }
			set { this["Autostart"] = value; }
		}
		
		/// <summary>
		/// Image to be used as a toolbar icon entry.
		/// This entry is optional.
		/// </summary>				
		[ConfigurationProperty("ToolbarImage", DefaultValue = null, IsKey = false, IsRequired = false)]
		public String ToolbarImage
		{
			get { return (String)this["ToolbarImage"]; }
			set { this["ToolbarImage"] = value; }
		}
		
		/// <summary>
		/// Image to be used as a toolbar icon entry.
		/// This entry is optional.
		/// </summary>				
		[ConfigurationProperty("ToolbarImageMouseOver", DefaultValue = null, IsKey = false, IsRequired = false)]
		public String ToolbarImageMouseOver
		{
			get { return (String)this["ToolbarImageMouseOver"]; }
			set { this["ToolbarImageMouseOver"] = value; }
		}

		/// <summary>
		/// Add a toolbar separator before or after this plugin toolbar entry
		/// This entry is optional.
		/// </summary>				
		[ConfigurationProperty("ToolbarSeparator", DefaultValue = null, IsKey = false, IsRequired = false)]
		public String ToolbarSeparator
		{
			get { return (String)this["ToolbarSeparator"]; }
			set { this["ToolbarSeparator"] = value; }
		}

	}
	
}

