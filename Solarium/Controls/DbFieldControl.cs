/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-07-11
 * Time: 12:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Solarium.Db.QueryTools;
using Solarium.Bios;

namespace Solarium.Controls
{
	/// <summary>
	/// Description of DbFieldControl.
	/// </summary>
	public partial class DbFieldControl : UserControl
	{
		private bool isChanged = false;
		public bool IsChanged {
			get { return isChanged; }
		}
		
		private string fieldName = "";
		public string FieldName {
			get { return fieldName; }
		}
		
		private object fieldValue = null;
		public object FieldValue {
			get { return fieldValue; }
		}
		
		private Type fieldType = null;
		public Type FieldType {
			get { return fieldType; }
		}
		
		/// <summary>
		/// Database field control
		/// </summary>
		/// <param name="fieldName"></param>
		/// <param name="fieldValue">QueryResultField/CodelistEntry</param>
		public DbFieldControl(string fieldName, object fieldValue, bool showType)
		{
			if(!showType){
				lType.Visible = false;
			}
			if(fieldValue is QueryResultField || fieldValue is CodelistEntry){
				this.fieldName = fieldName;
				this.fieldValue = fieldValue;
				InitializeComponent();
				PostInit();
			} else {
				throw new ArgumentException("The fieldValue parameter must be QueryResultField/CodelistEntry!");
			}
		}
		
		private void PostInit()
		{
			lField.Text = fieldName;
			if(fieldValue is QueryResultField){
				fieldType = ((QueryResultField)fieldValue).FieldDataType;
				tbValue.Text = ((QueryResultField)fieldValue).FieldValue.ToString();
			} else if (fieldValue is CodelistEntry) {
				fieldType = Type.GetTypeHandle(fieldValue).GetType();
				tbValue.Text = ((CodelistEntry)fieldValue).ToString();
				tbValue.Enabled = false;
			}
			lType.Text = fieldType.Name;
		}
		
		void TbValueTextChanged(object sender, EventArgs e)
		{
			tbValue.BackColor = Color.White;
			try{
				if(tbValue.Text != null && tbValue.Text.Length>0){
					object o = Convert.ChangeType(tbValue.Text, fieldType);
					if(!o.ToString().Equals(fieldValue)){
						fieldValue = o;
						isChanged = true;
					}
				}
			}catch(Exception){
				tbValue.BackColor = Color.Red;
			}
		}
	}
}
