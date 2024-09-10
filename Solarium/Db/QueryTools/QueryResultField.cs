/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-10-05
 * Time: 20:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Solarium.Db.QueryTools
{
	/// <summary>
	/// Description of QueryResultField.
	/// </summary>
	public class QueryResultField
	{
		#region _properties

		private string fieldName = null;
		
		/// <summary>
		/// Name of a data field
		/// </summary>
		public string FieldName {
			get { return fieldName; }
		}
		
		private object fieldValue = null;
		
		/// <summary>
		/// Value of a data
		/// </summary>
		public object FieldValue {
			get { return fieldValue; }
		}

		
		private Type fieldDataType = null;
		
		/// <summary>
		/// Data type containing by this field
		/// </summary>
		public Type FieldDataType {
			get { return fieldDataType; }
		}
		
		#endregion
		
		#region _constructors

		/// <summary>
		/// Constructor of a QueryResultField.
		/// </summary>
		/// <param name="name">Name of a data field (column)</param>
		/// <param name="value">Data value</param>
		public QueryResultField(string name, object value, Type type)
		{
			this.fieldName = name;
			this.fieldValue = value;
			this.fieldDataType = type;
		}

		#endregion
		
		#region _public_methods

		public int GetInt(){
			return (int)fieldValue;
		}
		
		public long GetLong(){
			return (long)fieldValue;
		}
		
		public float GetFloat(){
			return (float)fieldValue;
		}
		
		public double GetDouble(){
			return (double)fieldValue;
		}
		
		public decimal GetDecimal(){
			return (decimal)FieldValue;
		}
		
		public string GetString(){
			return (string)FieldValue;
		}
		
		public bool GetBool(){
			return (bool)FieldValue;
		}
		
		public DateTime GetDateTime(){
			return FieldValue!=DBNull.Value ? (DateTime)FieldValue : DateTime.MinValue;
		}
		
		public override string ToString()
		{
			return string.Format("[QueryResultField FieldName={0} FieldValue={1} FieldDataType={2}]",
			                     this.fieldName, this.fieldValue, this.fieldDataType);
		}
		
		#endregion

	}
}
