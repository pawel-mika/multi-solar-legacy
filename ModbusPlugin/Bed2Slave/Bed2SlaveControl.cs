/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-07-11
 * Time: 09:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Solarium.Bios;
using Solarium.Frame;
using Solarium.Controls;
using Solarium.Controller;
using Solarium.Settings;
using Solarium.Utils;

namespace ModbusPlugin.Bed2Slave
{
	/// <summary>
	/// Description of Bed2SlaveControl.
	/// 
	/// TODO: dodaæ aktualizacje po zapisie w RcObjectEditControl...?
	/// </summary>
	public partial class Bed2SlaveControl : UserControl
	{
		private IMainFrame mf = null;
		
		private LinkedList<RcObject> engineObjects = new LinkedList<RcObject>();
		private LinkedList<RcObject> controlObjects = new LinkedList<RcObject>();
		
		public Bed2SlaveControl(IMainFrame mf)
		{
			this.mf = mf;
			
			InitializeComponent();
			
			PostInit();
			
			mf.Database.Bios.ObjectModified += new BiosEventHandler(OnObjectModified);
		}
		
		private void PostInit(){
			ToolTip tt = new ToolTip();
			tt.SetToolTip(bBedAdd, "Adds new engine object (otype: 40) to the database");
			tt.SetToolTip(bBedRemove, "Removes currently selected engine object from the database");
			tt.SetToolTip(bSlaveAdd, "Adds new control object (otype: 70) to the database");
			tt.SetToolTip(bSlaveRemove, "Removes currently selected control object from the database");
			
//			ThreadUtils.AsyncRun(getDbData, engineObjects, controlObjects);
			ThreadUtils.AsyncRun(getDbData);
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void getDbData(object param) {
			try {
				engineObjects = mf.Database.Bios.GetObjectsWithClause(40,null);
				
				FormUtils.ListBoxCrossThreadClear(lbEngine);
				foreach(RcObject o in engineObjects){
					FormUtils.ListBoxCrossThreadAddItem(new EngineListEntry(o), lbEngine);
				}
				
				FormUtils.ListBoxCrossThreadClear(lbSlave);
				controlObjects = mf.Database.Bios.GetObjectsWithClause(70,null);
				foreach(RcObject o in controlObjects){
					bool assigned = false;
					ObjectID cOid = o.Oid;
					foreach(EngineListEntry ele in lbEngine.Items) {
						if(ele.EngineObject.MainComponent.GetInt("control_oid") == cOid.Oid &&
						   ele.EngineObject.MainComponent.GetInt("control_otype") == cOid.Otype) {
							assigned = true;
							break;
						}
					}
					FormUtils.ListBoxCrossThreadAddItem(new ControlListEntry(o, assigned), lbSlave);
				}
			} catch (Exception) {
				DialogUtils.ShowError(mf, "B³¹d", "Wyst¹pi³ problem podczas pobierania listy urz¹dzeñ z bazy!");
			}		
		}
		
		private void FillListBoxes(){
			Cursor.Current = Cursors.WaitCursor;
			lbEngine.Items.Clear();
			foreach(RcObject o in engineObjects){
				lbEngine.Items.Add(new EngineListEntry(o));
			}
			
			lbSlave.Items.Clear();
			foreach(RcObject o in controlObjects){
				bool assigned = false;
				ObjectID cOid = o.Oid;
				foreach(EngineListEntry ele in lbEngine.Items) {
					if(ele.EngineObject.MainComponent.GetInt("control_oid") == cOid.Oid &&
					   ele.EngineObject.MainComponent.GetInt("control_otype") == cOid.Otype) {
						assigned = true;
						break;
					}
				}
				lbSlave.Items.Add(new ControlListEntry(o, assigned));
			}
			Cursor.Current = Cursors.Default;
		}
		
		private void OnObjectModified(object sender, BiosEvent be) {
			RcObject o = null;
			try {
				foreach(RcObject r in engineObjects){
					if(r.Oid.Oid == be.AffectedObjectId.Oid && r.Oid.Otype == be.AffectedObjectId.Otype) {
						o = r;
						break;
					}
				}
				if(o != null){
					engineObjects.Remove(o);
					engineObjects.AddLast(be.AffectedObject);
					o = null;
				}
				foreach(RcObject r in controlObjects){
					if(r.Oid.Oid == be.AffectedObjectId.Oid && r.Oid.Otype == be.AffectedObjectId.Otype) {
						o = r;
						break;
					}
				}
				if(o != null){
					controlObjects.Remove(o);
					controlObjects.AddLast(be.AffectedObject);
					o = null;
				}
			} catch (Exception ex) {
				throw new Exception(string.Format("Class: {0}\nMethod: {1}", this.GetType().FullName,
                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()), ex);
			}
			FillListBoxes();
		}
		
		private class EngineListEntry{
			private RcObject engineObject = null;
			public RcObject EngineObject {
				get { return engineObject; }
				set { engineObject = value; }
			}
	
			private bool slaveAssigned = false;
			public bool SlaveAssigned {
				get { return slaveAssigned; }
				set { slaveAssigned = value; }
			}
			
			public EngineListEntry(RcObject engine){
				this.engineObject = engine;
				this.slaveAssigned = (engine.MainComponent.FieldFilled("control_oid") && 
				                      engine.MainComponent.FieldFilled("control_otype"));
			}
			
			public override string ToString()
			{
				int coid = 0, cotype = 0;
				try{
					coid = engineObject.MainComponent.GetInt("control_oid");
					cotype = engineObject.MainComponent.GetInt("control_otype");
				}catch(Exception){
					
				}
				return string.Format("[{0}] ({1}, {2}) {3}, {4}, {5}",
				                     slaveAssigned?"+":"-",
				                     engineObject.Oid.Oid,
				                     engineObject.Oid.Otype,
				                     engineObject.MainComponent.GetString("name"),
				                     coid, cotype);
			}
		}
		
		private class ControlListEntry{
			private RcObject controlObject = null;
			public RcObject ControlObject {
				get { return controlObject; }
				set { controlObject = value; }
			}
			
			private int slaveId = 0;
			public int SlaveId {
				get { return slaveId; }
				set { slaveId = value; }
			}
			
			private bool assignedToEngine = false;
			public bool AssignedToEngine {
				get { return assignedToEngine; }
				set { assignedToEngine = value; }
			}
			
			public ControlListEntry(RcObject control){
				this.controlObject = control;
				slaveId = controlObject.MainComponent.FieldFilled("slave_id") ? 
					controlObject.MainComponent.GetInt("slave_id") : 0;
					
			}
			
			public ControlListEntry(RcObject control, bool assigned){
				this.controlObject = control;
				slaveId = controlObject.MainComponent.FieldFilled("slave_id") ? 
					controlObject.MainComponent.GetInt("slave_id") : 0;
				this.assignedToEngine = assigned;
			}
			
			public override string ToString()
			{
				string si = "";
				try{
					si = controlObject.MainComponent.GetInt("slave_id").ToString();
				}catch(Exception){
					
				}
				return string.Format("[{0}] ({1}, {2}) {3}, {4}",
				                     assignedToEngine?"+":"-",
				                     controlObject.Oid.Oid, 
				                     controlObject.Oid.Otype, 
				                     si, 
				                     controlObject.MainComponent.GetString("name"));
			}
		}
			
		
		void LbEngineSelectedIndexChanged(object sender, EventArgs e)
		{
			panel1.Controls.Clear();
			if(lbEngine.SelectedItem != null) {
				RcObjectEditControl ro = new RcObjectEditControl(mf, ((EngineListEntry)lbEngine.SelectedItem).EngineObject);
				ro.Location = new Point(0, 0);
				ro.Width = panel1.Width;
				ro.Height = panel1.Height;
				ro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
				panel1.Controls.Add(ro);
			}
		}
		
		void LbSlaveSelectedIndexChanged(object sender, EventArgs e)
		{
			panel1.Controls.Clear();
			if(lbSlave.SelectedItem != null) {
				RcObjectEditControl ro = new RcObjectEditControl(mf, ((ControlListEntry)lbSlave.SelectedItem).ControlObject);
				ro.Location = new Point(0, 0);
				ro.Width = panel1.Width;
				ro.Height = panel1.Height;
				ro.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
				panel1.Controls.Add(ro);
			}
		}
		
		void BBedAddClick(object sender, EventArgs e)
		{
			RcObject createdObj = null;
			ObjectID oid = mf.Database.Bios.CreateObject(40);
			createdObj = mf.Database.Bios.GetObject(oid);
			engineObjects.AddLast(createdObj);
			lbEngine.Items.Add(new EngineListEntry(createdObj));
		}
		
		void BBedRemoveClick(object sender, EventArgs e)
		{
			if(lbEngine.SelectedItem != null){
				RcObject selected = ((EngineListEntry)lbEngine.SelectedItem).EngineObject;
				mf.Database.Bios.DeleteObject(selected.Oid);
				engineObjects.Remove(selected);
				lbEngine.Items.Remove(lbEngine.SelectedItem);
			}
			
		}
		
		void BSlaveAddClick(object sender, EventArgs e)
		{
			RcObject createdObj = null;
			ObjectID oid = mf.Database.Bios.CreateObject(70);
			createdObj = mf.Database.Bios.GetObject(oid);
			controlObjects.AddLast(createdObj);
			lbSlave.Items.Add(new ControlListEntry(createdObj, false));
		}
		
		void BSlaveRemoveClick(object sender, EventArgs e)
		{
			if(lbSlave.SelectedItem != null){
				RcObject selected = ((ControlListEntry)lbSlave.SelectedItem).ControlObject;
				mf.Database.Bios.DeleteObject(selected.Oid);
				controlObjects.Remove(selected);
				lbSlave.Items.Remove(lbSlave.SelectedItem);
			}
		}
	}
}
