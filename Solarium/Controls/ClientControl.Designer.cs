/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-03-31
 * Time: 20:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Solarium.Controls
{
	partial class ClientControl
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientControl));
			this.label1 = new System.Windows.Forms.Label();
			this.tbName = new System.Windows.Forms.TextBox();
			this.tbSurname = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbStreet = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbHouseNo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbPostcode = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbCity = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tbPhone = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tbMobilePhone = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tbEmail = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label5 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.ccbAdAgreement = new Solarium.Controls.CodelistComboBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.tbBirthDay = new System.Windows.Forms.TextBox();
			this.tbBirthMonth = new System.Windows.Forms.TextBox();
			this.ccbProvince = new Solarium.Controls.CodelistComboBox();
			this.label16 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.ccbGender = new Solarium.Controls.CodelistComboBox();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(130, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Imię";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// tbName
			// 
			this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbName.Location = new System.Drawing.Point(3, 23);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(130, 20);
			this.tbName.TabIndex = 1;
			// 
			// tbSurname
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.tbSurname, 2);
			this.tbSurname.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbSurname.Location = new System.Drawing.Point(139, 23);
			this.tbSurname.Name = "tbSurname";
			this.tbSurname.Size = new System.Drawing.Size(266, 20);
			this.tbSurname.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(139, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(130, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Nazwisko";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// tbStreet
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.tbStreet, 2);
			this.tbStreet.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbStreet.Location = new System.Drawing.Point(3, 69);
			this.tbStreet.Name = "tbStreet";
			this.tbStreet.Size = new System.Drawing.Size(266, 20);
			this.tbStreet.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Location = new System.Drawing.Point(3, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(130, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "Ulica";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// tbHouseNo
			// 
			this.tbHouseNo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbHouseNo.Location = new System.Drawing.Point(275, 69);
			this.tbHouseNo.Name = "tbHouseNo";
			this.tbHouseNo.Size = new System.Drawing.Size(130, 20);
			this.tbHouseNo.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label4.Location = new System.Drawing.Point(275, 46);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(130, 20);
			this.label4.TabIndex = 6;
			this.label4.Text = "Nr domu/mieszkania";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// tbPostcode
			// 
			this.tbPostcode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbPostcode.Location = new System.Drawing.Point(3, 115);
			this.tbPostcode.Name = "tbPostcode";
			this.tbPostcode.Size = new System.Drawing.Size(130, 20);
			this.tbPostcode.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label6.Location = new System.Drawing.Point(3, 92);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(130, 20);
			this.label6.TabIndex = 10;
			this.label6.Text = "Kod pocztowy";
			this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// tbCity
			// 
			this.tbCity.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbCity.Location = new System.Drawing.Point(139, 115);
			this.tbCity.Name = "tbCity";
			this.tbCity.Size = new System.Drawing.Size(130, 20);
			this.tbCity.TabIndex = 13;
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label7.Location = new System.Drawing.Point(139, 92);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(130, 20);
			this.label7.TabIndex = 12;
			this.label7.Text = "Miejscowość";
			this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// tbPhone
			// 
			this.tbPhone.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbPhone.Location = new System.Drawing.Point(3, 161);
			this.tbPhone.Name = "tbPhone";
			this.tbPhone.Size = new System.Drawing.Size(130, 20);
			this.tbPhone.TabIndex = 15;
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label8.Location = new System.Drawing.Point(3, 138);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(130, 20);
			this.label8.TabIndex = 14;
			this.label8.Text = "Telefon";
			this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// tbMobilePhone
			// 
			this.tbMobilePhone.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbMobilePhone.Location = new System.Drawing.Point(139, 161);
			this.tbMobilePhone.Name = "tbMobilePhone";
			this.tbMobilePhone.Size = new System.Drawing.Size(130, 20);
			this.tbMobilePhone.TabIndex = 17;
			// 
			// label9
			// 
			this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label9.Location = new System.Drawing.Point(139, 138);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(130, 20);
			this.label9.TabIndex = 16;
			this.label9.Text = "Telefon kom.";
			this.label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// tbEmail
			// 
			this.tbEmail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbEmail.Location = new System.Drawing.Point(275, 161);
			this.tbEmail.Name = "tbEmail";
			this.tbEmail.Size = new System.Drawing.Size(130, 20);
			this.tbEmail.TabIndex = 19;
			// 
			// label10
			// 
			this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label10.Location = new System.Drawing.Point(275, 138);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(130, 20);
			this.label10.TabIndex = 18;
			this.label10.Text = "e-mail";
			this.label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbEmail, 2, 7);
			this.tableLayoutPanel1.Controls.Add(this.tbName, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label10, 2, 6);
			this.tableLayoutPanel1.Controls.Add(this.tbMobilePhone, 1, 7);
			this.tableLayoutPanel1.Controls.Add(this.label9, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.tbCity, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.tbPhone, 0, 7);
			this.tableLayoutPanel1.Controls.Add(this.label7, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.tbStreet, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.label8, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.label4, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.tbHouseNo, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.tbPostcode, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbSurname, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 8);
			this.tableLayoutPanel1.Controls.Add(this.label11, 1, 8);
			this.tableLayoutPanel1.Controls.Add(this.label12, 2, 8);
			this.tableLayoutPanel1.Controls.Add(this.label13, 3, 8);
			this.tableLayoutPanel1.Controls.Add(this.label14, 2, 4);
			this.tableLayoutPanel1.Controls.Add(this.label15, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.ccbAdAgreement, 3, 9);
			this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 0, 9);
			this.tableLayoutPanel1.Controls.Add(this.tbBirthDay, 1, 9);
			this.tableLayoutPanel1.Controls.Add(this.tbBirthMonth, 2, 9);
			this.tableLayoutPanel1.Controls.Add(this.ccbProvince, 2, 5);
			this.tableLayoutPanel1.Controls.Add(this.label16, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.ccbGender, 3, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 10;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(546, 230);
			this.tableLayoutPanel1.TabIndex = 20;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label5.Location = new System.Drawing.Point(3, 184);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(130, 20);
			this.label5.TabIndex = 20;
			this.label5.Text = "Data dodania";
			this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label11
			// 
			this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label11.Location = new System.Drawing.Point(139, 184);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(130, 20);
			this.label11.TabIndex = 21;
			this.label11.Text = "Dzień urodzin";
			this.label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label12
			// 
			this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label12.Location = new System.Drawing.Point(275, 184);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(130, 20);
			this.label12.TabIndex = 22;
			this.label12.Text = "Miesiąc urodzin";
			this.label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label13
			// 
			this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label13.Location = new System.Drawing.Point(411, 184);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(132, 20);
			this.label13.TabIndex = 23;
			this.label13.Text = "Zgoda na reklamę";
			this.label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label14
			// 
			this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label14.Location = new System.Drawing.Point(275, 92);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(130, 20);
			this.label14.TabIndex = 24;
			this.label14.Text = "Województwo";
			this.label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label15
			// 
			this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label15.Location = new System.Drawing.Point(411, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(132, 20);
			this.label15.TabIndex = 25;
			this.label15.Text = "Płeć";
			this.label15.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// ccbAdAgreement
			// 
			this.ccbAdAgreement.Codelist = null;
			this.ccbAdAgreement.CurrentValue = null;
			this.ccbAdAgreement.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ccbAdAgreement.FormattingEnabled = true;
			this.ccbAdAgreement.Location = new System.Drawing.Point(411, 207);
			this.ccbAdAgreement.Name = "ccbAdAgreement";
			this.ccbAdAgreement.Size = new System.Drawing.Size(132, 21);
			this.ccbAdAgreement.TabIndex = 27;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dateTimePicker1.Location = new System.Drawing.Point(3, 207);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(130, 20);
			this.dateTimePicker1.TabIndex = 28;
			// 
			// tbBirthDay
			// 
			this.tbBirthDay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbBirthDay.Location = new System.Drawing.Point(139, 207);
			this.tbBirthDay.Name = "tbBirthDay";
			this.tbBirthDay.Size = new System.Drawing.Size(130, 20);
			this.tbBirthDay.TabIndex = 29;
			// 
			// tbBirthMonth
			// 
			this.tbBirthMonth.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbBirthMonth.Location = new System.Drawing.Point(275, 207);
			this.tbBirthMonth.Name = "tbBirthMonth";
			this.tbBirthMonth.Size = new System.Drawing.Size(130, 20);
			this.tbBirthMonth.TabIndex = 30;
			// 
			// ccbProvince
			// 
			this.ccbProvince.Codelist = null;
			this.ccbProvince.CurrentValue = null;
			this.ccbProvince.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ccbProvince.FormattingEnabled = true;
			this.ccbProvince.Location = new System.Drawing.Point(275, 115);
			this.ccbProvince.Name = "ccbProvince";
			this.ccbProvince.Size = new System.Drawing.Size(130, 21);
			this.ccbProvince.TabIndex = 31;
			// 
			// label16
			// 
			this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label16.Location = new System.Drawing.Point(411, 46);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(132, 20);
			this.label16.TabIndex = 32;
			this.label16.Text = "Zdjęcie";
			this.label16.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(411, 69);
			this.pictureBox1.Name = "pictureBox1";
			this.tableLayoutPanel1.SetRowSpan(this.pictureBox1, 5);
			this.pictureBox1.Size = new System.Drawing.Size(132, 112);
			this.pictureBox1.TabIndex = 33;
			this.pictureBox1.TabStop = false;
			// 
			// ccbGender
			// 
			this.ccbGender.Codelist = null;
			this.ccbGender.CurrentValue = null;
			this.ccbGender.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ccbGender.FormattingEnabled = true;
			this.ccbGender.Location = new System.Drawing.Point(411, 23);
			this.ccbGender.Name = "ccbGender";
			this.ccbGender.Size = new System.Drawing.Size(132, 21);
			this.ccbGender.TabIndex = 34;
			// 
			// ClientControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "ClientControl";
			this.Size = new System.Drawing.Size(552, 236);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}
		private Solarium.Controls.CodelistComboBox ccbAdAgreement;
		private Solarium.Controls.CodelistComboBox ccbProvince;
		private Solarium.Controls.CodelistComboBox ccbGender;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox tbBirthMonth;
		private System.Windows.Forms.TextBox tbBirthDay;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox tbPhone;
		private System.Windows.Forms.TextBox tbMobilePhone;
		private System.Windows.Forms.TextBox tbEmail;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbCity;
		private System.Windows.Forms.TextBox tbHouseNo;
		private System.Windows.Forms.TextBox tbPostcode;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbStreet;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbSurname;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.Label label1;
	}
}
