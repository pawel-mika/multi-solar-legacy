/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-08-09
 * Time: 22:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;

using Solarium.Controller;

namespace Solarium.Controller
{
	/// <summary>
	/// Description of INetwork.
	/// </summary>
	public interface IModbusNetwork
	{
		/// <summary>
		/// List of all slave devices detected during last scan
		/// </summary>
		LinkedList<Solarium.Controls.ISlaveDeviceControl> SlaveDevices {
			get;
		}
		
		/// <summary>
		/// Access to the Modbus master device (the one with FTDI chip;)
		/// </summary>
		Modbus.Device.IModbusSerialMaster ModbusMaster {
			get;
		}
		
		/// <summary>
		/// Perform a critical slave remove. This method sould be used only when
		/// slave device stops responding. Be carefull!
		/// </summary>
		/// <param name="slave"></param>
		void CriticalSlaveRemove(Solarium.Controls.ISlaveDeviceControl slave);
		
		ModbusTransactionResult PerformTransaction (ModbusTransaction transaction);
		
		int MaximumSlaveCount {
			get;
		}
	}
}
