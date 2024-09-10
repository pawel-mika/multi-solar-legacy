/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-16
 * Time: 21:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

using Solarium.Frame;
using Solarium.Settings;

namespace Solarium.Gui
{
	/// <summary>
	/// Description of SplashForm.
	/// </summary>
	public partial class SplashForm : Form
	{
		private IMainFrame mf = null;
	
		public delegate void StringParamDelegate (string value);
		public delegate void IntParamDelegate (int value);
		public delegate void ImageParamDelegate (Image value);
		
		private int totalItems = 0;
		public int TotalItems {
			get { return totalItems; }
			set { 
				totalItems = value;
				if(totalItems>0){
					SetProgress((100*doneItems)/totalItems);
				}
			}
		}

		private int doneItems = 0;
		public int DoneItems {
			get { return doneItems; }
			set { 
				doneItems = value;
				if(totalItems>0){
					SetProgress((100*doneItems)/totalItems);
				}
			}
		}
		
		public string Status {
			get { return lStatus.Text; }
			set { SetStatus(value); }
		}
		
		public Image Image {
			get { return pbImage.Image; }
			set { SetImage(value); }
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="mf"></param>
		public SplashForm(IMainFrame mf)
		{
			this.mf = mf;
			InitializeComponent();
			
			if(mf.ApplicationSettings.Paths != null){
				string basePath,imgPath;
				
				ApplicationElement ae = mf.ApplicationSettings.Paths["basePath"];
				if(ae != null){
					basePath = ae.Value;
				}else{
					ae = new ApplicationElement();
					ae.Name = "BasePath";
					ae.Value = "./";
					mf.ApplicationSettings.Paths.Add(ae);
					mf.ApplicationSettings.Save();
					basePath = ae.Value;
				}
				
				ae = mf.ApplicationSettings.Paths["splashPath"];
				if(ae != null){
					imgPath = ae.Value;
				}else{
					ae = new ApplicationElement();
					ae.Name = "SplashPath";
					ae.Value = "images/Splash2White.png";
					mf.ApplicationSettings.Paths.Add(ae);
					mf.ApplicationSettings.Save();
					imgPath = ae.Value;
				}
				
				Bitmap b = new Bitmap(string.Format("{0}{1}",basePath, imgPath));
				
				//przeliczamy wielkosci...
				this.Width = b.Width;
				this.Height = b.Height + pbProgress.Height + lStatus.Height;
				
				pbImage.Height = b.Height;
				pbImage.Width = b.Width;
				
				pbImage.Left = 0;
				pbImage.Top = 0;
				
				pbProgress.Top = pbImage.Height;
				pbProgress.Width = pbImage.Width;
				SetImage(b);
			}else{
				//hard version...
				SetImage(new Bitmap("images/Splash2White.png"));
			}
		}
		
		private void SetProgress(int progress){
			if (pbProgress.InvokeRequired)
			{
				pbProgress.BeginInvoke(new IntParamDelegate(SetProgress), new object[]{progress});
				return;
			}
			this.pbProgress.Value = progress;
			this.Update();
		}
		
		private void SetStatus(string status){
			if (lStatus.InvokeRequired)
			{
				lStatus.BeginInvoke(new StringParamDelegate(SetStatus), new object[]{status});
				return;
			}
			this.lStatus.Text = status;
			this.Update();
		}
		
		private void SetImage(Image image){
			if(pbImage.InvokeRequired){
				pbImage.BeginInvoke(new ImageParamDelegate(SetImage), new object[]{image});
				return;
			}
			this.pbImage.Image = image;
			this.Update();
		}
	}
}
