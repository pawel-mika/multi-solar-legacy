/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-18
 * Time: 23:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Configuration;
using System.Windows.Forms;

using Solarium.Bios;
using Solarium.Db;
using Solarium.Frame;
using Solarium.Plugin;
using Solarium.Controller;
using Solarium.Gui;
using Solarium.Settings;
using Solarium.Utils;

namespace Solarium.Config
{
	/// <summary>
	/// Description of AppLoader.
	/// </summary>
	public class AppLauncher
	{
		private IMainFrame mf = null;

		public AppLauncher(IMainFrame mf)
		{
			this.mf = mf;
		}
		
		public bool Launch(){
			#if (DEBUG)
			log4net.LogManager.GetLogger("AppLauncher").Info("Launching application...");

			System.Version buildVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			DateTime buildDate = new DateTime(
				buildVersion.Build * TimeSpan.TicksPerDay +
				buildVersion.Revision * TimeSpan.TicksPerSecond * 2).AddYears(1999);
			log4net.LogManager.GetLogger("AppLauncher").Info(String.Format("Build: {0}", buildDate));
			#endif
			
			//reading of config sections in each class...
			mf.MainFrameUI.SplashForm.TotalItems = 5;	//5 object for the moment to create...
			mf.MainFrameUI.SplashForm.Status = "Initialising database connection...";
				
			try {
				mf.Database = new DataBase(mf);
				mf.Database.connect();
				mf.MainFrameUI.SplashForm.DoneItems += 1;

				LoginForm lf = new LoginForm(mf);
				LoginForm.LoginDialogResult result = lf.ShowDialog();
				if(result.Result == DialogResult.Cancel){
					return false;
				}

				mf.MainFrameUI.SplashForm.Status = "Setting up Bios...";
				mf.Database.InitBios(false);
				mf.MainFrameUI.SplashForm.DoneItems += 1;
				
				mf.MainFrameUI.CurrentUser = new AppUser(mf, result.WorkerOid);
				
			} catch (BiosException bex) {
				//jesli cos jest nie teges w biosie to wychodzimy w cholere
				//co by nie naprodukować bajzlu w bazie...
				Utils.DialogUtils.ShowError(mf, new Exception(string.Format("Class: {0}\nMethod: {1}",
                                                  this.GetType().FullName,
                                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                                  bex));
				mf.MainFrameUI.QuitApplication();
			} catch (Exception ex) {
				Utils.DialogUtils.ShowError(mf, new Exception(string.Format("Class: {0}\nMethod: {1}",
                                                  this.GetType().FullName,
                                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                                  ex));
			}

			mf.MainFrameUI.SplashForm.Status = "Loading plugins...";
			mf.PluginHost = new PluginHost(mf);
			mf.MainFrameUI.SplashForm.DoneItems += 1;

			mf.MainFrameUI.SplashForm.Status = "Starting view manager...";
			mf.MainFrameUI.ViewManager = new ViewManager(mf);
			mf.MainFrameUI.SplashForm.DoneItems += 1;
			
			try {
				mf.MainFrameUI.SplashForm.Status = "Starting solarium bed network...";
				mf.Network = new ModbusNetwork(mf);
				mf.MainFrameUI.SplashForm.DoneItems += 1;
			} catch (Exception ex) {
				Utils.DialogUtils.ShowError(mf, new Exception(string.Format("Class: {0}\nMethod: {1}",
                                                  this.GetType().FullName,
                                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                                  ex));
			}
	
			//trying to start autostart plugins...
			foreach(BasePlugin plug in mf.PluginHost.Plugins){
				if(plug.PluginConfigElement.Autostart){
					mf.PluginHost.ActivatePlugin(plug);
				}
			}
			
			#if (DEBUG)
			log4net.LogManager.GetLogger("AppLauncher").Info("Application ready!");
			#endif
			
			return true;
		}
	}
}
