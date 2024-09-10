/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-07-11
 * Time: 12:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Solarium.Bios;
using Solarium.Frame;
using Solarium.Controller;
using Solarium.Settings;
using Solarium.Utils;

namespace Solarium.Controls
{
	/// <summary>
	/// Description of RcObjectEditControl.
	/// </summary>
	public partial class RcObjectEditControl : UserControl
	{
		private IMainFrame mf = null;
		private RcObject editedObject = null;
		public RcObject EditedObject {
			get { return editedObject; }
			set { 
				editedObject = value; 
				PostInit();
			}
		}
		
		private Dictionary<RcComponent, ChangeSet> modifiedComponents = new Dictionary<RcComponent, ChangeSet> ();
		
		public RcObjectEditControl(IMainFrame mf, RcObject rcObject)
		{
			this.mf = mf;
			this.editedObject = rcObject;
			InitializeComponent();
			
			PostInit();
		}
		
		private void PostInit() {
			cbObject.Items.Clear();
			cbObject.Items.Add(editedObject.MainComponent);
			foreach(RcComponent c in editedObject.DataComponents){
				cbObject.Items.Add(c);
			}
			cbObject.SelectedItem = editedObject.MainComponent;
		}
		
		
		private void UpdateHeader() {
			UpdateHeader(null);
		}
		
		private void UpdateHeader(RcComponent comp) {
			if(comp == null) {
				comp = (RcComponent)cbObject.SelectedItem;
			}
			lHeader.Text = string.Format("({0}, {1}) {2} [table: {3}]", 
				                             comp.ComponentId.RcOtype,
				                             comp.ComponentId.RcCtype, 
				                             mf.Database.Bios.GetBiosComponentType(comp.ComponentId.RcCtype).Name,
				                             mf.Database.Bios.GetBiosComponentType(comp.ComponentId.RcCtype).CTable);
		}
		
		private void FillPanel(){
			int shift = 0;
			RcComponent comp = (RcComponent)cbObject.SelectedItem;
			panel1.Controls.Clear();
			foreach(string s in comp.ComponentData.Keys){
				object v = comp.ComponentData[s];
				DbFieldControl dbf = new DbFieldControl(s, v, true);
				dbf.Location = new Point(0, shift);
				dbf.Width = panel1.Width;
				dbf.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
				shift += dbf.Height;
				panel1.Controls.Add(dbf);
			}
		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateHeader();
			
			FillPanel();
		}
		
		void BAcceptClick(object sender, EventArgs e)
		{
			UpdateObject();
		}
		
		void BCancelClick(object sender, EventArgs e)
		{
			
		}
		
		private void CancelChanges(){
			
		}
		
		private void UpdateObject(){
			try{
				CollectChanges();
				foreach(RcComponent r in modifiedComponents.Keys){
					mf.Database.Bios.ModifyComponent(modifiedComponents[r]);
				}
				editedObject = mf.Database.Bios.GetObject(editedObject.Oid);
				PostInit();
			} catch(BiosException bex) {
				DialogUtils.ShowError(mf, new Exception(string.Format("Class: {0}\nMethod: {1}",
                                  this.GetType().FullName,
                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                  bex));
			}
		}
		
		private void CollectChanges(){
			RcComponent comp = (RcComponent)cbObject.SelectedItem;
			foreach(DbFieldControl d in panel1.Controls){
				if(d.IsChanged){
					if(modifiedComponents.ContainsKey(comp)){
						modifiedComponents[comp].AddChange(d.FieldName, d.FieldValue);
					} else {
						ChangeSet cs = new ChangeSet(comp);
						cs.AddChange(d.FieldName, d.FieldValue);
						modifiedComponents.Add(comp, cs);
					}
				}
			}
		}
		
//		private ChangeSet FindChangeSet(RcComponent comp) {
//			foreach(ChangeSet cs in modifiedComponents){
//				if(cs.ComponentId.RcOid == comp.ComponentId.RcOid && 
//				   cs.ComponentId.RcOtype == comp.ComponentId.RcOtype &&
//				   cs.ComponentId.RcOcc == comp.ComponentId.RcOcc &&
//				   cs.ComponentId.RcCtype == comp.ComponentId.RcCtype &&) {
//					
//				}
//			}
//		}
		
//		/// <summary>
//		/// Check if component data was modified
//		/// </summary>
//		/// <returns></returns>
//		private bool IsComponentModified(){
//			foreach(DbFieldControl d in panel1.Controls){
//				if(d.IsChanged){
//					return true;
//				}
//			}
//			return false;
//		}
		
		/// <summary>
		/// Check if objects components was modified (so if the object is modified)
		/// </summary>
		/// <returns></returns>
		public bool IsObjectModified(){
			if(modifiedComponents.Count>0){
				return true;
			}
//			foreach(RcComponent r in modifiedComponents.Keys){
//				if(modifiedComponents[r] != null){
//					return true;
//				}
//			}
			return false;
		}
	}
}
