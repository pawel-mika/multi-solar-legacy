/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-04-15
 * Time: 11:13
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
	public sealed class ApplicationElement : ConfigurationElement
	{
		/// <summary>
		/// The attribute <c>name</c> of a <c>ApplicationElement</c>.
		/// pozwala zapisac dowolny element konfiguracyjny aplikacji pod postacia np:
		/// Application name="SplashPath" value="/images/splash.png" etc
		/// </summary>
		[ConfigurationProperty("name", IsKey = true, IsRequired = true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}
	
	
		[ConfigurationProperty("value", IsKey = true, IsRequired = true)]
		public string Value
		{
			get { return (string)this["value"]; }
			set { this["value"] = value; }
		}
	}
	
}

