/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-07-09
 * Time: 23:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ModbusPlugin
{
	/// <summary>
	/// Description of SlaveLoadStatus.
	/// </summary>
	public partial class SlaveLoadStatus : UserControl
	{
		public delegate void StringParamDelegate (string value, Control c);
		
		private int slaveId = 0;
		public int SlaveId {
			get { return slaveId; }
		}

		private int msgTotalSent = 0;
		public int MsgTotalSent {
			get { return msgTotalSent; }
			set { 
				msgTotalSent = value;
				SetStringValue(msgTotalSent.ToString(), lSentV);
			}
		}
		
		private int respOk = 0;
		public int RespOk {
			get { return respOk; }
			set { 
				respOk = value;
				SetStringValue(respOk.ToString(), lOkV);
			}
		}
		private int respOtherErr = 0;
		public int RespOtherErr {
			get { return respOtherErr; }
			set { 
				respOtherErr = value;
				SetStringValue(respOtherErr.ToString(), lOtherErrV);
			}
		}
		
		private int respTimeouts = 0;
		public int RespTimeouts {
			get { return respTimeouts; }
			set { 
				respTimeouts = value;
				SetStringValue(respTimeouts.ToString(), lTimeoutsV);
			}
		}
		
		
		private int totalRespOkTime = 0;
		public int TotalRespOkTime {
			get { return totalRespOkTime; }
			set { 
				totalRespOkTime = value;
				SetStringValue((totalRespOkTime / (respOk != 0 ? respOk : 1) ).ToString(), lRespOkTimeV);
			}
		}
		
		public SlaveLoadStatus(int slaveId)
		{
			this.slaveId = slaveId;
			InitializeComponent();
			lIdV.Text = slaveId.ToString();
		}
		
		private void SetStringValue(string s, Control c) {
			if (c.InvokeRequired)
			{
				c.BeginInvoke(new StringParamDelegate(SetStringValue), new object[]{s, c});
				return;
			}
			c.Text = s;
			c.Update();
		}
	}
}
