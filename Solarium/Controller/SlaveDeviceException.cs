/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-11-11
 * Time: 16:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Solarium.Controller
{
	/// <summary>
	/// Description of SlaveDeviceException.
	/// </summary>
	public class SlaveDeviceException : Exception
	{
		public SlaveDeviceException() : base()
		{
		}
		
		public SlaveDeviceException(string message) : base(message)
		{
		}
				
		public SlaveDeviceException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
