﻿/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-10-06
 * Time: 15:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

using Solarium.Frame;

namespace Solarium.Gui
{
	/// <summary>
	/// Description of AboutForm.
	/// </summary>
	public partial class AboutForm : Form
	{
		private IMainFrame mf = null;
		private string about = "";
		
		public AboutForm(IMainFrame mf)
		{
			InitializeComponent();
			this.mf = mf;
			
			Bitmap b = new Bitmap("images/Splash2White.png");
			pictureBox1.Image = b;
			
			System.Version buildVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

			// v.Build is days since Jan. 1, 2000
			// v.Revision*2 is seconds since local midnight
			// (NEVER daylight saving time)

			DateTime buildDate = new DateTime(2000,1,1).AddDays(buildVersion.Build).AddSeconds(buildVersion.Revision * 2);

			about += Environment.NewLine;
			about += "Solarium"+Environment.NewLine;
			about += string.Format("App/Bios version: {0}", 
			                       mf.Database.Bios!=null?mf.Database.Bios.BiosVersion.ToString():"DB_ERROR");
			about += Environment.NewLine;
			about += string.Format("Compilation: {0} ({1})",
			                       buildVersion, buildDate);
			about += Environment.NewLine;
			about += "Copyright 2007-2009 by Pablo & RedCod";
			about += Environment.NewLine;
			about += "All rights reserverd";
			about += Environment.NewLine;
			about += "MutanaFramework Copyright 2007-2009 by Pablo";
			about += Environment.NewLine;
			about += "All rights reserverd";
			rtbAbout.AppendText(about);
		}
	}
}
