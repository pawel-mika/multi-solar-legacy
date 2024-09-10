/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-17
 * Time: 23:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DBLoggerPlugin
{
	partial class DBLoggerView
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
			this.rtbConsole = new System.Windows.Forms.RichTextBox();
			this.bClear = new System.Windows.Forms.Button();
			this.cbScrollToEnd = new System.Windows.Forms.CheckBox();
			this.cbFileLog = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// rtbConsole
			// 
			this.rtbConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.rtbConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbConsole.Location = new System.Drawing.Point(0, 0);
			this.rtbConsole.Margin = new System.Windows.Forms.Padding(0);
			this.rtbConsole.Name = "rtbConsole";
			this.rtbConsole.ReadOnly = true;
			this.rtbConsole.Size = new System.Drawing.Size(400, 170);
			this.rtbConsole.TabIndex = 0;
			this.rtbConsole.Text = "";
			// 
			// bClear
			// 
			this.bClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bClear.Location = new System.Drawing.Point(297, 173);
			this.bClear.Name = "bClear";
			this.bClear.Size = new System.Drawing.Size(100, 24);
			this.bClear.TabIndex = 1;
			this.bClear.Text = "Clear";
			this.bClear.UseVisualStyleBackColor = true;
			this.bClear.Click += new System.EventHandler(this.BClearClick);
			// 
			// cbScrollToEnd
			// 
			this.cbScrollToEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbScrollToEnd.Location = new System.Drawing.Point(0, 174);
			this.cbScrollToEnd.Name = "cbScrollToEnd";
			this.cbScrollToEnd.Size = new System.Drawing.Size(104, 24);
			this.cbScrollToEnd.TabIndex = 2;
			this.cbScrollToEnd.Text = "Scroll to bottom";
			this.cbScrollToEnd.UseVisualStyleBackColor = true;
			// 
			// cbFileLog
			// 
			this.cbFileLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbFileLog.Location = new System.Drawing.Point(110, 174);
			this.cbFileLog.Name = "cbFileLog";
			this.cbFileLog.Size = new System.Drawing.Size(104, 24);
			this.cbFileLog.TabIndex = 3;
			this.cbFileLog.Text = "Log to file";
			this.cbFileLog.UseVisualStyleBackColor = true;
			// 
			// DBLoggerView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cbFileLog);
			this.Controls.Add(this.cbScrollToEnd);
			this.Controls.Add(this.bClear);
			this.Controls.Add(this.rtbConsole);
			this.Name = "DBLoggerView";
			this.Size = new System.Drawing.Size(400, 200);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox cbFileLog;
		private System.Windows.Forms.CheckBox cbScrollToEnd;
		private System.Windows.Forms.RichTextBox rtbConsole;
		private System.Windows.Forms.Button bClear;
	}
}
