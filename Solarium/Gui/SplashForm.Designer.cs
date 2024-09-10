/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-16
 * Time: 21:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Solarium.Gui
{
	partial class SplashForm
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
			this.lStatus = new System.Windows.Forms.Label();
			this.pbProgress = new System.Windows.Forms.ProgressBar();
			this.pbImage = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
			this.SuspendLayout();
			// 
			// lStatus
			// 
			this.lStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lStatus.Location = new System.Drawing.Point(0, 226);
			this.lStatus.Margin = new System.Windows.Forms.Padding(0);
			this.lStatus.Name = "lStatus";
			this.lStatus.Size = new System.Drawing.Size(410, 16);
			this.lStatus.TabIndex = 1;
			this.lStatus.Text = "Status";
			this.lStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pbProgress
			// 
			this.pbProgress.Location = new System.Drawing.Point(0, 210);
			this.pbProgress.Margin = new System.Windows.Forms.Padding(0);
			this.pbProgress.Name = "pbProgress";
			this.pbProgress.Size = new System.Drawing.Size(410, 16);
			this.pbProgress.TabIndex = 2;
			// 
			// pbImage
			// 
			this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.pbImage.BackColor = System.Drawing.Color.Transparent;
			this.pbImage.Location = new System.Drawing.Point(0, 0);
			this.pbImage.Margin = new System.Windows.Forms.Padding(0);
			this.pbImage.Name = "pbImage";
			this.pbImage.Size = new System.Drawing.Size(410, 210);
			this.pbImage.TabIndex = 3;
			this.pbImage.TabStop = false;
			// 
			// SplashForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(410, 242);
			this.Controls.Add(this.pbImage);
			this.Controls.Add(this.pbProgress);
			this.Controls.Add(this.lStatus);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SplashForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SplashForm";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ProgressBar pbProgress;
		private System.Windows.Forms.Label lStatus;
		private System.Windows.Forms.PictureBox pbImage;
	}
}
