/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-09-29
 * Time: 20:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Solarium.Controls
{
	partial class BedControl
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
			this.buttonStart = new Glass.GlassButton();
			this.buttonStop = new Glass.GlassButton();
			this.timerLabel = new System.Windows.Forms.Label();
			this.nameLabel = new System.Windows.Forms.Label();
			this.idLabel = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.selectedTimeLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonStart
			// 
			this.buttonStart.BackColor = System.Drawing.Color.Purple;
			this.buttonStart.Enabled = false;
			this.buttonStart.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.buttonStart.Location = new System.Drawing.Point(7, 133);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(90, 32);
			this.buttonStart.TabIndex = 4;
			this.buttonStart.Text = "-";
			this.buttonStart.Click += new System.EventHandler(this.ButtonStartClick);
			// 
			// buttonStop
			// 
			this.buttonStop.BackColor = System.Drawing.Color.Purple;
			this.buttonStop.Enabled = false;
			this.buttonStop.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.buttonStop.Location = new System.Drawing.Point(103, 133);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(90, 32);
			this.buttonStop.TabIndex = 5;
			this.buttonStop.Text = "-";
			this.buttonStop.Click += new System.EventHandler(this.ButtonStopClick);
			// 
			// timerLabel
			// 
			this.timerLabel.BackColor = System.Drawing.Color.Transparent;
			this.timerLabel.Font = new System.Drawing.Font("Trebuchet MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.timerLabel.ForeColor = System.Drawing.Color.White;
			this.timerLabel.Location = new System.Drawing.Point(7, 30);
			this.timerLabel.Name = "timerLabel";
			this.timerLabel.Size = new System.Drawing.Size(186, 39);
			this.timerLabel.TabIndex = 6;
			this.timerLabel.Text = "00:00:00";
			this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nameLabel
			// 
			this.nameLabel.BackColor = System.Drawing.Color.Transparent;
			this.nameLabel.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.nameLabel.ForeColor = System.Drawing.Color.White;
			this.nameLabel.Location = new System.Drawing.Point(37, 7);
			this.nameLabel.Margin = new System.Windows.Forms.Padding(3);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(156, 20);
			this.nameLabel.TabIndex = 7;
			this.nameLabel.Text = "Mega sun 9000";
			this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// idLabel
			// 
			this.idLabel.BackColor = System.Drawing.Color.Transparent;
			this.idLabel.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.idLabel.ForeColor = System.Drawing.Color.White;
			this.idLabel.Location = new System.Drawing.Point(7, 7);
			this.idLabel.Margin = new System.Windows.Forms.Padding(3);
			this.idLabel.Name = "idLabel";
			this.idLabel.Size = new System.Drawing.Size(24, 20);
			this.idLabel.TabIndex = 8;
			this.idLabel.Text = "01";
			this.idLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// statusLabel
			// 
			this.statusLabel.BackColor = System.Drawing.Color.Transparent;
			this.statusLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusLabel.ForeColor = System.Drawing.Color.White;
			this.statusLabel.Location = new System.Drawing.Point(7, 168);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(186, 23);
			this.statusLabel.TabIndex = 9;
			this.statusLabel.Text = "Gotowe";
			this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// selectedTimeLabel
			// 
			this.selectedTimeLabel.BackColor = System.Drawing.Color.Transparent;
			this.selectedTimeLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.selectedTimeLabel.ForeColor = System.Drawing.Color.Silver;
			this.selectedTimeLabel.Location = new System.Drawing.Point(7, 69);
			this.selectedTimeLabel.Name = "selectedTimeLabel";
			this.selectedTimeLabel.Size = new System.Drawing.Size(186, 16);
			this.selectedTimeLabel.TabIndex = 10;
			this.selectedTimeLabel.Text = "00:00:00";
			this.selectedTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BedControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.SlateBlue;
			this.Caption = "";
			this.Controls.Add(this.selectedTimeLabel);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.idLabel);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.timerLabel);
			this.Controls.Add(this.buttonStop);
			this.Controls.Add(this.buttonStart);
			this.ForeColor = System.Drawing.Color.Black;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "BedControl";
			this.Opacity = 128;
			this.Padding = new System.Windows.Forms.Padding(4);
			this.Radius = 16;
			this.ShapeBorderStyle = DOALibrary.DOATransparentLabel.ShapeBorderStyles.ShapeBSFixedSingle;
			this.Size = new System.Drawing.Size(200, 200);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label selectedTimeLabel;
		private Glass.GlassButton buttonStart;
		private Glass.GlassButton buttonStop;
		private System.Windows.Forms.Label timerLabel;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.Label idLabel;
		private System.Windows.Forms.Label statusLabel;
	}
}
