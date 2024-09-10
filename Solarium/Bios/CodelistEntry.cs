/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-06
 * Time: 16:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;

using Solarium.Db.QueryTools;

namespace Solarium.Bios
{
	/// <summary>
	/// Description of CodelistEntry.
	/// </summary>
	public class CodelistEntry
	{
		private int codenum = 0;
		public int Codenum {
			get { return codenum; }
		}
		
		private int langCodenum = 0;
		public int LangCodenum {
			get { return langCodenum; }
		}
		
		private string name = "";
		public string Name {
			get { return name; }
		}
		
		private LinkedList<QueryResultField> additionalFields = new LinkedList<QueryResultField>();
		public LinkedList<QueryResultField> AdditionalFields {
			get { return additionalFields; }
		}
		
		/// <summary>
		/// Pojedynczy wpis w kodliscie (odwzorowanie wiersza kodlisty)
		/// </summary>
		/// <param name="codenum"></param>
		/// <param name="langCodenum"></param>
		/// <param name="name"></param>
		public CodelistEntry(int codenum, int langCodenum, string name)
		{
			this.codenum = codenum;
			this.langCodenum = langCodenum;
			this.name = name;
		}
		
		public override string ToString()
		{
			string s = String.Format("{0}: [codenum: {1}, langCodenum: {2}, name: {3}] ",
			                     this.GetType().ToString(), codenum, langCodenum, name);
			return s;
		}
	}
}
