/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-06
 * Time: 16:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;

namespace Solarium.Bios.Model
{
	/// <summary>
	/// Dictionary of codelists from database.
	/// Key - <see cref="BiosCodelistEntry">BiosCodelistEntry</see>
	/// Value - <see cref="Solarium.Bios.Codelist">Codelist</see>
	/// </summary>
	public class BiosCodelist : DictionaryBase
	{
		public Codelist this[int rcCtype, string fieldName]
		{
			get
			{
				IEnumerator ie = this.Dictionary.Keys.GetEnumerator();
				while(ie.MoveNext()){
					BiosCodelistEntry bce = (BiosCodelistEntry)ie.Current;
					if(bce.RcCtype == rcCtype && bce.FieldName == fieldName){
						return (Codelist)this.Dictionary[bce];
					}
				}
				return null;
			}
			set
			{
				IEnumerator ie = this.Dictionary.Keys.GetEnumerator();
				while(ie.MoveNext()){
					BiosCodelistEntry bce = (BiosCodelistEntry)ie.Current;
					if(bce.RcCtype == rcCtype && bce.FieldName == fieldName){
						this.Dictionary[bce] = value;
					}
				}
			}
		}
		
		public void Add(BiosCodelistEntry bce, Codelist cl)
		{
			this.Dictionary.Add(bce, cl);
		}
		
		public bool Contains(BiosCodelistEntry key)
		{
			return this.Dictionary.Contains(key);
		}

		public ICollection Keys
		{
			get {return this.Dictionary.Keys;}
		}
	}
}
