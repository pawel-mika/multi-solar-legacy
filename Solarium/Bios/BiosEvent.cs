/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-07-12
 * Time: 21:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Solarium.Bios
{
	public delegate void BiosEventHandler (object sender, BiosEvent be);
	
	public class BiosEvent : EventArgs
	{
		private ObjectID affectedObjectId = null;
		public ObjectID AffectedObjectId {
			get { return affectedObjectId; }
			set { affectedObjectId = value; }
		}
		
		private ComponentID affectedComponentId = null;
		public ComponentID AffectedComponentId {
			get { return affectedComponentId; }
			set { affectedComponentId = value; }
		}
		
		private RcObject affectedObject = null;
		public RcObject AffectedObject {
			get { return affectedObject; }
			set { affectedObject = value; }
		}
		
		private RcComponent affectedComponent = null;
		public RcComponent AffectedComponent {
			get { return affectedComponent; }
			set { affectedComponent = value; }
		}

		public BiosEvent(ObjectID objectId, ComponentID componentId)
		{
			this.affectedObjectId = objectId;
			this.affectedComponentId = componentId;
		}

		public BiosEvent(ObjectID objectId, RcObject rcObject, ComponentID componentId, RcComponent rcComponent)
		{
			this.affectedObjectId = objectId;
			this.affectedObject = rcObject;
			this.affectedComponentId = componentId;
			this.affectedComponent = rcComponent;
		}
	}
}
