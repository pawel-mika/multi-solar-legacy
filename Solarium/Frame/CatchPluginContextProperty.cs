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
	/// Description of CatchPluginContextProperty.
	/// </summary>
	public class CatchPluginContextProperty : IContextProperty, IContributeObjectSink
	{
		public CatchPluginContextProperty()
		{
		}
		
		public string Name {
			get {
				return GetType().Name;
			}
		}
		
		public bool IsNewContextOK(Context newCtx)
		{
			return true;
		}
		
		public void Freeze(Context newContext)
		{
		}
		
		public System.Runtime.Remoting.Messaging.IMessageSink GetObjectSink(MarshalByRefObject obj, System.Runtime.Remoting.Messaging.IMessageSink nextSink)
		{
			return new CatchPluginAttributeSink(obj, nextSink);
		}
	}
}
