/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-06
 * Time: 16:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.Collections.Generic;

namespace Solarium.Bios
{
	/// <summary>
	/// Description of Codelist.
	/// </summary>
	public class Codelist : CollectionBase
	{
		/// <summary>
		/// Get the value from codelist by codenum and lang.
		/// </summary>
		public CodelistEntry this[int codenum, int lang]
		{
			get
			{
				IEnumerator cee = this.List.GetEnumerator();
				CodelistEntry ce = null;
				while(cee.MoveNext()){
					ce = (CodelistEntry)cee.Current;
					if(ce.Codenum == codenum && ce.LangCodenum == lang){
						return ce;
					}
				}
				return null;
			}
			set
			{
				IEnumerator cee = this.List.GetEnumerator();
				CodelistEntry ce = null;
				while(cee.MoveNext()){
					ce = (CodelistEntry)cee.Current;
					if(ce.Codenum == codenum && ce.LangCodenum == lang){
						ce = value;
					}
				}
			}
		}
		
		public void Add(CodelistEntry ce){
			this.List.Add(ce);
		}
		
		public void Remove(CodelistEntry ce){
			this.List.Remove(ce);
		}
		
	}
}
