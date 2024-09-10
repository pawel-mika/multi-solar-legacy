/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-07-22
 * Time: 22:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ModbusPlugin.XMLConfig
{
	partial class XMLConfig
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
			this.label1 = new System.Windows.Forms.Label();
			this.cbHeatingRelay = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbCoolingRelay = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.cbStartButtonAddress = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.cbStopButtonAddress = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.bSave = new System.Windows.Forms.Button();
			this.bReload = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.tbKeyFilterTime = new System.Windows.Forms.TextBox();
			this.tbKeyHoldTime = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 21);
			this.label1.TabIndex = 0;
			this.label1.Text = "Heating relay";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbHeatingRelay
			// 
			this.cbHeatingRelay.FormattingEnabled = true;
			this.cbHeatingRelay.Location = new System.Drawing.Point(137, 4);
			this.cbHeatingRelay.Name = "cbHeatingRelay";
			this.cbHeatingRelay.Size = new System.Drawing.Size(64, 21);
			this.cbHeatingRelay.TabIndex = 1;
			this.cbHeatingRelay.SelectedIndexChanged += new System.EventHandler(this.CbHeatingRelaySelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(207, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 21);
			this.label2.TabIndex = 2;
			this.label2.Text = "[COIL_ADDR_RELAY_0]";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(207, 31);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 21);
			this.label3.TabIndex = 5;
			this.label3.Text = "[COIL_ADDR_RELAY_1]";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbCoolingRelay
			// 
			this.cbCoolingRelay.FormattingEnabled = true;
			this.cbCoolingRelay.Location = new System.Drawing.Point(137, 31);
			this.cbCoolingRelay.Name = "cbCoolingRelay";
			this.cbCoolingRelay.Size = new System.Drawing.Size(64, 21);
			this.cbCoolingRelay.TabIndex = 4;
			this.cbCoolingRelay.SelectedIndexChanged += new System.EventHandler(this.CbCoolingRelaySelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(3, 30);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 21);
			this.label4.TabIndex = 3;
			this.label4.Text = "Cooling relay";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Enabled = false;
			this.label5.Location = new System.Drawing.Point(207, 58);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(128, 21);
			this.label5.TabIndex = 8;
			this.label5.Text = "[COIL_ADDR_RELAY_1]";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBox2
			// 
			this.comboBox2.Enabled = false;
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(137, 58);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(64, 21);
			this.comboBox2.TabIndex = 7;
			// 
			// label6
			// 
			this.label6.Enabled = false;
			this.label6.Location = new System.Drawing.Point(3, 57);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(128, 21);
			this.label6.TabIndex = 6;
			this.label6.Text = "Cooling relay";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Enabled = false;
			this.label7.Location = new System.Drawing.Point(207, 85);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(128, 21);
			this.label7.TabIndex = 11;
			this.label7.Text = "[COIL_ADDR_RELAY_1]";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBox3
			// 
			this.comboBox3.Enabled = false;
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Location = new System.Drawing.Point(137, 85);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(64, 21);
			this.comboBox3.TabIndex = 10;
			// 
			// label8
			// 
			this.label8.Enabled = false;
			this.label8.Location = new System.Drawing.Point(3, 84);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(128, 21);
			this.label8.TabIndex = 9;
			this.label8.Text = "Cooling relay";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(207, 112);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(128, 21);
			this.label9.TabIndex = 14;
			this.label9.Text = "[BIT_ADDR_KEY_1]";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbStartButtonAddress
			// 
			this.cbStartButtonAddress.FormattingEnabled = true;
			this.cbStartButtonAddress.Location = new System.Drawing.Point(137, 112);
			this.cbStartButtonAddress.Name = "cbStartButtonAddress";
			this.cbStartButtonAddress.Size = new System.Drawing.Size(64, 21);
			this.cbStartButtonAddress.TabIndex = 13;
			this.cbStartButtonAddress.SelectedIndexChanged += new System.EventHandler(this.CbStartButtonAddressSelectedIndexChanged);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(3, 111);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(128, 21);
			this.label10.TabIndex = 12;
			this.label10.Text = "Start button address";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(207, 139);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(128, 21);
			this.label11.TabIndex = 17;
			this.label11.Text = "[BIT_ADDR_KEY_2]";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbStopButtonAddress
			// 
			this.cbStopButtonAddress.FormattingEnabled = true;
			this.cbStopButtonAddress.Location = new System.Drawing.Point(137, 139);
			this.cbStopButtonAddress.Name = "cbStopButtonAddress";
			this.cbStopButtonAddress.Size = new System.Drawing.Size(64, 21);
			this.cbStopButtonAddress.TabIndex = 16;
			this.cbStopButtonAddress.SelectedIndexChanged += new System.EventHandler(this.CbStopButtonAddressSelectedIndexChanged);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(3, 138);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(128, 21);
			this.label12.TabIndex = 15;
			this.label12.Text = "Stop button address";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bSave
			// 
			this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bSave.Location = new System.Drawing.Point(3, 303);
			this.bSave.Name = "bSave";
			this.bSave.Size = new System.Drawing.Size(64, 32);
			this.bSave.TabIndex = 18;
			this.bSave.Text = "Save";
			this.bSave.UseVisualStyleBackColor = true;
			this.bSave.Click += new System.EventHandler(this.BSaveClick);
			// 
			// bReload
			// 
			this.bReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bReload.Location = new System.Drawing.Point(73, 303);
			this.bReload.Name = "bReload";
			this.bReload.Size = new System.Drawing.Size(64, 32);
			this.bReload.TabIndex = 19;
			this.bReload.Text = "Reload";
			this.bReload.UseVisualStyleBackColor = true;
			this.bReload.Click += new System.EventHandler(this.BReloadClick);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(3, 165);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(128, 21);
			this.label13.TabIndex = 20;
			this.label13.Text = "Key filter time";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbKeyFilterTime
			// 
			this.tbKeyFilterTime.Location = new System.Drawing.Point(137, 166);
			this.tbKeyFilterTime.Name = "tbKeyFilterTime";
			this.tbKeyFilterTime.Size = new System.Drawing.Size(64, 20);
			this.tbKeyFilterTime.TabIndex = 21;
			// 
			// tbKeyHoldTime
			// 
			this.tbKeyHoldTime.Location = new System.Drawing.Point(137, 192);
			this.tbKeyHoldTime.Name = "tbKeyHoldTime";
			this.tbKeyHoldTime.Size = new System.Drawing.Size(64, 20);
			this.tbKeyHoldTime.TabIndex = 23;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(3, 191);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(128, 21);
			this.label14.TabIndex = 22;
			this.label14.Text = "Key hold time";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ButtonConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tbKeyHoldTime);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.tbKeyFilterTime);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.bReload);
			this.Controls.Add(this.bSave);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.cbStopButtonAddress);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.cbStartButtonAddress);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.comboBox3);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cbCoolingRelay);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbHeatingRelay);
			this.Controls.Add(this.label1);
			this.Name = "ButtonConfig";
			this.Size = new System.Drawing.Size(605, 338);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbKeyHoldTime;
		private System.Windows.Forms.TextBox tbKeyFilterTime;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button bReload;
		private System.Windows.Forms.Button bSave;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox cbStopButtonAddress;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cbStartButtonAddress;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbCoolingRelay;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbHeatingRelay;
		private System.Windows.Forms.Label label1;
	}
}
