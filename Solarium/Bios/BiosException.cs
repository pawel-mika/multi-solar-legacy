/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-10-01
 * Time: 21:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Solarium.Bios
{
	/// <summary>
	/// Description of BiosException.
	/// </summary>
	public class BiosException : Exception
	{
		
		public BiosException() : base()
		{
		}
		
		public BiosException(string message) : base(message)
		{
		}
				
		public BiosException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
