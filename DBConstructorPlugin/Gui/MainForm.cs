/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-07
 * Time: 20:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Solarium;
using Solarium.Bios;
using Solarium.Bios.Model;
using Solarium.Frame;
using Solarium.Utils;

using DBConstructorPlugin.Controls;

namespace DBConstructorPlugin.Gui
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private IMainFrame mf = null;
		
		public const int CREATE_OBJECT 		=	01;
		public const int DELETE_OBJECT		=	02;

		public const int CREATE_COMPONENT	=	11;
		public const int DELETE_COMPONENT	=	12;

		public const int CREATE_CODELIST	=	21;
		public const int DELETE_CODELIST	=	22;

		public const int CREATE_RELATION	=	31;
		public const int DELETE_RELATION	=	32;

		public const int CREATE_C_FIELD		=	41;
		public const int DELETE_C_FIELD		=	42;

		private Dictionary<Object, int> pendingOperations = new Dictionary<Object, int>();
		public Dictionary<object, int> PendingOperations {
			get { return pendingOperations; }
		}
		
		/// <summary>
		/// Main form for the object/component/codelist editor
		/// </summary>
		/// <param name="mf"></param>
		public MainForm(IMainFrame mf)
		{
			this.mf = mf;
			InitializeComponent();
			
			PostInit();
			InitMainMenu();
		}
		
		private void PostInit() {
			if(mf.Database.Bios != null){
				foreach(BiosObjectType bot in mf.Database.Bios.BiosObjects.Keys){
					BiosTreeNode tn = new BiosTreeNode(bot);
					foreach(BiosComponent bc in mf.Database.Bios.BiosObjects[bot]){
						BiosTreeNode tnChild = new BiosTreeNode(bc);
						tn.Nodes.Add(tnChild);
					}
					biosTreeView.Nodes.Add(tn);
				}
				
				foreach (BiosCodelistEntry bcle in Bios.Codelists.Keys){
					BiosTreeNode tn = new BiosTreeNode(bcle);
					biosTreeView.Nodes.Add(tn);
				}
			}
			biosTreeView.Refresh();
		}
	
		private void InitMainMenu(){
			//object options
			ToolStripItem tsi = new ToolStripMenuItem("Create object");
			tsi.Click += new EventHandler(OnCreateObjectClick);
			tsi.Tag = CREATE_OBJECT;
			contextMenuStrip1.Items.Add(tsi);
			
			tsi = new ToolStripMenuItem("Delete object");
			tsi.Click += new EventHandler(OnDeleteObjectClick);
			tsi.Tag = DELETE_OBJECT;
			contextMenuStrip1.Items.Add(tsi);
			
			contextMenuStrip1.Items.Add(new ToolStripSeparator());
			
			//component options
			tsi = new ToolStripMenuItem("Create component");
			tsi.Click += new EventHandler(OnCreateComponentClick);
			tsi.Tag = CREATE_COMPONENT;
			contextMenuStrip1.Items.Add(tsi);
			
			tsi = new ToolStripMenuItem("Delete component");
			//tsi.Click += new EventHandler(OnCreateComponentClick);
			tsi.Tag = DELETE_COMPONENT;
			contextMenuStrip1.Items.Add(tsi);
			
			contextMenuStrip1.Items.Add(new ToolStripSeparator());
			
			//codelist options
			tsi = new ToolStripMenuItem("Create codelist");
			//tsi.Click += new EventHandler(OnCreateComponentClick);
			tsi.Tag = CREATE_CODELIST;
			contextMenuStrip1.Items.Add(tsi);			

			tsi = new ToolStripMenuItem("Delete codelist");
			//tsi.Click += new EventHandler(OnCreateComponentClick);
			tsi.Tag = DELETE_CODELIST;
			contextMenuStrip1.Items.Add(tsi);		
			
			contextMenuStrip1.Items.Add(new ToolStripSeparator());
			
			//relation options
			tsi = new ToolStripMenuItem("Create relation");
			//tsi.Click += new EventHandler(OnCreateComponentClick);
			tsi.Tag = CREATE_RELATION;
			contextMenuStrip1.Items.Add(tsi);			
			
			tsi = new ToolStripMenuItem("Delete relation");
			//tsi.Click += new EventHandler(OnCreateComponentClick);
			tsi.Tag = DELETE_RELATION;
			contextMenuStrip1.Items.Add(tsi);		
		}
		
		void TvOCAfterSelect(object sender, TreeViewEventArgs e)
		{
			toolStrip1.Items.Clear();
			LDetails.Text = e.Node.ToString();
			//object o = ((DBCTreeNode)e.Node).Tag;
			if(e.Node is BiosTreeNode){
				
				if(((BiosTreeNode)e.Node).BiosComponent != null && ((BiosTreeNode)e.Node).BiosComponent.BiosComponentType != null){
					panel1.Controls.Clear();
					BiosComponentTypeEdit bcte = new BiosComponentTypeEdit(mf, ((BiosTreeNode)e.Node).BiosComponent.BiosComponentType);
					bcte.Width = panel1.Width;
					bcte.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
					panel1.Controls.Add(bcte);
					foreach(ToolStripItem tsi in bcte.EditorButtons){
						toolStrip1.Items.Add(tsi);
					}
				}else if(((BiosTreeNode)e.Node).BiosObjectType != null){
					panel1.Controls.Clear();
				}else if(((BiosTreeNode)e.Node).BiosCodelistEntry != null){
					panel1.Controls.Clear();
				}
			}
		}

		private void OnCreateObjectClick(object sender, EventArgs e){
			CreateObject();
		}
		
		private void OnDeleteObjectClick(object sender, EventArgs e){
			BiosTreeNode dtv = (BiosTreeNode)biosTreeView.SelectedNode;
			if(dtv != null && dtv.BiosObjectType != null){
				if( DialogResult.OK == 
				   DialogUtils.ShowOkCancel(mf,
				                            "R U SIUR?",
				                            string.Format("Czy na pewno usunąc obiekt: \r\n{0}", dtv.BiosObjectType.ToString()))
				  ){
					if(dtv.PendingOperation == 0){
						dtv.PendingOperation = DELETE_OBJECT;
						pendingOperations.Add(dtv.BiosObjectType, DELETE_OBJECT);
					} else {
						DialogUtils.ShowInfo(mf, "Info", "Dla tego elementu jest już zdefiniowana operacja!");
					}
				}else{
					
				}
			}
		}

		private void OnCreateComponentClick(object sender, EventArgs e){
			CreateComponent();
		}
		
		private void CreateObject(){
			
		}
		
		private void ModifyObject(){
			
		}
		
		private void CreateComponent(){
			Solarium.Utils.DialogUtils.ShowError(mf, "dupa", "dupny error?");
		}

		private void ModifyComponent(){
			
		}

		private void DeleteComponent(){
			
		}

		private void CreateRelation(){
			
		}

		private void CreateCodelist(){
			
		}

		private void CreateCodelistRelation(){
			
		}

		
		void ContextMenuStrip1Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//blokujemy/odblokowujemy opcje w menu...
			object o = ((BiosTreeNode)biosTreeView.SelectedNode).Tag;
			if(o is BiosComponent){
				foreach(ToolStripItem tsi in ((ContextMenuStrip)sender).Items){
					if (tsi.Tag != null) {
						switch((int)tsi.Tag){
							case CREATE_COMPONENT:
							case DELETE_COMPONENT:
							case CREATE_RELATION:
							case DELETE_RELATION:
								tsi.Enabled = true;
								break;
							default:
								tsi.Enabled = false;
								break;
						}
					}
				}
			} else if(o is BiosObjectType){
				foreach(ToolStripItem tsi in ((ContextMenuStrip)sender).Items){
					if (tsi.Tag != null) {
						switch((int)tsi.Tag){
							case CREATE_OBJECT:
							case DELETE_OBJECT:
							case CREATE_COMPONENT:
							case DELETE_COMPONENT:
							case CREATE_RELATION:
							case DELETE_RELATION:
								tsi.Enabled = true;
								break;
							default:
								tsi.Enabled = false;
								break;
						}

					}				}
			} else if(o is BiosCodelistEntry){
				foreach(ToolStripItem tsi in ((ContextMenuStrip)sender).Items){
					if (tsi.Tag != null) {
						switch((int)tsi.Tag){
							case CREATE_RELATION:
							case DELETE_RELATION:
							case CREATE_CODELIST:
							case DELETE_CODELIST:
								tsi.Enabled = true;
								break;
							default:
								tsi.Enabled = false;
								break;
						}
					}
				}
			}
		}
		
		void TvOCMouseClick(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right){
				TreeNode tn = biosTreeView.GetNodeAt(e.Location);
				if(tn!=null){
					biosTreeView.SelectedNode = tn;
				}
			}
		}
	}
}
