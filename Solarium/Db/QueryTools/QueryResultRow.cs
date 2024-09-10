/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-10-05
 * Time: 20:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;

namespace Solarium.Db.QueryTools
{
	/// <summary>
	/// Description of QueryResultRow.
	/// </summary>
	public class QueryResultRow : IEnumerable<QueryResultField>
	{
		#region _properties

		private List<QueryResultField> rowData = new List<QueryResultField>();
		public List<QueryResultField> RowData {
			get { return rowData; }
		}

		#endregion
		
		#region _constructors

		public QueryResultRow()
		{
		}
		
		/// <summary>
		/// Create QueryResultRow from list of a QueryResultField
		/// </summary>
		/// <param name="row">List of QueryResultField</param>
		public QueryResultRow(List<QueryResultField> row)
		{
			this.rowData = row;
		}

		#endregion
		
		#region _public_methods

		public object GetObject(string key){
			foreach(QueryResultField qrf in rowData){
				if(key.ToUpper().CompareTo(qrf.FieldName.ToUpper())==0){
					return qrf.FieldValue;
				}
			}
			throw new Bios.BiosException(string.Format("No field named '{0}' in row.", key));
		}
		
		public QueryResultField GetField(string key){
			foreach(QueryResultField qrf in rowData){
				if(key.ToUpper().CompareTo(qrf.FieldName.ToUpper())==0){
					return qrf;
				}
			}
			throw new Bios.BiosException(string.Format("No field named '{0}' in row.", key));
		}
		


		/// <summary>
		/// Try to get specified field as an int
		/// </summary>
		/// <param name="key">field name (column)</param>
		/// <returns>int value or int.MinValue id data is null!!</returns>
		public int GetInt(string key){
			object o = GetObject(key);
			if(o is DBNull){
				return int.MinValue;
			}else{
				return (int)o;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns>long value or long.MinValue if data is null!!</returns>
		public long GetLong(string key){
			return GetObject(key)!=DBNull.Value?(long)GetObject(key):long.MinValue;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns>float value or float.NaN if data is null!!</returns>
		public float GetFloat(string key){
			return GetObject(key)!=DBNull.Value?(float)GetObject(key):float.NaN;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns>double value or double.NaN if data is null!!</returns>
		public double GetDouble(string key){
			return GetObject(key)!=DBNull.Value?(double)GetObject(key):double.NaN;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns>decimal value or devimal.MinValue if data is null!!</returns>
		public decimal GetDecimal(string key){
			return GetObject(key)!=DBNull.Value?(decimal)GetObject(key):decimal.MinValue;
		}
		
		/// <summary>
		/// Try to get specified field as a string
		/// </summary>
		/// <param name="key">field name (column)</param>
		/// <returns>string value or null</returns>
		public string GetString(string key){
			object o = GetObject(key);
			if(o is DBNull){
				return null;
			}else if(o is string){
				return (string)o;
			}else if(o is byte[]){
				return System.Text.ASCIIEncoding.UTF8.GetString((byte[])o);
			}
			return null;
		}
		
		/// <summary>
		/// Try to get specified field as an bool
		/// </summary>
		/// <param name="key">field name (column)</param>
		/// <returns></returns>
		public bool GetBool(string key){
			object o = GetObject(key);
			if(o is string && ((string)o).Length==0){
				return false;
			} else {
				return (bool)o;
			}
		}
		
		/// <summary>
		/// Try to get specified field as an date
		/// </summary>
		/// <param name="key">field name (column)</param>
		/// <returns></returns>
		public DateTime GetDateTime(string key){
			return (DateTime)GetObject(key);
		}
		
		public override string ToString()
		{
			string result = string.Format("QueryResultRow with {0} fields: ", rowData.Count);
			foreach(QueryResultField qrf in rowData){
				result += qrf.ToString() + "; ";
			}
			return result;
		}

		#endregion
		
		#region _Enumerator_implementation

		public IEnumerator<QueryResultField> GetEnumerator()
		{
			return rowData.GetEnumerator();
		}
		
		[System.Runtime.InteropServices.DispIdAttribute(2049)]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return rowData.GetEnumerator();
		}

		#endregion
		
	}
}
