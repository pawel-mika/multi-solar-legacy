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

using Solarium.Db.QueryTools;
using Solarium.Bios.Model;

namespace Solarium.Bios
{
	/// <summary>
	/// Description of RcComponent.
	/// </summary>
	public class RcComponent : IRcComponent
	{
		#region _component_system_fields

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
		
		public ComponentID ComponentId{
			get { return new ComponentID(rcOid,rcOtype,rcCtype,rcOcc); }
		}		
		
		private Dictionary<string, object> componentData = null;
		public Dictionary<string, object> ComponentData {
			get { return componentData; }
		}

		#endregion
		
		#region _constructors
		
		/// <summary>
		/// Constructor of RcComponent.
		/// RcComponent describes a component of an RcObject.
		/// </summary>
		/// <param name="rcOid">Unique object identifier that the component belongs to</param>
		/// <param name="rcOtype">Type of an object that the component belongs to</param>
		/// <param name="rcCtype">Type of an component</param>
		/// <param name="rcStore"></param>
		/// <param name="rcOcc">Occurence of an component</param>
		/// <param name="rcSign">Id of an user that created component</param>
		/// <param name="rcMod">Last time modified</param>
		/// <param name="rcLock">If locked - Id of an user that locked this component</param>
		public RcComponent(int rcOid, int rcOtype, int rcCtype, int rcStore, int rcOcc, int rcSign, DateTime rcMod, int rcLock)
		{
			this.rcOid = rcOid;
			this.rcOtype = rcOtype;
			this.rcCtype = rcCtype;
			this.rcStore = rcStore;
			this.rcOcc = rcOcc;
			this.rcSign = rcSign;
			this.rcMod = rcMod;
			this.rcLock = rcLock;
		}

		/// <summary>
		/// Create a component from QueryResultRow
		/// </summary>
		/// <param name="qrr">Row containing component data (system fields+data fields)</param>
		public RcComponent(QueryResultRow qrr)
		{
			this.componentData = new Dictionary<string, object>();
			
			foreach(QueryResultField qrf in qrr.RowData){
				switch(qrf.FieldName){
					case "rc_oid":
						this.rcOid = qrf.GetInt();
						break;
					case "rc_otype":
						this.rcOtype = qrf.GetInt();
						break;
					case "rc_ctype":
						this.rcCtype = qrf.GetInt();
						break;
					case "rc_store":
						this.rcStore = qrf.GetInt();
						break;
					case "rc_occ":
						this.rcOcc = qrf.GetInt();
						break;
					case "rc_sign":
						this.rcSign = qrf.GetInt();
						break;
					case "rc_mod":
						this.rcMod = qrf.GetDateTime();
						break;
					case "rc_lock":
						this.rcLock = qrf.GetInt();
						break;
					default:
						Codelist cl = Bios.Codelists[rcCtype, qrf.FieldName.ToLower()];
						if(cl != null && qrf.FieldValue != DBNull.Value){
							componentData.Add(qrf.FieldName.ToLower(), cl[qrf.GetInt(), 0]); // lang = 0 - for the moment = polish
//						} else if (qrf.FieldValue == DBNull.Value){
//							componentData.Add(qrf.FieldName.ToLower(), null); //co dla nulla w bazie???
						} else {
							componentData.Add(qrf.FieldName.ToLower(), qrf);
						}
						break;
				}
			}
		}
		
		#endregion
		
		#region _public_methods

		public QueryResultField Get(String key)
		{
			if(componentData.ContainsKey(key.ToLower())){
				return (QueryResultField)componentData[key];
			}else{
				throw new BiosException(string.Format("No field named '{0}' in component {1} data.", key, this.rcCtype));
			}
		}
		
		/// <summary>
		/// Get an value from specified field.
		/// </summary>
		/// <param name="key">Field name (key)</param>
		/// <returns>Object (data)</returns>
		public object GetValue(string key)
		{
			if(componentData.ContainsKey(key.ToLower())){
				return ((QueryResultField)componentData[key]).FieldValue;
			}else{
				throw new BiosException(string.Format("No field named '{0}' in component {1} data.", key, this.rcCtype));
			}
		}
		
		public CodelistEntry GetCodelistEntry(string key){
			if(componentData.ContainsKey(key.ToLower())){
				object o = componentData[key];
				if(o is CodelistEntry) {
					return (CodelistEntry)o;
				}
				return null;
			}else{
				throw new BiosException(string.Format("No field named '{0}' in component {1} data.", key, this.rcCtype));
			}
		}
		
		public int GetInt(string key){
			object o = GetValue(key);
			if(o == DBNull.Value){
				throw new FormatException(
					string.Format("The value of {0} field is null therefore it can't be parsed to int!", key));
			}
			return (int)o;
		}

		public string GetString(string key){
			return GetValue(key) != DBNull.Value ? (string)GetValue(key) : "";
		}

		public bool GetBool(string key){
			return (bool)GetValue(key);
		}

		public DateTime GetDateTime(string key){
			return GetValue(key) != DBNull.Value ? (DateTime)GetValue(key) : DateTime.MinValue;
		}

		public float GetFloat(string key){
			return GetValue(key) != DBNull.Value ? (float)GetValue(key) : float.NaN;
		}

		public decimal GetDecimal(string key){
			object o = GetValue(key);
			if(o == DBNull.Value){
				throw new FormatException(
					string.Format("The value of {0} field is null therefore it can't be parsed to decimal!", key));
			}
			return (decimal)o;
		}

		/// <summary>
		/// Check if the specified field does exist in component
		/// Omits the system fields
		/// </summary>
		/// <param name="fieldName"></param>
		/// <returns></returns>
		public bool FieldExist(string fieldName)
		{
			return componentData.ContainsKey(fieldName.ToLower());
		}

		/// <summary>
		/// Check if the specified field does contain a value (!=NULL)
		/// Omits the system fields
		/// </summary>
		/// <param name="fieldName"></param>
		/// <returns></returns>
		public bool FieldFilled(string fieldName)
		{
			return GetValue(fieldName) != DBNull.Value ? true : false;
		}
		
		/// <summary>
		/// Get the changeset for this component.
		/// </summary>
		/// <returns>new changeset for this component</returns>
		public ChangeSet GetChangeSet(){
			return new ChangeSet(this);
		}
		
		public override string ToString()
		{
			string s = String.Format("{0}; system fields: [rcOid: {1}, rcOtype: {2}, rcCtype: {3}, rcStore: {4}, " +
			                     "rcOcc: {5}, rcSign: {6}, rcMod: {7}, rcLock: {8}]; data fields: [",
			                     this.GetType().ToString(), rcOid, rcOtype, rcCtype, rcStore,
			                     rcOcc, rcSign, rcMod, rcLock);
			foreach(string key in componentData.Keys){
				s += String.Format("{0}: {1}, ", key, componentData[key] is QueryResultField ?
				                   ((QueryResultField)componentData[key]).FieldValue :
				                   ((CodelistEntry)componentData[key]).Codenum);
			}
			s = s.Remove(s.Length-2,2);
			s += "]";
			return s;
		}
		
		#endregion
		
		#region _private_methods

		#endregion
	}
}
