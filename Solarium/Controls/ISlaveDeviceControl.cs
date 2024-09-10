/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-11-08
 * Time: 19:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;

using Solarium.Bios;
using Solarium.Controller;

namespace Solarium.Controls
{
	/// <summary>
	/// Description of ISlaveDeviceControl.
	/// </summary>
	public interface ISlaveDeviceControl
	{
		event SlaveDeviceControlEventHandler CountdownEnded;
		event SlaveDeviceControlEventHandler PropertyChanged;
		event SlaveDeviceControlEventHandler StatusChanged;
		event SlaveDeviceControlEventHandler TimerPaused;
		event SlaveDeviceControlEventHandler TimerStarted;
		event SlaveDeviceControlEventHandler TimerStopped;
		event SlaveDeviceControlEventHandler TimerTicked;
		
		/// <summary>
		/// Aktualna wartosc timera wyswietlana na kontrolce
		/// </summary>
		TimeSpan CurrentTimerValue
		{
			get;
		}
		
		/// <summary>
		/// Czas opalania dla tego lózka
		/// </summary>
		TimeSpan HeatingTime
		{
			get;
			set;
		}
		
		/// <summary>
		/// Akutualny stan w jakim sie znajduje lózko/kontrolka
		/// </summary>
		BedState CurrentState 
		{
			get;
		}
		
		/// <summary>
		/// Id urzadzenia - tylko do odczytu
		/// </summary>
		int DeviceId
		{
			get;
		}
		
		/// <summary>
		/// Nazwa danej maszyny. Przy ustawianiu wartoby zapisac w bazie i odswiezyc DbEngine czy dbControl
		/// </summary>
		string DeviceName
		{
			get;
			set;
		}
		
		/// <summary>
		/// Dane klienta aktualnie uzywajacego kontrolki/lozka/slave'a...
		/// </summary>
		RcObject CurrentClient {
			get;
			set;
		}
		
		/// <summary>
		/// 
		/// </summary>
		RcObject DbEngine
		{
			get;
		}
		
		/// <summary>
		/// 
		/// </summary>
		RcObject DbControl
		{
			get;
		}
		
		/// <summary>
		/// Lista uslug przypisanych do danej maszyny. Np opalanie 1,2,3,4,5,6,7,8.... min
		/// </summary>
		LinkedList<RcObject> DbServices
		{
			get;
		}
		
		void DisposeDevice();
	}
}
