/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-07
 * Time: 23:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Solarium;
using Solarium.Db;

namespace DBConstructorPlugin
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
		
		private bool selected = false;
		public bool Selected {
			get { return selected; }
			set { selected = value; }
		}
		
		public DBField(string fieldName, object fieldType, bool selected)
		{
			this.fieldName = fieldName;
			this.fieldType = fieldType;
			this.selected = selected;
			InitializeComponent();
			PostInit();
		}
		
		private void PostInit(){
			tbName.Text = fieldName;
			//TYP!!
			cbSelected.Checked = selected;
		}
	}
}
