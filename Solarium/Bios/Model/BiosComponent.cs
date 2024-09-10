/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-10-08
 * Time: 23:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Solarium.Bios.Model
{
	/// <summary>
	/// Description of BiosComponent, mapping to bios_components from db
	/// </summary>
	public class BiosComponent
	{
		#region _properties

		private BiosComponentType biosComponentType = null;
		public BiosComponentType BiosComponentType {
			get { return biosComponentType; }
		}

		private bool required = false;
		public bool Required {
			get { return required; }
		}

		private bool active = false;
		public bool Active {
			get { return active; }
		}

		private int minCount = 0;
		public int MinCount {
			get { return minCount; }
		}

		private int maxCount = 0;
		/// <summary>
		/// Max count of the component in the object.
		/// null/0 - unlimited
		/// number - specified number
		/// </summary>
		public int MaxCount {
			get { return maxCount; }
		}

		#endregion

		#region _constructors

		public BiosComponent(BiosComponentType bct, bool required, bool active, int min_count, int max_count)
		{
			this.biosComponentType = bct;
			this.required = required;
			this.active = active;
			this.minCount = min_count;
			this.maxCount = max_count;
		}

		#endregion
		
		public override string ToString()
		{
			return string.Format("[BiosComponent BiosComponentType={0} Required={1} Active={2} MinCount={3} MaxCount={4}]", 
			                     this.biosComponentType, this.required, this.active, this.minCount, this.maxCount);
		}
		
	}
}
