/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-10-04
 * Time: 23:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data.Odbc;
using System.Collections.Generic;

namespace Solarium.Db.QueryTools
{
	/// <summary>
	/// Description of QueryResult.
	/// </summary>
	public class QueryResult : IEnumerable<QueryResultRow>
	{
		List<QueryResultRow> rows = new List<QueryResultRow>();
		
		/// <summary>
		/// Rows in that query result
		/// </summary>
		public List<QueryResultRow> Rows {
			get { return rows; }
		}
		
		/// <summary>
		/// Class containing results from SQL queries.
		/// </summary>
		/// <param name="dataReader">OdbcDataReader containing data to process</param>
		public QueryResult(OdbcDataReader dataReader)
		{
			while(dataReader.Read()){
				QueryResultRow qrr = new QueryResultRow();
				for(int i = 0; i<dataReader.FieldCount; i++){
					qrr.RowData.Add(new QueryResultField(dataReader.GetName(i),dataReader.GetValue(i),dataReader.GetFieldType(i)));
				}
				rows.Add(qrr);
			}
		}

		/// <summary>
		/// Enumerator for QueryResultRows in that QueryResult
		/// </summary>
		/// <returns></returns>
		public IEnumerator<QueryResultRow> GetEnumerator()
		{
			return rows.GetEnumerator();
		}
		
		[System.Runtime.InteropServices.DispIdAttribute(2048)]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return rows.GetEnumerator();
		}
	}
}
