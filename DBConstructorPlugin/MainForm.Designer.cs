/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-07
 * Time: 20:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DBConstructorPlugin
{
	partial class MainForm
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
			this.tvOC = new System.Windows.Forms.TreeView();
			this.label1 = new System.Windows.Forms.Label();
			this.LDetails = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// tvOC
			// 
			this.tvOC.Location = new System.Drawing.Point(12, 36);
			this.tvOC.Name = "tvOC";
			this.tvOC.Size = new System.Drawing.Size(280, 328);
			this.tvOC.TabIndex = 0;
			this.tvOC.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvOCAfterSelect);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(280, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Objects/components:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LDetails
			// 
			this.LDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.LDetails.Location = new System.Drawing.Point(12, 367);
			this.LDetails.Name = "LDetails";
			this.LDetails.Size = new System.Drawing.Size(770, 40);
			this.LDetails.TabIndex = 2;
			this.LDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.panel1.Location = new System.Drawing.Point(298, 36);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(484, 328);
			this.panel1.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(794, 416);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tvOC);
			this.Controls.Add(this.LDetails);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label LDetails;
		private System.Windows.Forms.TreeView tvOC;
		private System.Windows.Forms.Label label1;
	}
}
