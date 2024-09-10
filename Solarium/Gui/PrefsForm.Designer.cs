/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-10
 * Time: 21:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Solarium.Gui
{
	partial class PrefsForm
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
			this.tPrefs = new System.Windows.Forms.TabControl();
			this.tpApperance = new System.Windows.Forms.TabPage();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.lLanguage = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.bg_bigFont = new Glass.GlassButton();
			this.bg_smallFont = new Glass.GlassButton();
			this.gb_normalFont = new Glass.GlassButton();
			this.tpPlugins = new System.Windows.Forms.TabPage();
			this.gbPluginsInfo = new System.Windows.Forms.GroupBox();
			this.lDescVal = new System.Windows.Forms.Label();
			this.lDesc = new System.Windows.Forms.Label();
			this.lVersionVal = new System.Windows.Forms.Label();
			this.lVersion = new System.Windows.Forms.Label();
			this.lAuthorVal = new System.Windows.Forms.Label();
			this.lAuthor = new System.Windows.Forms.Label();
			this.lNameVal = new System.Windows.Forms.Label();
			this.lName = new System.Windows.Forms.Label();
			this.lbPluginList = new System.Windows.Forms.ListBox();
			this.tpNetwork = new System.Windows.Forms.TabPage();
			this.tpDevices = new System.Windows.Forms.TabPage();
			this.gbTimes = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.gbOk = new Glass.GlassButton();
			this.gbCancel = new Glass.GlassButton();
			this.panelButtons = new System.Windows.Forms.Panel();
			this.panelTabs = new System.Windows.Forms.Panel();
			this.fontDialog = new System.Windows.Forms.FontDialog();
			this.cbWaitingMinutes = new System.Windows.Forms.ComboBox();
			this.cbWaitingSeconds = new System.Windows.Forms.ComboBox();
			this.cbCleaningSeconds = new System.Windows.Forms.ComboBox();
			this.cbCleaningMinutes = new System.Windows.Forms.ComboBox();
			this.cbCoolingSeconds = new System.Windows.Forms.ComboBox();
			this.cbCoolingMinutes = new System.Windows.Forms.ComboBox();
			this.tPrefs.SuspendLayout();
			this.tpApperance.SuspendLayout();
			this.tpPlugins.SuspendLayout();
			this.gbPluginsInfo.SuspendLayout();
			this.tpDevices.SuspendLayout();
			this.gbTimes.SuspendLayout();
			this.panelButtons.SuspendLayout();
			this.panelTabs.SuspendLayout();
			this.SuspendLayout();
			// 
			// tPrefs
			// 
			this.tPrefs.Controls.Add(this.tpApperance);
			this.tPrefs.Controls.Add(this.tpPlugins);
			this.tPrefs.Controls.Add(this.tpNetwork);
			this.tPrefs.Controls.Add(this.tpDevices);
			this.tPrefs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tPrefs.Location = new System.Drawing.Point(2, 2);
			this.tPrefs.Margin = new System.Windows.Forms.Padding(2);
			this.tPrefs.Name = "tPrefs";
			this.tPrefs.Padding = new System.Drawing.Point(4, 4);
			this.tPrefs.SelectedIndex = 0;
			this.tPrefs.Size = new System.Drawing.Size(472, 467);
			this.tPrefs.TabIndex = 0;
			// 
			// tpApperance
			// 
			this.tpApperance.Controls.Add(this.comboBox2);
			this.tpApperance.Controls.Add(this.lLanguage);
			this.tpApperance.Controls.Add(this.comboBox1);
			this.tpApperance.Controls.Add(this.bg_bigFont);
			this.tpApperance.Controls.Add(this.bg_smallFont);
			this.tpApperance.Controls.Add(this.gb_normalFont);
			this.tpApperance.Location = new System.Drawing.Point(4, 24);
			this.tpApperance.Name = "tpApperance";
			this.tpApperance.Padding = new System.Windows.Forms.Padding(3);
			this.tpApperance.Size = new System.Drawing.Size(464, 439);
			this.tpApperance.TabIndex = 0;
			this.tpApperance.Text = "Apperance";
			this.tpApperance.UseVisualStyleBackColor = true;
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(112, 3);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(160, 21);
			this.comboBox2.TabIndex = 5;
			// 
			// lLanguage
			// 
			this.lLanguage.Location = new System.Drawing.Point(6, 3);
			this.lLanguage.Name = "lLanguage";
			this.lLanguage.Size = new System.Drawing.Size(100, 20);
			this.lLanguage.TabIndex = 4;
			this.lLanguage.Text = "Language:";
			this.lLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(134, 409);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(320, 21);
			this.comboBox1.TabIndex = 3;
			// 
			// bg_bigFont
			// 
			this.bg_bigFont.BackColor = System.Drawing.Color.Blue;
			this.bg_bigFont.Location = new System.Drawing.Point(134, 380);
			this.bg_bigFont.Margin = new System.Windows.Forms.Padding(2);
			this.bg_bigFont.Name = "bg_bigFont";
			this.bg_bigFont.Size = new System.Drawing.Size(320, 24);
			this.bg_bigFont.TabIndex = 2;
			this.bg_bigFont.Text = "gb_bigFont";
			// 
			// bg_smallFont
			// 
			this.bg_smallFont.BackColor = System.Drawing.Color.Blue;
			this.bg_smallFont.Location = new System.Drawing.Point(134, 324);
			this.bg_smallFont.Margin = new System.Windows.Forms.Padding(2);
			this.bg_smallFont.Name = "bg_smallFont";
			this.bg_smallFont.Size = new System.Drawing.Size(320, 24);
			this.bg_smallFont.TabIndex = 1;
			this.bg_smallFont.Text = "bg_smallFont";
			// 
			// gb_normalFont
			// 
			this.gb_normalFont.BackColor = System.Drawing.Color.Blue;
			this.gb_normalFont.Location = new System.Drawing.Point(134, 352);
			this.gb_normalFont.Margin = new System.Windows.Forms.Padding(2);
			this.gb_normalFont.Name = "gb_normalFont";
			this.gb_normalFont.Size = new System.Drawing.Size(320, 24);
			this.gb_normalFont.TabIndex = 0;
			this.gb_normalFont.Text = "gb_normalFont";
			this.gb_normalFont.Click += new System.EventHandler(this.gb_normalFontClicked);
			// 
			// tpPlugins
			// 
			this.tpPlugins.Controls.Add(this.gbPluginsInfo);
			this.tpPlugins.Location = new System.Drawing.Point(4, 24);
			this.tpPlugins.Name = "tpPlugins";
			this.tpPlugins.Size = new System.Drawing.Size(464, 439);
			this.tpPlugins.TabIndex = 3;
			this.tpPlugins.Text = "Plugins";
			this.tpPlugins.UseVisualStyleBackColor = true;
			// 
			// gbPluginsInfo
			// 
			this.gbPluginsInfo.Controls.Add(this.lDescVal);
			this.gbPluginsInfo.Controls.Add(this.lDesc);
			this.gbPluginsInfo.Controls.Add(this.lVersionVal);
			this.gbPluginsInfo.Controls.Add(this.lVersion);
			this.gbPluginsInfo.Controls.Add(this.lAuthorVal);
			this.gbPluginsInfo.Controls.Add(this.lAuthor);
			this.gbPluginsInfo.Controls.Add(this.lNameVal);
			this.gbPluginsInfo.Controls.Add(this.lName);
			this.gbPluginsInfo.Controls.Add(this.lbPluginList);
			this.gbPluginsInfo.Location = new System.Drawing.Point(6, 3);
			this.gbPluginsInfo.Name = "gbPluginsInfo";
			this.gbPluginsInfo.Size = new System.Drawing.Size(448, 427);
			this.gbPluginsInfo.TabIndex = 1;
			this.gbPluginsInfo.TabStop = false;
			this.gbPluginsInfo.Text = "Loaded plugins info";
			// 
			// lDescVal
			// 
			this.lDescVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lDescVal.Location = new System.Drawing.Point(170, 130);
			this.lDescVal.Name = "lDescVal";
			this.lDescVal.Size = new System.Drawing.Size(272, 64);
			this.lDescVal.TabIndex = 8;
			this.lDescVal.Text = ".";
			// 
			// lDesc
			// 
			this.lDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lDesc.Location = new System.Drawing.Point(170, 114);
			this.lDesc.Name = "lDesc";
			this.lDesc.Size = new System.Drawing.Size(272, 16);
			this.lDesc.TabIndex = 7;
			this.lDesc.Text = "Description:";
			this.lDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lVersionVal
			// 
			this.lVersionVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lVersionVal.Location = new System.Drawing.Point(170, 98);
			this.lVersionVal.Name = "lVersionVal";
			this.lVersionVal.Size = new System.Drawing.Size(272, 16);
			this.lVersionVal.TabIndex = 6;
			this.lVersionVal.Text = ".";
			// 
			// lVersion
			// 
			this.lVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lVersion.Location = new System.Drawing.Point(170, 82);
			this.lVersion.Name = "lVersion";
			this.lVersion.Size = new System.Drawing.Size(272, 16);
			this.lVersion.TabIndex = 5;
			this.lVersion.Text = "Version:";
			this.lVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lAuthorVal
			// 
			this.lAuthorVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lAuthorVal.Location = new System.Drawing.Point(170, 66);
			this.lAuthorVal.Name = "lAuthorVal";
			this.lAuthorVal.Size = new System.Drawing.Size(272, 16);
			this.lAuthorVal.TabIndex = 4;
			this.lAuthorVal.Text = ".";
			// 
			// lAuthor
			// 
			this.lAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lAuthor.Location = new System.Drawing.Point(170, 50);
			this.lAuthor.Name = "lAuthor";
			this.lAuthor.Size = new System.Drawing.Size(272, 16);
			this.lAuthor.TabIndex = 3;
			this.lAuthor.Text = "Author:";
			this.lAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lNameVal
			// 
			this.lNameVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lNameVal.Location = new System.Drawing.Point(170, 34);
			this.lNameVal.Name = "lNameVal";
			this.lNameVal.Size = new System.Drawing.Size(272, 16);
			this.lNameVal.TabIndex = 2;
			this.lNameVal.Text = ".";
			// 
			// lName
			// 
			this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lName.Location = new System.Drawing.Point(170, 18);
			this.lName.Name = "lName";
			this.lName.Size = new System.Drawing.Size(272, 16);
			this.lName.TabIndex = 1;
			this.lName.Text = "Name:";
			this.lName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbPluginList
			// 
			this.lbPluginList.FormattingEnabled = true;
			this.lbPluginList.Location = new System.Drawing.Point(5, 18);
			this.lbPluginList.Margin = new System.Windows.Forms.Padding(2);
			this.lbPluginList.Name = "lbPluginList";
			this.lbPluginList.Size = new System.Drawing.Size(160, 394);
			this.lbPluginList.TabIndex = 0;
			this.lbPluginList.SelectedIndexChanged += new System.EventHandler(this.lbPlugins_selIndexChanged);
			// 
			// tpNetwork
			// 
			this.tpNetwork.Location = new System.Drawing.Point(4, 24);
			this.tpNetwork.Name = "tpNetwork";
			this.tpNetwork.Padding = new System.Windows.Forms.Padding(3);
			this.tpNetwork.Size = new System.Drawing.Size(464, 439);
			this.tpNetwork.TabIndex = 1;
			this.tpNetwork.Text = "Network";
			this.tpNetwork.UseVisualStyleBackColor = true;
			// 
			// tpDevices
			// 
			this.tpDevices.Controls.Add(this.gbTimes);
			this.tpDevices.Location = new System.Drawing.Point(4, 24);
			this.tpDevices.Name = "tpDevices";
			this.tpDevices.Size = new System.Drawing.Size(464, 439);
			this.tpDevices.TabIndex = 2;
			this.tpDevices.Text = "Devices";
			this.tpDevices.UseVisualStyleBackColor = true;
			// 
			// gbTimes
			// 
			this.gbTimes.Controls.Add(this.cbCoolingSeconds);
			this.gbTimes.Controls.Add(this.label3);
			this.gbTimes.Controls.Add(this.label2);
			this.gbTimes.Controls.Add(this.cbCoolingMinutes);
			this.gbTimes.Controls.Add(this.cbCleaningSeconds);
			this.gbTimes.Controls.Add(this.cbCleaningMinutes);
			this.gbTimes.Controls.Add(this.cbWaitingSeconds);
			this.gbTimes.Controls.Add(this.cbWaitingMinutes);
			this.gbTimes.Controls.Add(this.label1);
			this.gbTimes.Location = new System.Drawing.Point(6, 3);
			this.gbTimes.Name = "gbTimes";
			this.gbTimes.Size = new System.Drawing.Size(450, 95);
			this.gbTimes.TabIndex = 0;
			this.gbTimes.TabStop = false;
			this.gbTimes.Text = "Times";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 20);
			this.label3.TabIndex = 2;
			this.label3.Text = "Cooling time:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "Cleaning time:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Waiting time:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// gbOk
			// 
			this.gbOk.BackColor = System.Drawing.Color.ForestGreen;
			this.gbOk.Location = new System.Drawing.Point(12, 3);
			this.gbOk.Name = "gbOk";
			this.gbOk.Size = new System.Drawing.Size(160, 24);
			this.gbOk.TabIndex = 1;
			this.gbOk.Text = "Ok";
			this.gbOk.Click += new System.EventHandler(this.GbOkClick);
			// 
			// gbCancel
			// 
			this.gbCancel.BackColor = System.Drawing.Color.Red;
			this.gbCancel.Location = new System.Drawing.Point(300, 3);
			this.gbCancel.Name = "gbCancel";
			this.gbCancel.Size = new System.Drawing.Size(160, 24);
			this.gbCancel.TabIndex = 2;
			this.gbCancel.Text = "Cancel";
			this.gbCancel.Click += new System.EventHandler(this.GbCancelClick);
			// 
			// panelButtons
			// 
			this.panelButtons.Controls.Add(this.gbOk);
			this.panelButtons.Controls.Add(this.gbCancel);
			this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelButtons.Location = new System.Drawing.Point(0, 469);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(474, 30);
			this.panelButtons.TabIndex = 3;
			// 
			// panelTabs
			// 
			this.panelTabs.Controls.Add(this.tPrefs);
			this.panelTabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelTabs.Location = new System.Drawing.Point(0, 0);
			this.panelTabs.Name = "panelTabs";
			this.panelTabs.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
			this.panelTabs.Size = new System.Drawing.Size(474, 469);
			this.panelTabs.TabIndex = 4;
			// 
			// fontDialog
			// 
			this.fontDialog.AllowVerticalFonts = false;
			this.fontDialog.ShowColor = true;
			// 
			// cbWaitingMinutes
			// 
			this.cbWaitingMinutes.FormattingEnabled = true;
			this.cbWaitingMinutes.Location = new System.Drawing.Point(132, 15);
			this.cbWaitingMinutes.Name = "cbWaitingMinutes";
			this.cbWaitingMinutes.Size = new System.Drawing.Size(40, 21);
			this.cbWaitingMinutes.TabIndex = 3;
			// 
			// cbWaitingSeconds
			// 
			this.cbWaitingSeconds.FormattingEnabled = true;
			this.cbWaitingSeconds.Location = new System.Drawing.Point(178, 15);
			this.cbWaitingSeconds.Name = "cbWaitingSeconds";
			this.cbWaitingSeconds.Size = new System.Drawing.Size(40, 21);
			this.cbWaitingSeconds.TabIndex = 4;
			// 
			// cbCleaningSeconds
			// 
			this.cbCleaningSeconds.FormattingEnabled = true;
			this.cbCleaningSeconds.Location = new System.Drawing.Point(178, 42);
			this.cbCleaningSeconds.Name = "cbCleaningSeconds";
			this.cbCleaningSeconds.Size = new System.Drawing.Size(40, 21);
			this.cbCleaningSeconds.TabIndex = 6;
			// 
			// cbCleaningMinutes
			// 
			this.cbCleaningMinutes.FormattingEnabled = true;
			this.cbCleaningMinutes.Location = new System.Drawing.Point(132, 42);
			this.cbCleaningMinutes.Name = "cbCleaningMinutes";
			this.cbCleaningMinutes.Size = new System.Drawing.Size(40, 21);
			this.cbCleaningMinutes.TabIndex = 5;
			// 
			// cbCoolingSeconds
			// 
			this.cbCoolingSeconds.FormattingEnabled = true;
			this.cbCoolingSeconds.Location = new System.Drawing.Point(178, 69);
			this.cbCoolingSeconds.Name = "cbCoolingSeconds";
			this.cbCoolingSeconds.Size = new System.Drawing.Size(40, 21);
			this.cbCoolingSeconds.TabIndex = 8;
			// 
			// cbCoolingMinutes
			// 
			this.cbCoolingMinutes.FormattingEnabled = true;
			this.cbCoolingMinutes.Location = new System.Drawing.Point(132, 69);
			this.cbCoolingMinutes.Name = "cbCoolingMinutes";
			this.cbCoolingMinutes.Size = new System.Drawing.Size(40, 21);
			this.cbCoolingMinutes.TabIndex = 7;
			// 
			// PrefsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(474, 499);
			this.Controls.Add(this.panelTabs);
			this.Controls.Add(this.panelButtons);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(480, 520);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(480, 520);
			this.Name = "PrefsForm";
			this.Text = "Preferences";
			this.tPrefs.ResumeLayout(false);
			this.tpApperance.ResumeLayout(false);
			this.tpPlugins.ResumeLayout(false);
			this.gbPluginsInfo.ResumeLayout(false);
			this.tpDevices.ResumeLayout(false);
			this.gbTimes.ResumeLayout(false);
			this.panelButtons.ResumeLayout(false);
			this.panelTabs.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ComboBox cbWaitingMinutes;
		private System.Windows.Forms.ComboBox cbWaitingSeconds;
		private System.Windows.Forms.ComboBox cbCleaningMinutes;
		private System.Windows.Forms.ComboBox cbCleaningSeconds;
		private System.Windows.Forms.ComboBox cbCoolingMinutes;
		private System.Windows.Forms.ComboBox cbCoolingSeconds;
		private System.Windows.Forms.Label lLanguage;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox gbTimes;
		private System.Windows.Forms.ComboBox comboBox1;
		private Glass.GlassButton gb_normalFont;
		private Glass.GlassButton bg_bigFont;
		private Glass.GlassButton bg_smallFont;
		private System.Windows.Forms.ListBox lbPluginList;
		private System.Windows.Forms.Label lName;
		private System.Windows.Forms.Label lNameVal;
		private System.Windows.Forms.Label lAuthor;
		private System.Windows.Forms.Label lAuthorVal;
		private System.Windows.Forms.Label lVersion;
		private System.Windows.Forms.Label lVersionVal;
		private System.Windows.Forms.Label lDesc;
		private System.Windows.Forms.Label lDescVal;
		private System.Windows.Forms.GroupBox gbPluginsInfo;
		private System.Windows.Forms.TabPage tpPlugins;
		private System.Windows.Forms.FontDialog fontDialog;
		private System.Windows.Forms.Panel panelButtons;
		private System.Windows.Forms.Panel panelTabs;
		private Glass.GlassButton gbCancel;
		private Glass.GlassButton gbOk;
		private System.Windows.Forms.TabPage tpDevices;
		private System.Windows.Forms.TabPage tpNetwork;
		private System.Windows.Forms.TabPage tpApperance;
		private System.Windows.Forms.TabControl tPrefs;
	}
}
