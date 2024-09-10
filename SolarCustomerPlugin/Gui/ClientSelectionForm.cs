/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-03-31
 * Time: 20:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Solarium.Controls;
using Solarium.Utils;
using Solarium.Frame;
using Solarium;
using Solarium.Bios;

namespace SolarCustomerPlugin.Gui
{
	/// <summary>
	/// Description of ClientSelectionForm.
	/// </summary>
	public partial class ClientSelectionForm : Form
	{
		private IMainFrame mf = null;
		
		private bool EditMode = false;
		private bool NewClientMode = false;
		
		private static int CLIENT_OTYPE = 10;
		private static int CLIENT_MAIN_COMP_CTYPE = 1010;
		
		private ClientControl clientControl = null;
		
		public RcObject SelectedClient{
			get 
			{
				if(clientControl != null){
					return clientControl.ClientObject;
				}
				return null;
			}
		}
		
		private ClientDialogResult result = null;
		
		public ClientSelectionForm(IMainFrame mf)
		{
			this.mf = mf;
			InitializeComponent();
			ccbCity.Codelist = Solarium.Bios.Bios.Codelists[CLIENT_MAIN_COMP_CTYPE, "city_codenum"];
		}
		
		void BSearchClick(object sender, EventArgs e)
		{
			if (tbSurname.Text.Length == 0 && tbName.Text.Length == 0 && ccbCity.SelectedItem == null) {
				DialogUtils.ShowInfo(mf, "Brak danych", "Proszę zdefiniować parametry wyszukiwania");
			}else{
				Cursor.Current = Cursors.WaitCursor;
				
				cbResult.Items.Clear();
				
				string clause = "";
				if(tbName.Text.Length>0){
					clause += "upper(name) like upper('" + tbName.Text + "%') and ";
				}
				if(tbSurname.Text.Length>0){
					clause += "upper(surname) like upper('" + tbSurname.Text + "%') and ";
				}
				if(ccbCity.Items.Count>0 && ccbCity.CurrentValue != null){
					clause += "city_codenum=" + ccbCity.CurrentValue.Codenum;
				}

				if(clause.EndsWith(" and ")){
					clause = clause.Substring(0, clause.Length - 5);
				}
				
				LinkedList<RcObject> clients = mf.Database.Bios.GetObjectsWithClause(CLIENT_OTYPE, clause);
				
				foreach(RcObject r in clients){
					cbResult.Items.Add(new Client(r));
				}
				
				if(cbResult.Items.Count>0){
					cbResult.SelectedIndex = 0;
				}else if(panel1.Controls.Count == 1 && panel1.Controls[0] is ClientControl){
					panel1.Controls.Clear();
				}
				
				Cursor.Current = Cursors.Default;
			}
		}
		
		void CbResultSelectedIndexChanged(object sender, EventArgs e)
		{
			//po zmianie wybranego itemka w liscie wynikow wyszukiwania 
			//sprawdzamy czy mamy juz cos w panelku z widokiem klienta
			//i jesli tak to tylko wypelniamy odpowiednimi danymi
			//a jesli nie to tworzymy nowy widoczek i dodajemy go do panelka
			try {
				if(panel1.Controls.Count == 1 && panel1.Controls[0] is ClientControl){
					((ClientControl)panel1.Controls[0]).ClientObject = ((Client)((ComboBox)sender).SelectedItem).ClientRcObject;
				}else{
					panel1.Controls.Clear();
					clientControl = new ClientControl(mf,((Client)((ComboBox)sender).SelectedItem).ClientRcObject);
					clientControl.Dock = DockStyle.Fill;
					clientControl.EnableEditMode(EditMode);
					panel1.Controls.Add(clientControl);
				}
			} catch (Exception ex) {
				//cos tutaj nie teges mogło pojsc...
				DialogUtils.ShowError(mf, /*"Problem",*/ "Coś poszło nie tak z wyszukiwaniem - spróbój ponownie",ex);
			}
		}
		
		void BEditDataClick(object sender, EventArgs e)
		{
			if(EditMode == false && clientControl != null){
				EditMode = true;
				clientControl.EnableEditMode(EditMode);
				//wylacz niepotrzebne przyciski tez na naszym glowym okienku
				EnableForm(false);
				bEditData.Text = "Zapisz";
				bEditData.Enabled = true;
				bCancelData.Enabled = true;
				
			}else if(EditMode == true && clientControl != null){
				
				clientControl.ModifyClientData();
				EditMode = false;
				clientControl.EnableEditMode(EditMode);
				bEditData.Text = "Edytuj dane";

				//a potem je wlacz
				EnableForm(true);
				
				//a takze pobierz dane z widoku klienta, zmodyfikuj komponent i odswiez go
				//na naszej liscie w comboboxie...
				//modyfikacja komponentu na podstawie ChangeSet i jakiejs nowej metody utworzonej w
				//kontrolce danych klienta. ChangeSet wypelniany danymi do zmiany np. na podstawie
				//porownania tego co mamy obecnie w TextBoxie z tym co mamy aktualnie w danym komponencie klienta
			}
		}
		
		void BChooseDataClick(object sender, EventArgs e)
		{
			this.result = new ClientDialogResult(DialogResult.OK, SelectedClient);
			this.Close();
		}

		void BAddDataClick(object sender, EventArgs e)
		{
			if(!NewClientMode){
				NewClientMode = true;
				clientControl = new ClientControl(mf);
				panel1.Controls.Clear();
				panel1.Controls.Add(clientControl);
				EnableForm(false);
				bAddData.Text = "Zapisz";
				bAddData.Enabled = true;
				bCancelData.Enabled = true;
			}else if (NewClientMode && clientControl!=null){
				clientControl.SaveNewClient();
				EnableForm(true);
				bAddData.Text = "Dodaj nowego";
				panel1.Controls.Clear();
			}
		}
		
		void BCancelDataClick(object sender, EventArgs e)
		{
			if(EditMode && clientControl!=null){
				bEditData.Text = "Edytuj dane";
				EditMode = false;
				clientControl.EnableEditMode(EditMode);
				EnableForm(true);
			}else if(!EditMode){
				this.result = new ClientDialogResult(DialogResult.Cancel, null);
				this.Close();
			}
		}
		
		private void EnableForm(bool enable){
			foreach(Control c in this.Controls){
				if(c is TextBox){
					((TextBox)c).Enabled = enable;
				} else if(c is ComboBox){
					((ComboBox)c).Enabled = enable;
				} else if(c is DateTimePicker){
					((DateTimePicker)c).Enabled = enable;
				} else if(c is Button){
					((Button)c).Enabled = enable;
				}
			}
		}
		
		public new virtual ClientDialogResult ShowDialog(){
			try {
				base.ShowDialog();
			} catch (Exception e) {
				DialogUtils.ShowError(mf, e);
			}
			return result;
		}
		
		public class ClientDialogResult{
			private DialogResult result = DialogResult.None;
			public DialogResult Result {
				get { return result; }
			}
			private RcObject client = null;
			public RcObject Client {
				get { return client; }
			}
			
			public ClientDialogResult(DialogResult result, RcObject client)
			{
				this.result = result;
				this.client = client;
			}
		}
	}
}
