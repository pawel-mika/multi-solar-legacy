/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-10-25
 * Time: 22:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;

namespace Solarium.Controller
{
	/// <summary>
	/// Klasa opisujaca stany mozliwe do przyjecia przez kontrolke lózka:
	/// Opisy przycisków, opis stanu, blokada przycisków, dlugosc trwania stanu
	/// TODO: moze dodac 'nastepny stan'
	/// na pewno dodac AKCJE!!:) ulatwi nam to zdeka:D
	/// chociaz z drugiej strony...hm...
	/// 
	/// </summary>
	public class BedState
	{
		public enum EState {
			NOT_READY,
			READY,
			WAITING,
			HEATING,
			COOLING,
			CLEANING
		}
		
		private EState state = EState.NOT_READY;
		public EState State {
			get { return state; }
		}
		
		private string stateString = null;
		public string StateString {
			get { return stateString; }
			set { stateString = value; }
		}
		private bool startButtonEnabled = false;
		public bool StartButtonEnabled {
			get { return startButtonEnabled; }
			set { startButtonEnabled = value; }
		}
		private string startButtonString = null;
		public string StartButtonString {
			get { return startButtonString; }
			set { startButtonString = value; }
		}
		private bool stopButtonEnabled = false;
		public bool StopButtonEnabled {
			get { return stopButtonEnabled; }
			set { stopButtonEnabled = value; }
		}
		private string stopButtonString = null;
		public string StopButtonString {
			get { return stopButtonString; }
			set { stopButtonString = value; }
		}
		private TimeSpan stateLenght = TimeSpan.Parse("00:00:00");
		public TimeSpan StateLenght {
			get { return stateLenght; }
			set { stateLenght = value; }
		}
		private TimeSpan stateTimeoutWarning = TimeSpan.Parse("00:00:20");
		public TimeSpan StateTimeoutWarning {
			get { return stateTimeoutWarning; }
			set { stateTimeoutWarning = value; }
		}
		private Color stateTimeoutBackground = Color.Red;
		public Color StateTimeoutBackground {
			get { return stateTimeoutBackground; }
			set { stateTimeoutBackground = value; }
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="stateString"></param>
		/// <param name="startButtonEnabled"></param>
		/// <param name="startButtonString"></param>
		/// <param name="stopButtonEnabled"></param>
		/// <param name="stopButtonString"></param>
		/// <param name="stateLenght"></param>
		public BedState(EState state, 
		                string stateString, 
		                bool startButtonEnabled, 
		                string startButtonString, 
		                bool stopButtonEnabled, 
		                string stopButtonString, 
		                TimeSpan stateLenght)
		{
			this.state = state;
			this.stateString = stateString;
			this.startButtonEnabled = startButtonEnabled;
			this.startButtonString = startButtonString;
			this.stopButtonEnabled = stopButtonEnabled;
			this.stopButtonString = stopButtonString;
			this.stateLenght = stateLenght;
		}
		
	}
}
