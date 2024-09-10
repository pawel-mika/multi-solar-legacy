/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-25
 * Time: 09:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace DBConstructorPlugin.Gui
{
	/// <summary>
	/// Description of BiosTreeView.
	/// </summary>
	public class BiosTreeView : TreeView
	{
		public BiosTreeView()
		{
		}

		public override void Refresh()
		{
			base.Refresh();
			foreach (TreeNode tn in this.Nodes){
				ReccurentRefresh(tn);
			}
		}
		
		private void ReccurentRefresh(TreeNode tn){
//			string t = null;
			if(tn is BiosTreeNode){
//				if(((BiosTreeNode)tn).BiosObjectType != null){
//					t = ((BiosTreeNode)tn).BiosObjectType.ToString();
//				} else if(((BiosTreeNode)tn).BiosComponentType != null){
//					t = ((BiosTreeNode)tn).BiosComponentType.ToString();
//				} else if(((BiosTreeNode)tn).BiosComponent != null){
//					t = ((BiosTreeNode)tn).BiosComponent.ToString();
//				} else if(((BiosTreeNode)tn).BiosCodelistEntry != null){
//					t = ((BiosTreeNode)tn).BiosCodelistEntry.ToString();
//				}
				tn.Text = tn.ToString();
			}
			
			foreach(TreeNode treeNode in tn.Nodes){
				ReccurentRefresh(treeNode);
			}
		}
	}
}
