/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-07-17
 * Time: 08:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Threading;

using Solarium.Db;
using Solarium.Bios;

namespace Solarium.Utils
{
	/// <summary>
	/// Description of DbUtils.
	/// </summary>
	public class ThreadUtils
	{
		public delegate void ThreadUtilsDelegate(object outList);
		
		public ThreadUtils()
		{
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="biosMethod">void biosMethod(object outList)</param>
		/// <param name="outList"></param>
		public static void AsyncRun(ThreadUtilsDelegate biosMethod, params LinkedList<RcObject>[] outList){
			Thread t = new Thread( new ParameterizedThreadStart( biosMethod ) );
			t.Start( outList );
		}
		
		/// <summary>
		/// Start method given as a parameter in separate thread.
		/// <example>
		/// <code>
		///		
		/// 	...
		/// 	//run thread gathering data from database and filling controls...
		///		ThreadUtils.AsyncRun(getDbData);
		///		...
		/// 
		///		private void getDbData(object param) {
		///			engineObjects = mf.Database.Bios.GetObjectsWithClause(40,null);
		///			
		///			FormUtils.ListBoxCrossThreadClear(lbEngine);
		///			foreach(RcObject o in engineObjects){
		///				FormUtils.ListBoxCrossThreadAddItem(new EngineListEntry(o), lbEngine);
		///			}
		///			
		///			FormUtils.ListBoxCrossThreadClear(lbSlave);
		///			controlObjects = mf.Database.Bios.GetObjectsWithClause(70,null);
		///			foreach(RcObject o in controlObjects){
		///				bool assigned = false;
		///				ObjectID cOid = o.Oid;
		///				foreach(EngineListEntry ele in lbEngine.Items) {
		///					if(ele.EngineObject.MainComponent.GetInt("control_oid") == cOid.Oid &&
		///					   ele.EngineObject.MainComponent.GetInt("control_otype") == cOid.Otype) {
		///						assigned = true;
		///						break;
		///					}
		///				}
		///				FormUtils.ListBoxCrossThreadAddItem(new ControlListEntry(o, assigned), lbSlave);
		///			}
		///		}
		/// </code>
		/// </example>
		/// </summary>
		/// <param name="callbackMethod"></param>
		public static void AsyncRun(ThreadUtilsDelegate callbackMethod){
			Thread t = new Thread( new ParameterizedThreadStart( callbackMethod ) );
			t.Start( );
		}
	}
}
