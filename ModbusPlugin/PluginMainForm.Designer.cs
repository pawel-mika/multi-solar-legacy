/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-11-27
 * Time: 19:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ModbusPlugin
{
	partial class PluginMainForm
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbSlave = new System.Windows.Forms.ComboBox();
			this.bRescan = new System.Windows.Forms.Button();
			this.bHardReset = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.bButtonsGet = new System.Windows.Forms.Button();
			this.tbButton2 = new System.Windows.Forms.TextBox();
			this.tbButton1 = new System.Windows.Forms.TextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.bGetStatus = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbSlave);
			this.groupBox1.Location = new System.Drawing.Point(9, 9);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(100, 46);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Slave device";
			// 
			// cbSlave
			// 
			this.cbSlave.FormattingEnabled = true;
			this.cbSlave.Location = new System.Drawing.Point(6, 19);
			this.cbSlave.Name = "cbSlave";
			this.cbSlave.Size = new System.Drawing.Size(88, 21);
			this.cbSlave.TabIndex = 0;
			this.cbSlave.SelectedIndexChanged += new System.EventHandler(this.OnSelectedSlaveChanged);
			// 
			// bRescan
			// 
			this.bRescan.Location = new System.Drawing.Point(525, 12);
			this.bRescan.Name = "bRescan";
			this.bRescan.Size = new System.Drawing.Size(97, 43);
			this.bRescan.TabIndex = 2;
			this.bRescan.Text = "Rescan network";
			this.bRescan.UseVisualStyleBackColor = true;
			this.bRescan.Click += new System.EventHandler(this.BRescanClick);
			// 
			// bHardReset
			// 
			this.bHardReset.Location = new System.Drawing.Point(215, 12);
			this.bHardReset.Name = "bHardReset";
			this.bHardReset.Size = new System.Drawing.Size(97, 43);
			this.bHardReset.TabIndex = 24;
			this.bHardReset.Text = "Hard reset";
			this.bHardReset.UseVisualStyleBackColor = true;
			this.bHardReset.Click += new System.EventHandler(this.BHardResetClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.bButtonsGet);
			this.groupBox2.Controls.Add(this.tbButton2);
			this.groupBox2.Controls.Add(this.tbButton1);
			this.groupBox2.Controls.Add(this.label35);
			this.groupBox2.Controls.Add(this.label34);
			this.groupBox2.Location = new System.Drawing.Point(9, 431);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(207, 66);
			this.groupBox2.TabIndex = 25;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Buttons status";
			// 
			// bButtonsGet
			// 
			this.bButtonsGet.Location = new System.Drawing.Point(137, 14);
			this.bButtonsGet.Name = "bButtonsGet";
			this.bButtonsGet.Size = new System.Drawing.Size(64, 47);
			this.bButtonsGet.TabIndex = 22;
			this.bButtonsGet.Text = "Start/Stop";
			this.bButtonsGet.UseVisualStyleBackColor = true;
			this.bButtonsGet.Click += new System.EventHandler(this.BButtonsGetClick);
			// 
			// tbButton2
			// 
			this.tbButton2.Location = new System.Drawing.Point(92, 41);
			this.tbButton2.Name = "tbButton2";
			this.tbButton2.Size = new System.Drawing.Size(40, 20);
			this.tbButton2.TabIndex = 21;
			this.tbButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbButton1
			// 
			this.tbButton1.Location = new System.Drawing.Point(92, 15);
			this.tbButton1.Name = "tbButton1";
			this.tbButton1.Size = new System.Drawing.Size(40, 20);
			this.tbButton1.TabIndex = 20;
			this.tbButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(6, 40);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(80, 20);
			this.label35.TabIndex = 2;
			this.label35.Text = "Button 2";
			this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(6, 13);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(80, 20);
			this.label34.TabIndex = 1;
			this.label34.Text = "Button 1";
			this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new System.Drawing.Point(9, 61);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(613, 364);
			this.tabControl1.TabIndex = 27;
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(605, 338);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Status";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// bGetStatus
			// 
			this.bGetStatus.Location = new System.Drawing.Point(112, 12);
			this.bGetStatus.Name = "bGetStatus";
			this.bGetStatus.Size = new System.Drawing.Size(97, 43);
			this.bGetStatus.TabIndex = 28;
			this.bGetStatus.Text = "Refresh status";
			this.bGetStatus.UseVisualStyleBackColor = true;
			this.bGetStatus.Click += new System.EventHandler(this.BGetStatusClick);
			// 
			// PluginMainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(634, 505);
			this.Controls.Add(this.bGetStatus);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.bHardReset);
			this.Controls.Add(this.bRescan);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PluginMainForm";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "ModbusPluginMainForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PluginMainFormFormClosed);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button bGetStatus;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.TextBox tbButton1;
		private System.Windows.Forms.TextBox tbButton2;
		private System.Windows.Forms.Button bButtonsGet;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button bHardReset;
		private System.Windows.Forms.Button bRescan;
		private System.Windows.Forms.ComboBox cbSlave;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
