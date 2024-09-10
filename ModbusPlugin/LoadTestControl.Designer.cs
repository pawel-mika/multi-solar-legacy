/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-07-09
 * Time: 23:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ModbusPlugin
{
	partial class LoadTestControl
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
			this.bStartMultiThreadedTest = new System.Windows.Forms.Button();
			this.tbIterations = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.panel1 = new System.Windows.Forms.Panel();
			this.bSingleThreadTest = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// bStartMultiThreadedTest
			// 
			this.bStartMultiThreadedTest.Location = new System.Drawing.Point(474, 293);
			this.bStartMultiThreadedTest.Name = "bStartMultiThreadedTest";
			this.bStartMultiThreadedTest.Size = new System.Drawing.Size(128, 42);
			this.bStartMultiThreadedTest.TabIndex = 27;
			this.bStartMultiThreadedTest.Text = "Start multithreaded test";
			this.bStartMultiThreadedTest.UseVisualStyleBackColor = true;
			this.bStartMultiThreadedTest.Click += new System.EventHandler(this.Button1Click);
			// 
			// tbIterations
			// 
			this.tbIterations.Location = new System.Drawing.Point(89, 13);
			this.tbIterations.Name = "tbIterations";
			this.tbIterations.Size = new System.Drawing.Size(60, 20);
			this.tbIterations.TabIndex = 30;
			this.tbIterations.Text = "150";
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(3, 0);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(80, 45);
			this.label36.TabIndex = 29;
			this.label36.Text = "Iterations:";
			this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(155, 0);
			this.trackBar1.Maximum = 50;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(447, 40);
			this.trackBar1.TabIndex = 31;
			this.trackBar1.Value = 15;
			this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1Scroll);
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(3, 48);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(599, 239);
			this.panel1.TabIndex = 32;
			// 
			// bSingleThreadTest
			// 
			this.bSingleThreadTest.Location = new System.Drawing.Point(328, 293);
			this.bSingleThreadTest.Name = "bSingleThreadTest";
			this.bSingleThreadTest.Size = new System.Drawing.Size(140, 42);
			this.bSingleThreadTest.TabIndex = 33;
			this.bSingleThreadTest.Text = "Start singlethreaded test";
			this.bSingleThreadTest.UseVisualStyleBackColor = true;
			this.bSingleThreadTest.Click += new System.EventHandler(this.BSingleThreadTestClick);
			// 
			// LoadTestControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.bSingleThreadTest);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.tbIterations);
			this.Controls.Add(this.label36);
			this.Controls.Add(this.bStartMultiThreadedTest);
			this.Name = "LoadTestControl";
			this.Size = new System.Drawing.Size(605, 338);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button bSingleThreadTest;
		private System.Windows.Forms.Button bStartMultiThreadedTest;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.TextBox tbIterations;
		private System.Windows.Forms.Label label36;
	}
}
