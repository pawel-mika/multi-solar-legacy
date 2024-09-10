/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-10-20
 * Time: 20:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;

using Solarium.Bios.Model;

namespace Solarium.Bios
{
	/// <summary>
	/// Description of ChangeSet.
	/// </summary>
	public class ChangeSet : IRcComponent
	{
		private Dictionary<string, object> changes = null;
		public Dictionary<string, object> Changes {
			get { return changes; }
			set { changes = value; }
		}

		public ChangeSet(IRcComponent rcComponent)
		{
			this.rcOid = rcComponent.RcOid;
			this.rcOtype = rcComponent.RcOtype;
			this.rcCtype = rcComponent.RcCtype;
			this.rcStore = rcComponent.RcStore;
			this.rcOcc = rcComponent.RcOcc;
			this.rcSign = rcComponent.RcSign;
			this.rcMod = rcComponent.RcMod;
			this.rcLock = rcComponent.RcLock;
			this.componentId = rcComponent.ComponentId;
			this.changes = new Dictionary<string, object>();
		}
		
		private int rcOid = 0;
		public int RcOid {
			get { return rcOid; }
		}
		
		private int rcOtype = 0;
		public int RcOtype {
			get { return rcOtype; }
		}
		
		private int rcCtype = 0;
		public int RcCtype {
			get { return rcCtype; }
		}
		
		private int rcStore = 0;
		public int RcStore {
			get { return rcStore; }
		}
		
		private int rcOcc = 0;
		public int RcOcc {
			get { return rcOcc; }
		}
		
		private int rcSign = 0;
		public int RcSign {
			get { return rcSign; }
		}
		
		private DateTime rcMod = DateTime.Now;
		public DateTime RcMod {
			get { return rcMod; }
		}
		
		private int rcLock = 0;
		public int RcLock {
			get { return rcLock; }
		}
		private ComponentID componentId = null;
		public ComponentID ComponentId{
			get { return componentId; }
		}

		
		public object GetValue(string key)
		{
			if(changes.ContainsKey(key)){
				return changes[key];
			}else{
				throw new BiosException(string.Format("No field named '{0}' in change set.", key));
			}
		}
		
		public int GetInt(string key)
		{
			throw new NotImplementedException();
		}
		
		public string GetString(string key)
		{
			throw new NotImplementedException();
		}
		
		public bool GetBool(string key)
		{
			throw new NotImplementedException();
		}
		
		public DateTime GetDateTime(string key)
		{
			throw new NotImplementedException();
		}
		
		public float GetFloat(string key)
		{
			throw new NotImplementedException();
		}

		public decimal GetDecimal(string key)
		{
			throw new NotImplementedException();
		}
		
		public void AddChange(string key, object val){
			this.changes.Add(key,val);
		}
		
		public Solarium.Db.QueryTools.QueryResultField Get(string key)
		{
			throw new NotImplementedException();
		}
		
	}
}
