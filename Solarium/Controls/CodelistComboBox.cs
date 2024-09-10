/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-04-01
 * Time: 13:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;

using Solarium.Bios;

namespace Solarium.Controls
{
	/// <summary>
	/// Description of CodelistComboBox.
	/// TODO napisac to wogole:)
	/// </summary>
	public class CodelistComboBox : ComboBox
	{
		private CodelistEntry currentValue = null;
		/// <summary>
		/// Current value choosen in CodelistComboBox
		/// </summary>
		public CodelistEntry CurrentValue {
			get { return currentValue; }
			set { 
				currentValue = value;
				foreach(clEntry ce in this.Items){
					if(ce.Entry == currentValue){
						this.SelectedItem = ce;
						break;
					}
				}
			}
		}
		
		private Codelist codelist = null;
		/// <summary>
		/// Codelist displayed by this CodelistComboBox
		/// </summary>
		public Codelist Codelist {
			get { return codelist; }
			set {
				this.codelist = value;
				if(codelist != null){
					foreach(CodelistEntry ce in codelist){
						this.Items.Add(new clEntry(ce));
					}
				}
			}
		}
		
		
		public CodelistComboBox()
		{
			
		}
		
		public CodelistComboBox(Codelist codelist)
		{
			if(codelist == null){
				throw new Exception("Codelist can't be null!");
			}
			this.codelist = codelist;
			foreach(CodelistEntry ce in codelist){
				this.Items.Add(new clEntry(ce));
			}
		}
		
		public CodelistComboBox(Codelist codelist, CodelistEntry selectedEntry)
		{
			this.codelist = codelist;
			foreach(CodelistEntry ce in codelist){
				this.Items.Add(new clEntry(ce));
				if(ce == selectedEntry){
					this.SelectedItem = ce;
					this.currentValue = ce;
				}
			}
		}
		
		public CodelistComboBox(Codelist codelist, int selectedEntryValue)
		{
			this.codelist = codelist;
			foreach(CodelistEntry ce in codelist){
				this.Items.Add(new clEntry(ce));
				if(ce.Codenum == selectedEntryValue){
					this.SelectedItem = ce;
					this.currentValue = ce;
				}
			}
		}

		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			base.OnSelectedIndexChanged(e);
			this.currentValue = this.SelectedItem != null ? 
				((clEntry)this.SelectedItem).Entry :
				null;
		}
				
		/// <summary>
		/// Private class used for proper rendering of CodelistComboBox values names.
		/// </summary>
		private class clEntry{
			private CodelistEntry entry = null;
			public CodelistEntry Entry {
				get { return entry; }
			}
			
			public clEntry(CodelistEntry entry){
				this.entry = entry;
			}
			
			public override string ToString()
			{
				return entry.Name;
			}
		}
	}
}
