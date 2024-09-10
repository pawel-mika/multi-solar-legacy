/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-07
 * Time: 23:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Solarium.Controls
{
	partial class SlaveDeviceControl
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
				mf.Database.Bios.ObjectModified-=new Solarium.Bios.BiosEventHandler(HandleObjectModified);
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
			this.components = new System.ComponentModel.Container();
			this.l_time = new System.Windows.Forms.Label();
			this.b_startPause = new Glass.GlassButton();
			this.b_stop = new Glass.GlassButton();
			this.l_status = new System.Windows.Forms.Label();
			this.cms_deviceControl = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.setNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.properitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tb_devName = new System.Windows.Forms.TextBox();
			this.tb_devId = new System.Windows.Forms.TextBox();
			this.lHeatingTime = new System.Windows.Forms.Label();
			this.cms_deviceControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// l_time
			// 
			this.l_time.BackColor = System.Drawing.Color.AliceBlue;
			this.l_time.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.l_time.Location = new System.Drawing.Point(6, 26);
			this.l_time.Margin = new System.Windows.Forms.Padding(2);
			this.l_time.Name = "l_time";
			this.l_time.Size = new System.Drawing.Size(169, 40);
			this.l_time.TabIndex = 1;
			this.l_time.Text = "00:00:00";
			this.l_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// b_startPause
			// 
			this.b_startPause.BackColor = System.Drawing.Color.Blue;
			this.b_startPause.Enabled = false;
			this.b_startPause.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.b_startPause.GlowColor = System.Drawing.Color.AliceBlue;
			this.b_startPause.Location = new System.Drawing.Point(6, 128);
			this.b_startPause.Margin = new System.Windows.Forms.Padding(2);
			this.b_startPause.Name = "b_startPause";
			this.b_startPause.Size = new System.Drawing.Size(92, 24);
			this.b_startPause.TabIndex = 2;
			this.b_startPause.Text = "start/pause";
			this.b_startPause.Click += new System.EventHandler(this.B_startPauseClick);
			// 
			// b_stop
			// 
			this.b_stop.BackColor = System.Drawing.Color.Blue;
			this.b_stop.Enabled = false;
			this.b_stop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.b_stop.GlowColor = System.Drawing.Color.AliceBlue;
			this.b_stop.Location = new System.Drawing.Point(102, 128);
			this.b_stop.Margin = new System.Windows.Forms.Padding(2);
			this.b_stop.Name = "b_stop";
			this.b_stop.Size = new System.Drawing.Size(73, 24);
			this.b_stop.TabIndex = 3;
			this.b_stop.Text = "stop";
			this.b_stop.Click += new System.EventHandler(this.B_stopClick);
			// 
			// l_status
			// 
			this.l_status.BackColor = System.Drawing.Color.AliceBlue;
			this.l_status.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.l_status.ForeColor = System.Drawing.Color.LimeGreen;
			this.l_status.Location = new System.Drawing.Point(6, 156);
			this.l_status.Margin = new System.Windows.Forms.Padding(2, 2, 2, 6);
			this.l_status.Name = "l_status";
			this.l_status.Size = new System.Drawing.Size(169, 18);
			this.l_status.TabIndex = 4;
			this.l_status.Text = "ready";
			this.l_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cms_deviceControl
			// 
			this.cms_deviceControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.setNameToolStripMenuItem,
									this.toolStripSeparator1,
									this.properitiesToolStripMenuItem});
			this.cms_deviceControl.Name = "contextMenuStrip1";
			this.cms_deviceControl.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.cms_deviceControl.Size = new System.Drawing.Size(127, 54);
			// 
			// setNameToolStripMenuItem
			// 
			this.setNameToolStripMenuItem.Name = "setNameToolStripMenuItem";
			this.setNameToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.setNameToolStripMenuItem.Text = "Set name";
			this.setNameToolStripMenuItem.Click += new System.EventHandler(this.SetNameToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(123, 6);
			// 
			// properitiesToolStripMenuItem
			// 
			this.properitiesToolStripMenuItem.Name = "properitiesToolStripMenuItem";
			this.properitiesToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.properitiesToolStripMenuItem.Text = "Properities";
			// 
			// tb_devName
			// 
			this.tb_devName.BackColor = System.Drawing.Color.AliceBlue;
			this.tb_devName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tb_devName.Enabled = false;
			this.tb_devName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tb_devName.Location = new System.Drawing.Point(42, 6);
			this.tb_devName.Margin = new System.Windows.Forms.Padding(2, 6, 2, 2);
			this.tb_devName.Name = "tb_devName";
			this.tb_devName.Size = new System.Drawing.Size(133, 16);
			this.tb_devName.TabIndex = 5;
			this.tb_devName.Text = "dev name";
			this.tb_devName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tb_devName.AcceptsTabChanged += new System.EventHandler(this.tb_nameTab);
			// 
			// tb_devId
			// 
			this.tb_devId.BackColor = System.Drawing.Color.AliceBlue;
			this.tb_devId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tb_devId.Enabled = false;
			this.tb_devId.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tb_devId.Location = new System.Drawing.Point(6, 6);
			this.tb_devId.Margin = new System.Windows.Forms.Padding(2, 6, 2, 2);
			this.tb_devId.Name = "tb_devId";
			this.tb_devId.Size = new System.Drawing.Size(32, 16);
			this.tb_devId.TabIndex = 6;
			this.tb_devId.Text = "ID";
			this.tb_devId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lHeatingTime
			// 
			this.lHeatingTime.BackColor = System.Drawing.Color.Transparent;
			this.lHeatingTime.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lHeatingTime.ForeColor = System.Drawing.Color.White;
			this.lHeatingTime.Location = new System.Drawing.Point(6, 70);
			this.lHeatingTime.Margin = new System.Windows.Forms.Padding(2);
			this.lHeatingTime.Name = "lHeatingTime";
			this.lHeatingTime.Size = new System.Drawing.Size(169, 16);
			this.lHeatingTime.TabIndex = 7;
			this.lHeatingTime.Text = "Heating time: 00:00:00";
			this.lHeatingTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SlaveDeviceControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightSteelBlue;
			this.Caption = "";
			this.ContextMenuStrip = this.cms_deviceControl;
			this.Controls.Add(this.lHeatingTime);
			this.Controls.Add(this.tb_devId);
			this.Controls.Add(this.l_status);
			this.Controls.Add(this.b_startPause);
			this.Controls.Add(this.b_stop);
			this.Controls.Add(this.tb_devName);
			this.Controls.Add(this.l_time);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "SlaveDeviceControl";
			this.Opacity = 150;
			this.Radius = 8;
			this.ShapeBorderStyle = DOALibrary.DOATransparentLabel.ShapeBorderStyles.ShapeBSFixedSingle;
			this.Size = new System.Drawing.Size(180, 180);
			this.Leave += new System.EventHandler(this.tb_nameTab);
			this.cms_deviceControl.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label lHeatingTime;
		private System.Windows.Forms.TextBox tb_devId;
		private System.Windows.Forms.ToolStripMenuItem properitiesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Label l_status;
		private System.Windows.Forms.TextBox tb_devName;
		private System.Windows.Forms.ToolStripMenuItem setNameToolStripMenuItem;
		private Glass.GlassButton b_startPause;
		private Glass.GlassButton b_stop;
		private System.Windows.Forms.Timer deviceTimer;
		private System.Timers.Timer operationTimer;
		private System.Windows.Forms.ContextMenuStrip cms_deviceControl;
		private System.Windows.Forms.Label l_time;
	}
}
