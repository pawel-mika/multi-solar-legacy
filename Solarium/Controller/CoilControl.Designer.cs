/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-11-14
 * Time: 22:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Solarium.Controller
{
	partial class CoilControl
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
			this.tbValue = new System.Windows.Forms.TextBox();
			this.buttonWriteTrue = new System.Windows.Forms.Button();
			this.buttonWriteFalse = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbValue
			// 
			this.tbValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbValue.Location = new System.Drawing.Point(100, 2);
			this.tbValue.Margin = new System.Windows.Forms.Padding(0);
			this.tbValue.Name = "tbValue";
			this.tbValue.ReadOnly = true;
			this.tbValue.Size = new System.Drawing.Size(50, 20);
			this.tbValue.TabIndex = 1;
			// 
			// buttonWriteTrue
			// 
			this.buttonWriteTrue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonWriteTrue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.buttonWriteTrue.Location = new System.Drawing.Point(175, 1);
			this.buttonWriteTrue.Margin = new System.Windows.Forms.Padding(1);
			this.buttonWriteTrue.Name = "buttonWriteTrue";
			this.buttonWriteTrue.Size = new System.Drawing.Size(22, 22);
			this.buttonWriteTrue.TabIndex = 3;
			this.buttonWriteTrue.Text = "1";
			this.buttonWriteTrue.UseVisualStyleBackColor = true;
			// 
			// buttonWriteFalse
			// 
			this.buttonWriteFalse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonWriteFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.buttonWriteFalse.Location = new System.Drawing.Point(151, 1);
			this.buttonWriteFalse.Margin = new System.Windows.Forms.Padding(1);
			this.buttonWriteFalse.Name = "buttonWriteFalse";
			this.buttonWriteFalse.Size = new System.Drawing.Size(22, 22);
			this.buttonWriteFalse.TabIndex = 4;
			this.buttonWriteFalse.Text = "0";
			this.buttonWriteFalse.UseVisualStyleBackColor = true;
			// 
			// CoilControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.buttonWriteFalse);
			this.Controls.Add(this.buttonWriteTrue);
			this.Controls.Add(this.tbValue);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "CoilControl";
			this.Size = new System.Drawing.Size(200, 24);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button buttonWriteFalse;
		private System.Windows.Forms.Button buttonWriteTrue;
		private System.Windows.Forms.TextBox tbValue;
		private System.Windows.Forms.Label label1;
	}
}
