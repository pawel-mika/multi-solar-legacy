/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-16
 * Time: 16:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;
using System.Drawing;

using Solarium.Plugin;
using Solarium.Frame;
	
namespace Solarium.Gui
{
	public delegate void TabChangedEventHandler ( object sender, TabChangedEventArgs e );
	
	public class TabChangedEventArgs : EventArgs
	{
		private TabPage tabPage = null;
		
		public TabPage TabPage {
			get { return tabPage; }
			set { tabPage = value; }
		}
		
		private BaseViewPlugin plugin = null;
		
		public BaseViewPlugin Plugin {
			get { return plugin; }
			set { plugin = value; }
		}
		
		public TabChangedEventArgs(TabPage tab, BaseViewPlugin plug)
		{
			this.tabPage = tab;
			this.plugin = plug;
		}
	}
	
	public delegate void PrefsChangedEventHandler ( object sender, PrefsChangedEventArgs e );
	
	public class PrefsChangedEventArgs : EventArgs
	{
		private IMainFrame mf = null;
		public IMainFrame Mf {
			get { return mf; }
		}
		
		private PrefsForm prefsForm = null;
		public PrefsForm PrefsForm {
			get { return prefsForm; }
		}
		
		private Font smallFont = null;
		public Font SmallFont {
			get { return smallFont; }
			set { smallFont = value; }
		}
		
		private Font normalFont = null;
		public Font NormalFont {
			get { return normalFont; }
			set { normalFont = value; }
		}
		
		private Font bigFont = null;
		public Font BigFont {
			get { return bigFont; }
			set { bigFont = value; }
		}
	
		public PrefsChangedEventArgs(PrefsForm prefsForm) {
			this.prefsForm = prefsForm;
		}
		
		public PrefsChangedEventArgs(IMainFrame mf) {
			this.mf = mf;
		}
	}
}
