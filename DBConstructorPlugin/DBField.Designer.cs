/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-07
 * Time: 23:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DBConstructorPlugin
{
	partial class DBField
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
			this.cbType = new System.Windows.Forms.ComboBox();
			this.tbName = new System.Windows.Forms.TextBox();
			this.cbSelected = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// cbType
			// 
			this.cbType.FormattingEnabled = true;
			this.cbType.Location = new System.Drawing.Point(3, 3);
			this.cbType.Name = "cbType";
			this.cbType.Size = new System.Drawing.Size(120, 21);
			this.cbType.TabIndex = 0;
			// 
			// tbName
			// 
			this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tbName.Location = new System.Drawing.Point(129, 4);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(120, 20);
			this.tbName.TabIndex = 1;
			// 
			// cbSelected
			// 
			this.cbSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbSelected.Location = new System.Drawing.Point(255, 4);
			this.cbSelected.Name = "cbSelected";
			this.cbSelected.Size = new System.Drawing.Size(13, 20);
			this.cbSelected.TabIndex = 2;
			this.cbSelected.Text = "checkBox1";
			this.cbSelected.UseVisualStyleBackColor = true;
			// 
			// DBField
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cbSelected);
			this.Controls.Add(this.tbName);
			this.Controls.Add(this.cbType);
			this.Name = "DBField";
			this.Size = new System.Drawing.Size(271, 27);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.CheckBox cbSelected;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.ComboBox cbType;
	}
}
