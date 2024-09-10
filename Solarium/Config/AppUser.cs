/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-13
 * Time: 22:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

using Solarium.Frame;
using Solarium.Bios;
using Solarium.Utils;

namespace Solarium.Config
{
	/// <summary>
	/// Description of AppUser.
	/// </summary>
	public class AppUser
	{
		private IMainFrame mf = null;
		private int workerOid = -1;

		private RcObject workerObject = null;
		public RcObject WorkerObject {
			get { return workerObject; }
		}

		public AppUser()
		{
		}

		/// <summary>
		/// Creates a new instance of application user information object.
		/// </summary>
		/// <param name="workerOid"></param>
		public AppUser(IMainFrame mf, int workerOid)
		{
			this.mf = mf;
			this.workerOid = workerOid;
			
//			mf.Database.Bios.BiosInitializationComplete += new BiosEventHandler(OnBiosInitialized);
			
			try{
				//20 - worker otype
				workerObject = mf.Database.Bios.GetObject(new ObjectID(workerOid, 20));
			}catch(BiosException){
				DialogUtils.ShowError(mf, 
				                      "Error!", 
				                      string.Format("Error during initializing AppUser object for worker oid = {0}", workerOid));
			}
			
			string title = string.Format("Solarium - User: {0}[id: {1}]", Login, WorkerOid);
			if(Admin) {
				title += " (Admin mode)";
			}
			mf.MainFrameUI.Text = title;
		}

//		private void OnBiosInitialized(object sender, BiosEvent be){
//			try{
//				//20 - worker otype
//				workerObject = mf.Database.Bios.GetObject(new ObjectID(workerOid, 20));
//			}catch(BiosException){
//				DialogUtils.ShowError(mf, 
//				                      "Error!", 
//				                      string.Format("Error during initializing AppUser object for worker oid = {0}", workerOid));
//			}
//		}
		
		public string Login {
			get { return workerObject.MainComponent.GetString("login"); }
		}
		
		public string Name {
			get { return workerObject.MainComponent.GetString("name"); }
		}

		public string Surname {
			get { return workerObject.MainComponent.GetString("surname"); }
		}

		public bool Admin {
			get { return workerObject.MainComponent.GetInt("admin")==0?false:true; }
		}

		public int RcStore {
			get { 
//				workerObject.MainComponent.GetInt("rc_store");
				return workerObject.MainComponent.RcStore; }
		}

		public int WorkerOid {
			get { return workerOid; }
		}
	}
}
