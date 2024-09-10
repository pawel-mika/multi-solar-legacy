/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-15
 * Time: 00:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Solarium;
using Solarium.Frame;

namespace Solarium.Utils
{
	/// <summary>
	/// Class providing some basic dialog boxes to use when needed.
	/// </summary>
	public static class DialogUtils
	{
		/// <summary>
		/// Method for displaying some error messages. 
		/// </summary>
		/// <param name="mf"></param>
		/// <param name="dialogCaption"></param>
		/// <param name="dialogMessage"></param>
		public static void ShowError(IMainFrame mf, string dialogCaption, string dialogMessage){
			MessageBox.Show(dialogMessage, dialogCaption);
		}
		
		/// <summary>
		/// Method for displaying some error messages. 
		/// When in debug mode, the exception is logged into log file.
		/// </summary>
		/// <param name="mf"></param>
		/// <param name="ex"></param>
		public static void ShowError(IMainFrame mf, Exception ex){
			#if (DEBUG)
			log4net.LogManager.GetLogger("DialogUtils").Error(ex.Message);
			log4net.LogManager.GetLogger("DialogUtils").Error(ex.InnerException);
			#endif
			MessageBox.Show(string.Format(
							"{0}\n\nInner exception:\n{1}",ex.Message,ex.InnerException),
			                "Exception@"+ex.Source);
		}
		
		/// <summary>
		/// Method for displaying some error messages. 
		/// When in debug mode, the exception is logged into log file.
		/// </summary>
		/// <param name="mf"></param>
		/// <param name="additionalInfo"></param>
		/// <param name="ex"></param>
		public static void ShowError(IMainFrame mf, string additionalInfo, Exception ex){
			#if (DEBUG)
			log4net.LogManager.GetLogger("DialogUtils").Error(additionalInfo);
			log4net.LogManager.GetLogger("DialogUtils").Error(ex.Message);
			log4net.LogManager.GetLogger("DialogUtils").Error(ex.InnerException);
			#endif
			MessageBox.Show(string.Format(
							"{0}\n\n{1}\n\nInner exception:\n{2}",additionalInfo,ex.Message,ex.InnerException),
			                "Exception@"+ex.Source);
		}

		/// <summary>
		/// Method for displaying OK/CANCEL dialog boxes.
		/// </summary>
		/// <param name="mf"></param>
		/// <param name="dialogCaption"></param>
		/// <param name="dialogQuestion"></param>
		/// <returns></returns>
		public static DialogResult ShowOkCancel(IMainFrame mf, string dialogCaption, string dialogQuestion){
			return MessageBox.Show(dialogQuestion,dialogCaption, MessageBoxButtons.OKCancel);
		}
		
		/// <summary>
		/// Method for displaying informations.
		/// </summary>
		/// <param name="mf"></param>
		/// <param name="dialogCaption"></param>
		/// <param name="dialogMessage"></param>
		/// <returns></returns>
		public static DialogResult ShowInfo(IMainFrame mf, string dialogCaption, string dialogMessage){
			return MessageBox.Show(dialogMessage, dialogCaption, MessageBoxButtons.OK);
		}
	}
}
