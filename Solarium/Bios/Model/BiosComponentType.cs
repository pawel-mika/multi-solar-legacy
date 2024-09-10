/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-10-06
 * Time: 15:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Solarium.Bios.Model
{
	/// <summary>
	/// Description of BiosComponentType.
	/// </summary>
	public class BiosComponentType
	{
		private int rcCtype = 0;
		public int RcCtype {
			get { return rcCtype; }
		}
		
		private string name = "";
		public string Name {
			get { return name; }
		}
		
		private string cTable = "";
		public string CTable {
			get { return cTable; }
		}
		
		private bool active = false;
		public bool Active {
			get { return active; }
		}
		
		public BiosComponentType(int rcCtype, string name, string cTable, bool active)
		{
			this.rcCtype = rcCtype;
			this.name = name;
			this.cTable = cTable;
			this.active = active;
		}
		
		public override string ToString()
		{
			return string.Format("[BiosComponentType RcCtype={0} Name={1} CTable={2} Active={3}]", 
			                     this.rcCtype, this.name, this.cTable, this.active);
		}
		
	}
}
