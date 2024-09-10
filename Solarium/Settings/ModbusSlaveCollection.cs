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
	/// A collection of ModbusSlaveElement(s).
	/// </summary>
	public sealed class ModbusSlaveCollection : ConfigurationElementCollection
	{
		#region Properties

		/// <summary>
		/// Gets the CollectionType of the ConfigurationElementCollection.
		/// </summary>
		public override ConfigurationElementCollectionType CollectionType
		{
			get { return ConfigurationElementCollectionType.BasicMap; }
		}
	   

		/// <summary>
		/// Gets the Name of Elements of the collection.
		/// </summary>
		protected override string ElementName
		{
		get { return "ModbusSlave"; }
		}
			   
	   
		/// <summary>
		/// Retrieve and item in the collection by index.
		/// </summary>
		public ModbusSlaveElement this[int index]
		{
			get   { return (ModbusSlaveElement)BaseGet(index); }
			set
			{
				if (BaseGet(index) != null)
				{
					BaseRemoveAt(index);
				}
				BaseAdd(index, value);
			}
		}


		#endregion

		/// <summary>
		/// Adds a ModbusSlaveElement to the configuration file.
		/// </summary>
		/// <param name="element">The ModbusSlaveElement to add.</param>
		public void Add(ModbusSlaveElement element)
		{
			BaseAdd(element);
		}
	   
	   
		/// <summary>
		/// Creates a new ModbusSlaveElement.
		/// </summary>
		/// <returns>A new <c>ModbusSlaveElement</c></returns>
		protected override ConfigurationElement CreateNewElement()
		{
			return new ModbusSlaveElement();
		}

	   
	   
		/// <summary>
		/// Gets the key of an element based on it's Id.
		/// </summary>
		/// <param name="element">Element to get the key of.</param>
		/// <returns>The key of <c>element</c>.</returns>
		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((ModbusSlaveElement)element).Id;
		}
	   
	   
		/// <summary>
		/// Removes a ModbusSlaveElement with the given name.
		/// </summary>
		/// <param name="name">The name of the ModbusSlaveElement to remove.</param>
		public void Remove (string name) {
			base.BaseRemove(name);
		}

	}
}

