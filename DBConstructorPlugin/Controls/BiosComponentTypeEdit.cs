/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-07
 * Time: 23:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Solarium;
using Solarium.Bios.Model;
using Solarium.Db;
using Solarium.Db.QueryTools;
using Solarium.Frame;

using DBConstructorPlugin.Controls;

namespace DBConstructorPlugin.Controls
{
	/// <summary>
	/// Description of BiosComponentTypeEdit.
	/// </summary>
	public partial class BiosComponentTypeEdit : UserControl, IEditor
	{
		private IMainFrame mf = null;
		private BiosComponentType bct = null;
		private LinkedList<ToolStripItem> editorControls = null;
		
		private int shift = 0;
		
		public BiosComponentTypeEdit(IMainFrame mf, BiosComponentType bct)
		{
			this.mf = mf;
			this.bct = bct;
			InitializeComponent();
			PostInit();
			InitControlsList();
		}
		
		private void PostInit(){
			string sql = string.Format("describe {0}", bct.CTable);
			QueryResult qr = new QueryResult(mf.Database.ConcurentQuery(sql));
			
//			System.Data.DataTable dt = mf.Database.getTableInfo(bct.CTable);
			
			this.SuspendLayout();
			
			foreach(QueryResultRow qrr in qr){
				string fieldName = qrr.GetString("field");
				object fieldType = qrr.GetObject("type");
				string nullable = qrr.GetString("null");
				string defaultVal = qrr.GetString("default");
				DBField dbf = new DBField(fieldName, fieldType, nullable.Equals("YES")?true:false, defaultVal);
				dbf.Location = new Point(0, shift);
				dbf.Width = this.Width;
				dbf.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
				shift += dbf.Height;
				this.Controls.Add(dbf);
			}
			this.Height = shift;
			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		
		/// <summary>
		/// Inicjalizacja kontrolek - opcji do toolstripa...
		/// </summary>
		private void InitControlsList(){
			editorControls = new LinkedList<ToolStripItem>();
			
			this.SuspendLayout();
			
			//dodawania itemka
			ToolStripButton tsb = new ToolStripButton("Dodaj");
			tsb.DisplayStyle = ToolStripItemDisplayStyle.Text;
			tsb.Click += delegate(object sender, EventArgs e) { 
				DBField dbf = new DBField();
				dbf.Location = new Point(0, shift);
				dbf.Width = this.Width;
				dbf.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
				this.Controls.Add(dbf);
				
				shift += dbf.Height;
				
				RearrangeRemainingControls();
			};
			editorControls.AddLast(tsb);
			
			//usuwanie zaznaczonych itemkow
			tsb = new ToolStripButton("Usuń");
			tsb.DisplayStyle = ToolStripItemDisplayStyle.Text;
			tsb.Click += delegate(object sender, EventArgs e) { 
				LinkedList<DBField> toRemove = new LinkedList<DBField>();
				foreach(DBField dbf in this.Controls){
					if(dbf.Selected == true){
						toRemove.AddLast(dbf);
					}
				}
				foreach(DBField dbf in toRemove){
					this.Controls.Remove(dbf);
				}
				RearrangeRemainingControls();	
			};
			editorControls.AddLast(tsb);
	
			//separator
			editorControls.AddLast(new ToolStripSeparator());
			
			//zaznacz wszystkie
			tsb = new ToolStripButton("Wszystkie");
			tsb.DisplayStyle = ToolStripItemDisplayStyle.Text;
			tsb.Click += delegate(object sender, EventArgs e) { 
				foreach(DBField dbf in this.Controls){
					dbf.Selected = true;
				}
			};
			editorControls.AddLast(tsb);
			
			//odwroc zaznaczenie
			tsb = new ToolStripButton("Odwróć");
			tsb.DisplayStyle = ToolStripItemDisplayStyle.Text;
			tsb.Click += delegate(object sender, EventArgs e) { 
				foreach(DBField dbf in this.Controls){
					dbf.Selected = !dbf.Selected;
				}
			};
			editorControls.AddLast(tsb);

			this.ResumeLayout(false);
			this.PerformLayout();

			//i tak dalej opcje lecą...
			//moze tak samo zrobic menu do pobierania stad 
			//zeby wyswietlać w drzewku??
		}
		
		private void RearrangeRemainingControls(){
			shift = 0;
			foreach(DBField dbf in this.Controls){
				dbf.Location = new Point(0, shift);
				dbf.Width = this.Width;
				dbf.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
				shift += dbf.Height;
			}
			this.Height = shift;
			this.Update();
		}
		
		public System.Collections.Generic.LinkedList<ToolStripItem> EditorButtons {
			get {
				return this.editorControls;
			}
			set {
				this.editorControls = value;
			}
		}
	}
}
