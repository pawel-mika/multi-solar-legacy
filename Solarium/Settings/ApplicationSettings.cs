/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-04-15
 * Time: 11:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;   
using System.Configuration;

namespace Solarium.Settings
{
	/// <summary>
	/// Configuration section &lt;Application&gt;
	/// </summary>
	/// <remarks>
	/// Assign properties to your child class that has the attribute 
	/// <c>[ConfigurationProperty]</c> to store said properties in the xml.
	/// </remarks>
	public sealed class ApplicationSettings : ConfigurationSection
	{
		System.Configuration.Configuration _Config;


		#region ConfigurationProperties
		
		/*
		 *  Uncomment the following section and add a Configuration Collection 
		 *  from the with the file named Application.cs
		 */
		// /// <summary>
		// /// A custom XML section for an application's configuration file.
		// /// </summary>
		// [ConfigurationProperty("customSection", IsDefaultCollection = true)]
		// public ApplicationCollection Application
		// {
		// 	get { return (ApplicationCollection) base["customSection"]; }
		// }

		/// <summary>
		/// Represents attribute <c>exampleAttribute</c> of &lt;Application&gt;
		/// </summary>
		[ConfigurationProperty("exampleAttribute", DefaultValue="exampleValue")]
		public string ExampleAttribute {
			get { return (string) this["exampleAttribute"]; }
			set { this["exampleAttribute"] = value; }
		}
		
		[ConfigurationProperty("paths")]
		public ApplicationCollection Paths {
			get { return (ApplicationCollection) base ["paths"]; }
		}

		#endregion

		/// <summary>
		/// Private Constructor used by our factory method.
		/// </summary>
		private ApplicationSettings () : base () {
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
		/// Gets the current applications &lt;Application&gt; section.
		/// </summary>
		/// <param name="ConfigLevel">
		/// The &lt;ConfigurationUserLevel&gt; that the config file
		/// is retrieved from.
		/// </param>
		/// <returns>
		/// The configuration file's &lt;Application&gt; section.
		/// </returns>
		public static ApplicationSettings GetSection (ConfigurationUserLevel ConfigLevel) {
			/* 
			 * This class is setup using a factory pattern that forces you to
			 * name the section &lt;Application&gt; in the config file.
			 * If you would prefer to be able to specify the name of the section,
			 * then remove this method and mark the constructor public.
			 */ 
			System.Configuration.Configuration Config = ConfigurationManager.OpenExeConfiguration
				(ConfigLevel);
			ApplicationSettings oApplicationSettings;
			
			oApplicationSettings =
				(ApplicationSettings)Config.GetSection("ApplicationSettings");
			if (oApplicationSettings == null) {
				oApplicationSettings = new ApplicationSettings();
				Config.Sections.Add("ApplicationSettings", oApplicationSettings);
			}
			oApplicationSettings._Config = Config;
			
			return oApplicationSettings;
		}
		
		#endregion
	}
}

