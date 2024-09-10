/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-12
 * Time: 19:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;

namespace Solarium.Config
{
	/// <summary>
	/// Description of Configurable.
	/// for plugins common entries goes as follow:
	/// Menu - main menu group (mandatory)
	/// Submenu - submenu group (optional)
	/// </summary>
	[Obsolete]
	public interface IConfigurable
	{
		Dictionary<string, object> getConfig();
		void setConfig(Dictionary<string, object> config);
	}
}
