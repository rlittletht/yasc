using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace yasc
{
	/// <summary>
	/// Summary description for newItem.
	/// </summary>
	public class FrmNewItem : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label m_lblEventStart;
		private System.Windows.Forms.TextBox m_ebStartDate;
		private System.Windows.Forms.TextBox m_ebStartTime;
		private System.Windows.Forms.Label m_lblDate;
		private System.Windows.Forms.Label m_lblTime;
		private System.Windows.Forms.Label m_lblEventEnd;
		private System.Windows.Forms.TextBox m_ebEndDate;
		private System.Windows.Forms.TextBox m_ebEndTime;
		private System.Windows.Forms.Label m_lblName;
		private System.Windows.Forms.Label m_lblDescription;
		private System.Windows.Forms.Label m_lblOwner;
		private System.Windows.Forms.Label m_lblResources;
		private System.Windows.Forms.CheckedListBox m_clbResources;
		private System.Windows.Forms.TextBox m_ebName;
		private System.Windows.Forms.TextBox m_ebDescription;
		private System.Windows.Forms.Button m_pbOK;
		private System.Windows.Forms.Button m_pbCancel;

		private CalItem m_ciEdit;
		private Cal m_cal;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ComboBox m_lbOwner;

		private MainForm m_frmMain;

		public FrmNewItem(MainForm frmMain, Cal cal)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_cal = cal;

			m_frmMain = frmMain;
			Cal.PopulateResourceList(m_clbResources);

			foreach (string s in m_clbResources.Items)
				{
				m_lbOwner.Items.Add(s);
				}

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
			this.m_lblEventStart = new System.Windows.Forms.Label();
			this.m_ebStartDate = new System.Windows.Forms.TextBox();
			this.m_ebStartTime = new System.Windows.Forms.TextBox();
			this.m_lblDate = new System.Windows.Forms.Label();
			this.m_lblTime = new System.Windows.Forms.Label();
			this.m_lblEventEnd = new System.Windows.Forms.Label();
			this.m_ebEndDate = new System.Windows.Forms.TextBox();
			this.m_ebEndTime = new System.Windows.Forms.TextBox();
			this.m_lblName = new System.Windows.Forms.Label();
			this.m_lblDescription = new System.Windows.Forms.Label();
			this.m_lblOwner = new System.Windows.Forms.Label();
			this.m_lblResources = new System.Windows.Forms.Label();
			this.m_clbResources = new System.Windows.Forms.CheckedListBox();
			this.m_ebName = new System.Windows.Forms.TextBox();
			this.m_ebDescription = new System.Windows.Forms.TextBox();
			this.m_pbOK = new System.Windows.Forms.Button();
			this.m_pbCancel = new System.Windows.Forms.Button();
			this.m_lbOwner = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// m_lblEventStart
			// 
			this.m_lblEventStart.AllowDrop = true;
			this.m_lblEventStart.Location = new System.Drawing.Point(16, 128);
			this.m_lblEventStart.Name = "m_lblEventStart";
			this.m_lblEventStart.Size = new System.Drawing.Size(64, 16);
			this.m_lblEventStart.TabIndex = 0;
			this.m_lblEventStart.Text = "Event Start";
			// 
			// m_ebStartDate
			// 
			this.m_ebStartDate.Location = new System.Drawing.Point(96, 128);
			this.m_ebStartDate.Name = "m_ebStartDate";
			this.m_ebStartDate.Size = new System.Drawing.Size(88, 20);
			this.m_ebStartDate.TabIndex = 6;
			this.m_ebStartDate.Text = "";
			// 
			// m_ebStartTime
			// 
			this.m_ebStartTime.Location = new System.Drawing.Point(200, 128);
			this.m_ebStartTime.Name = "m_ebStartTime";
			this.m_ebStartTime.Size = new System.Drawing.Size(64, 20);
			this.m_ebStartTime.TabIndex = 7;
			this.m_ebStartTime.Text = "09:00";
			// 
			// m_lblDate
			// 
			this.m_lblDate.Location = new System.Drawing.Point(112, 112);
			this.m_lblDate.Name = "m_lblDate";
			this.m_lblDate.Size = new System.Drawing.Size(56, 16);
			this.m_lblDate.TabIndex = 3;
			this.m_lblDate.Text = "Date";
			// 
			// m_lblTime
			// 
			this.m_lblTime.Location = new System.Drawing.Point(208, 112);
			this.m_lblTime.Name = "m_lblTime";
			this.m_lblTime.Size = new System.Drawing.Size(48, 16);
			this.m_lblTime.TabIndex = 4;
			this.m_lblTime.Text = "Time";
			// 
			// m_lblEventEnd
			// 
			this.m_lblEventEnd.Location = new System.Drawing.Point(16, 160);
			this.m_lblEventEnd.Name = "m_lblEventEnd";
			this.m_lblEventEnd.Size = new System.Drawing.Size(64, 16);
			this.m_lblEventEnd.TabIndex = 5;
			this.m_lblEventEnd.Text = "Event End";
			// 
			// m_ebEndDate
			// 
			this.m_ebEndDate.Location = new System.Drawing.Point(96, 160);
			this.m_ebEndDate.Name = "m_ebEndDate";
			this.m_ebEndDate.Size = new System.Drawing.Size(80, 20);
			this.m_ebEndDate.TabIndex = 8;
			this.m_ebEndDate.Text = "";
			// 
			// m_ebEndTime
			// 
			this.m_ebEndTime.Location = new System.Drawing.Point(200, 160);
			this.m_ebEndTime.Name = "m_ebEndTime";
			this.m_ebEndTime.Size = new System.Drawing.Size(64, 20);
			this.m_ebEndTime.TabIndex = 9;
			this.m_ebEndTime.Text = "11:00";
			// 
			// m_lblName
			// 
			this.m_lblName.Location = new System.Drawing.Point(8, 16);
			this.m_lblName.Name = "m_lblName";
			this.m_lblName.Size = new System.Drawing.Size(72, 16);
			this.m_lblName.TabIndex = 8;
			this.m_lblName.Text = "Event Name";
			// 
			// m_lblDescription
			// 
			this.m_lblDescription.Location = new System.Drawing.Point(8, 64);
			this.m_lblDescription.Name = "m_lblDescription";
			this.m_lblDescription.Size = new System.Drawing.Size(80, 16);
			this.m_lblDescription.TabIndex = 9;
			this.m_lblDescription.Text = "Description";
			// 
			// m_lblOwner
			// 
			this.m_lblOwner.Location = new System.Drawing.Point(8, 40);
			this.m_lblOwner.Name = "m_lblOwner";
			this.m_lblOwner.Size = new System.Drawing.Size(48, 16);
			this.m_lblOwner.TabIndex = 10;
			this.m_lblOwner.Text = "Owner";
			// 
			// m_lblResources
			// 
			this.m_lblResources.Location = new System.Drawing.Point(16, 208);
			this.m_lblResources.Name = "m_lblResources";
			this.m_lblResources.Size = new System.Drawing.Size(64, 16);
			this.m_lblResources.TabIndex = 11;
			this.m_lblResources.Text = "Participants";
			// 
			// m_clbResources
			// 
			this.m_clbResources.CheckOnClick = true;
			this.m_clbResources.Location = new System.Drawing.Point(96, 208);
			this.m_clbResources.Name = "m_clbResources";
			this.m_clbResources.Size = new System.Drawing.Size(200, 64);
			this.m_clbResources.TabIndex = 10;
			// 
			// m_ebName
			// 
			this.m_ebName.Location = new System.Drawing.Point(88, 16);
			this.m_ebName.Name = "m_ebName";
			this.m_ebName.Size = new System.Drawing.Size(144, 20);
			this.m_ebName.TabIndex = 3;
			this.m_ebName.Text = "";
			// 
			// m_ebDescription
			// 
			this.m_ebDescription.AllowDrop = true;
			this.m_ebDescription.Location = new System.Drawing.Point(88, 64);
			this.m_ebDescription.Multiline = true;
			this.m_ebDescription.Name = "m_ebDescription";
			this.m_ebDescription.Size = new System.Drawing.Size(208, 40);
			this.m_ebDescription.TabIndex = 5;
			this.m_ebDescription.Text = "";
			// 
			// m_pbOK
			// 
			this.m_pbOK.Location = new System.Drawing.Point(176, 288);
			this.m_pbOK.Name = "m_pbOK";
			this.m_pbOK.Size = new System.Drawing.Size(64, 24);
			this.m_pbOK.TabIndex = 1;
			this.m_pbOK.Text = "OK";
			this.m_pbOK.Click += new System.EventHandler(this.HandleOK);
			// 
			// m_pbCancel
			// 
			this.m_pbCancel.Location = new System.Drawing.Point(248, 288);
			this.m_pbCancel.Name = "m_pbCancel";
			this.m_pbCancel.Size = new System.Drawing.Size(64, 24);
			this.m_pbCancel.TabIndex = 2;
			this.m_pbCancel.Text = "Cancel";
			this.m_pbCancel.Click += new System.EventHandler(this.HandleCancel);
			// 
			// m_lbOwner
			// 
			this.m_lbOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_lbOwner.Location = new System.Drawing.Point(88, 40);
			this.m_lbOwner.Name = "m_lbOwner";
			this.m_lbOwner.Size = new System.Drawing.Size(144, 21);
			this.m_lbOwner.TabIndex = 4;
			// 
			// FrmNewItem
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 318);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_lbOwner,
																		  this.m_pbCancel,
																		  this.m_pbOK,
																		  this.m_ebDescription,
																		  this.m_ebName,
																		  this.m_clbResources,
																		  this.m_lblResources,
																		  this.m_lblOwner,
																		  this.m_lblDescription,
																		  this.m_lblName,
																		  this.m_ebEndTime,
																		  this.m_ebEndDate,
																		  this.m_lblEventEnd,
																		  this.m_lblTime,
																		  this.m_lblDate,
																		  this.m_ebStartTime,
																		  this.m_ebStartDate,
																		  this.m_lblEventStart});
			this.Name = "FrmNewItem";
			this.Text = "Create Event";
			this.ResumeLayout(false);

		}
		#endregion

		/* H A N D L E  O K */
		/*----------------------------------------------------------------------------
			%%Function: HandleOK
			%%Qualified: yasc.FrmNewItem.HandleOK
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void HandleOK(object sender, System.EventArgs e)
		{
			string sName = m_ebName.Text;
			string sOwner = m_lbOwner.SelectedItem.ToString();
			string sDateStart = m_ebStartDate.Text + " " + m_ebStartTime.Text;
			string sDateEnd = m_ebEndDate.Text + " " + m_ebEndTime.Text;
			DateTime dttmStart;
			DateTime dttmEnd;
			string sID;

			if (m_clbResources.CheckedItems.Count <= 0)
				{
				MessageBox.Show("You must select at least one participant.", "Yet Another Shared Calendar", MessageBoxButtons.OK);
				return;
				}

			try
				{
				dttmStart = DateTime.Parse(sDateStart).ToUniversalTime();
				}
			catch
				{
				MessageBox.Show("The Start Date or Time is invalid.", "Yet Another Shared Calendar", MessageBoxButtons.OK);
				return;
				}

			try
				{
				dttmEnd = DateTime.Parse(sDateEnd).ToUniversalTime();
				}
			catch
				{
				MessageBox.Show("The End Date or Time is invalid.", "Yet Another Shared Calendar", MessageBoxButtons.OK);
				return;
				}

			string sResources = "";

			if (m_clbResources.CheckedItems.Count > 0)
				{
				bool fFirst = true;
				
				foreach (string s in m_clbResources.CheckedItems)
					{
					if (!fFirst)
						sResources += ",";
					
					fFirst = false;
					sResources += "'" + s + "'";
					}
				}

			string sDescription = m_ebDescription.Text;

			Calendar cal = new Calendar();
			bool fResult = false;

			if (m_ciEdit != null)
				{
				string sReason;
				
				sID = m_ciEdit.GetID();

				if (!m_frmMain.FParseCalendarResult(cal.ModifyCalendarEvent(sID, sName, dttmStart.ToString("G"), dttmEnd.ToString("G"), sDescription, sOwner, 0, sResources), out sReason))
					MessageBox.Show("Server edit failed: " + sReason);
				else
					{
					m_cal.RemoveItem(m_ciEdit);
					m_ciEdit = null;
					fResult = true;
					}
				}
			else
				{
				string sReason;

				if (!m_frmMain.FParseCalendarResult(cal.CreateCalendarEvent(sName, dttmStart.ToString("G"), dttmEnd.ToString("G"), sDescription, sOwner, 0, sResources), out sReason, out sID))
					{
					MessageBox.Show("Server edit failed: " + sReason);
					}
				else
					{
					fResult = true;
					}
				}


			if (fResult)
				{
				CalItem ciNew = new CalItem(sID, sName, sDescription, m_cal.RgcrEnsure(sResources), dttmStart.ToLocalTime(), dttmEnd.ToLocalTime(), 0, sOwner);

				m_cal.AddItem(ciNew);
				}
			this.Close();

		}

		/* H A N D L E  C A N C E L */
		/*----------------------------------------------------------------------------
			%%Function: HandleCancel
			%%Qualified: yasc.FrmNewItem.HandleCancel
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void HandleCancel(object sender, System.EventArgs e)
		{
			this.Close();
		}

		/* S E T  C A L  I T E M  F O R  E D I T */
		/*----------------------------------------------------------------------------
			%%Function: SetCalItemForEdit
			%%Qualified: yasc.FrmNewItem.SetCalItemForEdit
			%%Contact: rlittle
			
		----------------------------------------------------------------------------*/
		public void SetCalItemForEdit(CalItem ci, bool fCopyOnly)
		{
			if (!fCopyOnly)
				m_ciEdit = ci;

			m_ebStartDate.Text = ci.GetStart().ToString("d");
			m_ebStartTime.Text = ci.GetStart().ToString("t");

			m_ebEndDate.Text = ci.GetEnd().ToString("d");
			m_ebEndTime.Text = ci.GetEnd().ToString("t");

			m_ebName.Text = ci.GetTitle();
			m_ebDescription.Text = ci.GetDescription();

			m_lbOwner.Text = ci.GetOwner();

			string []rgs = ci.RgsGetResources();

			m_clbResources.ClearSelected();

			if (rgs != null)
				{
				int i, iMac;

				for (i = 0, iMac = rgs.Length; i < iMac; i++)
					{
					string s = rgs[i];
					int iclb = m_clbResources.Items.IndexOf(s);

					if (iclb >= 0)
						m_clbResources.SetItemChecked(iclb, true);
					}
				}
		}

		public void SetDates(DateTime dt)
		{
			m_ebStartDate.Text = dt.ToString("d");
			m_ebEndDate.Text = dt.ToString("d");
		}

	}
}
