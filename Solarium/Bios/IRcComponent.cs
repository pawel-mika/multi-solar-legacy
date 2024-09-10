/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-10-20
 * Time: 19:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

using Solarium.Db.QueryTools;
using Solarium.Bios.Model;

namespace Solarium.Bios
{
	/// <summary>
	/// Description of IRcComponent.
	/// </summary>
	public interface IRcComponent
	{
		int RcOid {
			get;
		}
		int RcOtype {
			get;
		}
		int RcCtype {
			get;
		}
		int RcStore {
			get;
		}
		int RcOcc {
			get;
		}
		int RcSign {
			get;
		}
		DateTime RcMod {
			get;
		}
		int RcLock {
			get;
		}
		ComponentID ComponentId{
			get;
		}
		
		QueryResultField Get(string key);
		object GetValue(string key);
		int GetInt(string key);
		string GetString(string key);
		bool GetBool(string key);
		DateTime GetDateTime(string key);
		float GetFloat(string key);
		decimal GetDecimal(string key);
	}
}
