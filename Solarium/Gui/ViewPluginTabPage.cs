/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-16
 * Time: 18:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Solarium;
using Solarium.Plugin;

namespace Solarium.Gui
{
	/// <summary>
	/// Description of ViewPluginTabPane.
	/// </summary>
	public partial class ViewPluginTabPage : TabPage
	{
		private BaseViewPlugin plugin = null;
		
		public BaseViewPlugin Plugin {
			get { return plugin; }
			set { plugin = value; }
		}
		
		public ViewPluginTabPage(BaseViewPlugin vp, string title) : base(title)
		{
			this.plugin = vp;
			this.Leave += delegate { OnLeave(new TabChangedEventArgs(this, plugin)); };
			this.Enter += delegate { OnLeave(new TabChangedEventArgs(this, plugin)); };
		}
		
		public event TabChangedEventHandler TabLeave;
		
		public event TabChangedEventHandler TabEnter;
		
		/// <summary>
		/// Occured when the tabcontrol is leaved
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnLeave(TabChangedEventArgs e){
			TabLeave(this, e);
		}

		/// <summary>
		/// Occured when the tabcontrol is entered
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnEnter(TabChangedEventArgs e){
			TabEnter(this, e);
		}
		
	}
}
