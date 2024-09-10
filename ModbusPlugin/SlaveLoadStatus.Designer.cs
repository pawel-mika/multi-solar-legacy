/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-07-09
 * Time: 23:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ModbusPlugin
{
	partial class SlaveLoadStatus
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lSent = new System.Windows.Forms.Label();
			this.lRespOkTimeV = new System.Windows.Forms.Label();
			this.lRespOkTime = new System.Windows.Forms.Label();
			this.lOtherErrV = new System.Windows.Forms.Label();
			this.lBad = new System.Windows.Forms.Label();
			this.lOkV = new System.Windows.Forms.Label();
			this.lOk = new System.Windows.Forms.Label();
			this.lId = new System.Windows.Forms.Label();
			this.lIdV = new System.Windows.Forms.Label();
			this.lSentV = new System.Windows.Forms.Label();
			this.lResp = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lTimeoutsV = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel1.ColumnCount = 10;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.Controls.Add(this.lResp, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.lSent, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.lOkV, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.lOk, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.lId, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.lIdV, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.lSentV, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.lRespOkTimeV, 9, 1);
			this.tableLayoutPanel1.Controls.Add(this.lRespOkTime, 8, 1);
			this.tableLayoutPanel1.Controls.Add(this.lOtherErrV, 7, 1);
			this.tableLayoutPanel1.Controls.Add(this.lBad, 6, 1);
			this.tableLayoutPanel1.Controls.Add(this.label1, 4, 1);
			this.tableLayoutPanel1.Controls.Add(this.lTimeoutsV, 5, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(593, 36);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// lSent
			// 
			this.lSent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lSent.Location = new System.Drawing.Point(66, 1);
			this.lSent.Name = "lSent";
			this.lSent.Size = new System.Drawing.Size(34, 16);
			this.lSent.TabIndex = 8;
			this.lSent.Text = "Sent:";
			this.lSent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lRespOkTimeV
			// 
			this.lRespOkTimeV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lRespOkTimeV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lRespOkTimeV.Location = new System.Drawing.Point(473, 18);
			this.lRespOkTimeV.Name = "lRespOkTimeV";
			this.lRespOkTimeV.Size = new System.Drawing.Size(116, 17);
			this.lRespOkTimeV.TabIndex = 7;
			this.lRespOkTimeV.Text = "0";
			this.lRespOkTimeV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lRespOkTime
			// 
			this.lRespOkTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lRespOkTime.Location = new System.Drawing.Point(372, 18);
			this.lRespOkTime.Name = "lRespOkTime";
			this.lRespOkTime.Size = new System.Drawing.Size(94, 17);
			this.lRespOkTime.TabIndex = 6;
			this.lRespOkTime.Text = "Avg ok resp time:";
			this.lRespOkTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lBadV
			// 
			this.lOtherErrV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lOtherErrV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lOtherErrV.ForeColor = System.Drawing.Color.Red;
			this.lOtherErrV.Location = new System.Drawing.Point(331, 18);
			this.lOtherErrV.Name = "lBadV";
			this.lOtherErrV.Size = new System.Drawing.Size(34, 17);
			this.lOtherErrV.TabIndex = 5;
			this.lOtherErrV.Text = "0";
			this.lOtherErrV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lBad
			// 
			this.lBad.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lBad.Location = new System.Drawing.Point(270, 18);
			this.lBad.Name = "lBad";
			this.lBad.Size = new System.Drawing.Size(54, 17);
			this.lBad.TabIndex = 4;
			this.lBad.Text = "Other err:";
			this.lBad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lOkV
			// 
			this.lOkV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lOkV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lOkV.ForeColor = System.Drawing.Color.Green;
			this.lOkV.Location = new System.Drawing.Point(107, 18);
			this.lOkV.Name = "lOkV";
			this.lOkV.Size = new System.Drawing.Size(44, 17);
			this.lOkV.TabIndex = 3;
			this.lOkV.Text = "0";
			this.lOkV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lOk
			// 
			this.lOk.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lOk.Location = new System.Drawing.Point(66, 18);
			this.lOk.Name = "lOk";
			this.lOk.Size = new System.Drawing.Size(34, 17);
			this.lOk.TabIndex = 2;
			this.lOk.Text = "Ok:";
			this.lOk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lId
			// 
			this.lId.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lId.Location = new System.Drawing.Point(4, 1);
			this.lId.Name = "lId";
			this.lId.Size = new System.Drawing.Size(24, 16);
			this.lId.TabIndex = 0;
			this.lId.Text = "ID:";
			this.lId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lIdV
			// 
			this.lIdV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lIdV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lIdV.Location = new System.Drawing.Point(35, 1);
			this.lIdV.Name = "lIdV";
			this.lIdV.Size = new System.Drawing.Size(24, 16);
			this.lIdV.TabIndex = 1;
			this.lIdV.Text = "0";
			this.lIdV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lSentV
			// 
			this.lSentV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lSentV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lSentV.ForeColor = System.Drawing.Color.Green;
			this.lSentV.Location = new System.Drawing.Point(107, 1);
			this.lSentV.Name = "lSentV";
			this.lSentV.Size = new System.Drawing.Size(44, 16);
			this.lSentV.TabIndex = 9;
			this.lSentV.Text = "0";
			this.lSentV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lResp
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.lResp, 2);
			this.lResp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lResp.Location = new System.Drawing.Point(4, 18);
			this.lResp.Name = "lResp";
			this.lResp.Size = new System.Drawing.Size(55, 17);
			this.lResp.TabIndex = 10;
			this.lResp.Text = "Resp:";
			this.lResp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(158, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 17);
			this.label1.TabIndex = 11;
			this.label1.Text = "Timeouts:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lTimeoutsV
			// 
			this.lTimeoutsV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lTimeoutsV.ForeColor = System.Drawing.Color.Red;
			this.lTimeoutsV.Location = new System.Drawing.Point(219, 18);
			this.lTimeoutsV.Name = "lTimeoutsV";
			this.lTimeoutsV.Size = new System.Drawing.Size(44, 17);
			this.lTimeoutsV.TabIndex = 12;
			this.lTimeoutsV.Text = "0";
			this.lTimeoutsV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SlaveLoadStatus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "SlaveLoadStatus";
			this.Size = new System.Drawing.Size(599, 42);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lTimeoutsV;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lResp;
		private System.Windows.Forms.Label lSentV;
		private System.Windows.Forms.Label lSent;
		private System.Windows.Forms.Label lRespOkTime;
		private System.Windows.Forms.Label lRespOkTimeV;
		private System.Windows.Forms.Label lIdV;
		private System.Windows.Forms.Label lId;
		private System.Windows.Forms.Label lOk;
		private System.Windows.Forms.Label lOkV;
		private System.Windows.Forms.Label lBad;
		private System.Windows.Forms.Label lOtherErrV;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}
