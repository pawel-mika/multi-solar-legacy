/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-04-06
 * Time: 22:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Runtime.Remoting.Contexts;

namespace Solarium.Frame
{
	/// <summary>
	/// Description of CatchPluginContextAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Interface|AttributeTargets.Class)]
	public class CatchPluginContextAttribute : ContextAttribute
	{
		public CatchPluginContextAttribute() : base("SampleCA")
		{
		}
		
		public override void GetPropertiesForNewContext(System.Runtime.Remoting.Activation.IConstructionCallMessage ctorMsg)
		{
			base.GetPropertiesForNewContext(ctorMsg);
			ctorMsg.ContextProperties.Add(new CatchPluginContextProperty());
		}
		
	}
}
