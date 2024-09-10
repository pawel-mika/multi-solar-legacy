/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-08-07
 * Time: 21:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

#define DEBUG
#define LOG_ERRORS

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Resources;
using System.Threading;

using log4net;
using log4net.Config;
using log4net.Appender;

using Solarium.Bios;
using Solarium.Bios.Model;
using Solarium.Config;
using Solarium.Controller;
using Solarium.Controls;
using Solarium.Db;
using Solarium.Frame;
using Solarium.Gui;
using Solarium.Plugin;
using Solarium.Settings;

namespace Solarium
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class SolariumMainForm : Form, IMainFrame
	{
		#if (DEBUG)
		private static readonly ILog logger = LogManager.GetLogger("Solarium");
		public ILog Logger {
			get { return logger; }
		}
		#endif
		
		private Font smallFont = new Font("Tahoma", 8.0f, FontStyle.Regular);
		public Font SmallFont {
			get { return smallFont; }
			set { smallFont = value; }
		}
		
		private Font normalFont = new Font("Tahoma", 9.0f, FontStyle.Regular);
		public Font NormalFont {
			get { return normalFont; }
			set {
				PrefsChangedEventArgs pcea = new PrefsChangedEventArgs(this);
				pcea.NormalFont = value;
				FirePrefsChanged(pcea);
				normalFont = value;
				mainMenuStrip.Font = normalFont;
				mainStatusStrip.Font = normalFont;
				foreach(Control c in flpDevices.Controls){
					if(c is SlaveDeviceControl){
						((SlaveDeviceControl)c).setNormalFont(normalFont);
					}
				}
			}
		}
		
		private Font bigFont = new Font("Tahoma", 11.0f, FontStyle.Regular);
		public Font BigFont {
			get { return bigFont; }
			set { bigFont = value; }
		}

		private string[] cmdParams = null;
		public string[] CmdParams {
			get { return cmdParams; }
		}
		
		private SplashForm splashForm = null;
		public SplashForm SplashForm {
			get { return splashForm; }
			set { splashForm = value; }
		}
		
		private AppUser currentUser = null;
		public AppUser CurrentUser {
			get { return currentUser; }
			set { currentUser = value; }
		}
		
		private ModbusNetwork network = null;
		public ModbusNetwork Network {
			get { return network; }
			set { network = value; }
		}

		private DataBase database = null;
		public DataBase Database {
			get { return database; }
			set { database = value; }
		}

		private PluginHost pluginHost = null;
		public PluginHost PluginHost {
			get { return pluginHost; }
			set { pluginHost = value; }
		}

		private ViewManager viewManager = null;
		public ViewManager ViewManager {
			get { return viewManager; }
			set { viewManager = value; }
		}
		
		private ResourceManager mfResourceManager = new ResourceManager("g", System.Reflection.Assembly.GetExecutingAssembly());
		public ResourceManager MFResourceManager {
			get { return mfResourceManager; }
		}
		
		public MFStatusStrip MFStatusStrip {
			get { return mainStatusStrip; }
			set { this.mainStatusStrip = value; }
		}
		
		private ApplicationSettings applicationSettings = ApplicationSettings.GetSection(ConfigurationUserLevel.None);
		public ApplicationSettings ApplicationSettings{
			get 
			{
				return applicationSettings; 
			}
		}

//		private AppUser currentShift = null;
//		public AppUser CurrentShift {
//			get { return currentShift; }
//			set { 
//				try {
//					//create shift object
//					ObjectID oid = database.Bios.CreateObject(30);
//					ChangeSet cs = new ChangeSet(database.Bios.GetMainComponentForObject(oid));
//					cs.AddChange("cash", 1000.0f);
//					
//					//database.Bios.ModifyComponent(cs);
//					
//					//database.Bios.g
//				} catch (Exception ex) {
//					Utils.DialogUtils.ShowError(this, "Error creating shift for user",
//                            new Exception(string.Format("Class: {0}\nMethod: {1}",
//                                  this.GetType().FullName,
//                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
//                                  ex));
//				}
//			}
//		}

		public SolariumMainForm MainFrameUI{
			get { return this; }
		}
		
		public ToolStrip ToolStrip{
			get { return this.toolStrip1; }
		}

		public FlowLayoutPanel SlaveDevicesPanel{
			get { return this.flpDevices; }
		}
		
		public event PrefsChangedEventHandler PrefsChanged;
		
		protected virtual void FirePrefsChanged(PrefsChangedEventArgs e){
			if(PrefsChanged!=null){
				PrefsChanged(this, e);
			}
		}

		/// <summary>
		/// Main TabControl holding devices tab, and all the IViewPlugin tabs
		/// </summary>
		public TabControl TabControl{
			get {return this.tcMain;}
		}
		
		/// <summary>
		/// Menu entry that is holding list of created IViewPlugins.
		/// </summary>
		public ToolStripMenuItem ViewMenuEntry{
			get {return this.viewToolStripMenuItem;}
			set {this.viewToolStripMenuItem = value;}
		}
		
		
		delegate void SDCParamDelegate(ISlaveDeviceControl sdc);
		
		
		/// <summary>
		/// Main entry point of the application.
		/// </summary>
		/// <param name="args">Command line parameters</param>
		[STAThread]
		public static void Main(string[] args)
		{
			#if (DEBUG)
			ConfigureLogger();
			#endif
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new SolariumMainForm(args));
		}
		
		/// <summary>
		/// Configure logging
		/// </summary>
		public static void ConfigureLogger() 
		{
			String path = Directory.GetCurrentDirectory() + "\\log";
			if(!Directory.Exists(path)) {
				Directory.CreateDirectory(path);
			}
			RollingFileAppender rfa = new log4net.Appender.RollingFileAppender();
			rfa.AppendToFile = true;
			rfa.MaxSizeRollBackups = 10;
			rfa.StaticLogFileName = false;
			rfa.DatePattern = " - yyyy-MM-dd.'log'";
			rfa.Layout = new log4net.Layout.PatternLayout("%date [thread:%thread] %-5level %logger - %message%newline");
			rfa.File = "./log/debug";
			rfa.ActivateOptions();
			log4net.Config.BasicConfigurator.Configure(rfa);
		}
		
		/// <summary>
		/// Main form ctor. Here the fun begins:)
		/// </summary>
		/// <param name="args"></param>
		public SolariumMainForm(string[] args)
		{
			try {
				//store the command line args for further use
				cmdParams = args;

				splashForm = new SplashForm(this);
				splashForm.Show();
				
				// The InitializeComponent() call is required for Windows Forms designer support.
				InitializeComponent();
				
				//w razie wyłaczenia maxymalizacji walniemy okno na pol ekranu tylko;)
				this.StartPosition = FormStartPosition.Manual;

				this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width / 2;
				this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
				this.Location = new Point(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Left,
				                         System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Top);
				
				this.WindowState = FormWindowState.Maximized;
				
				//viewManager = new ViewManager(this);
				//Configure application from a file.
				//if no config file found, create
				//default main objects in delivered frame (this)
				//Configuration cfg = new Configuration(this);
				
				//chwilowo sprawdzamy po konfigu zeby miec poinizjalizowane obiekty starym sposobem:
				AppLauncher al = new AppLauncher(this);
				if(al.Launch() == false){
					QuitApplication();
				}else{
					//fill panel with devices
					if(network != null && network.SlaveDevices!=null){
						foreach(ISlaveDeviceControl dc in network.SlaveDevices){
							flpDevices.Controls.Add((Control)dc);
						}
						mainStatusStrip.StatusMessage.Text="Liczba urządzeń: "+network.SlaveDevices.Count;
						
						network.SlaveRemoved += new ModbusNetworkEventHandler(OnSlaveRemoved);
						network.SlaveAdded += new ModbusNetworkEventHandler(OnSlaveAdded);
					}
					splashForm.Dispose();
				}
			} catch (Exception ex) {
				Utils.DialogUtils.ShowError(this, "Application launching error",
                            new Exception(string.Format("Class: {0}\nMethod: {1}",
                                  this.GetType().FullName,
                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()),
                                  ex));
			} finally {
				if(splashForm.Visible){
					splashForm.Dispose();
				}
			}
		}

		/// <summary>
		/// handles event when slave is disconnected and removed from Network
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSlaveRemoved(object sender, ModbusNetworkEvent e){
			RemoveSlaveFromPanel(e.SlaveDeviceControl);
		}

		/// <summary>
		/// handles event when slave is connected and appears in Network
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSlaveAdded(object sender, ModbusNetworkEvent e){
			AddSlaveToPanel(e.SlaveDeviceControl);
		}

		/// <summary>
		/// Add slave control to slave devices panel
		/// </summary>
		/// <param name="sdc"></param>
		public void AddSlaveToPanel(ISlaveDeviceControl sdc){
			if(flpDevices.InvokeRequired){
				flpDevices.BeginInvoke( new SDCParamDelegate( AddSlaveToPanel ), new object[]{sdc});
				return;
			}
			flpDevices.Controls.Add((Control)sdc);
			mainStatusStrip.StatusMessage.Text="Liczba urządzeń: "+network.SlaveDevices.Count;
		}
		
		/// <summary>
		/// Remove slave control from slave devices panel
		/// </summary>
		/// <param name="sdc"></param>
		public void RemoveSlaveFromPanel(ISlaveDeviceControl sdc){
			if(flpDevices.InvokeRequired){
				flpDevices.BeginInvoke( new SDCParamDelegate( RemoveSlaveFromPanel ), new object[]{sdc});
				return;
			}
			flpDevices.Controls.Remove((Control)sdc);
			mainStatusStrip.StatusMessage.Text="Liczba urządzeń: "+network.SlaveDevices.Count;
		}

		/// <summary>
		/// Paint flowPanelLayout background...
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void flpDevicesPaint(object sender, PaintEventArgs e)
		{
              LinearGradientBrush b = new LinearGradientBrush(this.ClientRectangle, Color.SteelBlue, Color.LightSkyBlue, 90, true);
              e.Graphics.FillRectangle(b, this.ClientRectangle);
		}
		
		/// <summary>
		/// Refresh UI after resize done...
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void sf_resizeEnd(object sender, EventArgs e)
		{
			flpDevices.Refresh();
		}
		
		#region _Menu handling

		void QuitToolStripMenuItemClick(object sender, EventArgs e)
		{
			QuitApplication();
			Application.Exit();
		}
		
		void PreferencesToolStripMenuItemClick(object sender, EventArgs e)
		{
			PrefsForm pf = new PrefsForm(this);
			pf.ShowDialog();
		}

		void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			AboutForm af = new AboutForm(this);
			af.ShowDialog();
		}

		#endregion

		void setNormalFont(Font font)
		{
		}
		

		public void QuitApplication(){
			if(PluginHost!=null){
				PluginHost.DisposeAll();
			}
			ShutdownNetwork();
			this.Close();
			this.Dispose();
			Environment.Exit(0);
		}
		
		void OnFormClosed(object sender, FormClosedEventArgs e)
		{

		}

		void OnFormClosing(object sender, FormClosingEventArgs e)
		{
			if(PluginHost!=null){
				PluginHost.DisposeAll();
			}
			Network.StopSlavePingTimer();
			ShutdownNetwork();
		}
		
		#region _private_methods
		
		/// <summary>
		/// Try to shutdown network if it was initialized and some slaves were present
		/// </summary>
		private void ShutdownNetwork(){
			if(network != null && network.SlaveDevices!=null){
				foreach(ISlaveDeviceControl s in network.SlaveDevices)
				{
					s.DisposeDevice();
				}
			}
		}

		#endregion
		
	}
}
