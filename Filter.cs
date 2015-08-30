using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace yasc
{
	/// <summary>
	/// Summary description for FrmFilter.
	/// </summary>
	public class FrmFilter : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckedListBox m_clbResources;
		private System.Windows.Forms.Label m_lblResources;
		private System.Windows.Forms.CheckBox m_cbColorResources;
		private System.Windows.Forms.CheckBox m_cbHadResourceCombinations;
		private System.Windows.Forms.Button m_pbCancel;
		private System.Windows.Forms.Button m_pbOK;
		private MainForm m_frmMain;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmFilter(MainForm frmMain)
		{
			m_frmMain = frmMain;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			Cal.PopulateResourceList(m_clbResources);

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
			this.m_clbResources = new System.Windows.Forms.CheckedListBox();
			this.m_lblResources = new System.Windows.Forms.Label();
			this.m_cbColorResources = new System.Windows.Forms.CheckBox();
			this.m_cbHadResourceCombinations = new System.Windows.Forms.CheckBox();
			this.m_pbCancel = new System.Windows.Forms.Button();
			this.m_pbOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_clbResources
			// 
			this.m_clbResources.AllowDrop = true;
			this.m_clbResources.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.m_clbResources.CheckOnClick = true;
			this.m_clbResources.Location = new System.Drawing.Point(32, 24);
			this.m_clbResources.Name = "m_clbResources";
			this.m_clbResources.Size = new System.Drawing.Size(265, 79);
			this.m_clbResources.TabIndex = 7;
			// 
			// m_lblResources
			// 
			this.m_lblResources.Location = new System.Drawing.Point(16, 7);
			this.m_lblResources.Name = "m_lblResources";
			this.m_lblResources.Size = new System.Drawing.Size(248, 17);
			this.m_lblResources.TabIndex = 8;
			this.m_lblResources.Text = "Limit the calendar to the following resources:";
			// 
			// m_cbColorResources
			// 
			this.m_cbColorResources.Location = new System.Drawing.Point(24, 120);
			this.m_cbColorResources.Name = "m_cbColorResources";
			this.m_cbColorResources.Size = new System.Drawing.Size(251, 18);
			this.m_cbColorResources.TabIndex = 9;
			this.m_cbColorResources.Text = "Use color to differentiate resources";
			// 
			// m_cbHadResourceCombinations
			// 
			this.m_cbHadResourceCombinations.Location = new System.Drawing.Point(24, 136);
			this.m_cbHadResourceCombinations.Name = "m_cbHadResourceCombinations";
			this.m_cbHadResourceCombinations.Size = new System.Drawing.Size(259, 18);
			this.m_cbHadResourceCombinations.TabIndex = 10;
			this.m_cbHadResourceCombinations.Text = "Color unique resource combinations";
			// 
			// m_pbCancel
			// 
			this.m_pbCancel.Location = new System.Drawing.Point(264, 168);
			this.m_pbCancel.Name = "m_pbCancel";
			this.m_pbCancel.Size = new System.Drawing.Size(64, 24);
			this.m_pbCancel.TabIndex = 12;
			this.m_pbCancel.Text = "Cancel";
			this.m_pbCancel.Click += new System.EventHandler(this.HandleCancel);
			// 
			// m_pbOK
			// 
			this.m_pbOK.Location = new System.Drawing.Point(192, 168);
			this.m_pbOK.Name = "m_pbOK";
			this.m_pbOK.Size = new System.Drawing.Size(64, 24);
			this.m_pbOK.TabIndex = 11;
			this.m_pbOK.Text = "OK";
			this.m_pbOK.Click += new System.EventHandler(this.HandleOK);
			// 
			// FrmFilter
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 198);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_pbCancel,
																		  this.m_pbOK,
																		  this.m_cbHadResourceCombinations,
																		  this.m_cbColorResources,
																		  this.m_lblResources,
																		  this.m_clbResources});
			this.Name = "FrmFilter";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Filtering and Options";
			this.ResumeLayout(false);

		}
		#endregion
		
		/* S E T  R E S O U R C E S */
		/*----------------------------------------------------------------------------
			%%Function: SetResources
			%%Qualified: yasc.FrmFilter.SetResources
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public void SetResources(string sResources)
		{
			string []rgs = Cal.RgsFromArrayList(Cal.BuildStringListFromResources(sResources));

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

		private void HandleOK(object sender, System.EventArgs e)
		{
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
			m_frmMain.SetResources(sResources);
			this.Close();
		}

		private void HandleCancel(object sender, System.EventArgs e)
		{
			this.Close();
		}

	}
}
