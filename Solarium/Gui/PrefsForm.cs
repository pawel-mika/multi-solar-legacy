/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-10
 * Time: 21:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

using Solarium.Controller;
using Solarium.Frame;
using Solarium.Plugin;
using Solarium.Settings;

namespace Solarium.Gui
{
	/// <summary>
	/// Description of PrefsForm.
	/// </summary>
	public partial class PrefsForm : Form
	{
		private IMainFrame mf = null;
		
		private TimesSettings timesSettings = null;
		
		/// <summary>
		/// Preferences form.
		/// </summary>
		/// <param name="mf"></param>
		public PrefsForm(IMainFrame mf)
		{
			this.mf = mf;
			InitializeComponent();
			gb_normalFont.Text = mf.MainFrameUI.NormalFont.ToString();
			
			lbPluginList.DisplayMember = "Name";
			foreach(BasePlugin p in mf.PluginHost.Plugins){
				lbPluginList.Items.Add(p);
			}
			
			for(int i = 0; i < System.Windows.Forms.Screen.AllScreens.Length; i++){
				Screen s = System.Windows.Forms.Screen.AllScreens[i];
				string st = String.Format("{0}, {1}x{2}@{3}bpp",
				                          s.DeviceName,
				                          s.Bounds.Width.ToString(),
				                          s.Bounds.Height.ToString(),
				                          s.BitsPerPixel.ToString());
				comboBox1.Items.Add(st);
			}
			
			//rsrc
			
			
			InitTimes();
		}

		/// <summary>
		/// Initlialize waiting/cleaning/cooling times controls...
		/// </summary>
		private void InitTimes(){
			int maxMinuntes = 10;
			for (int i = 0; i <= maxMinuntes; i++){
				cbWaitingMinutes.Items.Add(i.ToString());
				cbCleaningMinutes.Items.Add(i.ToString());
				cbCoolingMinutes.Items.Add(i.ToString());
			}
			for (int i = 0; i < 60; i++){
				cbWaitingSeconds.Items.Add(i.ToString());
				cbCleaningSeconds.Items.Add(i.ToString());
				cbCoolingSeconds.Items.Add(i.ToString());
			}
			
			timesSettings = TimesSettings.GetSection(ConfigurationUserLevel.None);
			
			int m = timesSettings.WaitingTime.Minutes;
			if (cbWaitingMinutes.Items[m] != null && m >=0 && m <= maxMinuntes){
				cbWaitingMinutes.SelectedIndex = m;
			} else {
				cbWaitingMinutes.SelectedIndex = 0;
			}
			int s = timesSettings.WaitingTime.Seconds;
			if (cbWaitingSeconds.Items[s] != null && s >=0 && s < 60){
				cbWaitingSeconds.SelectedIndex = s;
			} else {
				cbWaitingSeconds.SelectedIndex = 0;
			}

			m = timesSettings.CleaningTime.Minutes;
			if (cbCleaningMinutes.Items[m] != null && m >=0 && m <= maxMinuntes){
				cbCleaningMinutes.SelectedIndex = m;
			} else {
				cbCleaningMinutes.SelectedIndex = 0;
			}
			s = timesSettings.CleaningTime.Seconds;
			if (cbCleaningSeconds.Items[s] != null && s >=0 && s < 60){
				cbCleaningSeconds.SelectedIndex = s;
			} else {
				cbCleaningSeconds.SelectedIndex = 0;
			}
			
			m = timesSettings.CoolingTime.Minutes;
			if (cbCoolingMinutes.Items[m] != null && m >=0 && m <= maxMinuntes){
				cbCoolingMinutes.SelectedIndex = m;
			} else {
				cbCoolingMinutes.SelectedIndex = 0;
			}
			s = timesSettings.CoolingTime.Seconds;
			if (cbCoolingSeconds.Items[s] != null && s >=0 && s < 60){
				cbCoolingSeconds.SelectedIndex = s;
			} else {
				cbCoolingSeconds.SelectedIndex = 0;
			}
		}
		
		void gb_normalFontClicked(object sender, EventArgs e)
		{
			if(fontDialog.ShowDialog()==DialogResult.OK){
				mf.MainFrameUI.NormalFont = fontDialog.Font;
				gb_normalFont.Text = fontDialog.Font.ToString();
			}
		}

		/// <summary>
		/// Close prefs form writting some changes to configs.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void GbOkClick(object sender, EventArgs e)
		{
			//zapisujemy ustawienia czasów...
			if(timesSettings != null){
				TimeSpan t = TimeSpan.Parse(
					string.Format("00:{0}:{1}", 
					              cbWaitingMinutes.SelectedIndex, 
					              cbWaitingSeconds.SelectedIndex));
				timesSettings.WaitingTime = t;
				
				t = TimeSpan.Parse(
					string.Format("00:{0}:{1}", 
					              cbCleaningMinutes.SelectedIndex, 
					              cbCleaningSeconds.SelectedIndex));
				timesSettings.CleaningTime = t;
				
				t = TimeSpan.Parse(
					string.Format("00:{0}:{1}", 
					              cbCoolingMinutes.SelectedIndex, 
					              cbCoolingSeconds.SelectedIndex));
				timesSettings.CoolingTime = t;
				
				timesSettings.Save();
			}
			
			//zamykamy dialog...
			this.Dispose();
		}

		/// <summary>
		/// Close prefs form doing nothing (canceling all changes).
		/// So... basically only dispose()
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void GbCancelClick(object sender, EventArgs e)
		{
			this.Dispose();
		}

		void lbPlugins_selIndexChanged(object sender, EventArgs e)
		{
			try{
				BasePlugin p = (BasePlugin)lbPluginList.SelectedItem;
				lNameVal.Text = p.Name;
				lAuthorVal.Text = p.Author;
				lVersionVal.Text = p.Version;	
				lDescVal.Text = p.Description;
			}catch(Exception ex){
				Solarium.Utils.DialogUtils.ShowError(mf,"Error",ex.Message);
			}
		}


	}
}
