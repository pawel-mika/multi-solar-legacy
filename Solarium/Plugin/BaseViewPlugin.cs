/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: Pablo
 * Data: 2009-04-23
 * Godzina: 17:45
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.Windows.Forms;

using Solarium.Frame;

namespace Solarium.Plugin
{
	/// <summary>
	/// Description of BaseViewPlugin.
	/// </summary>
	public abstract class BaseViewPlugin : BasePlugin
	{
		/// <summary>
		/// Default abstract view - get
		/// </summary>
		//[CatchMethodAttribute]
		public abstract Control View 
		{
			get;
		}
	}
}
