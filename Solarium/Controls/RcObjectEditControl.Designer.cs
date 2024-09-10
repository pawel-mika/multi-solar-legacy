/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-07-11
 * Time: 12:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Solarium.Controls
{
	partial class RcObjectEditControl
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
			this.lHeader = new System.Windows.Forms.Label();
			this.cbObject = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.bAccept = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lHeader
			// 
			this.lHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lHeader.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lHeader.Location = new System.Drawing.Point(3, 0);
			this.lHeader.Name = "lHeader";
			this.lHeader.Size = new System.Drawing.Size(354, 20);
			this.lHeader.TabIndex = 0;
			this.lHeader.Text = "(0, 0) No name";
			this.lHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbObject
			// 
			this.cbObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.cbObject.FormattingEnabled = true;
			this.cbObject.Location = new System.Drawing.Point(3, 23);
			this.cbObject.Name = "cbObject";
			this.cbObject.Size = new System.Drawing.Size(354, 21);
			this.cbObject.TabIndex = 1;
			this.cbObject.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Location = new System.Drawing.Point(3, 50);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(354, 149);
			this.panel1.TabIndex = 2;
			// 
			// bAccept
			// 
			this.bAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bAccept.Location = new System.Drawing.Point(223, 205);
			this.bAccept.Name = "bAccept";
			this.bAccept.Size = new System.Drawing.Size(64, 32);
			this.bAccept.TabIndex = 3;
			this.bAccept.Text = "Accept";
			this.bAccept.UseVisualStyleBackColor = true;
			this.bAccept.Click += new System.EventHandler(this.BAcceptClick);
			// 
			// bCancel
			// 
			this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bCancel.Location = new System.Drawing.Point(293, 205);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(64, 32);
			this.bCancel.TabIndex = 4;
			this.bCancel.Text = "Cancel";
			this.bCancel.UseVisualStyleBackColor = true;
			this.bCancel.Click += new System.EventHandler(this.BCancelClick);
			// 
			// RcObjectEditControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bAccept);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.cbObject);
			this.Controls.Add(this.lHeader);
			this.Name = "RcObjectEditControl";
			this.Size = new System.Drawing.Size(360, 240);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button bCancel;
		private System.Windows.Forms.Button bAccept;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox cbObject;
		private System.Windows.Forms.Label lHeader;
	}
}
