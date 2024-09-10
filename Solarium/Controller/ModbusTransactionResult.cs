/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-07-08
 * Time: 18:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Runtime;

namespace Solarium.Controller
{
	/// <summary>
	/// Description of ModbusTransactionResult.
	/// </summary>
	public class ModbusTransactionResult
	{
		private object caller = null;
		public object Caller {
			get { return caller; }
		}
		
		private object result = null;
		public object Result {
			get { return result; }
		}
		
		public ModbusTransactionResult(object caller, object result)
		{
			this.caller = caller;
			this.result = result;
		}
	}
}
