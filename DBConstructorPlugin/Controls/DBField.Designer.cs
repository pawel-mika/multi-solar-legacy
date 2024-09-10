/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-07
 * Time: 23:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DBConstructorPlugin.Controls
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
			this.cbNullable = new System.Windows.Forms.CheckBox();
			this.tbDataSize = new System.Windows.Forms.TextBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.tbDefaultValue = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.cbSelected = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbType
			// 
			this.cbType.FormattingEnabled = true;
			this.cbType.Location = new System.Drawing.Point(3, 3);
			this.cbType.Name = "cbType";
			this.cbType.Size = new System.Drawing.Size(94, 21);
			this.cbType.TabIndex = 0;
			// 
			// tbName
			// 
			this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tbName.Location = new System.Drawing.Point(153, 3);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(154, 20);
			this.tbName.TabIndex = 1;
			// 
			// cbNullable
			// 
			this.cbNullable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbNullable.Location = new System.Drawing.Point(310, 0);
			this.cbNullable.Margin = new System.Windows.Forms.Padding(0);
			this.cbNullable.Name = "cbNullable";
			this.cbNullable.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.cbNullable.Size = new System.Drawing.Size(20, 26);
			this.cbNullable.TabIndex = 2;
			this.cbNullable.Text = "null";
			this.cbNullable.UseVisualStyleBackColor = true;
			this.cbNullable.CheckedChanged += new System.EventHandler(this.CbNullableCheckedChanged);
			// 
			// tbDataSize
			// 
			this.tbDataSize.Location = new System.Drawing.Point(103, 3);
			this.tbDataSize.Name = "tbDataSize";
			this.tbDataSize.Size = new System.Drawing.Size(44, 20);
			this.tbDataSize.TabIndex = 3;
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(333, 3);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(54, 21);
			this.comboBox1.TabIndex = 4;
			// 
			// tbDefaultValue
			// 
			this.tbDefaultValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tbDefaultValue.Location = new System.Drawing.Point(393, 3);
			this.tbDefaultValue.MinimumSize = new System.Drawing.Size(100, 20);
			this.tbDefaultValue.Name = "tbDefaultValue";
			this.tbDefaultValue.Size = new System.Drawing.Size(154, 20);
			this.tbDefaultValue.TabIndex = 5;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 7;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
			this.tableLayoutPanel1.Controls.Add(this.cbType, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbDefaultValue, 5, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbDataSize, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.comboBox1, 4, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbName, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.cbNullable, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.cbSelected, 6, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(571, 26);
			this.tableLayoutPanel1.TabIndex = 6;
			// 
			// cbSelected
			// 
			this.cbSelected.BackColor = System.Drawing.Color.Bisque;
			this.cbSelected.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbSelected.Location = new System.Drawing.Point(550, 0);
			this.cbSelected.Margin = new System.Windows.Forms.Padding(0);
			this.cbSelected.Name = "cbSelected";
			this.cbSelected.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
			this.cbSelected.Size = new System.Drawing.Size(21, 26);
			this.cbSelected.TabIndex = 6;
			this.cbSelected.UseVisualStyleBackColor = false;
			this.cbSelected.CheckedChanged += new System.EventHandler(this.CbSelectedCheckedChanged);
			// 
			// DBField
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "DBField";
			this.Size = new System.Drawing.Size(571, 26);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TextBox tbDefaultValue;
		private System.Windows.Forms.CheckBox cbSelected;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.TextBox tbDataSize;
		private System.Windows.Forms.CheckBox cbNullable;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.ComboBox cbType;
	}
}
