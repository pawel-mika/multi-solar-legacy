/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-04
 * Time: 22:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Solarium.Controls
{
	public delegate void SlaveDeviceControlEventHandler ( object sender, SlaveDeviceControlEvent e );
	
	public class SlaveDeviceControlEvent : EventArgs
	{
		
		private ISlaveDeviceControl slaveDeviceControl = null;
		public ISlaveDeviceControl SlaveDeviceControl {
			get { return slaveDeviceControl; }
			set { slaveDeviceControl = value; }
		}
		
		public SlaveDeviceControlEvent(ISlaveDeviceControl slaveControl)
		{
			this.slaveDeviceControl = slaveControl;
		}
	}
}
