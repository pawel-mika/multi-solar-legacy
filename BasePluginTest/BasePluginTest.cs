/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-02-15
 * Time: 10:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

using Solarium;
using Solarium.Plugin;
using Solarium.Settings;

namespace BasePluginTest
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class BasePluginTest : BasePlugin
	{
		public override string Name {
			get {
				return "BasePluginTest";
			}
		}
		
		public override string Description {
			get {
				return "extending abstract BasePlugin test";
			}
		}
		
		public override string Author {
			get {
				return "Pablo";
			}
		}
		
		public override string Version {
			get {
				return "0.1";
			}
		}
		
	}
}
