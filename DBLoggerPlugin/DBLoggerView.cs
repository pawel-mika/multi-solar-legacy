/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-17
 * Time: 23:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Solarium;
using Solarium.Frame;
using Solarium.Utils;

using log4net;
using log4net.Appender;

namespace DBLoggerPlugin
{
	/// <summary>
	/// Description of DBLoggerView.
	/// </summary>
	public partial class DBLoggerView : UserControl
	{
		private IMainFrame mf = null;
		public delegate void StringParameterDelegate (string value);
		
		public DBLoggerView(IMainFrame mf)
		{
			this.mf = mf;
			InitializeComponent();
		}
		
		public void Log(string s){
			rtbConsole.AppendText(s);
		}
		
		public void LogOnConsole(string txt)
		{
			if (rtbConsole.InvokeRequired)
			{
				rtbConsole.BeginInvoke(new StringParameterDelegate(LogOnConsole), new object[]{txt});
				return;
			}
			this.rtbConsole.AppendText(txt);
			this.rtbConsole.Select(this.rtbConsole.TextLength,0);
			if(cbScrollToEnd.Checked) {
				this.rtbConsole.ScrollToCaret();
			} 
			if(cbFileLog.Checked) {
//				log4net.LogManager.GetLoggerRepository().GetLogger("Database").
			}
		}
				
		void BClearClick(object sender, EventArgs e)
		{
			rtbConsole.Clear();
		}
		
		private void ConfigureLog()
		{
			String path = Directory.GetCurrentDirectory() + "\\log";
			if(!Directory.Exists(path)) {
				Directory.CreateDirectory(path);
			}
			RollingFileAppender rfa = new log4net.Appender.RollingFileAppender();
			rfa.AppendToFile = true;
			rfa.MaxSizeRollBackups = 10;
			rfa.StaticLogFileName = false;
			rfa.Layout = new log4net.Layout.PatternLayout("%date [thread:%thread] %-5level %logger - %message%newline");
			rfa.File = "./log/DBLogger.txt";
			rfa.ActivateOptions();
			log4net.Config.BasicConfigurator.Configure(rfa);
		}
	}
}
