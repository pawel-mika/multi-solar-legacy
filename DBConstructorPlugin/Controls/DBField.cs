/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-07
 * Time: 23:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Solarium;
using Solarium.Db;

namespace DBConstructorPlugin.Controls
{
	/// <summary>
	/// Description of DBField.
	/// </summary>
	public partial class DBField : UserControl
	{
		private string fieldName = "";
		public string FieldName {
			get { return fieldName; }
			set { fieldName = value; }
		}
		
		private object fieldType = null;
		public object FieldType {
			get { return fieldType; }
			set { fieldType = value; }
		}
		
		private int dataSize = 0;
		public int DataSize {
			get { return dataSize; }
			set { dataSize = value; }
		}
		
		private string defaultValue = "";
		public string DefaultValue {
			get { return defaultValue; }
			set { defaultValue = value; }
		}
		
		
		private bool nullabe = false;
		public bool Nullabe {
			get { return nullabe; }
			set { 
				this.cbNullable.Checked = value;
				nullabe = value; 
			}
		}
		
		private bool selected = false;
		public bool Selected {
			get { return selected; }
			set { 
				this.cbSelected.Checked = value;
				selected = value; 
			}
		}
		
		public DBField(){
			InitializeComponent();
		}
		
		public DBField(string fieldName, object fieldType, bool nullabe, string defaultValue)
		{
			this.fieldName = fieldName;
			this.fieldType = fieldType;
			this.nullabe = nullabe;
			this.defaultValue = defaultValue;
			InitializeComponent();
			PostInit();
		}
		
		private void PostInit(){
			tbName.Text = fieldName;
			//TYP!!
			cbNullable.Checked = nullabe;
			tbDefaultValue.Text = defaultValue;
			
			Array ta = System.Enum.GetValues(typeof(System.Data.DbType));
			foreach(DbType t in ta) {
				cbType.Items.Add(t);
			}
		}
		
		void CbSelectedCheckedChanged(object sender, EventArgs e)
		{
			selected = ((CheckBox)sender).Checked;
		}
		
		void CbNullableCheckedChanged(object sender, EventArgs e)
		{
			nullabe = ((CheckBox)sender).Checked;
		}
	}
}
