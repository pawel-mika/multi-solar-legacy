/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-05-10
 * Time: 21:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Timers;
using System.Collections.Generic;

namespace Solarium.Controller
{
	/// <summary>
	/// Description of ModbusNetwork - transaction thread part.
	/// </summary>
	public partial class ModbusNetwork
	{
		private Timer WaitTimer = null;
		private bool mBusFree = true;
		private Queue<ModbusTransaction> transactionQueue = new Queue<ModbusTransaction>();
		
		public ModbusTransactionResult PerformTransaction(ModbusTransaction transaction)
		{
			//jezeli wolne to wykonujemy od razu... a jesli zajete to czekamy 
			//np 5ms i probojemy znow wykonac?
			if(mBusFree){
				mBusFree = !mBusFree;
				return ExecuteTransaction(transaction);
			}else{
				WaitTimer = new System.Timers.Timer();
				WaitTimer.Interval = 5;	//5ms
				WaitTimer.Elapsed += new ElapsedEventHandler(WaitForBus);
				WaitTimer.Start();
				mBusFree = !mBusFree;
			}
			return null;
		}
		
		private void WaitForBus(object sender, EventArgs e)
		{
			
		}
		
		/// <summary>
		/// Execute the modbus command from transaction and return data.
		/// </summary>
		/// <param name="transaction"></param>
		/// <returns></returns>
		private ModbusTransactionResult ExecuteTransaction(ModbusTransaction transaction)
		{
			switch(transaction.MOperation){
				case ModbusTransaction.ModbusOperation.READ_COILS:
					return new ModbusTransactionResult(
						transaction.Caller,
						modbusMaster.ReadCoils(transaction.MDeviceId,
					                       transaction.MDeviceMemAddress, 
					                       (ushort)transaction.Data)
					);
				
				case ModbusTransaction.ModbusOperation.READ_BIT_INPUTS:
					return new ModbusTransactionResult(
						transaction.Caller,
						modbusMaster.ReadInputs(transaction.MDeviceId,
					                       transaction.MDeviceMemAddress, 
					                       (ushort)transaction.Data)
					);
				
				case ModbusTransaction.ModbusOperation.READ_HOLDING_REGISTERS:
					return new ModbusTransactionResult(
						transaction.Caller,
						modbusMaster.ReadHoldingRegisters(transaction.MDeviceId,
					                       transaction.MDeviceMemAddress, 
					                       (ushort)transaction.Data)
					);

				case ModbusTransaction.ModbusOperation.READ_INPUT_REGISTERS:
					return new ModbusTransactionResult(
						transaction.Caller,
						modbusMaster.ReadInputRegisters(transaction.MDeviceId,
					                       transaction.MDeviceMemAddress, 
					                       (ushort)transaction.Data)
					);

				case ModbusTransaction.ModbusOperation.WRITE_SINGLE_COIL:
					modbusMaster.WriteSingleCoil(transaction.MDeviceId, 
					                       transaction.MDeviceMemAddress, 
					                       (bool)transaction.Data);
					return null;
				case ModbusTransaction.ModbusOperation.WRITE_SINGLE_REGISTER:
					modbusMaster.WriteSingleRegister(transaction.MDeviceId, 
					                       transaction.MDeviceMemAddress, 
					                       (ushort)transaction.Data);
					return null;
				case ModbusTransaction.ModbusOperation.WRITE_MULTIPLE_COILS:
					modbusMaster.WriteMultipleCoils(transaction.MDeviceId, 
					                       transaction.MDeviceMemAddress, 
					                       (bool[])transaction.Data);
					return null;
				case ModbusTransaction.ModbusOperation.WRITE_MULTIPLE_REGISTERS:
					modbusMaster.WriteMultipleRegisters(transaction.MDeviceId, 
					                       transaction.MDeviceMemAddress, 
					                       (ushort[])transaction.Data);
					return null;
				case ModbusTransaction.ModbusOperation.NONE:
				default:
					return null;
			}
		}
	}
}
