/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-10-06
 * Time: 01:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Solarium.Bios.Model
{
	/// <summary>
	/// Description of BiosObjectType.
	/// </summary>
	public class BiosObjectType
	{
		private int rcOtype = 0;
		public int RcOtype {
			get { return rcOtype; }
		}

		private int mainComponent = 0;
		public int MainComponent {
			get { return mainComponent; }
		}

		private string name = "";
		public string Name {
			get { return name; }
		}
		
		public BiosObjectType(int rcOtype, int mainComponent, string name)
		{
			this.rcOtype = rcOtype;
			this.mainComponent = mainComponent;
			this.name = name;
		}
		
		public override string ToString()
		{
			return string.Format("[BiosObjectType RcOtype={0} MainComponent={1} Name={2}]", 
			                     this.rcOtype, this.mainComponent, this.name);
		}
		
	}
}
