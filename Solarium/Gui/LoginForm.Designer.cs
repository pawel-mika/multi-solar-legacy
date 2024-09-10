/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-11
 * Time: 23:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Solarium.Gui
{
	partial class LoginForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.tbPass = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.gbCancel = new Glass.GlassButton();
			this.gbOk = new Glass.GlassButton();
			this.cbLogin = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.AccessibleDescription = null;
			this.pictureBox1.AccessibleName = null;
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("pictureBox1.Anchor")));
			this.pictureBox1.BackgroundImage = null;
			this.pictureBox1.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("pictureBox1.BackgroundImageLayout")));
			this.pictureBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("pictureBox1.Dock")));
			this.pictureBox1.Font = null;
			this.pictureBox1.ImageLocation = null;
			this.pictureBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("pictureBox1.ImeMode")));
			this.pictureBox1.Location = ((System.Drawing.Point)(resources.GetObject("pictureBox1.Location")));
			this.pictureBox1.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("pictureBox1.Margin")));
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("pictureBox1.RightToLeft")));
			this.pictureBox1.Size = ((System.Drawing.Size)(resources.GetObject("pictureBox1.Size")));
			this.pictureBox1.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode)(resources.GetObject("pictureBox1.SizeMode")));
			this.pictureBox1.TabIndex = ((int)(resources.GetObject("pictureBox1.TabIndex")));
			this.pictureBox1.TabStop = false;
			this.pictureBox1.WaitOnLoad = ((bool)(resources.GetObject("pictureBox1.WaitOnLoad")));
			// 
			// label1
			// 
			this.label1.AccessibleDescription = null;
			this.label1.AccessibleName = null;
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label1.Anchor")));
			this.label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
			this.label1.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("label1.BackgroundImageLayout")));
			this.label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label1.Dock")));
			this.label1.Font = null;
			this.label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.ImageAlign")));
			this.label1.ImageIndex = ((int)(resources.GetObject("label1.ImageIndex")));
			this.label1.ImageKey = resources.GetString("label1.ImageKey");
			this.label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label1.ImeMode")));
			this.label1.Location = ((System.Drawing.Point)(resources.GetObject("label1.Location")));
			this.label1.Name = "label1";
			this.label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label1.RightToLeft")));
			this.label1.Size = ((System.Drawing.Size)(resources.GetObject("label1.Size")));
			this.label1.TabIndex = ((int)(resources.GetObject("label1.TabIndex")));
			this.label1.Text = resources.GetString("label1.Text");
			this.label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.TextAlign")));
			// 
			// textBox1
			// 
			this.textBox1.AccessibleDescription = null;
			this.textBox1.AccessibleName = null;
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("textBox1.Anchor")));
			this.textBox1.BackgroundImage = null;
			this.textBox1.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("textBox1.BackgroundImageLayout")));
			this.textBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("textBox1.Dock")));
			this.textBox1.Font = null;
			this.textBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("textBox1.ImeMode")));
			this.textBox1.Location = ((System.Drawing.Point)(resources.GetObject("textBox1.Location")));
			this.textBox1.MaxLength = ((int)(resources.GetObject("textBox1.MaxLength")));
			this.textBox1.Multiline = ((bool)(resources.GetObject("textBox1.Multiline")));
			this.textBox1.Name = "textBox1";
			this.textBox1.PasswordChar = ((char)(resources.GetObject("textBox1.PasswordChar")));
			this.textBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("textBox1.RightToLeft")));
			this.textBox1.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("textBox1.ScrollBars")));
			this.textBox1.Size = ((System.Drawing.Size)(resources.GetObject("textBox1.Size")));
			this.textBox1.TabIndex = ((int)(resources.GetObject("textBox1.TabIndex")));
			this.textBox1.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("textBox1.TextAlign")));
			this.textBox1.Visible = ((bool)(resources.GetObject("textBox1.Visible")));
			this.textBox1.WordWrap = ((bool)(resources.GetObject("textBox1.WordWrap")));
			// 
			// tbPass
			// 
			this.tbPass.AccessibleDescription = null;
			this.tbPass.AccessibleName = null;
			this.tbPass.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tbPass.Anchor")));
			this.tbPass.BackgroundImage = null;
			this.tbPass.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("tbPass.BackgroundImageLayout")));
			this.tbPass.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tbPass.Dock")));
			this.tbPass.Font = null;
			this.tbPass.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tbPass.ImeMode")));
			this.tbPass.Location = ((System.Drawing.Point)(resources.GetObject("tbPass.Location")));
			this.tbPass.MaxLength = ((int)(resources.GetObject("tbPass.MaxLength")));
			this.tbPass.Multiline = ((bool)(resources.GetObject("tbPass.Multiline")));
			this.tbPass.Name = "tbPass";
			this.tbPass.PasswordChar = ((char)(resources.GetObject("tbPass.PasswordChar")));
			this.tbPass.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tbPass.RightToLeft")));
			this.tbPass.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("tbPass.ScrollBars")));
			this.tbPass.Size = ((System.Drawing.Size)(resources.GetObject("tbPass.Size")));
			this.tbPass.TabIndex = ((int)(resources.GetObject("tbPass.TabIndex")));
			this.tbPass.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("tbPass.TextAlign")));
			this.tbPass.WordWrap = ((bool)(resources.GetObject("tbPass.WordWrap")));
			this.tbPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbPassKeyPress);
			// 
			// label2
			// 
			this.label2.AccessibleDescription = null;
			this.label2.AccessibleName = null;
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label2.Anchor")));
			this.label2.AutoSize = ((bool)(resources.GetObject("label2.AutoSize")));
			this.label2.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("label2.BackgroundImageLayout")));
			this.label2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label2.Dock")));
			this.label2.Font = null;
			this.label2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.ImageAlign")));
			this.label2.ImageIndex = ((int)(resources.GetObject("label2.ImageIndex")));
			this.label2.ImageKey = resources.GetString("label2.ImageKey");
			this.label2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label2.ImeMode")));
			this.label2.Location = ((System.Drawing.Point)(resources.GetObject("label2.Location")));
			this.label2.Name = "label2";
			this.label2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label2.RightToLeft")));
			this.label2.Size = ((System.Drawing.Size)(resources.GetObject("label2.Size")));
			this.label2.TabIndex = ((int)(resources.GetObject("label2.TabIndex")));
			this.label2.Text = resources.GetString("label2.Text");
			this.label2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.TextAlign")));
			// 
			// gbCancel
			// 
			this.gbCancel.AccessibleDescription = null;
			this.gbCancel.AccessibleName = null;
			this.gbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gbCancel.Anchor")));
			this.gbCancel.AutoSize = ((bool)(resources.GetObject("gbCancel.AutoSize")));
			this.gbCancel.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("gbCancel.AutoSizeMode")));
			this.gbCancel.BackColor = System.Drawing.Color.Red;
			this.gbCancel.BackgroundImage = null;
			this.gbCancel.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("gbCancel.BackgroundImageLayout")));
			this.gbCancel.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("gbCancel.Dock")));
			this.gbCancel.Font = null;
			this.gbCancel.GlowColor = System.Drawing.Color.LavenderBlush;
			this.gbCancel.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("gbCancel.ImageAlign")));
			this.gbCancel.ImageIndex = ((int)(resources.GetObject("gbCancel.ImageIndex")));
			this.gbCancel.ImageKey = resources.GetString("gbCancel.ImageKey");
			this.gbCancel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gbCancel.ImeMode")));
			this.gbCancel.Location = ((System.Drawing.Point)(resources.GetObject("gbCancel.Location")));
			this.gbCancel.Name = "gbCancel";
			this.gbCancel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("gbCancel.RightToLeft")));
			this.gbCancel.Size = ((System.Drawing.Size)(resources.GetObject("gbCancel.Size")));
			this.gbCancel.TabIndex = ((int)(resources.GetObject("gbCancel.TabIndex")));
			this.gbCancel.Text = resources.GetString("gbCancel.Text");
			this.gbCancel.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("gbCancel.TextAlign")));
			this.gbCancel.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("gbCancel.TextImageRelation")));
			this.gbCancel.Click += new System.EventHandler(this.GbCancelClick);
			// 
			// gbOk
			// 
			this.gbOk.AccessibleDescription = null;
			this.gbOk.AccessibleName = null;
			this.gbOk.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gbOk.Anchor")));
			this.gbOk.AutoSize = ((bool)(resources.GetObject("gbOk.AutoSize")));
			this.gbOk.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("gbOk.AutoSizeMode")));
			this.gbOk.BackColor = System.Drawing.Color.Green;
			this.gbOk.BackgroundImage = null;
			this.gbOk.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("gbOk.BackgroundImageLayout")));
			this.gbOk.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("gbOk.Dock")));
			this.gbOk.Font = null;
			this.gbOk.GlowColor = System.Drawing.Color.Honeydew;
			this.gbOk.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("gbOk.ImageAlign")));
			this.gbOk.ImageIndex = ((int)(resources.GetObject("gbOk.ImageIndex")));
			this.gbOk.ImageKey = resources.GetString("gbOk.ImageKey");
			this.gbOk.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gbOk.ImeMode")));
			this.gbOk.Location = ((System.Drawing.Point)(resources.GetObject("gbOk.Location")));
			this.gbOk.Name = "gbOk";
			this.gbOk.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("gbOk.RightToLeft")));
			this.gbOk.Size = ((System.Drawing.Size)(resources.GetObject("gbOk.Size")));
			this.gbOk.TabIndex = ((int)(resources.GetObject("gbOk.TabIndex")));
			this.gbOk.Text = resources.GetString("gbOk.Text");
			this.gbOk.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("gbOk.TextAlign")));
			this.gbOk.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("gbOk.TextImageRelation")));
			this.gbOk.Click += new System.EventHandler(this.GbOkClick);
			// 
			// cbLogin
			// 
			this.cbLogin.AccessibleDescription = null;
			this.cbLogin.AccessibleName = null;
			this.cbLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cbLogin.Anchor")));
			this.cbLogin.BackgroundImage = null;
			this.cbLogin.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("cbLogin.BackgroundImageLayout")));
			this.cbLogin.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cbLogin.Dock")));
			this.cbLogin.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cbLogin.FlatStyle")));
			this.cbLogin.Font = null;
			this.cbLogin.FormattingEnabled = true;
			this.cbLogin.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cbLogin.ImeMode")));
			this.cbLogin.IntegralHeight = ((bool)(resources.GetObject("cbLogin.IntegralHeight")));
			this.cbLogin.Location = ((System.Drawing.Point)(resources.GetObject("cbLogin.Location")));
			this.cbLogin.MaxDropDownItems = ((int)(resources.GetObject("cbLogin.MaxDropDownItems")));
			this.cbLogin.MaxLength = ((int)(resources.GetObject("cbLogin.MaxLength")));
			this.cbLogin.Name = "cbLogin";
			this.cbLogin.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cbLogin.RightToLeft")));
			this.cbLogin.Size = ((System.Drawing.Size)(resources.GetObject("cbLogin.Size")));
			this.cbLogin.TabIndex = ((int)(resources.GetObject("cbLogin.TabIndex")));
			this.cbLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CbLoginKeyDown);
			// 
			// LoginForm
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AutoScaleDimensions = ((System.Drawing.SizeF)(resources.GetObject("$this.AutoScaleDimensions")));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoSize = ((bool)(resources.GetObject("$this.AutoSize")));
			this.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("$this.AutoSizeMode")));
			this.BackgroundImage = null;
			this.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("$this.BackgroundImageLayout")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.ControlBox = false;
			this.Controls.Add(this.cbLogin);
			this.Controls.Add(this.gbOk);
			this.Controls.Add(this.gbCancel);
			this.Controls.Add(this.tbPass);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Font = null;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = null;
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximizeBox = false;
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimizeBox = false;
			this.Name = "LoginForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.RightToLeftLayout = ((bool)(resources.GetObject("$this.RightToLeftLayout")));
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox tbPass;
		private System.Windows.Forms.ComboBox cbLogin;
		private Glass.GlassButton gbOk;
		private Glass.GlassButton gbCancel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
