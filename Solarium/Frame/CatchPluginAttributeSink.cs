/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-04-06
 * Time: 22:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

using Solarium.Utils;

namespace Solarium.Frame
{
	/// <summary>
	/// Description of CatchPluginAttributeSink.
	/// </summary>
	public class CatchPluginAttributeSink : IMessageSink
	{
		private object server = null;
		private IMessageSink nextSink = null;
		
		public CatchPluginAttributeSink(object server, IMessageSink nextSink)
		{
			this.server = server;
			this.nextSink = nextSink;
		}
		
		public IMessageSink NextSink {
			get {
				return nextSink;
			}
		}
		
		public IMessage SyncProcessMessage(IMessage msg)
		{
			IMethodCallMessage method = msg as IMethodCallMessage;
			
			if(method != null && method.MethodBase.DeclaringType.FullName.Equals("Solarium.Plugin.IPlugin"))
			{
				//poki co oba warunki takie same, plugin niech dziecziczy tez po ContextBoundException
				// i trzeba uzyc znacznika [CatchPlugin] wtedy wszystkie exceptiony z tego plugina pojda
				//tutaj i zostana tutaj obsluzone... poki  co;/
				//niestety nie działa to z formami i innymi kotrolkami wiec tam trzeba UWAZAC BARDZO CO SIE ROBI!
				CatchPluginAttribute [] cpa = method.MethodBase.GetCustomAttributes(typeof(CatchPluginAttribute), true) as CatchPluginAttribute[];
				if(cpa.Length > 0){
					object ret = null;
					try{
						ret = method.MethodBase.Invoke(server, method.Args);
					} catch (TargetInvocationException tie){
						System.Windows.Forms.MessageBox.Show(string.Format(
										"{0}\n\n{1}\n\nInner exception:\n{2}",
										"----",
										tie.Message,
										tie.InnerException),
						                "Exception@"+tie.Source);
					}
					return new ReturnMessage(ret, null, 0, method.LogicalCallContext, method);
				}else{
					object ret = null;
					try{
						ret = method.MethodBase.Invoke(server, method.Args);
					} catch (TargetInvocationException tie){
						System.Windows.Forms.MessageBox.Show(string.Format(
										"{0}\n\n{1}\n\nInner exception:\n{2}",
										"----\r\nWystąpił błąd z wtyczką!\r\n----",
										tie.Message,
										tie.InnerException),
						                "Exception@"+tie.Source);
					}
					return new ReturnMessage(ret, null, 0, method.LogicalCallContext, method);
				}
			}
			IMessage returnMessage = nextSink.SyncProcessMessage(msg);
			return returnMessage;
		}
		
		public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
		{
			 throw new Exception("The method or operation is not implemented.");
		}
	}
}
