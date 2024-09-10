/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-07-09
 * Time: 23:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

using Solarium;
using Solarium.Frame;
using Solarium.Controller;

using Modbus.Device;

using ModbusPlugin;

namespace ModbusPlugin
{
	/// <summary>
	/// Description of LoadTestControl.
	/// </summary>
	public partial class LoadTestControl : UserControl
	{
		private IMainFrame mf = null;
		private IModbusSerialMaster mMaster = null;
		private PluginMainForm pmf = null;
		private Thread loadTestThread = null;
		private Dictionary<int, SlaveLoadStatus> slControls = new Dictionary<int, SlaveLoadStatus>();
		
		public LoadTestControl(IMainFrame mf, PluginMainForm pmf)
		{
			this.mf = mf;
			this.pmf = pmf;
			this.mMaster = mf.Network.ModbusMaster;
			InitializeComponent();
			int shift = 0;
			foreach(object o in pmf.CbSlave.Items)
			{
				if(o is Solarium.Controller.ModbusSlave)
				{
					int i = ((Solarium.Controller.ModbusSlave)o).DeviceId;
					SlaveLoadStatus sls = new SlaveLoadStatus(i);
					sls.Location = new Point(0, shift);
					sls.Width = this.Width;
					sls.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
					shift += sls.Height;
					panel1.Controls.Add(sls);
					slControls.Add(i, sls);
				}
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			foreach(object o in pmf.CbSlave.Items){
				#if (DEBUG)
				log4net.LogManager.GetLogger("LoadTest").Info("Starting test thread for slave id = " + o.ToString());
				#endif	
				int i = ((Solarium.Controller.ModbusSlave)o).DeviceId;
				loadTestThread = new Thread(new ParameterizedThreadStart(loadTestLoop));
				loadTestThread.Start(i);
			}
		}
		
		private void loadTestLoop(object id) {
			SlaveLoadStatus sls = slControls[(int)id];
			int iterations = 0;
			long then = 0, now = 0;
			
			try{
				iterations = Convert.ToInt32(tbIterations.Text);
			}catch{
				
			}
			for (int i = 0; i <= iterations; i ++) {
				try{
					sls.MsgTotalSent += 1;
					then = Stopwatch.GetTimestamp();
					ushort[] reg = mMaster.ReadHoldingRegisters((byte)((int)id), 0x0000, 8);
					now = Stopwatch.GetTimestamp();
					int respTime = TimeSpan.FromTicks(now-then).Milliseconds;
					sls.RespOk += 1;
					sls.TotalRespOkTime += respTime;
				}catch(TimeoutException){
					sls.RespTimeouts += 1;
				}catch(Exception){
					sls.RespOtherErr += 1;
					#if (DEBUG)
					log4net.LogManager.GetLogger("LoadTest").Error("Exception while load test iteration = " + i.ToString() + " device id = " + id.ToString());
					#endif	
				}
			}
		}
		
		void TrackBar1Scroll(object sender, EventArgs e)
		{
			tbIterations.Text = (10 * trackBar1.Value).ToString();
		}
		
		void BSingleThreadTestClick(object sender, EventArgs e)
		{
			int iterations = 0;
			long then = 0, now = 0;
			
			try{
				iterations = Convert.ToInt32(tbIterations.Text);
			}catch{
				
			}
			for (int i = 0; i <= iterations; i ++) {
				foreach(SlaveLoadStatus sls in slControls.Values){
					try{
						sls.MsgTotalSent += 1;
						then = Stopwatch.GetTimestamp();
						ushort[] reg = mf.Network.ModbusMaster.ReadHoldingRegisters((byte)sls.SlaveId, 0x0000, 8);
						now = Stopwatch.GetTimestamp();
						int respTime =  TimeSpan.FromTicks(now-then).Milliseconds;
						sls.RespOk += 1;
						sls.TotalRespOkTime += respTime;
					}catch(TimeoutException){
						sls.RespTimeouts += 1;
					}catch(Exception){
						sls.RespOtherErr += 1;
						#if (DEBUG)
						log4net.LogManager.GetLogger("LoadTest").Error("Exception while load test iteration = " + i.ToString() + " device id = " + sls.SlaveId.ToString());
						#endif	
					}
				}
			}
		}
	}
}
