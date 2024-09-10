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
	/// A collection of ApplicationElement(s).
	/// </summary>
	public sealed class ApplicationCollection : ConfigurationElementCollection
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
		get { return "Application"; }
		}
			   
	   
		/// <summary>
		/// Retrieve and item in the collection by index.
		/// </summary>
		public ApplicationElement this[int index]
		{
			get   { return (ApplicationElement)BaseGet(index); }
			set
			{
				if (BaseGet(index) != null)
				{
					BaseRemoveAt(index);
				}
				BaseAdd(index, value);
			}
		}
		
		public new ApplicationElement this[string key_Name]
		{
			get
			{
				foreach(ApplicationElement ae in this){
					if(ae.Name.Equals(key_Name, StringComparison.OrdinalIgnoreCase)){
						return ae;
					}
				}
				return null;
			}
			set
			{
//				if (BaseGet(index) != null)
//				{
//					BaseRemoveAt(index);
//				}
//				BaseAdd(index, value);
			}
		}


		#endregion

		/// <summary>
		/// Adds a ApplicationElement to the configuration file.
		/// </summary>
		/// <param name="element">The ApplicationElement to add.</param>
		public void Add(ApplicationElement element)
		{
			BaseAdd(element);
		}
	   
	   
		/// <summary>
		/// Creates a new ApplicationElement.
		/// </summary>
		/// <returns>A new <c>ApplicationElement</c></returns>
		protected override ConfigurationElement CreateNewElement()
		{
			return new ApplicationElement();
		}

	   
	   
		/// <summary>
		/// Gets the key of an element based on it's Id.
		/// </summary>
		/// <param name="element">Element to get the key of.</param>
		/// <returns>The key of <c>element</c>.</returns>
		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((ApplicationElement)element).Name;
		}
	   
	   
		/// <summary>
		/// Removes a ApplicationElement with the given name.
		/// </summary>
		/// <param name="name">The name of the ApplicationElement to remove.</param>
		public void Remove (string name) {
			base.BaseRemove(name);
		}

	}
}

