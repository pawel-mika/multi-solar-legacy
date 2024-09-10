/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-07
 * Time: 20:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

using Solarium;
using Solarium.Bios;
using Solarium.Bios.Model;

namespace DBConstructorPlugin
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private IMainFrame mf = null;
		
		public MainForm(IMainFrame mf)
		{
			this.mf = mf;
			InitializeComponent();
			
			PostInit();
		}
		
		private void PostInit() {
			foreach(BiosObjectType bot in mf.Database.Bios.BiosObjects.Keys){
				DBCTreeNode tn = new DBCTreeNode(bot);
				foreach(BiosComponent bc in mf.Database.Bios.BiosObjects[bot]){
					DBCTreeNode tnChild = new DBCTreeNode(bc);
					tn.Nodes.Add(tnChild);
				}
				tvOC.Nodes.Add(tn);
			}
		}

		
		void TvOCAfterSelect(object sender, TreeViewEventArgs e)
		{
			LDetails.Text = e.Node.ToString();
			object o = ((DBCTreeNode)e.Node).Tag;
			if(o is BiosComponent){
				panel1.Controls.Clear();
				panel1.Controls.Add(new BiosComponentTypeEdit(mf, ((BiosComponent)o).BiosComponentType));
			}
		}
	}
}
