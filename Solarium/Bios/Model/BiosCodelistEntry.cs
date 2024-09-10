/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-06
 * Time: 16:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Solarium.Bios.Model
{
	/// <summary>
	/// Description of BiosCodelistEntry.
	/// </summary>
	public class BiosCodelistEntry
	{
		private int rcCtype = 0;
		public int RcCtype {
			get { return rcCtype; }
		}

		private string fieldName = "";
		public string FieldName {
			get { return fieldName; }
		}

		private string clTable = "";
		public string ClTable {
			get { return clTable; }
		}

		private string clKey = "";
		public string ClKey {
			get { return clKey; }
		}

		private string clField = "";
		public string ClField {
			get { return clField; }
		}
		
		public BiosCodelistEntry(int rcCtype, string fieldName, string clTable, string clKey, string clField)
		{
			this.rcCtype = rcCtype;
			this.fieldName = fieldName;
			this.clTable = clTable;
			this.clKey = clKey;
			this.clField = clField;
		}
		
//		public override string ToString()
//		{
//			string s = String.Format("{0}: [rcCtype: {1}, fieldName: {2}, clTable: {3}, clKey: {4}, clField: {5}] ",
//			                     this.GetType().ToString(), rcCtype, fieldName, clTable, clKey, clField);
//			return s;
//		}
		
		public override string ToString()
		{
			return string.Format("[BiosCodelistEntry RcCtype={0} FieldName={1} ClTable={2} ClKey={3} ClField={4}]", 
			                     this.rcCtype, this.fieldName, this.clTable, this.clKey, this.clField);
		}
		
	}
}
