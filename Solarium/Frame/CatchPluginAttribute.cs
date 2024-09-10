/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-04-06
 * Time: 20:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Solarium.Frame
{
	/// <summary>
	/// Description of CatchPluginAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Interface|AttributeTargets.Class)]
	public class CatchPluginAttribute : Attribute
	{
		private Type[] exceptionTypes = null;
		
		public CatchPluginAttribute() : this(typeof(Exception))
		{
			
		}
		
		public CatchPluginAttribute(params Type[] exceptionTypes)
		{
			this.exceptionTypes  = exceptionTypes;
		}
	}
}
