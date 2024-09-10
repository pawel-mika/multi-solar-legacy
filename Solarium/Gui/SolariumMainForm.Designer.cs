/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-08-07
 * Time: 21:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Solarium
{
	partial class SolariumMainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolariumMainForm));
			this.mainStatusStrip = new Solarium.Gui.MFStatusStrip();
			this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tcMain = new System.Windows.Forms.TabControl();
			this.tpDevices = new System.Windows.Forms.TabPage();
			this.flpDevices = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.mainMenuStrip.SuspendLayout();
			this.tcMain.SuspendLayout();
			this.tpDevices.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainStatusStrip
			// 
			this.mainStatusStrip.AccessibleDescription = null;
			this.mainStatusStrip.AccessibleName = null;
			this.mainStatusStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("mainStatusStrip.Anchor")));
			this.mainStatusStrip.AutoSize = ((bool)(resources.GetObject("mainStatusStrip.AutoSize")));
			this.mainStatusStrip.BackgroundImage = null;
			this.mainStatusStrip.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("mainStatusStrip.BackgroundImageLayout")));
			this.mainStatusStrip.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("mainStatusStrip.Dock")));
			this.mainStatusStrip.Font = null;
			this.mainStatusStrip.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("mainStatusStrip.ImeMode")));
			this.mainStatusStrip.Location = ((System.Drawing.Point)(resources.GetObject("mainStatusStrip.Location")));
			this.mainStatusStrip.Name = "mainStatusStrip";
			this.mainStatusStrip.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("mainStatusStrip.RightToLeft")));
			this.mainStatusStrip.Size = ((System.Drawing.Size)(resources.GetObject("mainStatusStrip.Size")));
			this.mainStatusStrip.TabIndex = ((int)(resources.GetObject("mainStatusStrip.TabIndex")));
			this.mainStatusStrip.Text = resources.GetString("mainStatusStrip.Text");
			// 
			// mainMenuStrip
			// 
			this.mainMenuStrip.AccessibleDescription = null;
			this.mainMenuStrip.AccessibleName = null;
			this.mainMenuStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("mainMenuStrip.Anchor")));
			this.mainMenuStrip.AutoSize = ((bool)(resources.GetObject("mainMenuStrip.AutoSize")));
			this.mainMenuStrip.BackgroundImage = null;
			this.mainMenuStrip.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("mainMenuStrip.BackgroundImageLayout")));
			this.mainMenuStrip.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("mainMenuStrip.Dock")));
			this.mainMenuStrip.Font = ((System.Drawing.Font)(resources.GetObject("mainMenuStrip.Font")));
			this.mainMenuStrip.GripMargin = new System.Windows.Forms.Padding(0);
			this.mainMenuStrip.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("mainMenuStrip.ImeMode")));
			this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem,
									this.editToolStripMenuItem,
									this.viewToolStripMenuItem,
									this.helpToolStripMenuItem});
			this.mainMenuStrip.Location = ((System.Drawing.Point)(resources.GetObject("mainMenuStrip.Location")));
			this.mainMenuStrip.Name = "mainMenuStrip";
			this.mainMenuStrip.Padding = ((System.Windows.Forms.Padding)(resources.GetObject("mainMenuStrip.Padding")));
			this.mainMenuStrip.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("mainMenuStrip.RightToLeft")));
			this.mainMenuStrip.Size = ((System.Drawing.Size)(resources.GetObject("mainMenuStrip.Size")));
			this.mainMenuStrip.TabIndex = ((int)(resources.GetObject("mainMenuStrip.TabIndex")));
			this.mainMenuStrip.Text = resources.GetString("mainMenuStrip.Text");
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.AccessibleDescription = null;
			this.fileToolStripMenuItem.AccessibleName = null;
			this.fileToolStripMenuItem.AutoSize = ((bool)(resources.GetObject("fileToolStripMenuItem.AutoSize")));
			this.fileToolStripMenuItem.BackgroundImage = null;
			this.fileToolStripMenuItem.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("fileToolStripMenuItem.BackgroundImageLayout")));
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Enabled = ((bool)(resources.GetObject("fileToolStripMenuItem.Enabled")));
			this.fileToolStripMenuItem.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("fileToolStripMenuItem.ImageAlign")));
			this.fileToolStripMenuItem.ImageScaling = ((System.Windows.Forms.ToolStripItemImageScaling)(resources.GetObject("fileToolStripMenuItem.ImageScaling")));
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.RightToLeftAutoMirrorImage = ((bool)(resources.GetObject("fileToolStripMenuItem.RightToLeftAutoMirrorImage")));
			this.fileToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(resources.GetObject("fileToolStripMenuItem.ShortcutKeys")));
			this.fileToolStripMenuItem.ShowShortcutKeys = ((bool)(resources.GetObject("fileToolStripMenuItem.ShowShortcutKeys")));
			this.fileToolStripMenuItem.Size = ((System.Drawing.Size)(resources.GetObject("fileToolStripMenuItem.Size")));
			this.fileToolStripMenuItem.Text = resources.GetString("fileToolStripMenuItem.Text");
			this.fileToolStripMenuItem.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("fileToolStripMenuItem.TextAlign")));
			this.fileToolStripMenuItem.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("fileToolStripMenuItem.TextImageRelation")));
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.AccessibleDescription = null;
			this.quitToolStripMenuItem.AccessibleName = null;
			this.quitToolStripMenuItem.AutoSize = ((bool)(resources.GetObject("quitToolStripMenuItem.AutoSize")));
			this.quitToolStripMenuItem.BackgroundImage = null;
			this.quitToolStripMenuItem.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("quitToolStripMenuItem.BackgroundImageLayout")));
			this.quitToolStripMenuItem.Enabled = ((bool)(resources.GetObject("quitToolStripMenuItem.Enabled")));
			this.quitToolStripMenuItem.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("quitToolStripMenuItem.ImageAlign")));
			this.quitToolStripMenuItem.ImageScaling = ((System.Windows.Forms.ToolStripItemImageScaling)(resources.GetObject("quitToolStripMenuItem.ImageScaling")));
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.quitToolStripMenuItem.RightToLeftAutoMirrorImage = ((bool)(resources.GetObject("quitToolStripMenuItem.RightToLeftAutoMirrorImage")));
			this.quitToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(resources.GetObject("quitToolStripMenuItem.ShortcutKeys")));
			this.quitToolStripMenuItem.ShowShortcutKeys = ((bool)(resources.GetObject("quitToolStripMenuItem.ShowShortcutKeys")));
			this.quitToolStripMenuItem.Size = ((System.Drawing.Size)(resources.GetObject("quitToolStripMenuItem.Size")));
			this.quitToolStripMenuItem.Text = resources.GetString("quitToolStripMenuItem.Text");
			this.quitToolStripMenuItem.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("quitToolStripMenuItem.TextAlign")));
			this.quitToolStripMenuItem.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("quitToolStripMenuItem.TextImageRelation")));
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItemClick);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.AccessibleDescription = null;
			this.editToolStripMenuItem.AccessibleName = null;
			this.editToolStripMenuItem.AutoSize = ((bool)(resources.GetObject("editToolStripMenuItem.AutoSize")));
			this.editToolStripMenuItem.BackgroundImage = null;
			this.editToolStripMenuItem.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("editToolStripMenuItem.BackgroundImageLayout")));
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.preferencesToolStripMenuItem});
			this.editToolStripMenuItem.Enabled = ((bool)(resources.GetObject("editToolStripMenuItem.Enabled")));
			this.editToolStripMenuItem.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("editToolStripMenuItem.ImageAlign")));
			this.editToolStripMenuItem.ImageScaling = ((System.Windows.Forms.ToolStripItemImageScaling)(resources.GetObject("editToolStripMenuItem.ImageScaling")));
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.RightToLeftAutoMirrorImage = ((bool)(resources.GetObject("editToolStripMenuItem.RightToLeftAutoMirrorImage")));
			this.editToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.editToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(resources.GetObject("editToolStripMenuItem.ShortcutKeys")));
			this.editToolStripMenuItem.ShowShortcutKeys = ((bool)(resources.GetObject("editToolStripMenuItem.ShowShortcutKeys")));
			this.editToolStripMenuItem.Size = ((System.Drawing.Size)(resources.GetObject("editToolStripMenuItem.Size")));
			this.editToolStripMenuItem.Text = resources.GetString("editToolStripMenuItem.Text");
			this.editToolStripMenuItem.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("editToolStripMenuItem.TextAlign")));
			this.editToolStripMenuItem.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("editToolStripMenuItem.TextImageRelation")));
			// 
			// preferencesToolStripMenuItem
			// 
			this.preferencesToolStripMenuItem.AccessibleDescription = null;
			this.preferencesToolStripMenuItem.AccessibleName = null;
			this.preferencesToolStripMenuItem.AutoSize = ((bool)(resources.GetObject("preferencesToolStripMenuItem.AutoSize")));
			this.preferencesToolStripMenuItem.BackgroundImage = null;
			this.preferencesToolStripMenuItem.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("preferencesToolStripMenuItem.BackgroundImageLayout")));
			this.preferencesToolStripMenuItem.Enabled = ((bool)(resources.GetObject("preferencesToolStripMenuItem.Enabled")));
			this.preferencesToolStripMenuItem.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("preferencesToolStripMenuItem.ImageAlign")));
			this.preferencesToolStripMenuItem.ImageScaling = ((System.Windows.Forms.ToolStripItemImageScaling)(resources.GetObject("preferencesToolStripMenuItem.ImageScaling")));
			this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
			this.preferencesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.preferencesToolStripMenuItem.RightToLeftAutoMirrorImage = ((bool)(resources.GetObject("preferencesToolStripMenuItem.RightToLeftAutoMirrorImage")));
			this.preferencesToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.preferencesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(resources.GetObject("preferencesToolStripMenuItem.ShortcutKeys")));
			this.preferencesToolStripMenuItem.ShowShortcutKeys = ((bool)(resources.GetObject("preferencesToolStripMenuItem.ShowShortcutKeys")));
			this.preferencesToolStripMenuItem.Size = ((System.Drawing.Size)(resources.GetObject("preferencesToolStripMenuItem.Size")));
			this.preferencesToolStripMenuItem.Text = resources.GetString("preferencesToolStripMenuItem.Text");
			this.preferencesToolStripMenuItem.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("preferencesToolStripMenuItem.TextAlign")));
			this.preferencesToolStripMenuItem.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("preferencesToolStripMenuItem.TextImageRelation")));
			this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.PreferencesToolStripMenuItemClick);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.AccessibleDescription = null;
			this.viewToolStripMenuItem.AccessibleName = null;
			this.viewToolStripMenuItem.AutoSize = ((bool)(resources.GetObject("viewToolStripMenuItem.AutoSize")));
			this.viewToolStripMenuItem.BackgroundImage = null;
			this.viewToolStripMenuItem.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("viewToolStripMenuItem.BackgroundImageLayout")));
			this.viewToolStripMenuItem.Enabled = ((bool)(resources.GetObject("viewToolStripMenuItem.Enabled")));
			this.viewToolStripMenuItem.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("viewToolStripMenuItem.ImageAlign")));
			this.viewToolStripMenuItem.ImageScaling = ((System.Windows.Forms.ToolStripItemImageScaling)(resources.GetObject("viewToolStripMenuItem.ImageScaling")));
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.RightToLeftAutoMirrorImage = ((bool)(resources.GetObject("viewToolStripMenuItem.RightToLeftAutoMirrorImage")));
			this.viewToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.viewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(resources.GetObject("viewToolStripMenuItem.ShortcutKeys")));
			this.viewToolStripMenuItem.ShowShortcutKeys = ((bool)(resources.GetObject("viewToolStripMenuItem.ShowShortcutKeys")));
			this.viewToolStripMenuItem.Size = ((System.Drawing.Size)(resources.GetObject("viewToolStripMenuItem.Size")));
			this.viewToolStripMenuItem.Text = resources.GetString("viewToolStripMenuItem.Text");
			this.viewToolStripMenuItem.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("viewToolStripMenuItem.TextAlign")));
			this.viewToolStripMenuItem.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("viewToolStripMenuItem.TextImageRelation")));
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.AccessibleDescription = null;
			this.helpToolStripMenuItem.AccessibleName = null;
			this.helpToolStripMenuItem.AutoSize = ((bool)(resources.GetObject("helpToolStripMenuItem.AutoSize")));
			this.helpToolStripMenuItem.BackgroundImage = null;
			this.helpToolStripMenuItem.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("helpToolStripMenuItem.BackgroundImageLayout")));
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Enabled = ((bool)(resources.GetObject("helpToolStripMenuItem.Enabled")));
			this.helpToolStripMenuItem.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("helpToolStripMenuItem.ImageAlign")));
			this.helpToolStripMenuItem.ImageScaling = ((System.Windows.Forms.ToolStripItemImageScaling)(resources.GetObject("helpToolStripMenuItem.ImageScaling")));
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.RightToLeftAutoMirrorImage = ((bool)(resources.GetObject("helpToolStripMenuItem.RightToLeftAutoMirrorImage")));
			this.helpToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.helpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(resources.GetObject("helpToolStripMenuItem.ShortcutKeys")));
			this.helpToolStripMenuItem.ShowShortcutKeys = ((bool)(resources.GetObject("helpToolStripMenuItem.ShowShortcutKeys")));
			this.helpToolStripMenuItem.Size = ((System.Drawing.Size)(resources.GetObject("helpToolStripMenuItem.Size")));
			this.helpToolStripMenuItem.Text = resources.GetString("helpToolStripMenuItem.Text");
			this.helpToolStripMenuItem.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("helpToolStripMenuItem.TextAlign")));
			this.helpToolStripMenuItem.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("helpToolStripMenuItem.TextImageRelation")));
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.AccessibleDescription = null;
			this.aboutToolStripMenuItem.AccessibleName = null;
			this.aboutToolStripMenuItem.AutoSize = ((bool)(resources.GetObject("aboutToolStripMenuItem.AutoSize")));
			this.aboutToolStripMenuItem.BackgroundImage = null;
			this.aboutToolStripMenuItem.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("aboutToolStripMenuItem.BackgroundImageLayout")));
			this.aboutToolStripMenuItem.Enabled = ((bool)(resources.GetObject("aboutToolStripMenuItem.Enabled")));
			this.aboutToolStripMenuItem.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("aboutToolStripMenuItem.ImageAlign")));
			this.aboutToolStripMenuItem.ImageScaling = ((System.Windows.Forms.ToolStripItemImageScaling)(resources.GetObject("aboutToolStripMenuItem.ImageScaling")));
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.aboutToolStripMenuItem.RightToLeftAutoMirrorImage = ((bool)(resources.GetObject("aboutToolStripMenuItem.RightToLeftAutoMirrorImage")));
			this.aboutToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.aboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(resources.GetObject("aboutToolStripMenuItem.ShortcutKeys")));
			this.aboutToolStripMenuItem.ShowShortcutKeys = ((bool)(resources.GetObject("aboutToolStripMenuItem.ShowShortcutKeys")));
			this.aboutToolStripMenuItem.Size = ((System.Drawing.Size)(resources.GetObject("aboutToolStripMenuItem.Size")));
			this.aboutToolStripMenuItem.Text = resources.GetString("aboutToolStripMenuItem.Text");
			this.aboutToolStripMenuItem.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("aboutToolStripMenuItem.TextAlign")));
			this.aboutToolStripMenuItem.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("aboutToolStripMenuItem.TextImageRelation")));
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// tcMain
			// 
			this.tcMain.AccessibleDescription = null;
			this.tcMain.AccessibleName = null;
			this.tcMain.Alignment = ((System.Windows.Forms.TabAlignment)(resources.GetObject("tcMain.Alignment")));
			this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tcMain.Anchor")));
			this.tcMain.Appearance = ((System.Windows.Forms.TabAppearance)(resources.GetObject("tcMain.Appearance")));
			this.tcMain.BackgroundImage = null;
			this.tcMain.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("tcMain.BackgroundImageLayout")));
			this.tcMain.Controls.Add(this.tpDevices);
			this.tcMain.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tcMain.Dock")));
			this.tcMain.Font = null;
			this.tcMain.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tcMain.ImeMode")));
			this.tcMain.Location = ((System.Drawing.Point)(resources.GetObject("tcMain.Location")));
			this.tcMain.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("tcMain.Margin")));
			this.tcMain.Name = "tcMain";
			this.tcMain.Padding = ((System.Drawing.Point)(resources.GetObject("tcMain.Padding")));
			this.tcMain.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tcMain.RightToLeft")));
			this.tcMain.RightToLeftLayout = ((bool)(resources.GetObject("tcMain.RightToLeftLayout")));
			this.tcMain.SelectedIndex = 0;
			this.tcMain.ShowToolTips = ((bool)(resources.GetObject("tcMain.ShowToolTips")));
			this.tcMain.Size = ((System.Drawing.Size)(resources.GetObject("tcMain.Size")));
			this.tcMain.TabIndex = ((int)(resources.GetObject("tcMain.TabIndex")));
			// 
			// tpDevices
			// 
			this.tpDevices.AccessibleDescription = null;
			this.tpDevices.AccessibleName = null;
			this.tpDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tpDevices.Anchor")));
			this.tpDevices.AutoScroll = ((bool)(resources.GetObject("tpDevices.AutoScroll")));
			this.tpDevices.BackgroundImage = null;
			this.tpDevices.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("tpDevices.BackgroundImageLayout")));
			this.tpDevices.Controls.Add(this.flpDevices);
			this.tpDevices.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tpDevices.Dock")));
			this.tpDevices.Font = null;
			this.tpDevices.ImageIndex = ((int)(resources.GetObject("tpDevices.ImageIndex")));
			this.tpDevices.ImageKey = resources.GetString("tpDevices.ImageKey");
			this.tpDevices.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tpDevices.ImeMode")));
			this.tpDevices.Location = ((System.Drawing.Point)(resources.GetObject("tpDevices.Location")));
			this.tpDevices.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("tpDevices.Margin")));
			this.tpDevices.Name = "tpDevices";
			this.tpDevices.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tpDevices.RightToLeft")));
			this.tpDevices.Size = ((System.Drawing.Size)(resources.GetObject("tpDevices.Size")));
			this.tpDevices.TabIndex = ((int)(resources.GetObject("tpDevices.TabIndex")));
			this.tpDevices.Text = resources.GetString("tpDevices.Text");
			this.tpDevices.ToolTipText = resources.GetString("tpDevices.ToolTipText");
			this.tpDevices.UseVisualStyleBackColor = true;
			// 
			// flpDevices
			// 
			this.flpDevices.AccessibleDescription = null;
			this.flpDevices.AccessibleName = null;
			this.flpDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("flpDevices.Anchor")));
			this.flpDevices.AutoScroll = ((bool)(resources.GetObject("flpDevices.AutoScroll")));
			this.flpDevices.AutoSize = ((bool)(resources.GetObject("flpDevices.AutoSize")));
			this.flpDevices.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("flpDevices.AutoSizeMode")));
			this.flpDevices.BackColor = System.Drawing.SystemColors.Control;
			this.flpDevices.BackgroundImage = null;
			this.flpDevices.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("flpDevices.BackgroundImageLayout")));
			this.flpDevices.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("flpDevices.Dock")));
			this.flpDevices.FlowDirection = ((System.Windows.Forms.FlowDirection)(resources.GetObject("flpDevices.FlowDirection")));
			this.flpDevices.Font = null;
			this.flpDevices.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("flpDevices.ImeMode")));
			this.flpDevices.Location = ((System.Drawing.Point)(resources.GetObject("flpDevices.Location")));
			this.flpDevices.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("flpDevices.Margin")));
			this.flpDevices.Name = "flpDevices";
			this.flpDevices.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("flpDevices.RightToLeft")));
			this.flpDevices.Size = ((System.Drawing.Size)(resources.GetObject("flpDevices.Size")));
			this.flpDevices.TabIndex = ((int)(resources.GetObject("flpDevices.TabIndex")));
			this.flpDevices.WrapContents = ((bool)(resources.GetObject("flpDevices.WrapContents")));
			this.flpDevices.Paint += new System.Windows.Forms.PaintEventHandler(this.flpDevicesPaint);
			// 
			// toolStripContainer1
			// 
			this.toolStripContainer1.AccessibleDescription = null;
			this.toolStripContainer1.AccessibleName = null;
			this.toolStripContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("toolStripContainer1.Anchor")));
			// 
			// toolStripContainer1.BottomToolStripPanel
			// 
			this.toolStripContainer1.BottomToolStripPanel.AccessibleDescription = null;
			this.toolStripContainer1.BottomToolStripPanel.AccessibleName = null;
			this.toolStripContainer1.BottomToolStripPanel.BackgroundImage = null;
			this.toolStripContainer1.BottomToolStripPanel.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("toolStripContainer1.BottomToolStripPanel.BackgroundImageLayout")));
			this.toolStripContainer1.BottomToolStripPanel.Font = null;
			this.toolStripContainer1.BottomToolStripPanel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("toolStripContainer1.BottomToolStripPanel.ImeMode")));
			this.toolStripContainer1.BottomToolStripPanel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("toolStripContainer1.BottomToolStripPanel.RightToLeft")));
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.AccessibleDescription = null;
			this.toolStripContainer1.ContentPanel.AccessibleName = null;
			this.toolStripContainer1.ContentPanel.AutoScroll = ((bool)(resources.GetObject("toolStripContainer1.ContentPanel.AutoScroll")));
			this.toolStripContainer1.ContentPanel.BackgroundImage = null;
			this.toolStripContainer1.ContentPanel.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("toolStripContainer1.ContentPanel.BackgroundImageLayout")));
			this.toolStripContainer1.ContentPanel.Controls.Add(this.tcMain);
			this.toolStripContainer1.ContentPanel.Font = null;
			this.toolStripContainer1.ContentPanel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("toolStripContainer1.ContentPanel.ImeMode")));
			this.toolStripContainer1.ContentPanel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("toolStripContainer1.ContentPanel.RightToLeft")));
			this.toolStripContainer1.ContentPanel.Size = ((System.Drawing.Size)(resources.GetObject("toolStripContainer1.ContentPanel.Size")));
			this.toolStripContainer1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("toolStripContainer1.Dock")));
			this.toolStripContainer1.Font = null;
			this.toolStripContainer1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("toolStripContainer1.ImeMode")));
			// 
			// toolStripContainer1.LeftToolStripPanel
			// 
			this.toolStripContainer1.LeftToolStripPanel.AccessibleDescription = null;
			this.toolStripContainer1.LeftToolStripPanel.AccessibleName = null;
			this.toolStripContainer1.LeftToolStripPanel.BackgroundImage = null;
			this.toolStripContainer1.LeftToolStripPanel.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("toolStripContainer1.LeftToolStripPanel.BackgroundImageLayout")));
			this.toolStripContainer1.LeftToolStripPanel.Font = null;
			this.toolStripContainer1.LeftToolStripPanel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("toolStripContainer1.LeftToolStripPanel.ImeMode")));
			this.toolStripContainer1.LeftToolStripPanel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("toolStripContainer1.LeftToolStripPanel.RightToLeft")));
			this.toolStripContainer1.Location = ((System.Drawing.Point)(resources.GetObject("toolStripContainer1.Location")));
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("toolStripContainer1.RightToLeft")));
			// 
			// toolStripContainer1.RightToolStripPanel
			// 
			this.toolStripContainer1.RightToolStripPanel.AccessibleDescription = null;
			this.toolStripContainer1.RightToolStripPanel.AccessibleName = null;
			this.toolStripContainer1.RightToolStripPanel.BackgroundImage = null;
			this.toolStripContainer1.RightToolStripPanel.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("toolStripContainer1.RightToolStripPanel.BackgroundImageLayout")));
			this.toolStripContainer1.RightToolStripPanel.Font = null;
			this.toolStripContainer1.RightToolStripPanel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("toolStripContainer1.RightToolStripPanel.ImeMode")));
			this.toolStripContainer1.RightToolStripPanel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("toolStripContainer1.RightToolStripPanel.RightToLeft")));
			this.toolStripContainer1.Size = ((System.Drawing.Size)(resources.GetObject("toolStripContainer1.Size")));
			this.toolStripContainer1.TabIndex = ((int)(resources.GetObject("toolStripContainer1.TabIndex")));
			this.toolStripContainer1.Text = resources.GetString("toolStripContainer1.Text");
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.AccessibleDescription = null;
			this.toolStripContainer1.TopToolStripPanel.AccessibleName = null;
			this.toolStripContainer1.TopToolStripPanel.BackgroundImage = null;
			this.toolStripContainer1.TopToolStripPanel.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("toolStripContainer1.TopToolStripPanel.BackgroundImageLayout")));
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
			this.toolStripContainer1.TopToolStripPanel.Font = null;
			this.toolStripContainer1.TopToolStripPanel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("toolStripContainer1.TopToolStripPanel.ImeMode")));
			this.toolStripContainer1.TopToolStripPanel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("toolStripContainer1.TopToolStripPanel.RightToLeft")));
			// 
			// toolStrip1
			// 
			this.toolStrip1.AccessibleDescription = null;
			this.toolStrip1.AccessibleName = null;
			this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("toolStrip1.Anchor")));
			this.toolStrip1.AutoSize = ((bool)(resources.GetObject("toolStrip1.AutoSize")));
			this.toolStrip1.BackgroundImage = null;
			this.toolStrip1.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("toolStrip1.BackgroundImageLayout")));
			this.toolStrip1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("toolStrip1.Dock")));
			this.toolStrip1.Font = null;
			this.toolStrip1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("toolStrip1.ImeMode")));
			this.toolStrip1.Location = ((System.Drawing.Point)(resources.GetObject("toolStrip1.Location")));
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("toolStrip1.RightToLeft")));
			this.toolStrip1.Size = ((System.Drawing.Size)(resources.GetObject("toolStrip1.Size")));
			this.toolStrip1.Stretch = true;
			this.toolStrip1.TabIndex = ((int)(resources.GetObject("toolStrip1.TabIndex")));
			// 
			// SolariumMainForm
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
			this.Controls.Add(this.toolStripContainer1);
			this.Controls.Add(this.mainStatusStrip);
			this.Controls.Add(this.mainMenuStrip);
			this.Font = null;
			this.Icon = null;
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MainMenuStrip = this.mainMenuStrip;
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "SolariumMainForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.RightToLeftLayout = ((bool)(resources.GetObject("$this.RightToLeftLayout")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
			this.ResizeEnd += new System.EventHandler(this.sf_resizeEnd);
			this.mainMenuStrip.ResumeLayout(false);
			this.mainMenuStrip.PerformLayout();
			this.tcMain.ResumeLayout(false);
			this.tpDevices.ResumeLayout(false);
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.FlowLayoutPanel flpDevices;
		private System.Windows.Forms.TabPage tpDevices;
		private System.Windows.Forms.TabControl tcMain;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
		private System.Windows.Forms.MenuStrip mainMenuStrip;
		//private System.Windows.Forms.StatusStrip mainStatusStrip;
		private Solarium.Gui.MFStatusStrip mainStatusStrip;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
	}
}
