/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-07-14
 * Time: 22:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Solarium.Frame
{
	public delegate void MainFrameEventHandler (object sender, MainFrameEvent e);
	
	public class MainFrameEvent : EventArgs
	{
		private object param = null;
		public object Param {
			get { return param; }
			set { param = value; }
		}
		
		public MainFrameEvent(object param)
		{
			this.param = param;
		}
	}
}
