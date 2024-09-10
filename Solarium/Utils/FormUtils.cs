/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-04-01
 * Time: 17:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Solarium.Controls;
using Solarium.Bios;

namespace Solarium.Utils
{
	/// <summary>
	/// Description of FormUtils.
	/// Utilities that helps handling some operations on forms controls.
	/// </summary>
	public sealed class FormUtils
	{
		private static FormUtils instance = new FormUtils();

		// Used for cacheing of CodelistComboBoxes populated with Codelists.
		// Should speed up some operations eg. when needed to create some huge 
		// CodelistComboBox.
		private LinkedList<CodelistComboBox> codelistComboBoxList = new LinkedList<CodelistComboBox>();
		
		public static FormUtils Instance {
			get {
				return instance;
			}
		}
		
		private FormUtils()
		{
		}
		
		
		
		public CodelistComboBox GetCodelistComboBox(Codelist codelist){
			foreach(CodelistComboBox ccb in codelistComboBoxList){
				if(ccb.Codelist == codelist){
					return ccb;
				}
			}
			CodelistComboBox c = new CodelistComboBox(codelist);
			codelistComboBoxList.AddLast(c);
			return c;
		}
		
		
		/// <summary>
		/// Control without parameters delegate.
		/// </summary>
		public delegate void ControlDelegate(Control ctrl);

		/// <summary>
		/// 
		/// </summary>
		public delegate void ControlControlParamDelegate(Control c1, Control c2);
		
		public delegate void TLPControlParamDelegate(Control c1, Control c2, int c, int r);
		
		/// <summary>
		/// Control with parameters delegate.
		/// </summary>
		public delegate void ObjectParamDelegate (object value, Control c);
		
		/// <summary>
		/// 
		/// </summary>
		public delegate void BlinkLabelDelegate (Control cntrl, Color cFrom, Color cTo, int msLength, int times);
		
		/// <summary>
		/// Cross thread add control to another control.
		/// </summary>
		/// <param name="addTo"></param>
		/// <param name="addThis"></param>
		public static void ControlCrossThreadAddControl(Control addTo, Control addThis) {
			if(addTo.InvokeRequired)
			{
				addTo.BeginInvoke(new ControlControlParamDelegate(ControlCrossThreadAddControl), new object[]{addTo, addThis});
				return;
			}
			addTo.Controls.Add(addThis);
		}
		
		/// <summary>
		/// Cross thread add control to tableLayoutPanel
		/// </summary>
		/// <param name="addTo"></param>
		/// <param name="addThis"></param>
		/// <param name="column"></param>
		/// <param name="row"></param>
		public static void ControlCrossThreadAddControl(Control addTo, Control addThis, int column, int row) {
			if (addTo is TableLayoutPanel) {
				if(addTo.InvokeRequired)
				{
					addTo.BeginInvoke(new TLPControlParamDelegate(ControlCrossThreadAddControl), new object[]{addTo, addThis, column, row});
					return;
				}
			}
			(addTo as TableLayoutPanel).Controls.Add(addThis, column, row);
		}
		
		/// <summary>
		/// Add item to listbox from thread different that the control was created in.
		/// </summary>
		/// <param name="val"></param>
		/// <param name="ctrl"></param>
		public static void ListBoxCrossThreadAddItem(object val, Control ctrl) {
			if(ctrl is ListBox) 
			{
				if (ctrl.InvokeRequired)
				{
					ctrl.BeginInvoke(new ObjectParamDelegate(ListBoxCrossThreadAddItem), new object[]{val, ctrl});
					return;
				}
				((ListBox)ctrl).Items.Add(val);
//				ctrl.Update();
			}
		}
		
		/// <summary>
		/// Clear listbox items from thread differnt that the control was created in.
		/// </summary>
		/// <param name="ctrl"></param>
		public static void ListBoxCrossThreadClear(Control ctrl) {
			if(ctrl is ListBox) 
			{
				if (ctrl.InvokeRequired)
				{
					ctrl.BeginInvoke(new ControlDelegate(ListBoxCrossThreadClear), new object[]{ctrl});
					return;
				}
				((ListBox)ctrl).Items.Clear();
//				ctrl.Update();
			}
		}
		
		/// <summary>
		/// TODO dodać statyczna listę juz 'cykanych' kontrolek zeby po kilka razy na jedna nie sikać
		/// </summary>
		/// <param name="cntrl">a control</param>
		/// <param name="cFrom">from color</param>
		/// <param name="cTo">to color</param>
		/// <param name="msLength">one blink length</param>
		/// <param name="times">how many times (0 - indifinetly)</param>
		public static void BlinkLabelBackground(Control cntrl, Color cFrom, Color cTo, int msLength, int times)
		{
			if((cntrl is Label || cntrl is DOALibrary.DOATransparentLabel) && !blinkingControls.ContainsKey(cntrl))
			{
				if(cntrl.InvokeRequired)
				{
					cntrl.BeginInvoke(new BlinkLabelDelegate(BlinkLabelBackground), 
					                  new object[]{cntrl, cFrom, cTo, msLength, times});
					return;
				}
				
				int steps = 25, iter = 0, blinks = 0;
				float stepRatio = 1.25F;
				float rs = (cFrom.R - cTo.R) / steps;
				float gs = (cFrom.G - cTo.G) / steps;
				float bs = (cFrom.B - cTo.B) / steps;
				float alphas = (cFrom.A - cTo.A) / steps;

				Color c = cFrom;
				Label l = cntrl is Label ? (Label)cntrl : null;
				DOALibrary.DOATransparentLabel dl = cntrl is DOALibrary.DOATransparentLabel ? (DOALibrary.DOATransparentLabel)cntrl : null;
				Timer t = new Timer();
				
				blinkingControls.Add(cntrl, t);
				
//				log4net.LogManager.GetLogger("FormUtils").Info(String.Format("Bink for: {0}, {1}ms, {2} times", cntrl, msLength, times));
				
				t.Interval = msLength / steps;
				t.Tick += delegate 
				{
					if(iter < steps)
					{
						iter++;
						int a = (int)(cFrom.A - alphas * iter * stepRatio);
						int r = (int)(cFrom.R - rs * iter * stepRatio);
						int g = (int)(cFrom.G - gs * iter * stepRatio);
						int b = (int)(cFrom.B - bs * iter * stepRatio);
						r = r < 0 ? 0 : r > 255 ? 255 : r;
						g = g < 0 ? 0 : g > 255 ? 255 : g;
						b = b < 0 ? 0 : b > 255 ? 255 : b;
						a = a < 0 ? 0 : a > 255 ? 255 : a;
						c = Color.FromArgb(a,r,g,b);
						stepRatio *= 1.1F;
					}
					else
					{
						stepRatio = 1.25F;
						blinks++;
						iter = 0;
						rs = (cFrom.R - cTo.R) / steps;
						gs = (cFrom.G - cTo.G) / steps;
						bs = (cFrom.B - cTo.B) / steps;
						alphas = (cFrom.A - cTo.A) / steps;
						c = cFrom;
					}
					
//					log4net.LogManager.GetLogger("FormUtils").Info(l.ToString() + ", " + c.ToString());
					
					if(l != null) 
					{
						l.BackColor = c;
					}
					else if(dl != null)
					{
						dl.BackColor = c;
					}
					
					if(blinks == times)
					{
						if(l != null) 
						{
							l.BackColor = cTo;
						}
						else if(dl != null)
						{
							dl.BackColor = cTo;
						}
						blinkingControls.Remove(cntrl);
						t.Stop();
						t.Dispose();
					}
				};
				t.Start();
			}
		}
		
		/// <summary>
		/// Lista aktualnie migających kontrolek
		/// </summary>
		private static Dictionary<Control, Timer> blinkingControls = new Dictionary<Control, Timer>();
		
		public static bool IsBlinking(Control c)
		{
			return blinkingControls.ContainsKey(c);
		}
		
		public static void StopBlinking(Control c)
		{
			if(blinkingControls.ContainsKey(c))
			{
				blinkingControls[c].Stop();
				blinkingControls[c].Dispose();
				blinkingControls.Remove(c);
			}
		}
	}
}
