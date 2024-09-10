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

namespace DBConstructorPlugin
{
	/// <summary>
	/// Description of DBCTreeNode.
	/// </summary>
	public class DBCTreeNode : TreeNode
	{
		private BiosObjectType bot = null;
		private BiosComponentType bct = null;
		private BiosComponent bc = null;
		
		public DBCTreeNode(BiosObjectType bot)
		{
			this.bot = bot;
			this.Tag = bot;
			this.Text = this.ToString();
		}
		
		public DBCTreeNode(BiosComponentType bct)
		{
			this.bct = bct;
			this.Tag = bct;
			this.Text = this.ToString();
		}
		
		public DBCTreeNode(BiosComponent bc)
		{
			this.bc = bc;
			this.Tag = bc;
			this.Text = this.ToString();
		}
		
		public object Tag {
			get {
				if(bot != null){
					return bot;
				} else if(bct != null){
					return bct;
				} else if(bc != null){
					return bc;
				}
				return null;
			}
			set {
				if(value is BiosObjectType){
					this.bot = (BiosObjectType)value;
				} else if(value is BiosComponentType){
					this.bct = (BiosComponentType)value;
				} else if(value is BiosComponent){
					this.bc = (BiosComponent)value;
				}
				this.Text = this.ToString();
			}
		}
		
		public object GetTag(){
			if(bot != null){
				return bot;
			} else if(bct != null){
				return bct;
			} else if(bc != null){
				return bc;
			}
			return null;
		}
		
		public override string ToString()
		{
			String s = "";
			if(bot != null){
				s = string.Format("[otype: {0}, ctype: {1}] {2}", 
				                  bot.RcOtype, 
				                  bot.MainComponent, 
				                  bot.Name);
			} else if(bc != null){
				s = string.Format("[ctype: {0}, ctable: {1}, active: {2}] {3}", 
				                  bc.BiosComponentType.RcCtype,
				                  bc.BiosComponentType.CTable, 
				                  bc.BiosComponentType.Active,
				                  bc.BiosComponentType.Name);
			}
			return s;
		}
	}
}
