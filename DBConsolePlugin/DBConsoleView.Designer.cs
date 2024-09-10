/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-20
 * Time: 14:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DBConsolePlugin
{
	partial class DBConsoleView
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
			this.rtbQuery = new System.Windows.Forms.RichTextBox();
			this.rtbResult = new System.Windows.Forms.RichTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.bClear = new System.Windows.Forms.Button();
			this.bRun = new System.Windows.Forms.Button();
			this.bShowTable = new System.Windows.Forms.Button();
			this.cbHistory = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lStatus = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(535, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Your SQL:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rtbQuery
			// 
			this.rtbQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.rtbQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbQuery.Location = new System.Drawing.Point(0, 16);
			this.rtbQuery.Margin = new System.Windows.Forms.Padding(0);
			this.rtbQuery.Name = "rtbQuery";
			this.rtbQuery.Size = new System.Drawing.Size(471, 32);
			this.rtbQuery.TabIndex = 1;
			this.rtbQuery.Text = "select * from users";
			this.rtbQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RtbQueryKeyDown);
			this.rtbQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onKeyPress);
			// 
			// rtbResult
			// 
			this.rtbResult.AcceptsTab = true;
			this.rtbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.rtbResult.Font = new System.Drawing.Font("DejaVu Sans Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.rtbResult.Location = new System.Drawing.Point(0, 91);
			this.rtbResult.Margin = new System.Windows.Forms.Padding(0);
			this.rtbResult.Name = "rtbResult";
			this.rtbResult.Size = new System.Drawing.Size(535, 156);
			this.rtbResult.TabIndex = 3;
			this.rtbResult.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 74);
			this.label2.Margin = new System.Windows.Forms.Padding(0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Result:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bClear
			// 
			this.bClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bClear.AutoSize = true;
			this.bClear.Location = new System.Drawing.Point(407, 247);
			this.bClear.Margin = new System.Windows.Forms.Padding(0);
			this.bClear.Name = "bClear";
			this.bClear.Size = new System.Drawing.Size(128, 32);
			this.bClear.TabIndex = 4;
			this.bClear.Text = "Clear";
			this.bClear.UseVisualStyleBackColor = true;
			this.bClear.Click += new System.EventHandler(this.BClearClick);
			// 
			// bRun
			// 
			this.bRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bRun.AutoSize = true;
			this.bRun.Location = new System.Drawing.Point(471, 16);
			this.bRun.Margin = new System.Windows.Forms.Padding(0);
			this.bRun.Name = "bRun";
			this.bRun.Size = new System.Drawing.Size(64, 32);
			this.bRun.TabIndex = 5;
			this.bRun.Text = "Run";
			this.bRun.UseVisualStyleBackColor = true;
			this.bRun.Click += new System.EventHandler(this.BRunClick);
			// 
			// bShowTable
			// 
			this.bShowTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bShowTable.AutoSize = true;
			this.bShowTable.Location = new System.Drawing.Point(279, 247);
			this.bShowTable.Margin = new System.Windows.Forms.Padding(0);
			this.bShowTable.Name = "bShowTable";
			this.bShowTable.Size = new System.Drawing.Size(128, 32);
			this.bShowTable.TabIndex = 6;
			this.bShowTable.Text = "Show table";
			this.bShowTable.UseVisualStyleBackColor = true;
			this.bShowTable.Click += new System.EventHandler(this.BShowTableClick);
			// 
			// cbHistory
			// 
			this.cbHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbHistory.FormattingEnabled = true;
			this.cbHistory.Location = new System.Drawing.Point(67, 52);
			this.cbHistory.Name = "cbHistory";
			this.cbHistory.Size = new System.Drawing.Size(468, 23);
			this.cbHistory.TabIndex = 7;
			this.cbHistory.SelectedIndexChanged += new System.EventHandler(this.ItemSelected);
			this.cbHistory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onKeyPress);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(0, 52);
			this.label3.Margin = new System.Windows.Forms.Padding(0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 22);
			this.label3.TabIndex = 8;
			this.label3.Text = "History:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lStatus
			// 
			this.lStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lStatus.Location = new System.Drawing.Point(3, 247);
			this.lStatus.Name = "lStatus";
			this.lStatus.Size = new System.Drawing.Size(273, 32);
			this.lStatus.TabIndex = 9;
			this.lStatus.Text = ".";
			this.lStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DBConsoleView
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.lStatus);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cbHistory);
			this.Controls.Add(this.bShowTable);
			this.Controls.Add(this.bRun);
			this.Controls.Add(this.bClear);
			this.Controls.Add(this.rtbResult);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.rtbQuery);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "DBConsoleView";
			this.Size = new System.Drawing.Size(535, 279);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label lStatus;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbHistory;
		private System.Windows.Forms.Button bShowTable;
		private System.Windows.Forms.Button bRun;
		private System.Windows.Forms.Button bClear;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RichTextBox rtbResult;
		private System.Windows.Forms.RichTextBox rtbQuery;
		private System.Windows.Forms.Label label1;
	}
}
