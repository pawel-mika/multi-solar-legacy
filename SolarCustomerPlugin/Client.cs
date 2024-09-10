/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-04-01
 * Time: 11:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

using Solarium.Bios;

namespace SolarCustomerPlugin
{
	/// <summary>
	/// Description of Client.
	/// </summary>
	public class Client
	{
		private RcObject clientRcObject = null;
		public RcObject ClientRcObject {
			get { return clientRcObject; }
		}
		
		public Client(RcObject client)
		{
			this.clientRcObject = client;
		}
		
		public override string ToString()
		{
			string s = string.Format("{0} {1}, {2} {3}", clientRcObject.MainComponent.GetString("surname"),
			                         clientRcObject.MainComponent.GetString("name"),
			                         clientRcObject.MainComponent.GetString("street"),
			                         clientRcObject.MainComponent.GetString("street_number"));
			return s;
		}
		
	}
}
