/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-07-11
 * Time: 09:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ModbusPlugin.Bed2Slave
{
	partial class Bed2SlaveControl
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
				mf.Database.Bios.ObjectModified-=new Solarium.Bios.BiosEventHandler(OnObjectModified);
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
			this.lbEngine = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbSlave = new System.Windows.Forms.ListBox();
			this.bBedAdd = new System.Windows.Forms.Button();
			this.bSlaveAdd = new System.Windows.Forms.Button();
			this.bBedRemove = new System.Windows.Forms.Button();
			this.bSlaveRemove = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// lbEngine
			// 
			this.lbEngine.FormattingEnabled = true;
			this.lbEngine.HorizontalScrollbar = true;
			this.lbEngine.Location = new System.Drawing.Point(3, 19);
			this.lbEngine.Name = "lbEngine";
			this.lbEngine.Size = new System.Drawing.Size(167, 147);
			this.lbEngine.TabIndex = 0;
			this.lbEngine.SelectedIndexChanged += new System.EventHandler(this.LbEngineSelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Beds (engine):";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(3, 169);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Slaves (control):";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbSlave
			// 
			this.lbSlave.FormattingEnabled = true;
			this.lbSlave.HorizontalScrollbar = true;
			this.lbSlave.Location = new System.Drawing.Point(3, 188);
			this.lbSlave.Name = "lbSlave";
			this.lbSlave.Size = new System.Drawing.Size(167, 147);
			this.lbSlave.TabIndex = 2;
			this.lbSlave.SelectedIndexChanged += new System.EventHandler(this.LbSlaveSelectedIndexChanged);
			// 
			// bBedAdd
			// 
			this.bBedAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.bBedAdd.Location = new System.Drawing.Point(176, 19);
			this.bBedAdd.Name = "bBedAdd";
			this.bBedAdd.Size = new System.Drawing.Size(24, 24);
			this.bBedAdd.TabIndex = 4;
			this.bBedAdd.Text = "+";
			this.bBedAdd.UseVisualStyleBackColor = true;
			this.bBedAdd.Click += new System.EventHandler(this.BBedAddClick);
			// 
			// bSlaveAdd
			// 
			this.bSlaveAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.bSlaveAdd.Location = new System.Drawing.Point(176, 188);
			this.bSlaveAdd.Name = "bSlaveAdd";
			this.bSlaveAdd.Size = new System.Drawing.Size(24, 24);
			this.bSlaveAdd.TabIndex = 5;
			this.bSlaveAdd.Text = "+";
			this.bSlaveAdd.UseVisualStyleBackColor = true;
			this.bSlaveAdd.Click += new System.EventHandler(this.BSlaveAddClick);
			// 
			// bBedRemove
			// 
			this.bBedRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.bBedRemove.Location = new System.Drawing.Point(176, 49);
			this.bBedRemove.Name = "bBedRemove";
			this.bBedRemove.Size = new System.Drawing.Size(24, 24);
			this.bBedRemove.TabIndex = 6;
			this.bBedRemove.Text = "X";
			this.bBedRemove.UseVisualStyleBackColor = true;
			this.bBedRemove.Click += new System.EventHandler(this.BBedRemoveClick);
			// 
			// bSlaveRemove
			// 
			this.bSlaveRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.bSlaveRemove.Location = new System.Drawing.Point(176, 218);
			this.bSlaveRemove.Name = "bSlaveRemove";
			this.bSlaveRemove.Size = new System.Drawing.Size(24, 24);
			this.bSlaveRemove.TabIndex = 7;
			this.bSlaveRemove.Text = "X";
			this.bSlaveRemove.UseVisualStyleBackColor = true;
			this.bSlaveRemove.Click += new System.EventHandler(this.BSlaveRemoveClick);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Location = new System.Drawing.Point(206, 19);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(400, 316);
			this.panel1.TabIndex = 8;
			// 
			// Bed2SlaveControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.bSlaveRemove);
			this.Controls.Add(this.bBedRemove);
			this.Controls.Add(this.bSlaveAdd);
			this.Controls.Add(this.bBedAdd);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbSlave);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbEngine);
			this.Name = "Bed2SlaveControl";
			this.Size = new System.Drawing.Size(605, 338);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button bSlaveRemove;
		private System.Windows.Forms.Button bBedRemove;
		private System.Windows.Forms.Button bSlaveAdd;
		private System.Windows.Forms.Button bBedAdd;
		private System.Windows.Forms.ListBox lbSlave;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lbEngine;
	}
}
