/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-07
 * Time: 23:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Solarium;
using Solarium.Bios.Model;
using Solarium.Db;
using Solarium.Db.QueryTools;

namespace DBConstructorPlugin
{
	/// <summary>
	/// Description of BiosComponentTypeEdit.
	/// </summary>
	public partial class BiosComponentTypeEdit : UserControl
	{
		private IMainFrame mf = null;
		private BiosComponentType bct = null;
		
		public BiosComponentTypeEdit(IMainFrame mf, BiosComponentType bct)
		{
			this.mf = mf;
			this.bct = bct;
			InitializeComponent();
			PostInit();
		}
		
		private void PostInit(){
			string sql = string.Format("describe {0}", bct.CTable);
			QueryResult qr = new QueryResult(mf.Database.ConcurentQuery(sql));
			
			int shift = 0;
			
			foreach(QueryResultRow qrr in qr){
				string fieldName = qrr.GetString("field");
				object fieldType = qrr.GetObject("type");
				string nullable = qrr.GetString("null");
				DBField dbf = new DBField(fieldName, fieldType, nullable.Equals("YES")?true:false);
				dbf.Location = new Point(0, shift);
				shift += dbf.Height;
				this.Controls.Add(dbf);
			}
//			foreach(Control c in ((Panel)parent).Controls){
//				c.Width = ((Panel)parent).ClientSize.Width;
//				c.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
//			}
		}
	}
}
