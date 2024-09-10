/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-11-18
 * Time: 23:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Solarium.Frame
{
	/// <summary>
	/// Description of CatchMethodAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class CatchMethodAttribute : Attribute
	{
		private Type[] exceptionTypes = null;
		
		public CatchMethodAttribute() : this(typeof(Exception))
		{
			
		}
		
		public CatchMethodAttribute(params Type[] exceptionTypes)
		{
			this.exceptionTypes  = exceptionTypes;
		}
	}
}
