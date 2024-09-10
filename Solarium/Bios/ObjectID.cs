/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-10-01
 * Time: 21:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Solarium.Bios
{
	/// <summary>
	/// Description of ObjectID - class that identifies specified object in database
	/// by the two fields: oid and otype.
	/// </summary>
	public class ObjectID
	{
		/// <summary>
		/// object identifier, all components belonging to one object has the same oid
		/// </summary>
		private int oid = 0;
		public int Oid {
			get { return oid; }
		}
		
		/// <summary>
		/// object type identifier, all components belonging to one object has the same object type
		/// </summary>
		private int otype = 0;
		public int Otype {
			get { return otype; }
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="oid">object identifier</param>
		/// <param name="otype">object type</param>
		public ObjectID(int oid, int otype)
		{
			this.oid = oid;
			this.otype = otype;
		}
		
		public override string ToString()
		{
			return String.Format("{0}: [oid: {1}, otype: {2}]",this.GetType().ToString(), oid, otype);
		}
	}
}
