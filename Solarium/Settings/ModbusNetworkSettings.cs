/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-26
 * Time: 12:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;   
using System.Configuration;

namespace Solarium.Settings
{
	/// <summary>
	/// Configuration section &lt;ModbusNetwork&gt;
	/// </summary>
	/// <remarks>
	/// Assign properties to your child class that has the attribute 
	/// <c>[ConfigurationProperty]</c> to store said properties in the xml.
	/// </remarks>
	public sealed class ModbusNetworkSettings : ConfigurationSection
	{
		System.Configuration.Configuration _Config;


		#region ConfigurationProperties
		
		/*
		 *  Uncomment the following section and add a Configuration Collection 
		 *  from the with the file named ModbusNetwork.cs
		 */
		// /// <summary>
		// /// A custom XML section for an application's configuration file.
		// /// </summary>
		// [ConfigurationProperty("customSection", IsDefaultCollection = true)]
		// public ModbusNetworkCollection ModbusNetwork
		// {
		// 	get { return (ModbusNetworkCollection) base["customSection"]; }
		// }

		/// <summary>
		/// Represents attribute <c>exampleAttribute</c> of &lt;ModbusNetwork&gt;
		/// </summary>
		[ConfigurationProperty("scanningThreadInterval", DefaultValue="30", IsRequired = true)]
		public int ScanningThreadInterval {
			get { return (int) this["scanningThreadInterval"]; }
			set { this["scanningThreadInterval"] = value; }
		}

		[ConfigurationProperty("slaves")]
		public ModbusSlaveCollection Slaves {
			get { return (ModbusSlaveCollection) base ["slaves"]; }
		}
		
		#endregion

		/// <summary>
		/// Private Constructor used by our factory method.
		/// </summary>
		private ModbusNetworkSettings () : base () {
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
		/// Gets the current applications &lt;ModbusNetwork&gt; section.
		/// </summary>
		/// <param name="ConfigLevel">
		/// The &lt;ConfigurationUserLevel&gt; that the config file
		/// is retrieved from.
		/// </param>
		/// <returns>
		/// The configuration file's &lt;ModbusNetwork&gt; section.
		/// </returns>
		public static ModbusNetworkSettings GetSection (ConfigurationUserLevel ConfigLevel) {
			/* 
			 * This class is setup using a factory pattern that forces you to
			 * name the section &lt;ModbusNetwork&gt; in the config file.
			 * If you would prefer to be able to specify the name of the section,
			 * then remove this method and mark the constructor public.
			 */ 
			System.Configuration.Configuration Config = ConfigurationManager.OpenExeConfiguration
				(ConfigLevel);
			ModbusNetworkSettings oModbusNetworkSettings;
			
			oModbusNetworkSettings =
				(ModbusNetworkSettings)Config.GetSection("ModbusNetworkSettings");
			if (oModbusNetworkSettings == null) {
				oModbusNetworkSettings = new ModbusNetworkSettings();
				Config.Sections.Add("ModbusNetworkSettings", oModbusNetworkSettings);
			}
			oModbusNetworkSettings._Config = Config;
			
			return oModbusNetworkSettings;
		}
		
		#endregion
	}
}

