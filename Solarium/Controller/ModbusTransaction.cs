/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-05-09
 * Time: 23:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Solarium.Controller
{
	/// <summary>
	/// Description of BaseModbusTransaction.
	/// </summary>
	public class ModbusTransaction
	{
		public enum ModbusOperation {
			NONE = 0x00,
			READ_COILS = 0x01,
			READ_BIT_INPUTS,
			READ_HOLDING_REGISTERS,
			READ_INPUT_REGISTERS,
			WRITE_SINGLE_COIL,
			WRITE_SINGLE_REGISTER,
			WRITE_MULTIPLE_COILS = 0x0F,
			WRITE_MULTIPLE_REGISTERS
//7 $07 odczyt statusu
//8 $08 test diagnostyczny
//17 $11 identyfikacja urządzenia slave			
		};
		
		private object caller = null;
		public object Caller {
			get { return caller; }
		}
		private ModbusOperation mOperation = ModbusOperation.NONE;
		public ModbusOperation MOperation {
			get { return mOperation; }
		}
		private byte mDeviceId = 0xFF;
		public byte MDeviceId {
			get { return mDeviceId; }
		}
		private ushort mDeviceMemAddress = 0xFFFF;
		public ushort MDeviceMemAddress {
			get { return mDeviceMemAddress; }
		}
		private Object data = null;
		public object Data {
			get { return data; }
		}
		
		public ModbusTransaction(object caller, ModbusOperation operation, byte deviceId, ushort address, object data)
		{
			this.caller = caller;
			this.mOperation = operation;
			this.mDeviceId = deviceId;
			this.mDeviceMemAddress = address;
			this.data = data;
		}
		
	}
}
