using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace yasc
{
	/// <summary>
	/// Summary description for CalItemInspector.
	/// </summary>
	public class CalItemInspector : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label m_lblHeading;
		private System.Windows.Forms.PictureBox m_pbxItems;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		private ArrayList m_plci;
		private Font m_hFont;
		private Font m_hFontTitle;
		private Brush m_hBrush;

		public void ClearItems()
		{
			m_plci.Clear();
		}

		public void SetTitle(string s)
		{
			m_lblHeading.Text = s;
		}

		public void SetLocation(Point pt)
		{
			int x, y, dx, dy;

			// try to make the bottom right of the popup be our location
			this.SetBounds(x = Math.Max(pt.X - this.Width / 2, 0),
						   y = Math.Max(pt.Y - this.Height, 0),
						   dx = this.Width, dy = this.Height,
						   BoundsSpecified.Location);

//			m_lblHeading.Text = x.ToString() + ", " + y.ToString() + ", " + dx.ToString() + ", " + dy.ToString();
		}


		public void SetPrefs(Font hFont, Font hFontTitle, Brush hBrush)
		{
			m_hFont = hFont;
			m_hFontTitle = hFontTitle;
			m_hBrush = hBrush;
		}

		public void AddItem(CalItem ci)
		{
			m_plci.Add(ci);
		}

		public CalItemInspector()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_plci = new ArrayList();
			m_lblHeading.Font = new Font("Tahoma", 16);

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_lblHeading = new System.Windows.Forms.Label();
			this.m_pbxItems = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// m_lblHeading
			// 
			this.m_lblHeading.Location = new System.Drawing.Point(8, 16);
			this.m_lblHeading.Name = "m_lblHeading";
			this.m_lblHeading.Size = new System.Drawing.Size(264, 40);
			this.m_lblHeading.TabIndex = 0;
			this.m_lblHeading.Text = "label1";
			// 
			// m_pbxItems
			// 
			this.m_pbxItems.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.m_pbxItems.Location = new System.Drawing.Point(8, 56);
			this.m_pbxItems.Name = "m_pbxItems";
			this.m_pbxItems.Size = new System.Drawing.Size(382, 214);
			this.m_pbxItems.TabIndex = 1;
			this.m_pbxItems.TabStop = false;
			this.m_pbxItems.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintItems);
			// 
			// CalItemInspector
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 278);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_pbxItems,
																		  this.m_lblHeading});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "CalItemInspector";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "CalItemInspector";
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HandleKeyMsg);
			this.ResumeLayout(false);

		}
		#endregion

		private void DrawStringWrap(Graphics gr, string s, Font hFont, Brush hBrush, Rectangle rect, out int cLines, bool fDraw)
		{
			int cChars;
			Size sz = new Size(rect.Width, rect.Height);

			gr.MeasureString(s, hFont, sz, null, out cChars, out cLines);
			if (fDraw)
				gr.DrawString(s, hFont, hBrush, rect);
		}

		private void PaintItems(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics gr = e.Graphics;
			PictureBox pbx = (PictureBox)sender;

			// walk through (in order) the items they want us to paint and paint as many
			// as we can.

			int i, iMac;
			int ya = 12;
			int xaTime = 3;
			int xaTitle = (((pbx.Width) * 20) / 100) + xaTime;
			int xaDescription = (((pbx.Width - xaTime) * 25) / 100) + xaTitle;

			int dxaTime = (xaTitle - xaTime);
			int dxaTitle = (xaDescription - xaTitle);
			int dxaDescription = pbx.Width - xaDescription;

			int yaMin, yaMac;

			yaMin = ya;
			for (i = 0, iMac = m_plci.Count; i < iMac; i++)
				{
				int cLinesMax = 1;
				int cLines;

				CalItem ci = (CalItem)m_plci[i];
				
				DrawStringWrap(gr, ci.GetStartFormatted() + "-" + ci.GetEndFormatted(), m_hFont, m_hBrush, new Rectangle(xaTime, ya, dxaTime, pbx.Height - ya), out cLines, false);
				cLinesMax = Math.Max(cLinesMax, cLines);

				DrawStringWrap(gr, ci.GetTitle(), m_hFont, m_hBrush, new Rectangle(xaTitle, ya, dxaTitle, pbx.Height - ya), out cLines, false);
				cLinesMax = Math.Max(cLinesMax, cLines);

				DrawStringWrap(gr, ci.GetDescription(), m_hFont, m_hBrush, new Rectangle(xaDescription, ya, dxaDescription, pbx.Height - ya), out cLines, false);
				cLinesMax = Math.Max(cLinesMax, cLines);
				
				Rectangle rect = new Rectangle(0, ya - 2, pbx.Width, (ya + cLinesMax * 12 + 2) - (ya - 2));

				Color cr;
				if ((i & 1) != 0)
					{
					cr = Color.FromArgb(192, 224, 224, 224);
					}
				else
					{
					cr = Color.FromArgb(192, 204, 204, 204);
					}

				gr.FillRectangle(new SolidBrush(cr), rect);

				DrawStringWrap(gr, ci.GetStartFormatted() + "-" + ci.GetEndFormatted(), m_hFont, m_hBrush, new Rectangle(xaTime, ya, dxaTime, pbx.Height - ya), out cLines, true);
				DrawStringWrap(gr, ci.GetTitle(), m_hFont, m_hBrush, new Rectangle(xaTitle, ya, dxaTitle, pbx.Height - ya), out cLines, true);
				DrawStringWrap(gr, ci.GetDescription(), m_hFont, m_hBrush, new Rectangle(xaDescription, ya, dxaDescription, pbx.Height - ya), out cLines, true);

				ya = ya + cLinesMax * 12 + 3;
				}
			yaMin = yaMin - 1;
			yaMac = ya - 1;

			Pen penOuter = new Pen(Color.FromArgb(255, 64,64,64), (float)1.5);
			Pen penInner = new Pen(Color.FromArgb(255, 192,192,192), (float)1.5);
			Pen penInside = new Pen(Color.FromArgb(128, 0, 0, 0), (float)1.5);

			gr.DrawLine(penOuter, 0, yaMin, pbx.Width - 1, yaMin);
			gr.DrawLine(penOuter, 0, yaMin, 0, yaMac);
			gr.DrawLine(penInner, pbx.Width - 1, yaMac, pbx.Width - 1, yaMin);
			gr.DrawLine(penInner, pbx.Width - 1, yaMac, 0, yaMac);

			gr.DrawLine(penInside, xaTitle - 2, yaMin, xaTitle - 2, yaMac);
			gr.DrawLine(penInside, xaDescription - 2, yaMin, xaDescription - 2, yaMac);

			// now draw the inside lines

		}

		private void HandleKeyMsg(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				this.Close();
		}

	}
}
