/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-10-06
 * Time: 00:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;

namespace Solarium.Bios
{
	/// <summary>
	/// Description of RcObject - projection of an object from database.
	/// </summary>
	public class RcObject
	{
		/// <summary>
		/// Object identifier.
		/// </summary>
		private ObjectID oid = null;
		public ObjectID Oid {
			get { return oid; }
		}
		
		/// <summary>
		/// Main component of this object.
		/// </summary>
		private RcComponent mainComponent = null;
		public RcComponent MainComponent {
			get { return mainComponent; }
		}
		
		/// <summary>
		/// List of all data components belonging to this object.
		/// It does NOT contain the main component.
		/// </summary>
		private LinkedList<IRcComponent> dataComponents = null;
		public LinkedList<IRcComponent> DataComponents {
			get { return dataComponents; }
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="oid">Object identifier</param>
		/// <param name="mainComponent">Main component</param>
		/// <param name="dataComponents">Data component list</param>
		public RcObject(ObjectID oid, RcComponent mainComponent, LinkedList<IRcComponent> dataComponents)
		{
			this.oid = oid;
			this.mainComponent = mainComponent;
			this.dataComponents = dataComponents;
		}
		
		public override string ToString()
		{
			return string.Format("{0}; oid: {1}, component count: {2}",
			                     this.GetType().ToString(), oid.ToString(), 1 + dataComponents.Count);
		}
		
	}
}
