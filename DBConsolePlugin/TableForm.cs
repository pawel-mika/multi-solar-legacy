/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-20
 * Time: 23:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.Odbc;

namespace DBConsolePlugin
{
	/// <summary>
	/// Description of TableForm.
	/// </summary>
	public partial class TableForm : Form
	{
		public TableForm(DataSet dataSet)
		{
			InitializeComponent();
			dataGridView.DataSource = dataSet.Tables["queryResult"];
		}
		
		void onFormClosed(object sender, FormClosedEventArgs e)
		{
			this.Dispose();
		}
	}
}
