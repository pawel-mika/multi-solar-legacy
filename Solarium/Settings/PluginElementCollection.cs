/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-19
 * Time: 18:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Configuration;


namespace Solarium.Settings
{
	/// <summary>
	/// A collection of PluginElement(s).
	/// </summary>
	public sealed class PluginElementCollection : ConfigurationElementCollection
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
			get { return "Plugin"; }
		}
			   
	   
		/// <summary>
		/// Retrieve and item in the collection by index.
		/// </summary>
		public PluginConfigElement this[int index]
		{
			get   { return (PluginConfigElement)BaseGet(index); }
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
		/// Adds a PluginElementElement to the configuration file.
		/// </summary>
		/// <param name="element">The PluginElement to add.</param>
		public void Add(PluginConfigElement element)
		{
			BaseAdd(element);
		}
	   
	   
		/// <summary>
		/// Creates a new PluginElementElement.
		/// </summary>
		/// <returns>A new <c>PluginElementElement</c></returns>
		protected override ConfigurationElement CreateNewElement()
		{
			return new PluginConfigElement();
		}

	   
	   
		/// <summary>
		/// Gets the key of an element based on it's Id.
		/// </summary>
		/// <param name="element">Element to get the key of.</param>
		/// <returns>The key of <c>element</c>.</returns>
		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((PluginConfigElement)element).Type;
		}
	   
	   
		/// <summary>
		/// Removes a PluginElementElement with the given name.
		/// </summary>
		/// <param name="name">The name of the PluginElementElement to remove.</param>
		public void Remove (string name) {
			base.BaseRemove(name);
		}

	}
}

