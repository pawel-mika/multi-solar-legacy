/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-15
 * Time: 17:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ViewTestPlugin
{
	partial class ViewTestPluginView
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel6 = new System.Windows.Forms.Panel();
			this.label17 = new System.Windows.Forms.Label();
			this.tbGetObjectOid = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.bGetObject = new System.Windows.Forms.Button();
			this.tbGetObjectOtype = new System.Windows.Forms.TextBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.label14 = new System.Windows.Forms.Label();
			this.tbGetCompCtype = new System.Windows.Forms.TextBox();
			this.tbGetCompOcc = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.bGetComp = new System.Windows.Forms.Button();
			this.tbGetCompOtype = new System.Windows.Forms.TextBox();
			this.tbGetCompOid = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.tbCreateCompCtype = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.bCreateComp = new System.Windows.Forms.Button();
			this.tbCreateCompOtype = new System.Windows.Forms.TextBox();
			this.tbCreateCompOid = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.tbModCompCtype = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tbModCompOtype = new System.Windows.Forms.TextBox();
			this.tbModCompOid = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.bModComp = new System.Windows.Forms.Button();
			this.tbModCompField = new System.Windows.Forms.TextBox();
			this.cbModCompType = new System.Windows.Forms.ComboBox();
			this.tbModCompValue = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.bGetMainComp = new System.Windows.Forms.Button();
			this.tbGetMainCompOtype = new System.Windows.Forms.TextBox();
			this.tbGetMainCompOid = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.bCreateObject = new System.Windows.Forms.Button();
			this.tbCreateObOtype = new System.Windows.Forms.TextBox();
			this.lStatus = new System.Windows.Forms.Label();
			this.tbModCompOcc = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel6);
			this.groupBox1.Controls.Add(this.panel5);
			this.groupBox1.Controls.Add(this.panel4);
			this.groupBox1.Controls.Add(this.panel3);
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Controls.Add(this.lStatus);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(626, 357);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Test tworzenia obiektów";
			// 
			// panel6
			// 
			this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.panel6.BackColor = System.Drawing.Color.Silver;
			this.panel6.Controls.Add(this.label17);
			this.panel6.Controls.Add(this.tbGetObjectOid);
			this.panel6.Controls.Add(this.label16);
			this.panel6.Controls.Add(this.bGetObject);
			this.panel6.Controls.Add(this.tbGetObjectOtype);
			this.panel6.Location = new System.Drawing.Point(3, 130);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(150, 173);
			this.panel6.TabIndex = 18;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(3, 30);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(50, 20);
			this.label17.TabIndex = 5;
			this.label17.Text = "oid";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbGetObjectOid
			// 
			this.tbGetObjectOid.Location = new System.Drawing.Point(59, 29);
			this.tbGetObjectOid.Name = "tbGetObjectOid";
			this.tbGetObjectOid.Size = new System.Drawing.Size(88, 20);
			this.tbGetObjectOid.TabIndex = 4;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(3, 4);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(50, 20);
			this.label16.TabIndex = 3;
			this.label16.Text = "otype";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bGetObject
			// 
			this.bGetObject.Location = new System.Drawing.Point(59, 55);
			this.bGetObject.Name = "bGetObject";
			this.bGetObject.Size = new System.Drawing.Size(88, 24);
			this.bGetObject.TabIndex = 0;
			this.bGetObject.Text = "get object";
			this.bGetObject.UseVisualStyleBackColor = true;
			this.bGetObject.Click += new System.EventHandler(this.BGetObjectClick);
			// 
			// tbGetObjectOtype
			// 
			this.tbGetObjectOtype.Location = new System.Drawing.Point(59, 3);
			this.tbGetObjectOtype.Name = "tbGetObjectOtype";
			this.tbGetObjectOtype.Size = new System.Drawing.Size(88, 20);
			this.tbGetObjectOtype.TabIndex = 1;
			// 
			// panel5
			// 
			this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.panel5.BackColor = System.Drawing.Color.Silver;
			this.panel5.Controls.Add(this.label14);
			this.panel5.Controls.Add(this.tbGetCompCtype);
			this.panel5.Controls.Add(this.tbGetCompOcc);
			this.panel5.Controls.Add(this.label15);
			this.panel5.Controls.Add(this.label12);
			this.panel5.Controls.Add(this.bGetComp);
			this.panel5.Controls.Add(this.tbGetCompOtype);
			this.panel5.Controls.Add(this.tbGetCompOid);
			this.panel5.Controls.Add(this.label13);
			this.panel5.Location = new System.Drawing.Point(159, 130);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(150, 173);
			this.panel5.TabIndex = 19;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(3, 54);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(50, 20);
			this.label14.TabIndex = 13;
			this.label14.Text = "ctype";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbGetCompCtype
			// 
			this.tbGetCompCtype.Location = new System.Drawing.Point(59, 55);
			this.tbGetCompCtype.Name = "tbGetCompCtype";
			this.tbGetCompCtype.Size = new System.Drawing.Size(88, 20);
			this.tbGetCompCtype.TabIndex = 11;
			// 
			// tbGetCompOcc
			// 
			this.tbGetCompOcc.Location = new System.Drawing.Point(59, 81);
			this.tbGetCompOcc.Name = "tbGetCompOcc";
			this.tbGetCompOcc.Size = new System.Drawing.Size(88, 20);
			this.tbGetCompOcc.TabIndex = 12;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(3, 80);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(50, 20);
			this.label15.TabIndex = 14;
			this.label15.Text = "occ";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(3, 2);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(50, 20);
			this.label12.TabIndex = 9;
			this.label12.Text = "otype";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bGetComp
			// 
			this.bGetComp.Location = new System.Drawing.Point(59, 107);
			this.bGetComp.Name = "bGetComp";
			this.bGetComp.Size = new System.Drawing.Size(88, 24);
			this.bGetComp.TabIndex = 6;
			this.bGetComp.Text = "get comp";
			this.bGetComp.UseVisualStyleBackColor = true;
			this.bGetComp.Click += new System.EventHandler(this.BGetCompClick);
			// 
			// tbGetCompOtype
			// 
			this.tbGetCompOtype.Location = new System.Drawing.Point(59, 3);
			this.tbGetCompOtype.Name = "tbGetCompOtype";
			this.tbGetCompOtype.Size = new System.Drawing.Size(88, 20);
			this.tbGetCompOtype.TabIndex = 7;
			// 
			// tbGetCompOid
			// 
			this.tbGetCompOid.Location = new System.Drawing.Point(59, 29);
			this.tbGetCompOid.Name = "tbGetCompOid";
			this.tbGetCompOid.Size = new System.Drawing.Size(88, 20);
			this.tbGetCompOid.TabIndex = 8;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(3, 28);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(50, 20);
			this.label13.TabIndex = 10;
			this.label13.Text = "oid";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.panel4.BackColor = System.Drawing.Color.Silver;
			this.panel4.Controls.Add(this.tbCreateCompCtype);
			this.panel4.Controls.Add(this.label11);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Controls.Add(this.bCreateComp);
			this.panel4.Controls.Add(this.tbCreateCompOtype);
			this.panel4.Controls.Add(this.tbCreateCompOid);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Location = new System.Drawing.Point(315, 19);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(150, 284);
			this.panel4.TabIndex = 20;
			// 
			// tbCreateCompCtype
			// 
			this.tbCreateCompCtype.Location = new System.Drawing.Point(59, 55);
			this.tbCreateCompCtype.Name = "tbCreateCompCtype";
			this.tbCreateCompCtype.Size = new System.Drawing.Size(88, 20);
			this.tbCreateCompCtype.TabIndex = 23;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(3, 54);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(50, 20);
			this.label11.TabIndex = 24;
			this.label11.Text = "ctype";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(3, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 20);
			this.label2.TabIndex = 9;
			this.label2.Text = "otype";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bCreateComp
			// 
			this.bCreateComp.Location = new System.Drawing.Point(59, 81);
			this.bCreateComp.Name = "bCreateComp";
			this.bCreateComp.Size = new System.Drawing.Size(88, 24);
			this.bCreateComp.TabIndex = 6;
			this.bCreateComp.Text = "create comp";
			this.bCreateComp.UseVisualStyleBackColor = true;
			this.bCreateComp.Click += new System.EventHandler(this.BCreateCompClick);
			// 
			// tbCreateCompOtype
			// 
			this.tbCreateCompOtype.Location = new System.Drawing.Point(59, 3);
			this.tbCreateCompOtype.Name = "tbCreateCompOtype";
			this.tbCreateCompOtype.Size = new System.Drawing.Size(88, 20);
			this.tbCreateCompOtype.TabIndex = 7;
			// 
			// tbCreateCompOid
			// 
			this.tbCreateCompOid.Location = new System.Drawing.Point(59, 29);
			this.tbCreateCompOid.Name = "tbCreateCompOid";
			this.tbCreateCompOid.Size = new System.Drawing.Size(88, 20);
			this.tbCreateCompOid.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(3, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 20);
			this.label3.TabIndex = 10;
			this.label3.Text = "oid";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.panel3.BackColor = System.Drawing.Color.Silver;
			this.panel3.Controls.Add(this.tbModCompOcc);
			this.panel3.Controls.Add(this.label18);
			this.panel3.Controls.Add(this.tbModCompCtype);
			this.panel3.Controls.Add(this.label10);
			this.panel3.Controls.Add(this.label8);
			this.panel3.Controls.Add(this.tbModCompOtype);
			this.panel3.Controls.Add(this.tbModCompOid);
			this.panel3.Controls.Add(this.label9);
			this.panel3.Controls.Add(this.label7);
			this.panel3.Controls.Add(this.bModComp);
			this.panel3.Controls.Add(this.tbModCompField);
			this.panel3.Controls.Add(this.cbModCompType);
			this.panel3.Controls.Add(this.tbModCompValue);
			this.panel3.Controls.Add(this.label6);
			this.panel3.Location = new System.Drawing.Point(471, 19);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(150, 284);
			this.panel3.TabIndex = 19;
			// 
			// tbModCompCtype
			// 
			this.tbModCompCtype.Location = new System.Drawing.Point(59, 55);
			this.tbModCompCtype.Name = "tbModCompCtype";
			this.tbModCompCtype.Size = new System.Drawing.Size(88, 20);
			this.tbModCompCtype.TabIndex = 21;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(3, 54);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(50, 20);
			this.label10.TabIndex = 22;
			this.label10.Text = "ctype";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(3, 2);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(50, 20);
			this.label8.TabIndex = 19;
			this.label8.Text = "otype";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbModCompOtype
			// 
			this.tbModCompOtype.Location = new System.Drawing.Point(59, 3);
			this.tbModCompOtype.Name = "tbModCompOtype";
			this.tbModCompOtype.Size = new System.Drawing.Size(88, 20);
			this.tbModCompOtype.TabIndex = 17;
			// 
			// tbModCompOid
			// 
			this.tbModCompOid.Location = new System.Drawing.Point(59, 29);
			this.tbModCompOid.Name = "tbModCompOid";
			this.tbModCompOid.Size = new System.Drawing.Size(88, 20);
			this.tbModCompOid.TabIndex = 18;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(3, 28);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(50, 20);
			this.label9.TabIndex = 20;
			this.label9.Text = "oid";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(3, 106);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(50, 20);
			this.label7.TabIndex = 14;
			this.label7.Text = "field";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bModComp
			// 
			this.bModComp.Location = new System.Drawing.Point(3, 185);
			this.bModComp.Name = "bModComp";
			this.bModComp.Size = new System.Drawing.Size(144, 24);
			this.bModComp.TabIndex = 11;
			this.bModComp.Text = "modify comp";
			this.bModComp.UseVisualStyleBackColor = true;
			this.bModComp.Click += new System.EventHandler(this.bModifyCompClick);
			// 
			// tbModCompField
			// 
			this.tbModCompField.Location = new System.Drawing.Point(59, 107);
			this.tbModCompField.Name = "tbModCompField";
			this.tbModCompField.Size = new System.Drawing.Size(88, 20);
			this.tbModCompField.TabIndex = 12;
			// 
			// cbModCompType
			// 
			this.cbModCompType.FormattingEnabled = true;
			this.cbModCompType.Items.AddRange(new object[] {
									"int",
									"string",
									"datetime",
									"float",
									"decimal"});
			this.cbModCompType.Location = new System.Drawing.Point(59, 158);
			this.cbModCompType.Name = "cbModCompType";
			this.cbModCompType.Size = new System.Drawing.Size(88, 21);
			this.cbModCompType.TabIndex = 16;
			// 
			// tbModCompValue
			// 
			this.tbModCompValue.Location = new System.Drawing.Point(59, 133);
			this.tbModCompValue.Name = "tbModCompValue";
			this.tbModCompValue.Size = new System.Drawing.Size(88, 20);
			this.tbModCompValue.TabIndex = 13;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(3, 132);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(50, 20);
			this.label6.TabIndex = 15;
			this.label6.Text = "value";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Silver;
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.bGetMainComp);
			this.panel2.Controls.Add(this.tbGetMainCompOtype);
			this.panel2.Controls.Add(this.tbGetMainCompOid);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Location = new System.Drawing.Point(159, 19);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(150, 105);
			this.panel2.TabIndex = 18;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(3, 2);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(50, 20);
			this.label5.TabIndex = 9;
			this.label5.Text = "otype";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bGetMainComp
			// 
			this.bGetMainComp.Location = new System.Drawing.Point(59, 55);
			this.bGetMainComp.Name = "bGetMainComp";
			this.bGetMainComp.Size = new System.Drawing.Size(88, 24);
			this.bGetMainComp.TabIndex = 6;
			this.bGetMainComp.Text = "get main comp";
			this.bGetMainComp.UseVisualStyleBackColor = true;
			this.bGetMainComp.Click += new System.EventHandler(this.bGetMainCompClick);
			// 
			// tbGetMainCompOtype
			// 
			this.tbGetMainCompOtype.Location = new System.Drawing.Point(59, 3);
			this.tbGetMainCompOtype.Name = "tbGetMainCompOtype";
			this.tbGetMainCompOtype.Size = new System.Drawing.Size(88, 20);
			this.tbGetMainCompOtype.TabIndex = 7;
			// 
			// tbGetMainCompOid
			// 
			this.tbGetMainCompOid.Location = new System.Drawing.Point(59, 29);
			this.tbGetMainCompOid.Name = "tbGetMainCompOid";
			this.tbGetMainCompOid.Size = new System.Drawing.Size(88, 20);
			this.tbGetMainCompOid.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(3, 28);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 20);
			this.label4.TabIndex = 10;
			this.label4.Text = "oid";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Silver;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.bCreateObject);
			this.panel1.Controls.Add(this.tbCreateObOtype);
			this.panel1.Location = new System.Drawing.Point(3, 19);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(150, 105);
			this.panel1.TabIndex = 17;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 20);
			this.label1.TabIndex = 3;
			this.label1.Text = "otype";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bCreateObject
			// 
			this.bCreateObject.Location = new System.Drawing.Point(59, 29);
			this.bCreateObject.Name = "bCreateObject";
			this.bCreateObject.Size = new System.Drawing.Size(88, 24);
			this.bCreateObject.TabIndex = 0;
			this.bCreateObject.Text = "create object";
			this.bCreateObject.UseVisualStyleBackColor = true;
			this.bCreateObject.Click += new System.EventHandler(this.bCreateObjectClick);
			// 
			// tbCreateObOtype
			// 
			this.tbCreateObOtype.Location = new System.Drawing.Point(59, 3);
			this.tbCreateObOtype.Name = "tbCreateObOtype";
			this.tbCreateObOtype.Size = new System.Drawing.Size(88, 20);
			this.tbCreateObOtype.TabIndex = 1;
			this.tbCreateObOtype.Text = "1";
			// 
			// lStatus
			// 
			this.lStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lStatus.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.lStatus.Location = new System.Drawing.Point(3, 306);
			this.lStatus.Name = "lStatus";
			this.lStatus.Size = new System.Drawing.Size(620, 48);
			this.lStatus.TabIndex = 5;
			this.lStatus.Text = "result:";
			// 
			// tbModCompOcc
			// 
			this.tbModCompOcc.Location = new System.Drawing.Point(59, 81);
			this.tbModCompOcc.Name = "tbModCompOcc";
			this.tbModCompOcc.Size = new System.Drawing.Size(88, 20);
			this.tbModCompOcc.TabIndex = 23;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(3, 80);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(50, 20);
			this.label18.TabIndex = 24;
			this.label18.Text = "occ";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ViewTestPluginView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "ViewTestPluginView";
			this.Size = new System.Drawing.Size(626, 357);
			this.groupBox1.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox tbModCompOcc;
		private System.Windows.Forms.TextBox tbGetObjectOid;
		private System.Windows.Forms.TextBox tbGetObjectOtype;
		private System.Windows.Forms.Button bGetObject;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.TextBox tbGetCompOid;
		private System.Windows.Forms.TextBox tbGetCompOtype;
		private System.Windows.Forms.Button bGetComp;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox tbGetCompOcc;
		private System.Windows.Forms.TextBox tbGetCompCtype;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbCreateCompOid;
		private System.Windows.Forms.TextBox tbCreateCompOtype;
		private System.Windows.Forms.Button bCreateComp;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tbCreateCompCtype;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button bModComp;
		private System.Windows.Forms.ComboBox cbModCompType;
		private System.Windows.Forms.TextBox tbModCompField;
		private System.Windows.Forms.TextBox tbModCompValue;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbModCompOid;
		private System.Windows.Forms.TextBox tbModCompOtype;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbModCompCtype;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button bGetMainComp;
		private System.Windows.Forms.TextBox tbGetMainCompOtype;
		private System.Windows.Forms.TextBox tbGetMainCompOid;
		private System.Windows.Forms.Button bCreateObject;
		private System.Windows.Forms.TextBox tbCreateObOtype;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lStatus;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
