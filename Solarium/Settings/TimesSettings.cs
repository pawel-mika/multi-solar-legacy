/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-11
 * Time: 10:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;   
using System.Configuration;

namespace Solarium.Settings
{
	/// <summary>
	/// Configuration section &lt;Times&gt;
	/// </summary>
	/// <remarks>
	/// Assign properties to your child class that has the attribute 
	/// <c>[ConfigurationProperty]</c> to store said properties in the xml.
	/// </remarks>
	public sealed class TimesSettings : ConfigurationSection
	{
		System.Configuration.Configuration _Config;


		#region ConfigurationProperties
		
		/*
		 *  Uncomment the following section and add a Configuration Collection 
		 *  from the with the file named Times.cs
		 */
		// /// <summary>
		// /// A custom XML section for an application's configuration file.
		// /// </summary>
		// [ConfigurationProperty("customSection", IsDefaultCollection = true)]
		// public TimesCollection Times
		// {
		// 	get { return (TimesCollection) base["customSection"]; }
		// }

		/// <summary>
		/// Represents attribute <c>exampleAttribute</c> of &lt;Times&gt;
		/// </summary>

		[ConfigurationProperty("WaitingTime", DefaultValue="00:00:20", IsRequired = true)]
		public TimeSpan WaitingTime {
			get { return (TimeSpan)this["WaitingTime"]; }
			set { this["WaitingTime"] = value; }
		}

		[ConfigurationProperty("CleaningTime", DefaultValue="00:00:20", IsRequired = true)]
		public TimeSpan CleaningTime {
			get { return (TimeSpan)this["CleaningTime"]; }
			set { this["CleaningTime"] = value; }
		}

		[ConfigurationProperty("CoolingTime", DefaultValue="00:00:20", IsRequired = true)]
		public TimeSpan CoolingTime {
			get { return (TimeSpan)this["CoolingTime"]; }
			set { this["CoolingTime"] = value; }
		}
		#endregion

		/// <summary>
		/// Private Constructor used by our factory method.
		/// </summary>
		private TimesSettings () : base () {
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
		/// Gets the current applications &lt;Times&gt; section.
		/// </summary>
		/// <param name="ConfigLevel">
		/// The &lt;ConfigurationUserLevel&gt; that the config file
		/// is retrieved from.
		/// </param>
		/// <returns>
		/// The configuration file's &lt;Times&gt; section.
		/// </returns>
		public static TimesSettings GetSection (ConfigurationUserLevel ConfigLevel) {
			/* 
			 * This class is setup using a factory pattern that forces you to
			 * name the section &lt;Times&gt; in the config file.
			 * If you would prefer to be able to specify the name of the section,
			 * then remove this method and mark the constructor public.
			 */ 
			System.Configuration.Configuration Config = ConfigurationManager.OpenExeConfiguration
				(ConfigLevel);
			TimesSettings oTimesSettings;
			
			oTimesSettings =
				(TimesSettings)Config.GetSection("TimesSettings");
			if (oTimesSettings == null) {
				oTimesSettings = new TimesSettings();
				Config.Sections.Add("TimesSettings", oTimesSettings);
			}
			oTimesSettings._Config = Config;
			
			return oTimesSettings;
		}
		
		#endregion
	}
}

