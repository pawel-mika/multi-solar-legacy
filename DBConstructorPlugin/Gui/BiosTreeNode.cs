/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-07
 * Time: 22:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

using Solarium.Bios.Model;

namespace DBConstructorPlugin.Gui
{
	/// <summary>
	/// Description of DBCTreeNode.
	/// </summary>
	public class BiosTreeNode : TreeNode
	{
		private int pendingOperation = 0;
		public int PendingOperation {
			get { return pendingOperation; }
			set { 
				pendingOperation = value;
				if(pendingOperation != 0){
					this.BackColor = Color.LightSalmon;
				}else{
					this.BackColor = Color.White;
				}
				this.TreeView.Refresh();
			}
		}
		
		private BiosObjectType biosObjectType = null;
		public BiosObjectType BiosObjectType {
			get { return biosObjectType; }
		}
		private BiosComponentType biosComponentType = null;
		public BiosComponentType BiosComponentType {
			get { return biosComponentType; }
		}
		private BiosComponent biosComponent = null;
		public BiosComponent BiosComponent {
			get { return biosComponent; }
		}
		private BiosCodelistEntry biosCodelistEntry = null;
		public BiosCodelistEntry BiosCodelistEntry {
			get { return biosCodelistEntry; }
		}
		
		public BiosTreeNode(BiosObjectType bot)
		{
			this.biosObjectType = bot;
			//this.Tag = bot;
			//this.Text = this.ToString();
		}
		
		public BiosTreeNode(BiosComponentType bct)
		{
			this.biosComponentType = bct;
			//this.Tag = bct;
			//this.Text = this.ToString();
		}
		
		public BiosTreeNode(BiosComponent bc)
		{
			this.biosComponent = bc;
			//this.Tag = bc;
			//this.Text = this.ToString();
		}
	
		public BiosTreeNode(BiosCodelistEntry bcl)
		{
			this.biosCodelistEntry = bcl;
			//this.Tag = bcl;
			//this.Text = this.ToString();
		}

		public new object Tag {
			get {
				if(biosObjectType != null){
					return biosObjectType;
				} else if(biosComponentType != null){
					return biosComponentType;
				} else if(biosComponent != null){
					return biosComponent;
				} else if(biosCodelistEntry != null){
					return biosCodelistEntry;
				}
				return null;
			}
			set {
				if(value is BiosObjectType){
					this.biosObjectType = (BiosObjectType)value;
				} else if(value is BiosComponentType){
					this.biosComponentType = (BiosComponentType)value;
				} else if(value is BiosComponent){
					this.biosComponent = (BiosComponent)value;
				} else if(value is BiosCodelistEntry){
					this.biosCodelistEntry = (BiosCodelistEntry)value;
				}
			}
		}
		
		public override string ToString()
		{
			String s = "";
			if(pendingOperation != 0){
				s += "<>";
			}
			if(biosObjectType != null){
				s += biosObjectType.ToString();
			} else if(biosComponent != null){
				s += biosComponent.ToString();
			} else if(biosComponentType!= null){
				s += biosComponentType.ToString();
			}else if(biosCodelistEntry != null){
				s += biosCodelistEntry.ToString();
			}
			return s;
		}
	}
}
