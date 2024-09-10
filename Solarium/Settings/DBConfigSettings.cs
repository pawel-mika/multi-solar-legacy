/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-20
 * Time: 10:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;   
using System.Configuration;
using System.Security;
using System.Security.Cryptography;

namespace Solarium.Settings
{
	/// <summary>
	/// Configuration section &lt;DBConfig&gt;
	/// </summary>
	/// <remarks>
	/// Assign properties to your child class that has the attribute 
	/// <c>[ConfigurationProperty]</c> to store said properties in the xml.
	/// </remarks>
	public sealed class DBConfigSettings : ConfigurationSection
	{
		System.Configuration.Configuration _Config;


		#region ConfigurationProperties
		
		/*
		 *  Uncomment the following section and add a Configuration Collection 
		 *  from the with the file named DBConfig.cs
		 */
		// /// <summary>
		// /// A custom XML section for an application's configuration file.
		// /// </summary>
		// [ConfigurationProperty("customSection", IsDefaultCollection = true)]
		// public DBConfigCollection DBConfig
		// {
		// 	get { return (DBConfigCollection) base["customSection"]; }
		// }

		/// <summary>
		/// Represents attribute <c>localUrl</c> of &lt;DBConfig&gt;
		/// </summary>
		[ConfigurationProperty("localUrl", DefaultValue="localhost", IsRequired = true)]
		public string LocalUrl {
			get { return (string) this["localUrl"]; }
			set { this["localUrl"] = value; }
		}
		[ConfigurationProperty("localPort", DefaultValue="0", IsRequired = true)]
		public int LocalPort {
			get { return (int) this["localPort"]; }
			set { this["localPort"] = value; }
		}		
		[ConfigurationProperty("localBase", DefaultValue="baza", IsRequired = true)]
		public string LocalBase {
			get { return (string) this["localBase"]; }
			set { this["localBase"] = value; }
		}		
		[ConfigurationProperty("localUser", DefaultValue="user", IsRequired = true)]
		public string LocalUser {
			get { return (string) this["localUser"]; }
			set { this["localUser"] = value; }
		}		
		[ConfigurationProperty("localPass", DefaultValue="pass", IsRequired = true)]
		public string LocalPass {
			get { return (string) this["localPass"]; }
			set { this["localPass"] = value; }
		}		
		[ConfigurationProperty("remoteUrl", DefaultValue="s91.superhost.pl", IsRequired = true)]
		public string RemoteUrl {
			get { return (string) this["remoteUrl"]; }
			set { this["remoteUrl"] = value; }
		}
		[ConfigurationProperty("remotePort", DefaultValue="3306", IsRequired = true)]
		public int RemotePort {
			get { return (int) this["remotePort"]; }
			set { this["remotePort"] = value; }
		}		
		[ConfigurationProperty("remoteBase", DefaultValue="solarium_baza", IsRequired = true)]
		public string RemoteBase {
			get { return (string) this["remoteBase"]; }
			set { this["remoteBase"] = value; }
		}		
		[ConfigurationProperty("remoteUser", DefaultValue="solarium_admin", IsRequired = true)]
		public string RemoteUser {
			get { return (string) this["remoteUser"]; }
			set { this["remoteUser"] = value; }
		}		
		[ConfigurationProperty("remotePass", DefaultValue="123qwe", IsRequired = true)]
		public string RemotePass {
			get { return (string) this["remotePass"]; }
			set { this["remotePass"] = value; }
		}
		[ConfigurationProperty("keeperThread", DefaultValue="true", IsRequired = true)]
		public bool KeeperThread {
			get { return (bool) this["keeperThread"]; }
			set { this["keeperThread"] = value; }
		}
		

		[ConfigurationProperty("md5test", DefaultValue="test test test", IsRequired = true)]
		public string Md5test {
			get { 
				return (string) this["md5test"]; 
			}
			set { 
				this["md5test"] = HashString(value);
			}
		}
		
		#endregion

		/// <summary>
		/// Private Constructor used by our factory method.
		/// </summary>
		private DBConfigSettings () : base () {
			// Allow this section to be stored in user.app. By default this is forbidden.
			this.SectionInformation.AllowExeDefinition =
				ConfigurationAllowExeDefinition.MachineToLocalUser;
		}

		private string Encode(string s){
			int i = 0;
			byte[] b = new byte[s.Length];
			foreach(char c in s.ToCharArray()){
				b[i] = (byte)c;
				i++;
			}
			return Convert.ToBase64String(b);
		}
		
		private string HashString(string Value)
		{
		        System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
		        byte[] data = System.Text.Encoding.ASCII.GetBytes(Value);
		        data = x.ComputeHash(data);
		        string ret = "";
		        for (int i=0; i < data.Length; i++)
		                ret += data[i].ToString("x2").ToLower();
		        return ret;
		}
		
		private string Decode(string s){
			return null;
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
		/// Gets the current applications &lt;DBConfig&gt; section.
		/// </summary>
		/// <param name="ConfigLevel">
		/// The &lt;ConfigurationUserLevel&gt; that the config file
		/// is retrieved from.
		/// </param>
		/// <returns>
		/// The configuration file's &lt;DBConfig&gt; section.
		/// </returns>
		public static DBConfigSettings GetSection (ConfigurationUserLevel ConfigLevel) {
			/* 
			 * This class is setup using a factory pattern that forces you to
			 * name the section &lt;DBConfig&gt; in the config file.
			 * If you would prefer to be able to specify the name of the section,
			 * then remove this method and mark the constructor public.
			 */ 
			System.Configuration.Configuration Config = ConfigurationManager.OpenExeConfiguration
				(ConfigLevel);
			DBConfigSettings oDBConfigSettings;
			
			oDBConfigSettings =
				(DBConfigSettings)Config.GetSection("DBConfigSettings");
			if (oDBConfigSettings == null) {
				oDBConfigSettings = new DBConfigSettings();
				Config.Sections.Add("DBConfigSettings", oDBConfigSettings);
				Config.Save();
			}
			oDBConfigSettings._Config = Config;
			
			return oDBConfigSettings;
		}
		
		#endregion
	}
}

