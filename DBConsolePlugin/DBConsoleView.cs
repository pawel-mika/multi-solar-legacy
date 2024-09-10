/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-20
 * Time: 14:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.Odbc;
using System.Data.Common;

using Solarium;
using Solarium.Db;
using Solarium.Frame;
using Solarium.Utils;

namespace DBConsolePlugin
{
	/// <summary>
	/// Description of DBConsoleView.
	/// </summary>
	public partial class DBConsoleView : UserControl
	{
		private IMainFrame mf = null;
		private DataTable dataTable = null;
		
		public DBConsoleView(IMainFrame mf)
		{
			this.mf = mf;
			InitializeComponent();
			mf.Database.ConnectionLost += delegate(object sender, DatabaseEventArgs e) { 
				lStatus.Text = e.Message;
				lStatus.ForeColor = System.Drawing.Color.Red;
			};
			mf.Database.ConnectionRestored += delegate(object sender, DatabaseEventArgs e) { 
				lStatus.Text = e.Message;
				lStatus.ForeColor = System.Drawing.Color.Green;
			};
			
			if(mf.Database.RemoteConnectionState == ConnectionState.Open) {
				lStatus.Text = "Connected";
				lStatus.ForeColor = System.Drawing.Color.Green;
			}
		}
		
		void BRunClick(object sender, EventArgs e)
		{
			runQuery();
		}
		
		void BClearClick(object sender, EventArgs e)
		{
			rtbResult.Clear();
		}
		
		void onKeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)Keys.Enter){
				runQuery();
			}
//			else if(false){
//				rtbQuery.Text = "sfsdgsdgf";
//			}
		}
		
		private void addToHistory(){
			if(!cbHistory.Items.Contains(rtbQuery.Text)){
				cbHistory.Items.Add(rtbQuery.Text);
			}
		}
		
		private void runQuery(){
			//remove enters if present...
			if(rtbQuery.Text.Contains("\n")){
				rtbQuery.Text = rtbQuery.Text.Replace("\n","");
			}
			//add to history if not present...
			addToHistory();
			try{
				dataTable = new DataTable("queryResult");
				using (OdbcDataReader dr = mf.Database.RemoteQuery(rtbQuery.Text)){
					int[] widths = new int[dr.FieldCount];
					for (int i = 0; i<dr.FieldCount; i++){
						dataTable.Columns.Add(new DataColumn(dr.GetName(i)));
						rtbResult.AppendText(dr.GetName(i)+"|");
						widths[i] = dr.GetName(i).Length;
						//widths[i] = (int)dataTable.Rows[i]["ColumnSize"];
					}
					rtbResult.AppendText(Environment.NewLine);
					//append content with extending/cutting to max width
					while(dr.Read()) {
						DataRow dataRow = dataTable.NewRow();
						for (int i = 0; i<dr.FieldCount; i++){
							string s = dr.GetValue(i)!=null?dr.GetValue(i).ToString()+"":"[brak]"+"";
							dataRow[i] = s;
							if(s.Length>widths[i]){
								s=s.Substring(0,widths[i]-3);
								s+="...|";
							}else if(s.Length==widths[i]){
								s+="|";
							}else{
								while(s.Length<widths[i])
									s+=" ";
								s+="|";
							}
							rtbResult.AppendText(s);
						}
						dataTable.Rows.Add(dataRow);
						rtbResult.AppendText(Environment.NewLine);
		         	}
					rtbResult.AppendText("--------------"+Environment.NewLine);
				}
			}catch(Exception ex){
				rtbResult.AppendText(ex.Message+Environment.NewLine);
				rtbResult.AppendText(ex.InnerException+Environment.NewLine);
				rtbResult.AppendText("--------------"+Environment.NewLine);
			}
			rtbResult.Select(rtbResult.TextLength,0);
			rtbResult.ScrollToCaret();
		}
		
		void BShowTableClick(object sender, EventArgs e)
		{
			if(dataTable!=null){
				DataSet ds = new DataSet();
				ds.Tables.Add(dataTable.Copy());
				TableForm tf = new TableForm(ds);
				tf.Show();
			}else{
				DialogUtils.ShowError(mf,"Problem","No result to view...");
			}
		}
		
		void ItemSelected(object sender, EventArgs e)
		{
			rtbQuery.Text = (string)cbHistory.SelectedItem;
		}
		
		void RtbQueryKeyDown(object sender, KeyEventArgs e)
		{
			if(e.Modifiers == Keys.Control && e.KeyCode == Keys.Up) {
				cbHistory.SelectedIndex =
					(cbHistory.SelectedIndex == 0) ? 
					cbHistory.SelectedIndex : 
					cbHistory.SelectedIndex - 1;
			} else if(e.Modifiers == Keys.Control && e.KeyCode == Keys.Down) {
				cbHistory.SelectedIndex =
					(cbHistory.SelectedIndex == cbHistory.Items.Count - 1) ? 
					cbHistory.SelectedIndex : 
					cbHistory.SelectedIndex + 1;
			}
		}
	}
}
