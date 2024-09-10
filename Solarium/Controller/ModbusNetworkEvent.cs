/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-12-01
 * Time: 18:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

using Solarium.Controls;

namespace Solarium.Controller
{
	public delegate void ModbusNetworkEventHandler ( object sender, ModbusNetworkEvent e );
	
	public class ModbusNetworkEvent : EventArgs
	{
		
		private ISlaveDeviceControl slaveDeviceControl = null;
		public ISlaveDeviceControl SlaveDeviceControl {
			get { return slaveDeviceControl; }
			set { slaveDeviceControl = value; }
		}
		
		public ModbusNetworkEvent(ISlaveDeviceControl slaveControl)
		{
			this.slaveDeviceControl = slaveControl;
		}
	}
}
