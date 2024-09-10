/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-03-31
 * Time: 20:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Solarium;
using Solarium.Bios;
using Solarium.Bios.Model;
using Solarium.Frame;
using Solarium.Utils;

namespace Solarium.Controls
{
	/// <summary>
	/// Description of ClientControl.
	/// </summary>
	public partial class ClientControl : UserControl
	{
		private IMainFrame mf = null;
		
		private static int CLIENT_OTYPE = 10;
		private static int CLIENT_MAIN_COMP_CTYPE = 1010;

		private RcObject clientObject = null;
		public RcObject ClientObject {
			get 
			{ return clientObject; }
			set 
			{
				clientObject = value;
				FillForm();
			}
		}
		
		public ClientControl()
		{
			InitializeComponent();
		}
		
 		public ClientControl(IMainFrame mf)
		{
			this.mf = mf;
			InitializeComponent();
			EnableForm(true);		
			
			TableLayoutPanelCellPosition pos = tableLayoutPanel1.GetPositionFromControl(ccbGender);
			tableLayoutPanel1.Controls.Remove(ccbGender);
			ccbGender = FormUtils.Instance.GetCodelistComboBox(Solarium.Bios.Bios.Codelists[CLIENT_MAIN_COMP_CTYPE, "sex_codenum"]);
			ccbGender.Dock = DockStyle.Fill;
			tableLayoutPanel1.Controls.Add(ccbGender, pos.Column, pos.Row);
			
			ccbProvince.Codelist = Solarium.Bios.Bios.Codelists[CLIENT_MAIN_COMP_CTYPE, "province_codenum"];
		}
 		
		/// <summary>
		/// Constructor for existing client.
		/// Displays client data.
		/// </summary>
		/// <param name="mf"></param>
		/// <param name="client"></param>
		public ClientControl(IMainFrame mf, RcObject client)
		{
			this.mf = mf;
			this.clientObject = client;
			if(client.Oid.Otype != CLIENT_OTYPE && client.MainComponent.ComponentId.RcCtype != CLIENT_MAIN_COMP_CTYPE){
				throw new BiosException("Not a client object/component!");
			}
			InitializeComponent();
			
			EnableForm(true);
			
			FillForm();
		}
		
		public ClientControl(RcObject client, bool editData)
		{
			this.clientObject = client;
			if(client.Oid.Otype != CLIENT_OTYPE && client.MainComponent.ComponentId.RcCtype != CLIENT_MAIN_COMP_CTYPE){
				throw new BiosException("Not a client object/component!");
			}
			InitializeComponent();
			
			EnableForm(editData);
			
			FillForm();
		}
		
		public void EnableEditMode(bool enable){
			EnableForm(enable);
		}
		
		public void ModifyClientData(){
			try {	
				RcComponent clientComp = mf.Database.Bios.GetMainComponentForObject(ClientObject.Oid);
				ChangeSet clientCs = clientComp.GetChangeSet();
	
				if(!Equals(ClientObject.MainComponent.GetString("surname"),tbSurname.Text)){
					clientCs.AddChange("surname", tbSurname.Text);
				}
				if(!Equals(ClientObject.MainComponent.GetString("name"),tbName.Text)){
					clientCs.AddChange("name", tbName.Text);
				}
				if(!Equals(ClientObject.MainComponent.GetString("mobile_phone"),tbMobilePhone.Text)){
					clientCs.AddChange("mobile_phone", tbMobilePhone.Text);			
				}
				if(!Equals(ClientObject.MainComponent.GetString("phone"),tbPhone.Text)){
					clientCs.AddChange("phone", tbPhone.Text);
				}
				if(!Equals(ClientObject.MainComponent.GetString("street"),tbStreet.Text)){
					clientCs.AddChange("street", tbStreet.Text);
				}
				if(!Equals(ClientObject.MainComponent.GetString("street_number"),tbHouseNo.Text)){
					clientCs.AddChange("street_number", tbHouseNo.Text);
				}
				if(!Equals(ClientObject.MainComponent.GetString("post_code"),tbPostcode.Text)){
					clientCs.AddChange("post_code", tbPostcode.Text);
				}
				if(tbBirthDay.Text.Length>0 && ClientObject.MainComponent.GetInt("day_born")!=Convert.ToInt32(tbBirthDay.Text)){
					clientCs.AddChange("day_born", Convert.ToInt32(tbBirthDay.Text));
				}
				if(tbBirthMonth.Text.Length>0 && ClientObject.MainComponent.GetInt("month_born")!=Convert.ToInt32(tbBirthMonth.Text)){
					clientCs.AddChange("month_born", Convert.ToInt32(tbBirthMonth.Text));
				}
				if(!Equals(clientObject.MainComponent.GetCodelistEntry("province_codenum").Codenum,
				           ccbProvince.CurrentValue.Codenum)) {
					clientCs.AddChange("province_codenum", ccbProvince.CurrentValue.Codenum);
				}
				if(!Equals(clientObject.MainComponent.GetCodelistEntry("sex_codenum").Codenum,
				           ccbGender.CurrentValue.Codenum)) {
					clientCs.AddChange("sex_codenum", ccbGender.CurrentValue.Codenum);
				}
				if(clientCs.Changes.Count>0){
					mf.Database.Bios.ModifyComponent(clientCs);
				}
			} catch (BiosException) {
				DialogUtils.ShowError(mf, "Bład", "Bład edycji obiektu klienta!");
			 }
		}
		
		public void SaveNewClient(){
			try {
				
				ObjectID clientOid = mf.Database.Bios.CreateObject(CLIENT_OTYPE);
				RcComponent clientComp = mf.Database.Bios.GetMainComponentForObject(clientOid);
				ChangeSet clientCs = clientComp.GetChangeSet();
				clientCs.AddChange("surname", tbSurname.Text);
				clientCs.AddChange("name", tbName.Text);
				clientCs.AddChange("mobile_phone", tbMobilePhone.Text);			
				clientCs.AddChange("phone", tbPhone.Text);
				clientCs.AddChange("street", tbStreet.Text);
				clientCs.AddChange("street_number", tbHouseNo.Text);
				clientCs.AddChange("post_code", tbPostcode.Text);
				
				mf.Database.Bios.ModifyComponent(clientCs);
			} catch (BiosException) {
				DialogUtils.ShowError(mf, "Bład", "Bład tworzenia obiektu klienta!");
			}
		}
		
		#region _private_methods

		 private void FillForm(){
			tbName.Text = clientObject.MainComponent.GetString("name");
			tbSurname.Text = clientObject.MainComponent.GetString("surname");
			tbStreet.Text = clientObject.MainComponent.GetString("street");
			tbHouseNo.Text = clientObject.MainComponent.GetString("street_number");
			tbPostcode.Text = clientObject.MainComponent.GetString("post_code");
			
			tbCity.Text = clientObject.MainComponent.GetCodelistEntry("city_codenum") != null?
				clientObject.MainComponent.GetCodelistEntry("city_codenum").Name:
				null;
			
			tbPhone.Text = clientObject.MainComponent.GetString("phone");
			tbMobilePhone.Text = clientObject.MainComponent.GetString("mobile_phone");
			tbEmail.Text = clientObject.MainComponent.GetString("email");
			
			//przykladowe 2 sposoby
			//pobranie i podmiana CCB z FormUtils
			TableLayoutPanelCellPosition pos = tableLayoutPanel1.GetPositionFromControl(ccbGender);
			tableLayoutPanel1.Controls.Remove(ccbGender);
			//hmm.... cos czasem sie wywala przy tworzeniu w FormUtils ze niby obiekt jest disposed...:/
			//TODO SPRAWDZIC TO!
			//ccbGender = FormUtils.Instance.GetCodelistComboBox(Solarium.Bios.Bios.Codelists[clientObject.MainComponent.RcCtype, "sex_codenum"]);
			ccbGender = new CodelistComboBox(Solarium.Bios.Bios.Codelists[clientObject.MainComponent.RcCtype, "sex_codenum"]);
			ccbGender.CurrentValue = clientObject.MainComponent.GetCodelistEntry("sex_codenum");
			ccbGender.Dock = DockStyle.Fill;
			tableLayoutPanel1.Controls.Add(ccbGender, pos.Column, pos.Row);

			//wypelnienie istniejacego danymi...
			ccbProvince.Codelist = Solarium.Bios.Bios.Codelists[clientObject.MainComponent.RcCtype, "province_codenum"];
			ccbProvince.CurrentValue = clientObject.MainComponent.GetCodelistEntry("province_codenum");
			
			ccbAdAgreement.Codelist = Solarium.Bios.Bios.Codelists[clientObject.MainComponent.RcCtype, "ad_agreed"];
			ccbAdAgreement.CurrentValue = clientObject.MainComponent.GetCodelistEntry("ad_agreed");
		}
		
		private void EnableForm(bool enable){
			foreach(Control c in this.tableLayoutPanel1.Controls){
				if(c is TextBox){
					((TextBox)c).Enabled = enable;
				} else if(c is ComboBox){
					((ComboBox)c).Enabled = enable;
				}else if(c is CodelistComboBox){
					((CodelistComboBox)c).Enabled = enable;
				} else if(c is DateTimePicker){
					((DateTimePicker)c).Enabled = enable;
				}
			}
		}
		
		#endregion

	}
}
