/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-10-20
 * Time: 20:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Solarium.Bios
{
	/// <summary>
	/// Description of ComponentID - class that identifies one specified component in database
	/// </summary>
	public class ComponentID
	{
		/// <summary>
		/// object identifier, all components belonging to one object has the same oid
		/// </summary>
		private int rcOid = 0;
		public int RcOid {
			get { return rcOid; }
		}
		
		/// <summary>
		/// object type identifier, all components belonging to one object has the same object type
		/// </summary>
		private int rcOtype  = 0;
		public int RcOtype {
			get { return rcOtype; }
		}
		
		/// <summary>
		/// component identifier, different components has diffrent identifiers.
		/// </summary>
		private int rcCtype = 0;
		public int RcCtype {
			get { return rcCtype; }
		}

		/// <summary>
		/// Component occurence. When object is allowed to have more than one component of
		/// specified type, this identifies the specific component.
		/// </summary>
		private int rcOcc = 0;
		public int RcOcc {
			get { return rcOcc; }
		}
		
		/// <summary>
		/// ObjectID of the object that this component belongs to.
		/// </summary>
		public ObjectID ObjectId{
			get { return new ObjectID(this.rcOid, this.rcOtype); }
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="rcOid">object identifier</param>
		/// <param name="rcOtype">component identifier</param>
		/// <param name="rcCtype">component type identifier</param>
		/// <param name="rcOcc">component occurence</param>
		public ComponentID(int rcOid, int rcOtype, int rcCtype, int rcOcc)
		{
			this.rcOid = rcOid;
			this.rcOtype = rcOtype;
			this.rcCtype = rcCtype;
			this.rcOcc = rcOcc;
		}
		
		/// <summary>
		/// Shorter constructor
		/// </summary>
		/// <param name="oid">object identifier</param>
		/// <param name="rcCtype">component type identifier</param>
		/// <param name="rcOcc">component occurence</param>
		public ComponentID(ObjectID oid, int rcCtype, int rcOcc){
			this.rcOid = oid.Oid;
			this.rcOtype = oid.Otype;
			this.rcCtype = rcCtype;
			this.rcOcc = rcOcc;
		}

		public override string ToString()
		{
			return String.Format("{0}; [rcOid: {1}, rcOtype: {2}, rcCtype: {3}, rcOcc: {4}]",
			                     this.GetType().ToString(), rcOid, rcOtype, rcCtype, rcOcc);
		}
	}
}
