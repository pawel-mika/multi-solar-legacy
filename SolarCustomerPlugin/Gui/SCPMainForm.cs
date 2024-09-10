/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-03
 * Time: 14:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Solarium;
using Solarium.Bios;
using Solarium.Controller;
using Solarium.Controls;
using Solarium.DataModel;
using Solarium.Frame;
using Solarium.Utils;

namespace SolarCustomerPlugin.Gui
{
	/// <summary>
	/// Description of SCPMainForm.
	/// </summary>
	public partial class SCPMainForm : Form
	{
		private IMainFrame mf = null;
		
		delegate void SDCParamDelegate(SlaveDeviceControl sdc);
		
		private int[] fryTimes = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,20,25,30};

		private ISlaveDeviceControl selectedSDC = null;
		private TimeSpan selectedTime = TimeSpan.Zero;
		
		public SCPMainForm(IMainFrame mf)
		{
			this.mf = mf;
			InitializeComponent();
			try {
				PostInit();
			} catch (Exception ex) {
				DialogUtils.ShowError(mf, "Error",
				                            new Exception(string.Format("Class: {0}\nMethod: {1}",
                                                  this.GetType().FullName,
                                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                                  ex));
			}
		}
		
		#region _public_methods

		#endregion

		#region _private_methods

		private void PostInit(){
//			//set times on listBox...
//			foreach(int i in fryTimes){
//				lbFryTimes.Items.Add(i.ToString());
//			}
			
			//set slaveDeviceControlsListView
			lvSdc.FullRowSelect = true;
			lvSdc.LabelEdit = false;
			lvSdc.View = View.Details;
			lvSdc.MultiSelect = false;
			lvSdc.OwnerDraw = true;
			lvSdc.Scrollable = true;
			//lvSdc.DrawItem += new DrawListViewItemEventHandler(LvSdc_OnDrawItem);
			lvSdc.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(LvSdc_OnDrawColumnHeader);
			lvSdc.DrawSubItem += new DrawListViewSubItemEventHandler(LvSdc_OnDrawSubItem);
			
			lvSdc.Columns.Add("Id",40,HorizontalAlignment.Center);
			lvSdc.Columns.Add("Nazwa",180,HorizontalAlignment.Center);
			lvSdc.Columns.Add("Czas",80,HorizontalAlignment.Center);
			lvSdc.Columns.Add("Status",90,HorizontalAlignment.Center);
			foreach(ISlaveDeviceControl sdc in mf.Network.SlaveDevices){
				ListViewItem lvi = new ListViewItem(new string[]{
				                                    	sdc.DeviceId.ToString(),
				                                    	sdc.DeviceName, 
				                                    	sdc.HeatingTime.ToString(),
				                                    	sdc.CurrentState.StateString});
				lvi.Tag = sdc;
				sdc.TimerTicked += new SlaveDeviceControlEventHandler(OnSlaveDeviceTimerTicked);
				sdc.StatusChanged += new SlaveDeviceControlEventHandler(OnSlaveDeviceStatusChanged);
				lvSdc.Items.Add(lvi);
			}
			
			mf.Network.SlaveAdded += new ModbusNetworkEventHandler(OnSlaveAdded);
			mf.Network.SlaveRemoved += new ModbusNetworkEventHandler(OnSlaveRemoved);
		}

		private void OnSlaveDeviceTimerTicked(object sender, SlaveDeviceControlEvent e){
			foreach(ListViewItem it in lvSdc.Items){
				if(e.SlaveDeviceControl.Equals(it.Tag)){
					string s = e.SlaveDeviceControl.CurrentTimerValue.ToString();
					it.SubItems[2].Text = s;
					it.SubItems[3].Text = e.SlaveDeviceControl.CurrentState.StateString;
				}
			}
		}
		
		private void OnSlaveDeviceStatusChanged(object sender, SlaveDeviceControlEvent e){
			foreach(ListViewItem it in lvSdc.Items){
				if(e.SlaveDeviceControl.Equals(it.Tag)){
					string s = e.SlaveDeviceControl.CurrentTimerValue.ToString();
					it.SubItems[2].Text = s;
					it.SubItems[3].Text = e.SlaveDeviceControl.CurrentState.StateString;
				}
			}
			lvSdc.Update();
		}
		
		private void OnSlaveAdded(object sender, ModbusNetworkEvent e){
			AddSlaveToList(e.SlaveDeviceControl);
		}

		private void OnSlaveRemoved(object sender, ModbusNetworkEvent e){
			RemoveSlaveFromList(e.SlaveDeviceControl);
		}

		private void AddSlaveToList(ISlaveDeviceControl sdc){
			if(lvSdc.InvokeRequired){
				lvSdc.BeginInvoke( new SDCParamDelegate( AddSlaveToList ), new object[]{sdc});
				return;
			}				
			ListViewItem lvi = new ListViewItem(new string[]{
				                                    	sdc.DeviceId.ToString(),
				                                    	sdc.DeviceName, 
				                                    	sdc.HeatingTime.ToString(),
				                                    	sdc.CurrentState.StateString});
			lvi.Tag = sdc;
			sdc.TimerTicked += new SlaveDeviceControlEventHandler(OnSlaveDeviceTimerTicked);
			lvSdc.Items.Add(lvi);
		}
		
		private void RemoveSlaveFromList(ISlaveDeviceControl sdc){
			if(lvSdc.InvokeRequired){
				lvSdc.BeginInvoke( new SDCParamDelegate( RemoveSlaveFromList ), new object[]{sdc});
				return;
			}
			foreach(ListViewItem it in lvSdc.Items){
				if(sdc.Equals(it.Tag)){
					lvSdc.Items.Remove(it);
				}
			}
		}
		
		private void LvSdc_OnDrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e){
			e.DrawDefault = true;
		}
		
		private void LvSdc_OnDrawItem(object sender, DrawListViewItemEventArgs e)
		{
		    if ((e.State & ListViewItemStates.Selected) != 0) {
		        // Draw the background and focus rectangle for a selected item.
	        	e.Graphics.FillRectangle(Brushes.LightSteelBlue, e.Bounds);
		        e.DrawFocusRectangle();
			} else {
		        // Draw the background for an unselected item.
		        e.Graphics.FillRectangle(Brushes.White, e.Bounds);
//		        using (LinearGradientBrush brush = 
//		               new LinearGradientBrush(e.Bounds, Color.Orange, Color.Maroon, LinearGradientMode.Horizontal)) {
//					e.Graphics.FillRectangle(brush, e.Bounds);
//				}
		    }
		    // Draw the item text for views other than the Details view.
//		    if (this.View == View.Details) {
//		        e.DrawText();
//		    }
		    if(e.Item.Tag != null && e.Item.Tag is ISlaveDeviceControl){
		    	e.DrawText();
		    }else{
				e.DrawText();
		    }
		}
		
		// Handle draw SubItem for listView
		private void LvSdc_OnDrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			ISlaveDeviceControl sdc = null;
			
			if(e.Item.Tag != null && e.Item.Tag is ISlaveDeviceControl){
				sdc = (ISlaveDeviceControl)e.Item.Tag;
			}
			
			if ((e.ItemState & ListViewItemStates.Selected) != 0) {
				// Draw the background and focus rectangle for a selected item.
				if(sdc != null && sdc.CurrentState.State == BedState.EState.READY){
					e.Graphics.FillRectangle(Brushes.LightSteelBlue, e.Bounds);
					e.DrawFocusRectangle(e.Bounds);
				} else if(sdc != null && sdc.CurrentState.State != BedState.EState.READY){
					e.Graphics.FillRectangle(Brushes.LightSalmon, e.Bounds);
					//e.DrawFocusRectangle(e.Bounds);
				}
			} else {
				// Draw the background for an unselected item.
				if(sdc != null && sdc.CurrentState.State == BedState.EState.READY){
					e.Graphics.FillRectangle(Brushes.White, e.Bounds);
				} else if(sdc != null && sdc.CurrentState.State != BedState.EState.READY){
					e.Graphics.FillRectangle(Brushes.LightSalmon, e.Bounds);
				}
			}
			
			if(sdc != null){
		    	e.DrawText();
		    }
		}

		private void UpdateStatus(){
			string s = "";
			if(selectedSDC != null && selectedSDC.CurrentState.State != BedState.EState.READY){
				s = "Niestety - wybrane przez Ciebie łóżko jest aktualnie zajęte! Proszę wybrać inne lub " +
					"poczekać na zwolnienie wybranego.";
			}else if(selectedSDC != null && selectedTime != TimeSpan.Zero){
				float c = ((ServiceObject)lbFryTimes.SelectedItem).Service.MainComponent.GetFloat("price");
				s = string.Format("łóżko {0} - {1} na czas {2} za kwotę {3} zł", 
				                  selectedSDC.DeviceId, selectedSDC.DeviceName, selectedTime.ToString(), c);
			} else if(selectedSDC != null && selectedTime == TimeSpan.Zero){
				s = string.Format("łóżko {0} - {1}. \r\nWybierz czas!", 
				                  selectedSDC.DeviceId, selectedSDC.DeviceName);
			} else if(selectedSDC == null && selectedTime != TimeSpan.Zero){
				s = string.Format("czas {0}. \r\nWybierz urządzenie!", selectedTime.ToString());
			}
			lDetails.Text = s;
		}
		
		private void TryToEnableOkButton(){
			if(selectedSDC != null && selectedSDC.CurrentState.State == BedState.EState.READY && selectedTime != TimeSpan.Zero){
				button1.Enabled = true;
			} else {
				//tu ma być false - chwilowo odblokowałem!
				button1.Enabled = false;
			}
		}
		
		#endregion
		
		void OnItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if(e.Item.Tag != null && e.Item.Tag is ISlaveDeviceControl){
				lbFryTimes.Items.Clear();
				selectedTime = TimeSpan.Zero;
				selectedSDC = (ISlaveDeviceControl)e.Item.Tag;
				foreach(RcObject ob in selectedSDC.DbServices){
					lbFryTimes.Items.Add(new ServiceObject(ob));
				}
				TryToEnableOkButton();
				UpdateStatus();
			}
		}
		
		void OnSelectedIndexChanged(object sender, EventArgs e)
		{
			if(sender.Equals(lbFryTimes)){
				if(lbFryTimes.SelectedIndex>=0){
//					string s = lbFryTimes.Items[lbFryTimes.SelectedIndex].ToString();
					double s = (double)((ServiceObject)lbFryTimes.SelectedItem).Service.MainComponent.GetDecimal("working_time");
//					selectedTime = TimeSpan.FromMinutes(Int16.Parse(s));
					selectedTime = TimeSpan.FromMinutes(s);
					TryToEnableOkButton();
					UpdateStatus();
				} else {
					selectedTime = TimeSpan.Zero;
				}
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			selectedSDC.HeatingTime = selectedTime;

			if(this.panel1.Controls.Count>0 && this.panel1.Controls[0] is ClientControl){
				ClientControl cc = (ClientControl)this.panel1.Controls[0];
				Visit v = new Visit(mf, cc.ClientObject.Oid.Oid, cc.ClientObject.Oid.Otype,
				                    mf.MainFrameUI.CurrentUser.WorkerOid,
				                    mf.MainFrameUI.CurrentUser.WorkerObject.Oid.Otype,
				                    0,0);
				//dodajemy informacje o zakupionym service
				RcObject o = ((ServiceObject)lbFryTimes.SelectedItem).Service;
				v.ServicesBought.AddLast(new Visit.Service(o.Oid.Oid, o.Oid.Otype));
				v.SaveVisit();
				
				selectedSDC.CurrentClient = cc.ClientObject;
				
			} else {
				//jesli nie wybrano klienta...
				Visit v = new Visit(mf, 0, 0,
				                    mf.MainFrameUI.CurrentUser.WorkerOid,
				                    mf.MainFrameUI.CurrentUser.WorkerObject.Oid.Otype,
				                    0,0);
				//dodajemy informacje o zakupionym service
				RcObject o = ((ServiceObject)lbFryTimes.SelectedItem).Service;
				v.ServicesBought.AddLast(new Visit.Service(o.Oid.Oid, o.Oid.Otype));
				v.SaveVisit();
			}
			
			this.Dispose();
			((Control)selectedSDC).Focus();
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			ClientSelectionForm csf = new ClientSelectionForm(mf);
			ClientSelectionForm.ClientDialogResult cdr =  csf.ShowDialog();
			if(cdr!=null && cdr.Result == DialogResult.OK && cdr.Client != null){
				ClientControl cc = new ClientControl(cdr.Client, false);
				cc.Dock = DockStyle.Fill;
				this.panel1.Controls.Clear();
				this.panel1.Controls.Add(cc); //????????????????????
			}
		}
		
		private class ServiceObject{
			private RcObject serviceObject = null;
			public RcObject Service {
				get { return serviceObject; }
			}
			
			public ServiceObject(RcObject rcObject){
				this.serviceObject = rcObject;
			}
			
			public int Time {
				get { return (int)serviceObject.MainComponent.GetDecimal("working_time"); }
			}
			
			public override string ToString()
			{
				return string.Format("{0:00}min / {1} zł", 
				                     serviceObject.MainComponent.GetDecimal("working_time"),
				                     serviceObject.MainComponent.GetFloat("price"));
			}
			
		}
	}
}
