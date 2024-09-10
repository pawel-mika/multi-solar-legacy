/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-27
 * Time: 07:59
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
	public sealed class ModbusSlaveElement : ConfigurationElement
	{
		/// <summary>
		/// The attribute <c>id</c> of a <c>ModbusSlaveElement</c>.
		/// Slave ID
		/// </summary>
		[ConfigurationProperty("id", IsKey = true, IsRequired = true)]
		public int Id
		{
			get { return (int)this["id"]; }
			set { this["id"] = value; }
		}
	
		[ConfigurationProperty("heatingRelay", DefaultValue="0x0000", IsRequired = true)]
		public int HeatingRelay
		{
			get { return (int)this["heatingRelay"]; }
			set { this["heatingRelay"] = value; }
		}
		
		[ConfigurationProperty("coolingRelay", DefaultValue="0x0001", IsRequired = true)]
		public int CoolingRelay
		{
			get { return (int)this["coolingRelay"]; }
			set { this["coolingRelay"] = value; }
		}
		
		[ConfigurationProperty("startButton", DefaultValue="0x1000", IsRequired = true)]
		public int StartButton
		{
			get { return (int)this["startButton"]; }
			set { this["startButton"] = value; }
		}
		
		[ConfigurationProperty("stopButton", DefaultValue="0x1001", IsRequired = true)]
		public int StopButton
		{
			get { return (int)this["stopButton"]; }
			set { this["stopButton"] = value; }
		}
		
		[ConfigurationProperty("keyFilterTime", DefaultValue="100", IsRequired = true)]
		public int KeyFilterTime
		{
			get { return (int)this["keyFilterTime"]; }
			set { this["keyFilterTime"] = value; }
		}
		
		[ConfigurationProperty("keyHoldTime", DefaultValue="7500", IsRequired = true)]
		public int KeyHoldTime
		{
			get { return (int)this["keyHoldTime"]; }
			set { this["keyHoldTime"] = value; }
		}
		
		[ConfigurationProperty("deviceName")]
		public string DeviceName
		{
			get { return (string)this["deviceName"]; }
			set { this["deviceName"] = value; }
		}

	}
	
}

