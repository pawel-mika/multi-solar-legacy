/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-07-11
 * Time: 12:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Solarium.Controls
{
	partial class DbFieldControl
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
			this.lField = new System.Windows.Forms.Label();
			this.tbValue = new System.Windows.Forms.TextBox();
			this.lType = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lField
			// 
			this.lField.Location = new System.Drawing.Point(3, 0);
			this.lField.Name = "lField";
			this.lField.Size = new System.Drawing.Size(90, 24);
			this.lField.TabIndex = 0;
			this.lField.Text = "label1";
			this.lField.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbValue
			// 
			this.tbValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tbValue.Location = new System.Drawing.Point(99, 3);
			this.tbValue.Name = "tbValue";
			this.tbValue.Size = new System.Drawing.Size(100, 20);
			this.tbValue.TabIndex = 1;
			this.tbValue.TextChanged += new System.EventHandler(this.TbValueTextChanged);
			// 
			// lType
			// 
			this.lType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lType.Location = new System.Drawing.Point(205, 0);
			this.lType.Name = "lType";
			this.lType.Size = new System.Drawing.Size(52, 23);
			this.lType.TabIndex = 2;
			this.lType.Text = "label1";
			this.lType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DbFieldControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lType);
			this.Controls.Add(this.tbValue);
			this.Controls.Add(this.lField);
			this.Name = "DbFieldControl";
			this.Size = new System.Drawing.Size(260, 24);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label lType;
		private System.Windows.Forms.Label lField;
		private System.Windows.Forms.TextBox tbValue;
	}
}
