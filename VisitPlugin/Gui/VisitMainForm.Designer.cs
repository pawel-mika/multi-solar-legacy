/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-04-21
 * Time: 22:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace VisitPlugin.Gui
{
	partial class VisitMainForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.lbVisit = new System.Windows.Forms.ListBox();
			this.bClient = new System.Windows.Forms.Button();
			this.bArticle = new System.Windows.Forms.Button();
			this.bHeating = new System.Windows.Forms.Button();
			this.bRemoveItems = new System.Windows.Forms.Button();
			this.bApply = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(340, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Lista:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbVisit
			// 
			this.lbVisit.FormattingEnabled = true;
			this.lbVisit.Location = new System.Drawing.Point(12, 32);
			this.lbVisit.Name = "lbVisit";
			this.lbVisit.Size = new System.Drawing.Size(340, 303);
			this.lbVisit.TabIndex = 1;
			// 
			// bClient
			// 
			this.bClient.Location = new System.Drawing.Point(420, 32);
			this.bClient.Name = "bClient";
			this.bClient.Size = new System.Drawing.Size(200, 30);
			this.bClient.TabIndex = 2;
			this.bClient.Text = "Klient >>";
			this.bClient.UseVisualStyleBackColor = true;
			// 
			// bArticle
			// 
			this.bArticle.Location = new System.Drawing.Point(420, 305);
			this.bArticle.Name = "bArticle";
			this.bArticle.Size = new System.Drawing.Size(200, 30);
			this.bArticle.TabIndex = 3;
			this.bArticle.Text = "Artykuł >>";
			this.bArticle.UseVisualStyleBackColor = true;
			// 
			// bHeating
			// 
			this.bHeating.Location = new System.Drawing.Point(420, 269);
			this.bHeating.Name = "bHeating";
			this.bHeating.Size = new System.Drawing.Size(200, 30);
			this.bHeating.TabIndex = 4;
			this.bHeating.Text = "Opalanie >>";
			this.bHeating.UseVisualStyleBackColor = true;
			// 
			// bRemoveItems
			// 
			this.bRemoveItems.Location = new System.Drawing.Point(12, 341);
			this.bRemoveItems.Name = "bRemoveItems";
			this.bRemoveItems.Size = new System.Drawing.Size(127, 30);
			this.bRemoveItems.TabIndex = 5;
			this.bRemoveItems.Text = "Usuń zaznaczone";
			this.bRemoveItems.UseVisualStyleBackColor = true;
			// 
			// bApply
			// 
			this.bApply.Location = new System.Drawing.Point(420, 491);
			this.bApply.Name = "bApply";
			this.bApply.Size = new System.Drawing.Size(200, 30);
			this.bApply.TabIndex = 6;
			this.bApply.Text = "Zatwierdź";
			this.bApply.UseVisualStyleBackColor = true;
			// 
			// bCancel
			// 
			this.bCancel.Location = new System.Drawing.Point(12, 491);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(200, 30);
			this.bCancel.TabIndex = 7;
			this.bCancel.Text = "Anuluj";
			this.bCancel.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(145, 346);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 20);
			this.label2.TabIndex = 8;
			this.label2.Text = "Suma:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(272, 346);
			this.label3.Name = "label3";
			this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label3.Size = new System.Drawing.Size(80, 20);
			this.label3.TabIndex = 9;
			this.label3.Text = "0,00 zł";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// VisitMainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 533);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bApply);
			this.Controls.Add(this.bRemoveItems);
			this.Controls.Add(this.bHeating);
			this.Controls.Add(this.bArticle);
			this.Controls.Add(this.bClient);
			this.Controls.Add(this.lbVisit);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "VisitMainForm";
			this.Text = "VisitMainForm";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button bHeating;
		private System.Windows.Forms.Button bCancel;
		private System.Windows.Forms.Button bApply;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button bRemoveItems;
		private System.Windows.Forms.Button bArticle;
		private System.Windows.Forms.Button bClient;
		private System.Windows.Forms.ListBox lbVisit;
		private System.Windows.Forms.Label label1;
	}
}
