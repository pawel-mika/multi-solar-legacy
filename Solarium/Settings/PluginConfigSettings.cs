/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-19
 * Time: 23:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;   
using System.Configuration;

namespace Solarium.Settings
{
	/// <summary>
	/// Configuration section &lt;PluginConfig&gt;
	/// </summary>
	/// <remarks>
	/// Assign properties to your child class that has the attribute 
	/// <c>[ConfigurationProperty]</c> to store said properties in the xml.
	/// </remarks>
	public sealed class PluginConfigSettings : ConfigurationSection
	{
		System.Configuration.Configuration _Config;


		#region ConfigurationProperties
		
		/*
		 *  Uncomment the following section and add a Configuration Collection 
		 *  from the with the file named PluginConfig.cs
		 */
		// /// <summary>
		// /// A custom XML section for an application's configuration file.
		// /// </summary>
		// [ConfigurationProperty("customSection", IsDefaultCollection = true)]
		// public PluginConfigCollection PluginConfig
		// {
		// 	get { return (PluginConfigCollection) base["customSection"]; }
		// }

		/// <summary>
		/// Represents attribute <c>exampleAttribute</c> of &lt;PluginConfig&gt;
		/// </summary>
		[ConfigurationProperty("exampleAttribute", DefaultValue="exampleValue")]
		public string ExampleAttribute {
			get { return (string) this["exampleAttribute"]; }
			set { this["exampleAttribute"] = value; }
		}
		
		[ConfigurationProperty("plugins")]
		public PluginElementCollection Plugins {
			get { return (PluginElementCollection) base ["plugins"]; }
			//set { this["exampleAttribute"] = value; }
		}

		

		#endregion

		/// <summary>
		/// Private Constructor used by our factory method.
		/// </summary>
		private PluginConfigSettings () : base () {
			// Allow this section to be stored in user.app. By default this is forbidden.
			this.SectionInformation.AllowExeDefinition =
				ConfigurationAllowExeDefinition.MachineToLocalUser;
		}

		#region Public Methods
		
		/// <summary>
		/// Saves the configuration to the config file.
		/// </summary>
		public void Save() {
			_Config.Save();
		}
		
		#endregion
		
		#region Static Members
		
		/// <summary>
		/// Gets the current applications &lt;PluginConfig&gt; section.
		/// </summary>
		/// <param name="ConfigLevel">
		/// The &lt;ConfigurationUserLevel&gt; that the config file
		/// is retrieved from.
		/// </param>
		/// <returns>
		/// The configuration file's &lt;PluginConfig&gt; section.
		/// </returns>
		public static PluginConfigSettings GetSection (ConfigurationUserLevel ConfigLevel) {
			/* 
			 * This class is setup using a factory pattern that forces you to
			 * name the section &lt;PluginConfig&gt; in the config file.
			 * If you would prefer to be able to specify the name of the section,
			 * then remove this method and mark the constructor public.
			 */ 
			System.Configuration.Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigLevel);
			PluginConfigSettings oPluginConfigSettings;
		
			oPluginConfigSettings =	(PluginConfigSettings)Config.GetSection("PluginConfigSettings");
			
			if (oPluginConfigSettings == null) {
				oPluginConfigSettings = new PluginConfigSettings();
				Config.Sections.Add("PluginConfigSettings", oPluginConfigSettings);
			}
			
			oPluginConfigSettings._Config = Config;
			
			return oPluginConfigSettings;
		}
		
		#endregion
	}
}

