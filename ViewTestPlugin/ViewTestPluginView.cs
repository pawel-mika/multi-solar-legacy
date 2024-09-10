/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-15
 * Time: 17:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Solarium;
using Solarium.Frame;
using Solarium.Bios;
using Solarium.Utils;

namespace ViewTestPlugin
{
	/// <summary>
	/// Description of ViewTestPluginView.
	/// </summary>
	public partial class ViewTestPluginView : UserControl
	{
		private IMainFrame mf = null;
		private ObjectID oid = null;
		private RcComponent tmpComp = null;

		public ViewTestPluginView(IMainFrame mf)
		{
			this.mf = mf;
			InitializeComponent();
		}
		
		void bCreateObjectClick(object sender, EventArgs e)
		{
			try{
				int otype = Convert.ToInt32(tbCreateObOtype.Text);

				oid = mf.Database.Bios.CreateObject(otype);
				tmpComp = mf.Database.Bios.GetMainComponentForObject(oid);
				
				lStatus.Text = oid.ToString();
				tbGetMainCompOid.Text = oid.Oid.ToString();
				tbGetMainCompOtype.Text = oid.Otype.ToString();
				tbCreateCompOid.Text = oid.Oid.ToString();
				tbCreateCompOtype.Text = oid.Otype.ToString();
				tbModCompOid.Text = oid.Oid.ToString();
				tbModCompOtype.Text = oid.Otype.ToString();
				tbModCompCtype.Text = tmpComp.RcCtype.ToString();
				tbModCompOcc.Text = tmpComp.RcOcc.ToString();
			} catch (Exception ex) {
				DialogUtils.ShowError(mf, new Exception(string.Format("Class: {0}\nMethod: {1}",
                                                  this.GetType().FullName,
                                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                                  ex));
			}
		}
		
		void bGetMainCompClick(object sender, EventArgs e)
		{
			try {
				oid = new ObjectID(Convert.ToInt32(tbGetMainCompOid.Text),Convert.ToInt32(tbGetMainCompOtype.Text));
				if(oid!=null){
					tmpComp = mf.Database.Bios.GetMainComponentForObject(oid);
					
					lStatus.Text = tmpComp.ToString();
					tbCreateCompOtype.Text = tmpComp.RcOtype.ToString();
					tbCreateCompOid.Text = tmpComp.RcOid.ToString();
					tbModCompOtype.Text = tmpComp.RcOtype.ToString();
					tbModCompOid.Text = tmpComp.RcOid.ToString();
					tbModCompCtype.Text = tmpComp.RcCtype.ToString();
					tbModCompOcc.Text = tmpComp.RcOcc.ToString();
				}
			} catch (Exception ex) {
				DialogUtils.ShowError(mf, new Exception(string.Format("Class: {0}\nMethod: {1}",
                                                  this.GetType().FullName,
                                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                                  ex));
			}
		}
		
		void bModifyCompClick(object sender, EventArgs e)
		{
			try {
				string type = "";
				if(cbModCompType.SelectedItem != null){
					type = (string)cbModCompType.SelectedItem;
				}else{
					DialogUtils.ShowError(mf,"Błąd","Wybierz typ danych z comboboxa.");
					return;
				}
				
				oid = new ObjectID(Convert.ToInt32(tbModCompOid.Text),Convert.ToInt32(tbModCompOtype.Text));
				ComponentID tmpCompId = new ComponentID(oid, Convert.ToInt32(tbModCompCtype.Text), Convert.ToInt32(tbModCompOcc.Text));
				
				if(oid!=null && tmpCompId!=null){
					tmpComp = mf.Database.Bios.GetComponent(tmpCompId);
					
					lStatus.Text = tmpComp.ToString();
					ChangeSet cs = tmpComp.GetChangeSet();
					
					object val = null;
					switch(type){
						case "int":
							val = Convert.ToInt32(tbModCompValue.Text);
							break;
						case "string":
							val = Convert.ToString(tbModCompValue.Text);
							break;
						case "datetime":
							val = Convert.ToDateTime(tbModCompValue.Text);
							break;
						default:
							DialogUtils.ShowError(mf,"Info", "Wybrany typ danych nie jest jeszcze zaimplementowany...");
							break;
					}
					cs.AddChange(tbModCompField.Text, val);
					mf.Database.Bios.ModifyComponent(cs);
					tmpComp = mf.Database.Bios.GetComponent(tmpCompId);
					
					lStatus.Text = tmpComp.ToString();
				}
			} catch (Exception ex) {
				DialogUtils.ShowError(mf, new Exception(string.Format("Class: {0}\nMethod: {1}",
                                                  this.GetType().FullName,
                                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                                  ex));
			}
		}
		
		void BCreateCompClick(object sender, EventArgs e)
		{
			try{
				int rcCtype = Convert.ToInt32(tbCreateCompCtype.Text);
				oid = new ObjectID(Convert.ToInt32(tbCreateCompOid.Text),Convert.ToInt32(tbCreateCompOtype.Text));
				
				ComponentID cid = mf.Database.Bios.CreateComponent(oid,rcCtype);
				
				lStatus.Text = cid.ToString();
				tbModCompOtype.Text = cid.RcOtype.ToString();
				tbModCompOid.Text = cid.RcOid.ToString();
				tbModCompCtype.Text = cid.RcCtype.ToString();
				tbModCompOcc.Text = cid.RcOcc.ToString();
			} catch (Exception ex) {
				DialogUtils.ShowError(mf, new Exception(string.Format("Class: {0}\nMethod: {1}",
                                                  this.GetType().FullName,
                                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                                  ex));
			}
		}
		
		void BGetCompClick(object sender, EventArgs e)
		{
			try{
				ComponentID cid = new ComponentID(Convert.ToInt32(tbGetCompOid.Text),
				                                  Convert.ToInt32(tbGetCompOtype.Text),
				                                  Convert.ToInt32(tbGetCompCtype.Text),
				                                  Convert.ToInt32(tbGetCompOcc.Text));
				
				RcComponent rcComp = mf.Database.Bios.GetComponent(cid);
				
				lStatus.Text = rcComp.ToString();
				tbModCompOtype.Text = rcComp.ComponentId.RcOtype.ToString();
				tbModCompOid.Text = rcComp.ComponentId.RcOid.ToString();
				tbModCompCtype.Text = rcComp.ComponentId.RcCtype.ToString();
				tbModCompOcc.Text = rcComp.ComponentId.RcOcc.ToString();
			} catch (Exception ex) {
				DialogUtils.ShowError(mf, new Exception(string.Format("Class: {0}\nMethod: {1}",
                                                  this.GetType().FullName,
                                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                                  ex));
			}
		}
		
		void BGetObjectClick(object sender, EventArgs e)
		{
			try {
				oid = new ObjectID(Convert.ToInt32(tbGetObjectOid.Text),Convert.ToInt32(tbGetObjectOtype.Text));
				if(oid!=null){
					RcObject rcObj = mf.Database.Bios.GetObject(oid);

					lStatus.Text = rcObj.ToString();
				} 			
			}catch (Exception ex) {
				DialogUtils.ShowError(mf, new Exception(string.Format("Class: {0}\nMethod: {1}",
                                                  this.GetType().FullName,
                                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                                  ex));
			}
		}
	}
}
