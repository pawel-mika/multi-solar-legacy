/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-03-31
 * Time: 20:41
 */
 
using Solarium.Controls;
using Solarium;

namespace SolarCustomerPlugin.Gui
{
	partial class ClientSelectionForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.tbSurname = new System.Windows.Forms.TextBox();
			this.tbName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbResult = new System.Windows.Forms.ComboBox();
			this.bSearch = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.bEditData = new System.Windows.Forms.Button();
			this.bAddData = new System.Windows.Forms.Button();
			this.bChooseData = new System.Windows.Forms.Button();
			this.bCancelData = new System.Windows.Forms.Button();
			this.ccbCity = new Solarium.Controls.CodelistComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nazwisko";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbSurname
			// 
			this.tbSurname.Location = new System.Drawing.Point(12, 28);
			this.tbSurname.Name = "tbSurname";
			this.tbSurname.Size = new System.Drawing.Size(100, 20);
			this.tbSurname.TabIndex = 1;
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(118, 28);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(100, 20);
			this.tbName.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(118, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Imię";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(224, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Miejscowość";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbResult
			// 
			this.cbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbResult.FormattingEnabled = true;
			this.cbResult.Location = new System.Drawing.Point(12, 54);
			this.cbResult.Name = "cbResult";
			this.cbResult.Size = new System.Drawing.Size(550, 21);
			this.cbResult.TabIndex = 6;
			this.cbResult.SelectedIndexChanged += new System.EventHandler(this.CbResultSelectedIndexChanged);
			// 
			// bSearch
			// 
			this.bSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.bSearch.Location = new System.Drawing.Point(382, 9);
			this.bSearch.Name = "bSearch";
			this.bSearch.Size = new System.Drawing.Size(180, 39);
			this.bSearch.TabIndex = 7;
			this.bSearch.Text = "Szukaj";
			this.bSearch.UseVisualStyleBackColor = true;
			this.bSearch.Click += new System.EventHandler(this.BSearchClick);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Location = new System.Drawing.Point(12, 81);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(550, 266);
			this.panel1.TabIndex = 8;
			// 
			// bEditData
			// 
			this.bEditData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.bEditData.Location = new System.Drawing.Point(12, 353);
			this.bEditData.Name = "bEditData";
			this.bEditData.Size = new System.Drawing.Size(128, 39);
			this.bEditData.TabIndex = 10;
			this.bEditData.Text = "Edycja danych";
			this.bEditData.UseVisualStyleBackColor = true;
			this.bEditData.Click += new System.EventHandler(this.BEditDataClick);
			// 
			// bAddData
			// 
			this.bAddData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.bAddData.Location = new System.Drawing.Point(146, 353);
			this.bAddData.Name = "bAddData";
			this.bAddData.Size = new System.Drawing.Size(128, 39);
			this.bAddData.TabIndex = 11;
			this.bAddData.Text = "Dodaj nowego";
			this.bAddData.UseVisualStyleBackColor = true;
			this.bAddData.Click += new System.EventHandler(this.BAddDataClick);
			// 
			// bChooseData
			// 
			this.bChooseData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.bChooseData.Location = new System.Drawing.Point(434, 353);
			this.bChooseData.Name = "bChooseData";
			this.bChooseData.Size = new System.Drawing.Size(128, 39);
			this.bChooseData.TabIndex = 12;
			this.bChooseData.Text = "Wybierz";
			this.bChooseData.UseVisualStyleBackColor = true;
			this.bChooseData.Click += new System.EventHandler(this.BChooseDataClick);
			// 
			// bCancelData
			// 
			this.bCancelData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.bCancelData.Location = new System.Drawing.Point(300, 353);
			this.bCancelData.Name = "bCancelData";
			this.bCancelData.Size = new System.Drawing.Size(128, 39);
			this.bCancelData.TabIndex = 13;
			this.bCancelData.Text = "Anuluj";
			this.bCancelData.UseVisualStyleBackColor = true;
			this.bCancelData.Click += new System.EventHandler(this.BCancelDataClick);
			// 
			// ccbCity
			// 
			this.ccbCity.Codelist = null;
			this.ccbCity.CurrentValue = null;
			this.ccbCity.FormattingEnabled = true;
			this.ccbCity.Location = new System.Drawing.Point(224, 27);
			this.ccbCity.Name = "ccbCity";
			this.ccbCity.Size = new System.Drawing.Size(152, 21);
			this.ccbCity.TabIndex = 14;
			// 
			// ClientSelectionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(574, 400);
			this.Controls.Add(this.ccbCity);
			this.Controls.Add(this.bCancelData);
			this.Controls.Add(this.bChooseData);
			this.Controls.Add(this.bAddData);
			this.Controls.Add(this.bEditData);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.bSearch);
			this.Controls.Add(this.cbResult);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbSurname);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ClientSelectionForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ClientSelectionForm";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button bChooseData;
		private System.Windows.Forms.Button bCancelData;
		private System.Windows.Forms.Button bAddData;
		private Solarium.Controls.CodelistComboBox ccbCity;
		private System.Windows.Forms.Button bEditData;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button bSearch;
		private System.Windows.Forms.ComboBox cbResult;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.TextBox tbSurname;
		private System.Windows.Forms.Label label1;
	}
}
