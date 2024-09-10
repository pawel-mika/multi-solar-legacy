/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-04
 * Time: 18:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using SolarCustomerPlugin;

namespace SolarCustomerPlugin.Gui
{
	/// <summary>
	/// Description of SDCList.
	/// </summary>
	public class SDCListView : ListView
	{
		public SDCListView()
		{
			this.FullRowSelect = true;
			this.LabelEdit = false;
			this.View = View.Details;
			this.MultiSelect = false;
			this.OwnerDraw = true;
//			this.BeforeLabelEdit += new LabelEditEventHandler(EListView_BeforeLabelEdit);
			
			this.Scrollable = true;
//			editBox = new TextBox();
//			editBox.Name = "eBox";
		}
		
		protected override void OnDrawItem(DrawListViewItemEventArgs e)
		{
		    if ((e.State & ListViewItemStates.Selected) != 0) {
		        // Draw the background and focus rectangle for a selected item.
		        e.Graphics.FillRectangle(Brushes.Maroon, e.Bounds);
		        e.DrawFocusRectangle();
			} else {
		        // Draw the background for an unselected item.
		        using (LinearGradientBrush brush = 
		               new LinearGradientBrush(e.Bounds, Color.Orange, Color.Maroon, LinearGradientMode.Horizontal)) {
					e.Graphics.FillRectangle(brush, e.Bounds);
				}
		    }
		
		    // Draw the item text for views other than the Details view.
		    if (this.View == View.Details) {
		        e.DrawText();
		    }
		    
			base.OnDrawItem(e);
		}
	}
}
