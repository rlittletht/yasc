using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;


namespace yasc
{
	// =======================
	// C A L   R E S O U R C E
	// =======================

	public class CalResource
	{
		private string m_sOwner;
		private Color m_color;

		/* C A L  R E S O U R C E */
		/*----------------------------------------------------------------------------
			%%Function: CalResource
			%%Qualified: yasc.CalResource.CalResource
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public CalResource(Color color, string sOwner)
		{
			m_color = color;
			m_sOwner = sOwner;
		}

		/* G E T  O W N E R */
		/*----------------------------------------------------------------------------
			%%Function: GetOwner
			%%Qualified: yasc.CalResource.GetOwner
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public string GetOwner()
		{
			return m_sOwner;
		}

		public Color GetColor()
		{
			return m_color;
		}

	}

	// ==============
	// C A L  I T E M
	// ==============

	public class CalItem
	{
		private string m_sName;
		private string m_sID;
		private string m_sDescription;
		private DateTime m_dtStart;
		private DateTime m_dtEnd;
		private CalResource []m_rgcr;
		private int m_nPrivateLevel;
		private int m_nTag;
		private string m_sOwner;

//		private string []rgsResources;
//		private string sResourceHash;

		/* C A L  I T E M */
		/*----------------------------------------------------------------------------
			%%Function: CalItem
			%%Qualified: yasc.CalItem.CalItem
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public CalItem(
			string sID,
			string sName,
			string sDescription,
			CalResource cr,
			DateTime dtStart,
			DateTime dtEnd,
			int nPrivateLevel,
			string sOwner)
		{
			if (sID != null)
				m_sID = String.Copy(sID);

			if (sName != null)
				m_sName = String.Copy(sName);

			if (sDescription != null)
				m_sDescription = String.Copy(sDescription);

			m_rgcr = new CalResource[] { cr };

			m_dtStart = dtStart.AddDays(0.0);
			m_dtEnd = dtEnd.AddDays(0.0);
			m_nPrivateLevel = nPrivateLevel;
			m_nTag = -1;
			if (sOwner != null)
				m_sOwner = String.Copy(sOwner);
		}

		/* C A L  I T E M */
		/*----------------------------------------------------------------------------
			%%Function: CalItem
			%%Qualified: yasc.CalItem.CalItem
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public CalItem(
			string sID,
			string sName,
			string sDescription,
			CalResource []rgcr,
			DateTime dtStart,
			DateTime dtEnd,
			int nPrivateLevel,
			string sOwner)
		{
			if (sID != null)
				m_sID = String.Copy(sID);

			if (sName != null)
				m_sName = String.Copy(sName);

			if (sDescription != null)
				m_sDescription = String.Copy(sDescription);

			if (sOwner != null)
				m_sOwner = String.Copy(sOwner);

			m_rgcr = new CalResource[rgcr.Length];
			int i = 0;

			foreach (CalResource cr in rgcr)
				{
				m_rgcr[i++] = cr;
				}
//			rgcr.Clone();

			m_dtStart = dtStart.AddDays(0.0);
			m_dtEnd = dtEnd.AddDays(0.0);
			m_nPrivateLevel = nPrivateLevel;
			m_nTag = -1;
		}

		public void SetTag(int n)
		{
			m_nTag = n;
		}

		public int GetTag()
		{
			return m_nTag;
		}

		/* C L O N E */
		/*----------------------------------------------------------------------------
			%%Function: Clone
			%%Qualified: yasc.CalItem.Clone
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public CalItem Clone(bool fGenerateID)
		{
			return new CalItem(fGenerateID ? new Guid().ToString() : m_sID, m_sName, m_sDescription, m_rgcr, m_dtStart, m_dtEnd, m_nPrivateLevel, m_sOwner);
		}

		/* G E T  T I T L E */
		/*----------------------------------------------------------------------------
			%%Function: GetTitle
			%%Qualified: yasc.CalItem.GetTitle
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public string GetTitle()
		{
			return m_sName;
		}

		/* G E T  D E S C R I P T I O N */
		/*----------------------------------------------------------------------------
			%%Function: GetDescription
			%%Qualified: yasc.CalItem.GetDescription
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public string GetDescription()
		{
			return m_sDescription;
		}


		public string GetOwner()
		{
			return m_sOwner;
		}

		public string GetID()
		{
			return m_sID;
		}

		/* R G S  G E T  R E S O U R C E S */
		/*----------------------------------------------------------------------------
			%%Function: RgsGetResources
			%%Qualified: yasc.CalItem.RgsGetResources
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public string[] RgsGetResources()
		{
			string []rgs = new string[m_rgcr.Length];

			int i, iMac; 

			for (i = 0, iMac = m_rgcr.Length; i < iMac; i++)
				{
				rgs[i] = m_rgcr[i].GetOwner();
				}

			return rgs;
		}

		/* G E T  S T A R T */
		/*----------------------------------------------------------------------------
			%%Function: GetStart
			%%Qualified: yasc.CalItem.GetStart
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public DateTime GetStart()
		{
			return m_dtStart;
		}

		/* F O R M A T  D A T E  T I M E */
		/*----------------------------------------------------------------------------
			%%Function: FormatDateTime
			%%Qualified: yasc.CalItem.FormatDateTime
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private string FormatDateTime(DateTime dtT)
		{
			string sTime = "";

			if (dtT.Hour == 0)
				sTime = "12:" + dtT.Minute.ToString("D2") + "am";
			else if (dtT.Hour == 12)
				sTime = "12:" + dtT.Minute.ToString("D2") + "pm";
			else if (dtT.Hour < 12)
				sTime = dtT.Hour.ToString("D2") + ":" + dtT.Minute.ToString("D2") + "am";
			else
				{
				int nHour = dtT.Hour - 12;

				sTime = nHour.ToString("D2") + ":" + dtT.Minute.ToString("D2") + "pm";
				}

			return sTime;
		}

		/* G E T  S T A R T  F O R M A T T E D */
		/*----------------------------------------------------------------------------
			%%Function: GetStartFormatted
			%%Qualified: yasc.CalItem.GetStartFormatted
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public string GetStartFormatted()
		{
			return FormatDateTime(GetStart());
		}

		/* G E T  E N D  F O R M A T T E D */
		/*----------------------------------------------------------------------------
			%%Function: GetEndFormatted
			%%Qualified: yasc.CalItem.GetEndFormatted
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public string GetEndFormatted()
		{
			return FormatDateTime(GetEnd());
		}

		/* S E T  S T A R T */
		/*----------------------------------------------------------------------------
			%%Function: SetStart
			%%Qualified: yasc.CalItem.SetStart
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public void SetStart(DateTime dt)
		{
			m_dtStart = dt;
		}

		public void SetEnd(DateTime dt)
		{
			m_dtEnd = dt;
		}

		/* G E T  E N D */
		/*----------------------------------------------------------------------------
			%%Function: GetEnd
			%%Qualified: yasc.CalItem.GetEnd
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public DateTime GetEnd()
		{
			return m_dtEnd;
		}

		private int DaySpan(DateTime dt1, DateTime dt2)
		{
			DateTime dtRound1 = new DateTime(dt1.Year, dt1.Month, dt1.Day);
			DateTime dtRound2 = new DateTime(dt2.Year, dt2.Month, dt2.Day);
			TimeSpan ts = dtRound1.Subtract(dtRound2);

			return Math.Abs((int)Math.Ceiling(ts.TotalDays));
		}

		/* C O M P A R E  T O */
		/*----------------------------------------------------------------------------
			%%Function: CompareTo
			%%Qualified: yasc.CalItem.CompareTo
			%%Contact: rlittle

			Some rules;

			1) Items that span days always sort before items that don't span days
			2) Items that span days and start on the same day sort in decreasing
			   order by length
		----------------------------------------------------------------------------*/
		public int CompareTo(CalItem ci)
		{
			DateTime dtOtherStart = ci.m_dtStart;
			DateTime dtOtherEnd = ci.m_dtEnd;
			int nDaysCur = DaySpan(m_dtEnd, m_dtStart);
			int nDaysOther = DaySpan(dtOtherEnd, dtOtherStart);
			int nDaysDiff = DaySpan(m_dtStart, dtOtherStart);

			if (nDaysDiff == 0)	// they start on the same day
				{
				if (nDaysCur > 1)
					{
					if (nDaysOther > nDaysCur)
						return 1;
					else if (nDaysOther == nDaysCur)
						return 0;
					else
						return -1;
					}

				if (nDaysOther > 1)
					return 1;
				}

			// just do a straight date diff since there are no whole-day
			// items, or they don't start on the same day.
			return m_dtStart.CompareTo(ci.GetStart());
		}

		/* I S  A F T E R */
		/*----------------------------------------------------------------------------
			%%Function: IsAfter
			%%Qualified: yasc.CalItem.IsAfter
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public bool IsAfter(CalItem ci)
		{
			return CompareTo(ci) > 0 ? true : false;
		}

		public Color GetColor()
		{
			return m_rgcr[0].GetColor();
		}

		/* I S  E Q U A L */
		/*----------------------------------------------------------------------------
			%%Function: IsEqual
			%%Qualified: yasc.CalItem.IsEqual
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public bool IsEqual(CalItem ci)
		{
			return m_sID.ToUpper() == ci.m_sID.ToUpper();
		}

	}

	// =====
	// C A L
	// =====

	public class Cal
	{

		// ===================
		// C A L  I T E M  L E
		// ===================

		public class CalItemLe
		{
			private CalItem m_ci;
			private CalItemLe m_cileNext;
			private CalItemLe m_cilePrev;

			/* C A L  I T E M  L E */
			/*----------------------------------------------------------------------------
				%%Function: CalItemLe
				%%Qualified: yasc.Cal:CalItemLe.CalItemLe
				%%Contact: rlittle

			----------------------------------------------------------------------------*/
			public CalItemLe(CalItem ci)
			{
				m_ci = ci;
				m_cileNext = null;
				m_cilePrev = null;
			}

			/* R E M O V E */
			/*----------------------------------------------------------------------------
				%%Function: Remove
				%%Qualified: yasc.Cal:CalItemLe.Remove
				%%Contact: rlittle

				be careful; removing an item from the linked list might create a new
				head.  we return what that new head would be.  it is the responsibility
				of the caller to decide whether or not the returned value *is* a new
				head.  (it this == m_cileHead, then the return value of this function
				should become the new head)
			----------------------------------------------------------------------------*/
			public CalItemLe Remove()
			{
				CalItemLe cileNewHead = null;

				if (m_cileNext != null)
					{
					// the new head is the next...
					m_cileNext.m_cilePrev = m_cilePrev;
					cileNewHead = m_cileNext;
					}

				if (m_cilePrev != null)
					{
					// ... unless we had a prev, in which case *its* the new head
					m_cilePrev.m_cileNext = m_cileNext;
					cileNewHead = m_cilePrev;
					}

				m_cileNext = null;
				m_cilePrev = null;
				m_ci = null;
			    
				return cileNewHead;
			}

			/* I N S E R T  A F T E R */
			/*----------------------------------------------------------------------------
				%%Function: InsertAfter
				%%Qualified: yasc.Cal:CalItemLe.InsertAfter
				%%Contact: rlittle

			----------------------------------------------------------------------------*/
			public void InsertAfter(CalItem ci)
			{
				CalItemLe cileNew = new CalItemLe(ci);

				if ((cileNew.m_cileNext = m_cileNext) != null)
					m_cileNext.m_cilePrev = cileNew;

				cileNew.m_cilePrev = this;
				m_cileNext = cileNew;
			}

			public CalItemLe InsertBefore(CalItem ci)
			{
				CalItemLe cileNew = new CalItemLe(ci);
				
				if (m_cilePrev != null)
					m_cilePrev.m_cileNext = cileNew;

				cileNew.m_cilePrev = m_cilePrev;
				m_cilePrev = cileNew;

				cileNew.m_cileNext = this;

				if (m_cilePrev != null)
					return m_cilePrev;
				else
					return cileNew;
			}

			/* N E X T */
			/*----------------------------------------------------------------------------
				%%Function: Next
				%%Qualified: yasc.Cal:CalItemLe.Next
				%%Contact: rlittle

			----------------------------------------------------------------------------*/
			public CalItemLe Next()
			{
				return m_cileNext;
			}

			/* P R E V */
			/*----------------------------------------------------------------------------
				%%Function: Prev
				%%Qualified: yasc.Cal:CalItemLe.Prev
				%%Contact: rlittle

			----------------------------------------------------------------------------*/
			public CalItemLe Prev()
			{
				return m_cilePrev;
			}

			/* C I  G E T */
			/*----------------------------------------------------------------------------
				%%Function: CiGet
				%%Qualified: yasc.Cal:CalItemLe.CiGet
				%%Contact: rlittle

			----------------------------------------------------------------------------*/
			public CalItem CiGet()
			{
				return m_ci;
			}
		}

		private CalItemLe m_cileHead;
		private CalItemLe m_cileCur;
		private ArrayList m_plcr;
		private Color[] m_rgColor;
		private int m_iNextColor;
		private int m_cItems;
		private DateTime m_dtLastCurSet;

		/* P O P U L A T E  R E S O U R C E  L I S T */
		/*----------------------------------------------------------------------------
			%%Function: PopulateResourceList
			%%Qualified: yasc.MainForm.PopulateResourceList
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		static public void PopulateResourceList(CheckedListBox clb)
		{
			Calendar cal = new Calendar();

			XmlNode node = cal.GetOwnerList();

			if (node != null)
				{
				clb.Items.Clear();

				XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);

				nsmgr.AddNamespace("c", "http://www.thetasoft.com/schemas/calendar");
				
				XmlNodeList nodes = node.SelectNodes("c:owner", nsmgr);

				if (nodes != null && nodes.Count > 0)
					{
					foreach (XmlNode nodeT in nodes)
						{
						string s = nodeT.InnerText;

						clb.Items.Add(s.Trim());
						}
					}
				}
		}


		/* R G S  F R O M  A R R A Y  L I S T */
		/*----------------------------------------------------------------------------
			%%Function: RgsFromArrayList
			%%Qualified: yasc.Cal.RgsFromArrayList
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		static public string[] RgsFromArrayList(ArrayList pls)
		{
			string []rgs = new string[pls.Count];
			int i, iMac;

			for (i = 0, iMac = pls.Count; i < iMac; i++)
				{
				rgs[i] = String.Copy((string)pls[i]);
				}

			return rgs;
		}
		
		/* B U I L D  S T R I N G  L I S T  F R O M  R E S O U R C E S */
		/*----------------------------------------------------------------------------
			%%Function: BuildStringListFromResources
			%%Qualified: yasc.Cal.BuildStringListFromResources
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		static public ArrayList BuildStringListFromResources(string sResources)
		{
			ArrayList pls = new ArrayList();

			try
				{
				int iStart;
				int iEnd;

				iStart = sResources.IndexOf('\'');

				while (iStart != -1 && iStart < sResources.Length - 1)
					{
					iEnd = sResources.IndexOf('\'', iStart + 1);
					if (iEnd < iStart || iEnd > sResources.Length)
						break;

					if (iEnd - iStart > 1)
						{
						// we have at least one character in the resource, so add it
						pls.Add(sResources.Substring(iStart + 1, iEnd - iStart - 1));
						}
					// look for the next '

					iStart = sResources.IndexOf('\'', iEnd + 1);
					}
				}
			catch
				{
				return null;
				}

			return pls;
		}


		/* C R  E N S U R E */
		/*----------------------------------------------------------------------------
			%%Function: CrEnsure
			%%Qualified: Cal.CrEnsure
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public CalResource CrEnsure(string sOwner)
		{
			int i, iMac;
			string sOwnerCompare = sOwner.ToUpper();

			for(i = 0, iMac = m_plcr.Count; i < iMac; i++)
				{
				if (((CalResource)m_plcr[i]).GetOwner().ToUpper().CompareTo(sOwnerCompare) == 0)
					return (CalResource)m_plcr[i];
				}

			CalResource crNew = new CalResource(m_rgColor[m_iNextColor], sOwner);
			m_iNextColor++;

			if (m_iNextColor >= m_rgColor.Length)
				m_iNextColor = 0;

			m_plcr.Add(crNew);
			return crNew;
		}


		/* R G C R  E N S U R E */
		/*----------------------------------------------------------------------------
			%%Function: RgcrEnsure
			%%Qualified: yasc.Cal.RgcrEnsure
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public CalResource[] RgcrEnsure(string []rgsResources)
		{
			CalResource []rgcr = new CalResource[rgsResources.Length];
			int i, iMac;

			for (i = 0, iMac = rgsResources.Length; i < iMac; i++)
				{
				rgcr[i] = CrEnsure(rgsResources[i]);
				}

			return rgcr;
		}

		/* R G C R  E N S U R E */
		/*----------------------------------------------------------------------------
			%%Function: RgcrEnsure
			%%Qualified: yasc.Cal.RgcrEnsure
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public CalResource[] RgcrEnsure(string sResources)
		{
			string []rgsResources = RgsFromArrayList(BuildStringListFromResources(sResources));

			CalResource []rgcr = new CalResource[rgsResources.Length];
			int i, iMac;

			for (i = 0, iMac = rgsResources.Length; i < iMac; i++)
				{
				rgcr[i] = CrEnsure(rgsResources[i]);
				}

			return rgcr;
		}

		/* I N I T */
		/*----------------------------------------------------------------------------
			%%Function: Init
			%%Qualified: yasc.Cal.Init
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void Init()
		{
			m_cileHead = null;
			m_plcr = new ArrayList();

			m_rgColor = new Color[] { Color.Teal, Color.Red, Color.RosyBrown, Color.Green };

//			int i = 0;

//			for (i = 0; i < m_rgColor.Length; i++)
//				m_rgColor[i] = Color.FromArgb(128, m_rgColor[i].R, m_rgColor[i].G, m_rgColor[i].B);

			m_iNextColor = 0;
			m_cItems = 0;
		}

		/* C A L */
		/*----------------------------------------------------------------------------
			%%Function: Cal
			%%Qualified: yasc.Cal.Cal
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public Cal()
		{
			Init();
		}

		/* A D D  I T E M */
		/*----------------------------------------------------------------------------
			%%Function: AddItem
			%%Qualified: yasc.Cal.AddItem
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public void AddItem(CalItem ci)
		{
			if (m_cileHead == null || m_cileHead.CiGet().IsAfter(ci))
				{
				if (m_cileHead != null)
					m_cileHead = m_cileHead.InsertBefore(ci);
				else
					m_cileHead = new CalItemLe(ci);

				m_cItems++;
				return;
				}

			CalItemLe cileCur = m_cileHead;

			while (cileCur.Next() != null && !cileCur.Next().CiGet().IsAfter(ci))
				cileCur = cileCur.Next();

			cileCur.InsertAfter(ci);
			m_cItems++;
		}

		/* R E M O V E  I T E M */
		/*----------------------------------------------------------------------------
			%%Function: RemoveItem
			%%Qualified: yasc.Cal.RemoveItem
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public void RemoveItem(CalItem ci)
		{
			// find the item and remove it
			CalItemLe cileCur = m_cileHead;

			while (cileCur != null && !cileCur.CiGet().IsEqual(ci))
				cileCur = cileCur.Next();

			if (cileCur != null)
				{
				CalItemLe cileNew = cileCur.Remove();
				m_cItems--;

				// if we are removing the head, then reset it
				if (m_cileHead == cileCur)
					m_cileHead = cileNew;
				}
		}

		/* C A L */
		/*----------------------------------------------------------------------------
			%%Function: Cal
			%%Qualified: yasc.Cal.Cal
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public Cal(bool fDebug)
		{
			Init();
			AddItem(new CalItem("id1", "Chris Birthday", "Christopher's Birthday", CrEnsure("rlittle"), DateTime.Parse("5/5/2003 00:00:00"), DateTime.Parse("5/5/2003 23:59:00"), 0, "rlittle"));
			AddItem(new CalItem("id1.1", "KillNext", "This is a test item", CrEnsure("rlittle"), DateTime.Parse("6/27/2003 00:00:00"), DateTime.Parse("6/27/2003 23:59:00"), 0, "rlittle"));
			AddItem(new CalItem("id1.2", "KilledByPrev", "This is a test item", CrEnsure("rlittle"), DateTime.Parse("6/27/2003 01:00:00"), DateTime.Parse("6/29/2003 23:59:00"), 0, "rlittle"));
			AddItem(new CalItem("id2", "Test 1234 One Two", "This is a test item", CrEnsure("rlittle"), DateTime.Parse("7/5/2003 00:00:00"), DateTime.Parse("7/5/2003 23:59:00"), 0, "rlittle"));
			AddItem(new CalItem("id2.5", "Overlap", "This is a test item", CrEnsure("rlittle"), DateTime.Parse("7/5/2003 00:00:00"), DateTime.Parse("7/7/2003 23:59:00"), 0, "rlittle"));
			AddItem(new CalItem("id3", "Test 1-2-3-4", "This is a test item 1-2-3-4", CrEnsure("little"), DateTime.Parse("7/15/2003 00:00:00"), DateTime.Parse("7/16/2003 23:59:00"), 0, "rlittle"));
			AddItem(new CalItem("id4", "Test1", "This is a test item1", CrEnsure("rlittle"), DateTime.Parse("7/23/2003 00:00:00"), DateTime.Parse("7/29/2003 23:59:00"), 0, "rlittle"));
			AddItem(new CalItem("id4.1", "Test1-2", "This is a test item1", CrEnsure("rlittle"), DateTime.Parse("7/25/2003 00:00:00"), DateTime.Parse("7/25/2003 23:59:00"), 0, "rlittle"));
			AddItem(new CalItem("id4.2", "Test1-3", "This is a test item1", CrEnsure("rlittle"), DateTime.Parse("7/27/2003 00:00:00"), DateTime.Parse("7/28/2003 23:59:00"), 0, "rlittle"));
			AddItem(new CalItem("id5", "Overlap2", "This is a test item 1-2-3-4", CrEnsure("little"), DateTime.Parse("7/8/2003 01:00:00"), DateTime.Parse("7/9/2003 23:59:00"), 0, "rlittle"));
			AddItem(new CalItem("id5.1", "Overlap3", "This is a test item 1-2-3-4", CrEnsure("little"), DateTime.Parse("7/9/2003 01:00:00"), DateTime.Parse("7/10/2003 23:59:00"), 0, "rlittle"));
			AddItem(new CalItem("id5.2", "Overlap4", "This is a test item 1-2-3-4", CrEnsure("little"), DateTime.Parse("7/10/2003 01:00:00"), DateTime.Parse("7/11/2003 23:59:00"), 0, "rlittle"));
			AddItem(new CalItem("id5.3", "Overlap4", "This is a test item 1-2-3-4", CrEnsure("little"), DateTime.Parse("7/8/2003 00:00:00"), DateTime.Parse("7/11/2003 23:59:00"), 0, "rlittle"));
		}

		public int GetCalSize()
		{
			return m_cItems;
		}

		/* S E T  C A L  I T E M */
		/*----------------------------------------------------------------------------
			%%Function: SetCalItem
			%%Qualified: yasc.Cal.SetCalItem
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public void SetCalItem(DateTime dtStart)
		{
			CalItemLe cile = m_cileHead;

			while (cile != null && cile.CiGet().GetEnd().CompareTo(dtStart) < 0)
				cile = cile.Next();

			m_cileCur = cile;
			m_dtLastCurSet = dtStart;
		}

		public void SetCalItem()
		{
			m_cileCur = m_cileHead;
		}

		/* G E T  C U R  I T E M */
		/*----------------------------------------------------------------------------
			%%Function: GetCurItem
			%%Qualified: yasc.Cal.GetCurItem
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public CalItem GetCurItem()
		{
			if (m_cileCur == null)
				return null;

			return m_cileCur.CiGet();
		}

		/* G E T  C U R  I T E M */
		/*----------------------------------------------------------------------------
			%%Function: GetCurItem
			%%Qualified: yasc.Cal.GetCurItem
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public CalItem GetCurItem(DateTime dtEnd)
		{
			if (m_cileCur == null)
				return null;

			if (m_cileCur.CiGet().GetStart().CompareTo(dtEnd) > 0)
				return null;

			return m_cileCur.CiGet();
		}

		/* N E X T  I T E M */
		/*----------------------------------------------------------------------------
			%%Function: NextItem
			%%Qualified: yasc.Cal.NextItem
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public CalItem NextItem()
		{
			if (m_cileCur == null)
				return null;

			m_cileCur = m_cileCur.Next();

			while (m_cileCur != null && m_cileCur.CiGet().GetEnd().CompareTo(m_dtLastCurSet) < 0)
				m_cileCur = m_cileCur.Next();

			return m_cileCur == null ? null : m_cileCur.CiGet();
		}

		/* N E X T  I T E M */
		/*----------------------------------------------------------------------------
			%%Function: NextItem
			%%Qualified: yasc.Cal.NextItem
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public CalItem NextItem(DateTime dtEnd)
		{
			CalItem ci = NextItem();

			if (ci == null)
				return null;

			if (ci.GetStart().CompareTo(dtEnd) > 0)
				return null;

			return ci;
		}
	}

	// ==============
	// H I T  T E S T
	// ==============

	public class HitTest
	{
		private class HitTestLe
		{
			public Rectangle rect;
			public object oData;
			public HitTestLe htleNext;
		}

		private HitTestLe m_htleHead;

		/* H I T  T E S T */
		/*----------------------------------------------------------------------------
			%%Function: HitTest
			%%Qualified: yasc.HitTest.HitTest
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public HitTest()
		{
			m_htleHead = null;
		}

		/* A D D */
		/*----------------------------------------------------------------------------
			%%Function: Add
			%%Qualified: yasc.HitTest.Add
			%%Contact: rlittle

			HitTest items get added in a sorted fashion for faster lookups.
			
			Sort by Y coordinates since we expect there to be more Y coords than
			X coords (hence a smaller linear search of X coords)
		----------------------------------------------------------------------------*/
		public void Add(Rectangle rect, object oData)
		{
			HitTestLe htleNew = new HitTestLe();

			htleNew.rect = rect;
			htleNew.oData = oData;

			if (m_htleHead == null)
				{
				m_htleHead = htleNew;
				m_htleHead.htleNext = null;

				return;
				}

			if (m_htleHead.rect.Y < rect.Y)
				{
				htleNew.htleNext = m_htleHead;
				m_htleHead = htleNew;

				return;
				}

			HitTestLe htle = m_htleHead;

			while (htle.htleNext != null && htle.htleNext.rect.Y > rect.Y)
				htle = htle.htleNext;

			htleNew.htleNext = htle.htleNext;
			htle.htleNext = htleNew;

			return;
		}

		/* D O  C O N T E N T  H I T */
		/*----------------------------------------------------------------------------
			%%Function: DoContentHit
			%%Qualified: yasc.HitTest.DoContentHit
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public object DoContentHit(Point pt, out Rectangle rect)
		{
			HitTestLe htle = m_htleHead;

			rect = new Rectangle(0,0,0,0);
			while (htle != null && htle.rect.Y > pt.Y)
				htle = htle.htleNext;

			if (htle == null)
				return null;

			while (htle != null)
				{
				if (htle.rect.Contains(pt))
					{
					rect = htle.rect;
					return htle.oData;
					}

				htle = htle.htleNext;
				}

			return null;
		}
	}


	// ================
	// M A I N  F O R M
	// ================

	public class MainForm : System.Windows.Forms.Form
	{
		private class ContextMenuSupport
		{
			public Rectangle rectHitRegionItem;
			public Rectangle rectHitRegionDay;
			public DateTime dtHit;
			public CalItem ciHit;
			public Point ptRaw;
		}

		private string m_sResources = "";
		private int m_nDayWidth = 0;
		private int m_nDayHeight = 0;
		private DateTime m_dtViewStart;
		private DateTime m_dtViewEnd;
		private Font m_hFontCalendar;
		private float m_dyaCalendarFont;
		private bool m_fInhibitMonthChange = false;
		private Cal m_cal;
		private CalItemInspector m_cii = null;
		private Hover m_ch = null;
		private bool m_fTipShowing = false;
		private Rectangle m_rectTipHitRegion;
		private ContextMenuSupport m_cxts;
		private FrmNewItem m_frmNew;
		private FrmFilter m_frmFilter;
		private System.Windows.Forms.PictureBox m_pbCalendar;
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox m_ebYear;
		private System.Windows.Forms.ComboBox m_cbMonth;

		private HitTest m_htItems;
		private HitTest m_htDays;
		private System.Windows.Forms.ContextMenu m_cxtMenu;
		private System.Windows.Forms.MenuItem m_cxtmiEdit;
		private System.Windows.Forms.MenuItem m_cxtmiDelete;
		private System.Windows.Forms.MenuItem m_cxtmiZoomDay;
		private System.Windows.Forms.Button m_pbPrevMonth;
		private System.Windows.Forms.Button m_pbPrevEvent;
		private System.Windows.Forms.Button m_pbNextMonth;
		private System.Windows.Forms.Button m_pbNextEvent;

		public const int dyCalendarReserved = 6; // 12 * 4;

		private const int xaOffset = 0;
		private System.Windows.Forms.MenuItem m_cxtmiCreate;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.Button m_pbNew;
		private System.Windows.Forms.Button m_pbRefresh;
		private System.Windows.Forms.Button m_pbFilters;
		private System.Windows.Forms.ToolTip m_ttp;
		private System.Windows.Forms.Button m_pbRefreshTb;
		private System.Windows.Forms.Button m_pbFilterTb;
		private System.Windows.Forms.MenuItem m_cxtmiCreateBased;
		private const int yaOffset = 10;


		/* X A  F R O M  D A Y */
		/*----------------------------------------------------------------------------
			%%Function: XaFromDay
			%%Qualified: yasc.MainForm.XaFromDay
			%%Contact: rlittle
			
			remember -- nDayOfWeek is 0-based.
		----------------------------------------------------------------------------*/
		public int XaFromDay(int nDayOfWeek)
		{
			return xaOffset + nDayOfWeek * m_nDayWidth;
		}

		/* Y A  F R O M  W E E K */
		/*----------------------------------------------------------------------------
			%%Function: YaFromWeek
			%%Qualified: yasc.MainForm.YaFromWeek
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public int YaFromWeek(int nWeek)
		{
			return dyCalendarReserved + 20 + nWeek * m_nDayHeight;
		}

		public Rectangle RectFromDay(int nDayOfWeek, int nWeek)
		{
			return new Rectangle(XaFromDay(nDayOfWeek), YaFromWeek(nWeek), m_nDayWidth, m_nDayHeight);
		}

		/* D R A W  C E N T E R E D  S T R I N G */
		/*----------------------------------------------------------------------------
			%%Function: DrawCenteredString
			%%Qualified: yasc.MainForm.DrawCenteredString
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public void DrawCenteredString(Graphics gr, string s, Font hFont, Brush hBrush, int xa, int ya, int dxa)
		{
			int dxaString = (int)gr.MeasureString(s, hFont).Width;

			gr.DrawString(s, hFont, hBrush, xa + (dxa - dxaString) / 2, ya);
		}

		/* D R A W  C I */
		/*----------------------------------------------------------------------------
			%%Function: DrawCi
			%%Qualified: yasc.MainForm.DrawCi
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public void DrawCi(PictureBox pb, CalItem ci, Graphics gr, int iItemOnDay)
		{
			SolidBrush hBrushBlack = new SolidBrush(Color.Black);
			SolidBrush hBrush = new SolidBrush(Color.White);
			SolidBrush hBrushFill = new SolidBrush(ci.GetColor());

			DateTime dtStart = ci.GetStart();
			DateTime dtEnd = ci.GetEnd();
			DateTime dt = dtStart;
			TimeSpan ts = dt.Subtract(m_dtViewStart);
			TimeSpan tsDraw;

			if (ts.TotalDays < 0)
				{
				dt = m_dtViewStart;
				ts = dt.Subtract(m_dtViewStart);
				}

			tsDraw = dtEnd.Subtract(dt);
			int nWeek = (int)(ts.TotalDays / 7);
			int nDay = (int)dt.DayOfWeek;

			if (tsDraw.TotalDays >= 1.0)
				{
				// make everyone think we start at 00:00 on the first day
				// and end at 23:59 on the last day.

				dtStart = DtFirstForDt(dtStart);
//				dtEnd = DtLastForDt(dtEnd);

				// and recalc everything
				dt = dtStart;
				ts = dt.Subtract(m_dtViewStart);

				tsDraw = dtEnd.Subtract(dt);
				nWeek = (int)(ts.TotalDays / 7);
				nDay = (int)dt.DayOfWeek;
				}

			while (tsDraw.TotalDays > 0.0)
				{
				bool fFirst = dt.CompareTo(dtStart) == 0;

				int ya = YaFromWeek(nWeek) + 16;
				int xa = XaFromDay(nDay);
				int nDaysToDraw = 1;
				bool fFullDay = !fFirst;

				// for the first day, indent 2
				if (fFirst)
					xa += 2;

				int dxa = m_nDayWidth;
				int dya = (int)Math.Ceiling(m_dyaCalendarFont); // m_nDayHeight - 17;

				ya += (iItemOnDay * (dya + 2));

				if (tsDraw.TotalDays >= 1.0)
					{
					fFullDay = true;
					nDaysToDraw = (int)Math.Ceiling(Math.Min((double)tsDraw.TotalDays, (double)(7 - nDay)));
					}

				tsDraw = tsDraw.Subtract(TimeSpan.FromDays(nDaysToDraw));
				bool fLast = tsDraw.TotalDays <= 1.0;

				dxa *= nDaysToDraw;

				if (fLast)
					dxa -= 2;

				if (fFirst)
					dxa -= 2;

				if (fFullDay)
					{
					m_htItems.Add(new Rectangle(xa, ya, dxa, dya), ci);

					gr.FillRectangle(hBrushFill, xa, ya, dxa, dya);

					Pen penOuter = new Pen(Color.FromArgb(255, 64,64,64), (float)1.5);
					Pen penInner = new Pen(Color.FromArgb(255, 192,192,192), (float)1.5);

					gr.DrawLine(penOuter, xa, ya, xa + dxa, ya);
					if (fFirst)
						gr.DrawLine(penOuter, xa, ya, xa, ya + dya);

					if (fLast)
						gr.DrawLine(penInner, xa + dxa, ya + dya, xa + dxa, ya);

					gr.DrawLine(penInner, xa + dxa, ya + dya, xa, ya + dya);
					DrawCenteredString(gr, ci.GetTitle(), m_hFontCalendar, hBrush, xa, ya, dxa);
					}
				else
					{
					// figure out if there's enough room for the time
					string sTime = ci.GetStartFormatted();

					sTime += " ";
					gr.SetClip(new Rectangle(xa, ya, dxa, dya));

					m_htItems.Add(new Rectangle(xa, ya, dxa, dya), ci);

					if (gr.MeasureString(sTime, m_hFontCalendar).Width > dxa / 2)
						gr.DrawString(ci.GetTitle(), m_hFontCalendar, hBrushBlack, xa, ya - 1);
					else
						gr.DrawString(sTime + ci.GetTitle(), m_hFontCalendar, hBrushBlack, xa, ya - 1);

					gr.SetClip(new Rectangle(0, 0, pb.Width, pb.Height));

					}

				dt = dt.Add(TimeSpan.FromDays(nDaysToDraw));
				ts = ts.Add(TimeSpan.FromDays(nDaysToDraw));

				nWeek = (int)(ts.TotalDays / 7);
				nDay = (int)dt.DayOfWeek;
				}
			
		}

		/* D T  F I R S T  F O R  D T */
		/*----------------------------------------------------------------------------
			%%Function: DtFirstForDt
			%%Qualified: yasc.MainForm.DtFirstForDt
			%%Contact: rlittle

			Return the earliest time for this date.
		----------------------------------------------------------------------------*/
		public DateTime DtFirstForDt(DateTime dt)
		{
			return DateTime.Parse(dt.ToString("d") + " 00:00:00");
		}

		/* D T  L A S T  F O R  D T */
		/*----------------------------------------------------------------------------
			%%Function: DtLastForDt
			%%Qualified: yasc.MainForm.DtLastForDt
			%%Contact: rlittle

			Return the latest time for this date
		----------------------------------------------------------------------------*/
		public DateTime DtLastForDt(DateTime dt)
		{
			return DateTime.Parse(dt.ToString("d") + " 23:59:59");
		}

		/* R E D R A W  C A L E N D A R  B O X */
		/*----------------------------------------------------------------------------
			%%Function: RedrawCalendarBox
			%%Qualified: yasc.MainForm.RedrawCalendarBox
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public void RedrawCalendarBox(PictureBox pb, Graphics gr)
		{
			m_htItems = new HitTest();

			m_nDayWidth = (pb.Width - (xaOffset * 2)) / 7;
			m_nDayHeight = (pb.Height - dyCalendarReserved - 20 - yaOffset) / 6;

			if (m_nDayHeight <= 0)
				return;

			m_hFontCalendar = new Font("Tahoma", 8);
			m_dyaCalendarFont = gr.MeasureString("foo", m_hFontCalendar).Height;

			int nDayItemsPerDay = (m_nDayHeight / ((int)Math.Ceiling(m_dyaCalendarFont) + 2)) - 1;
			bool []rgfUsed = new bool[nDayItemsPerDay];

			Pen oPen = new Pen(Color.Black, 1.0f);

			gr.Clear(this.BackColor);

			int c; 

			// draw each of the vertical lines
			for (c = 0; c <= 7; c++)
				gr.DrawLine(oPen, xaOffset + c * m_nDayWidth, dyCalendarReserved, xaOffset + c * m_nDayWidth, dyCalendarReserved + 20 + 6 * m_nDayHeight);
				
			for (c = 0; c <= 6; c++)
				gr.DrawLine(oPen, xaOffset, dyCalendarReserved + 20 + c * m_nDayHeight, xaOffset + 7 * m_nDayWidth, dyCalendarReserved + 20 + c * m_nDayHeight);

			gr.DrawLine(oPen, xaOffset, dyCalendarReserved, xaOffset + 7 * m_nDayWidth, dyCalendarReserved);

			string s;
			SolidBrush hBrush = new SolidBrush(Color.Black);

			if (m_cbMonth.SelectedIndex >= 0)
				s = m_cbMonth.Items[m_cbMonth.SelectedIndex].ToString();
			else
				s = "";

			//Font hFont = new Font("Tahoma", 18, FontStyle.Bold);

			//gr.DrawString(s + " " + m_ebYear.Text, hFont, hBrush, 10, 10);
//			m_lblMonth.Text = s + " " + m_ebYear.Text;

			Font hFont = new Font("Tahoma", 10);

			DrawCenteredString(gr, "Sunday", hFont, hBrush, XaFromDay(0), YaFromWeek(0) - 18, XaFromDay(1) - XaFromDay(0));
			DrawCenteredString(gr, "Monday", hFont, hBrush, XaFromDay(1), YaFromWeek(0) - 18, XaFromDay(2) - XaFromDay(1));
			DrawCenteredString(gr, "Tuesday", hFont, hBrush, XaFromDay(2), YaFromWeek(0) - 18, XaFromDay(3) - XaFromDay(2));
			DrawCenteredString(gr, "Wednesday", hFont, hBrush, XaFromDay(3), YaFromWeek(0) - 18, XaFromDay(4) - XaFromDay(3));
			DrawCenteredString(gr, "Thursday", hFont, hBrush, XaFromDay(4), YaFromWeek(0) - 18, XaFromDay(5) - XaFromDay(4));
			DrawCenteredString(gr, "Friday", hFont, hBrush, XaFromDay(5), YaFromWeek(0) - 18, XaFromDay(6) - XaFromDay(5));
			DrawCenteredString(gr, "Saturday", hFont, hBrush, XaFromDay(6), YaFromWeek(0) - 18, XaFromDay(7) - XaFromDay(6));

			// ok, figure out what the first day of this month falls on
			DateTime dt = new DateTime(Int32.Parse(m_ebYear.Text), m_cbMonth.SelectedIndex + 1, 1);

			int nDay = (int)dt.DayOfWeek;

			SolidBrush hBrushGray = new SolidBrush(Color.FromArgb(255, 176, 176, 176));
			DateTime dtLastMonth = dt.AddDays(0);
			
			m_htDays = new HitTest();

			for (c = nDay - 1; c >= 0; c--)
				{
				dtLastMonth = dtLastMonth.AddDays(-1);
				m_htDays.Add(RectFromDay(c, 0), dtLastMonth.AddDays(0));
				gr.DrawString(dtLastMonth.Day.ToString(), hFont, hBrushGray, XaFromDay(c), YaFromWeek(0));
				}

			m_dtViewStart = dtLastMonth.AddDays(0);
			int nWeek = 0;
			int nMonth = dt.Month;

			while (nWeek < 6)
				{
				while (nDay < 7)
					{
					m_htDays.Add(RectFromDay(nDay, nWeek), dt.AddDays(0));
					gr.DrawString(dt.Day.ToString(), hFont, dt.Month != nMonth ? hBrushGray : hBrush, XaFromDay(nDay), YaFromWeek(nWeek));
					dt = dt.AddDays(1);
					nDay++;
					}
				nDay = 0;
				nWeek++;
				}

			m_dtViewEnd = dt.AddDays(0);

			if (m_cal != null)
				{
				Cal calOverlap = new Cal();

				m_cal.SetCalItem(m_dtViewStart);

				CalItem ci;

				ci = m_cal.GetCurItem();

				while (ci != null)
					{
					// prune out the leading items from the overlap calendar, if
					// appropriate

					calOverlap.SetCalItem();
					CalItem ciOverlap = calOverlap.GetCurItem();

					while (ciOverlap != null)
						{
						if (ciOverlap.GetEnd().CompareTo(ci.GetStart()) < 0)
							{
							// this item doesn't overlap; remove it
							int iIndexUsed = ciOverlap.GetTag();
							if (iIndexUsed >= 0 && iIndexUsed < nDayItemsPerDay)
								rgfUsed[iIndexUsed] = false;

							calOverlap.RemoveItem(ciOverlap);
							calOverlap.SetCalItem();
							}
						else
							{
							calOverlap.NextItem();
							}
						ciOverlap = calOverlap.GetCurItem();
						}

					// find the first index not used
					int iIndexToUse = 0;

					while (iIndexToUse < nDayItemsPerDay)
						{
						if (rgfUsed[iIndexToUse] == false)
							break;

						iIndexToUse++;
						}

					if (iIndexToUse >= nDayItemsPerDay)
						{
						// no room to draw this item!  draw some kind of widget here!
						ci = m_cal.NextItem(m_dtViewEnd);
						continue;
						}

					// at this point, we've removed all the leading items from
					// the overlap calendar that don't really overlap.  This means
					// that whatever we have left really do overlap us.
					DrawCi(pb, ci, gr, iIndexToUse);

					// add to the overlapping calendar.
					CalItem ciClone = ci.Clone(false/*fGenerateID*/);

					ciClone.SetStart(ciClone.GetEnd());
					ciClone.SetEnd(DtLastForDt(ciClone.GetEnd()));

					rgfUsed[iIndexToUse] = true;
					ciClone.SetTag(iIndexToUse);
					calOverlap.AddItem(ciClone);
					ci = m_cal.NextItem(m_dtViewEnd);
					}
				}
		}

		private void PaintBox(Object sender, PaintEventArgs e)
		{
			PictureBox pb = (PictureBox)sender;
			
			RedrawCalendarBox(pb, e.Graphics);
		}

		private void ResizeBox(Object sender, EventArgs e)
		{
			PictureBox pb = (PictureBox)sender;
			
			RedrawCalendarBox(pb, pb.CreateGraphics());
		}

		/* M A I N  F O R M */
		/*----------------------------------------------------------------------------
			%%Function: MainForm
			%%Qualified: yasc.MainForm.MainForm
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public MainForm()
		{
			Calendar cal = new Calendar();

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cxts = new ContextMenuSupport();

//			PopulateResourceList(m_clbResources);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			DateTime dt = DateTime.Now;

			m_fInhibitMonthChange = true;
			m_cbMonth.SelectedIndex = dt.Month - 1;
			m_ebYear.Text = dt.Year.ToString();
			m_fInhibitMonthChange = false;

			m_ttp.SetToolTip(m_pbPrevMonth, "Go to the previous month");
			m_ttp.SetToolTip(m_pbPrevEvent, "Find the nearest event before this month (NYI)");
			m_ttp.SetToolTip(m_pbNextMonth, "Go to the next month");
			m_ttp.SetToolTip(m_pbNextEvent, "Find the nearest event after this month (NYI)");
			m_ttp.SetToolTip(m_pbFilterTb, "Choose which resources to show");
			m_ttp.SetToolTip(m_pbRefreshTb, "Fetch and Refresh the current calendar view");

			m_pbCalendar.AllowDrop = true;

		}

		/* D I S P O S E */
		/*----------------------------------------------------------------------------
			%%Function: Dispose
			%%Qualified: yasc.MainForm.Dispose
			%%Contact: rlittle

			Clean up any resources being used.
		----------------------------------------------------------------------------*/
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/* I N I T I A L I Z E  C O M P O N E N T */
		/*----------------------------------------------------------------------------
			%%Function: InitializeComponent
			%%Qualified: yasc.MainForm.InitializeComponent
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.m_pbCalendar = new System.Windows.Forms.PictureBox();
			this.m_cxtMenu = new System.Windows.Forms.ContextMenu();
			this.m_cxtmiCreate = new System.Windows.Forms.MenuItem();
			this.m_cxtmiCreateBased = new System.Windows.Forms.MenuItem();
			this.m_cxtmiEdit = new System.Windows.Forms.MenuItem();
			this.m_cxtmiDelete = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.m_cxtmiZoomDay = new System.Windows.Forms.MenuItem();
			this.m_ebYear = new System.Windows.Forms.TextBox();
			this.m_cbMonth = new System.Windows.Forms.ComboBox();
			this.m_pbPrevMonth = new System.Windows.Forms.Button();
			this.m_pbPrevEvent = new System.Windows.Forms.Button();
			this.m_pbNextMonth = new System.Windows.Forms.Button();
			this.m_pbNextEvent = new System.Windows.Forms.Button();
			this.m_pbNew = new System.Windows.Forms.Button();
			this.m_pbRefresh = new System.Windows.Forms.Button();
			this.m_pbFilters = new System.Windows.Forms.Button();
			this.m_pbRefreshTb = new System.Windows.Forms.Button();
			this.m_pbFilterTb = new System.Windows.Forms.Button();
			this.m_ttp = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// m_pbCalendar
			// 
			this.m_pbCalendar.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.m_pbCalendar.ContextMenu = this.m_cxtMenu;
			this.m_pbCalendar.Location = new System.Drawing.Point(8, 48);
			this.m_pbCalendar.Name = "m_pbCalendar";
			this.m_pbCalendar.Size = new System.Drawing.Size(605, 672);
			this.m_pbCalendar.TabIndex = 1;
			this.m_pbCalendar.TabStop = false;
			this.m_pbCalendar.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.Test2);
			this.m_pbCalendar.Resize += new System.EventHandler(this.ResizeBox);
			this.m_pbCalendar.DragLeave += new System.EventHandler(this.Test3);
			this.m_pbCalendar.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBox);
			this.m_pbCalendar.MouseHover += new System.EventHandler(this.HoverCal);
			this.m_pbCalendar.DragDrop += new System.Windows.Forms.DragEventHandler(this.HandleCalendarDrop);
			this.m_pbCalendar.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.Test);
			this.m_pbCalendar.DoubleClick += new System.EventHandler(this.PaintBoxDoubleClick);
			this.m_pbCalendar.DragOver += new System.Windows.Forms.DragEventHandler(this.Test4);
			this.m_pbCalendar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HandleMouse);
			this.m_pbCalendar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandleMouseDown);
			// 
			// m_cxtMenu
			// 
			this.m_cxtMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.m_cxtmiCreate,
																					  this.m_cxtmiCreateBased,
																					  this.m_cxtmiEdit,
																					  this.m_cxtmiDelete,
																					  this.menuItem1,
																					  this.m_cxtmiZoomDay});
			// 
			// m_cxtmiCreate
			// 
			this.m_cxtmiCreate.Index = 0;
			this.m_cxtmiCreate.Text = "&Create Item";
			this.m_cxtmiCreate.Click += new System.EventHandler(this.InvokeCreateItem);
			// 
			// m_cxtmiCreateBased
			// 
			this.m_cxtmiCreateBased.Index = 1;
			this.m_cxtmiCreateBased.Text = "New Item &Based On...";
			this.m_cxtmiCreateBased.Click += new System.EventHandler(this.InvokeCreateCopy);
			// 
			// m_cxtmiEdit
			// 
			this.m_cxtmiEdit.Index = 2;
			this.m_cxtmiEdit.Text = "&Edit Item";
			this.m_cxtmiEdit.Click += new System.EventHandler(this.InvokeEditItem);
			// 
			// m_cxtmiDelete
			// 
			this.m_cxtmiDelete.Index = 3;
			this.m_cxtmiDelete.Text = "&Delete Item";
			this.m_cxtmiDelete.Click += new System.EventHandler(this.InvokeDeleteItem);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 4;
			this.menuItem1.Text = "-";
			// 
			// m_cxtmiZoomDay
			// 
			this.m_cxtmiZoomDay.Index = 5;
			this.m_cxtmiZoomDay.Text = "&Zoom Day";
			this.m_cxtmiZoomDay.Click += new System.EventHandler(this.InvokeZoomDay);
			// 
			// m_ebYear
			// 
			this.m_ebYear.BackColor = System.Drawing.SystemColors.Control;
			this.m_ebYear.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ebYear.Location = new System.Drawing.Point(232, 16);
			this.m_ebYear.Name = "m_ebYear";
			this.m_ebYear.Size = new System.Drawing.Size(72, 33);
			this.m_ebYear.TabIndex = 7;
			this.m_ebYear.Text = "textBox2";
			this.m_ebYear.Validated += new System.EventHandler(this.HandleMonthChange);
			// 
			// m_cbMonth
			// 
			this.m_cbMonth.BackColor = System.Drawing.SystemColors.Control;
			this.m_cbMonth.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbMonth.ItemHeight = 25;
			this.m_cbMonth.Items.AddRange(new object[] {
														   "January",
														   "February",
														   "March",
														   "April",
														   "May",
														   "June",
														   "July",
														   "August",
														   "September",
														   "October",
														   "November",
														   "December"});
			this.m_cbMonth.Location = new System.Drawing.Point(72, 16);
			this.m_cbMonth.Name = "m_cbMonth";
			this.m_cbMonth.Size = new System.Drawing.Size(160, 33);
			this.m_cbMonth.TabIndex = 6;
			this.m_cbMonth.Text = "comboBox1";
			this.m_cbMonth.SelectedIndexChanged += new System.EventHandler(this.HandleMonthChange);
			// 
			// m_pbPrevMonth
			// 
			this.m_pbPrevMonth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_pbPrevMonth.Location = new System.Drawing.Point(40, 16);
			this.m_pbPrevMonth.Name = "m_pbPrevMonth";
			this.m_pbPrevMonth.Size = new System.Drawing.Size(32, 32);
			this.m_pbPrevMonth.TabIndex = 5;
			this.m_pbPrevMonth.Text = "<";
			this.m_pbPrevMonth.Click += new System.EventHandler(this.HandlePrevMonthClick);
			// 
			// m_pbPrevEvent
			// 
			this.m_pbPrevEvent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_pbPrevEvent.Location = new System.Drawing.Point(8, 16);
			this.m_pbPrevEvent.Name = "m_pbPrevEvent";
			this.m_pbPrevEvent.Size = new System.Drawing.Size(32, 32);
			this.m_pbPrevEvent.TabIndex = 4;
			this.m_pbPrevEvent.Text = "<<";
			// 
			// m_pbNextMonth
			// 
			this.m_pbNextMonth.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.m_pbNextMonth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_pbNextMonth.Location = new System.Drawing.Point(552, 16);
			this.m_pbNextMonth.Name = "m_pbNextMonth";
			this.m_pbNextMonth.Size = new System.Drawing.Size(32, 32);
			this.m_pbNextMonth.TabIndex = 10;
			this.m_pbNextMonth.Text = ">";
			this.m_pbNextMonth.Click += new System.EventHandler(this.HandleNextMonthClick);
			// 
			// m_pbNextEvent
			// 
			this.m_pbNextEvent.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.m_pbNextEvent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_pbNextEvent.Location = new System.Drawing.Point(584, 16);
			this.m_pbNextEvent.Name = "m_pbNextEvent";
			this.m_pbNextEvent.Size = new System.Drawing.Size(32, 32);
			this.m_pbNextEvent.TabIndex = 11;
			this.m_pbNextEvent.Text = ">>";
			// 
			// m_pbNew
			// 
			this.m_pbNew.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.m_pbNew.Location = new System.Drawing.Point(376, 728);
			this.m_pbNew.Name = "m_pbNew";
			this.m_pbNew.Size = new System.Drawing.Size(112, 24);
			this.m_pbNew.TabIndex = 2;
			this.m_pbNew.Text = "Create New Item";
			this.m_pbNew.Click += new System.EventHandler(this.HandleNewClick);
			// 
			// m_pbRefresh
			// 
			this.m_pbRefresh.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.m_pbRefresh.Location = new System.Drawing.Point(256, 728);
			this.m_pbRefresh.Name = "m_pbRefresh";
			this.m_pbRefresh.Size = new System.Drawing.Size(112, 24);
			this.m_pbRefresh.TabIndex = 1;
			this.m_pbRefresh.Text = "Refresh Calendar";
			this.m_pbRefresh.Click += new System.EventHandler(this.HandleRefresh);
			// 
			// m_pbFilters
			// 
			this.m_pbFilters.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.m_pbFilters.Location = new System.Drawing.Point(496, 728);
			this.m_pbFilters.Name = "m_pbFilters";
			this.m_pbFilters.Size = new System.Drawing.Size(112, 24);
			this.m_pbFilters.TabIndex = 3;
			this.m_pbFilters.Text = "Filters and Options";
			this.m_pbFilters.Click += new System.EventHandler(this.HandleFilterClick);
			// 
			// m_pbRefreshTb
			// 
			this.m_pbRefreshTb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_pbRefreshTb.Location = new System.Drawing.Point(512, 16);
			this.m_pbRefreshTb.Name = "m_pbRefreshTb";
			this.m_pbRefreshTb.Size = new System.Drawing.Size(32, 32);
			this.m_pbRefreshTb.TabIndex = 9;
			this.m_pbRefreshTb.Text = "!";
			this.m_pbRefreshTb.Click += new System.EventHandler(this.HandleRefresh);
			// 
			// m_pbFilterTb
			// 
			this.m_pbFilterTb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_pbFilterTb.Location = new System.Drawing.Point(480, 16);
			this.m_pbFilterTb.Name = "m_pbFilterTb";
			this.m_pbFilterTb.Size = new System.Drawing.Size(32, 32);
			this.m_pbFilterTb.TabIndex = 8;
			this.m_pbFilterTb.Text = "F";
			this.m_pbFilterTb.Click += new System.EventHandler(this.HandleFilterClick);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(622, 758);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_pbFilterTb,
																		  this.m_pbRefreshTb,
																		  this.m_pbFilters,
																		  this.m_pbNew,
																		  this.m_pbRefresh,
																		  this.m_pbNextEvent,
																		  this.m_pbNextMonth,
																		  this.m_pbPrevEvent,
																		  this.m_pbPrevMonth,
																		  this.m_cbMonth,
																		  this.m_ebYear,
																		  this.m_pbCalendar});
			this.Name = "MainForm";
			this.Text = "Yet Another Shared Calendar";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		/* S  F E T C H  F R O M  E V E N T  N O D E */
		/*----------------------------------------------------------------------------
			%%Function: SFetchFromEventNode
			%%Qualified: yasc.MainForm.SFetchFromEventNode
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private string SFetchFromEventNode(XmlNode nodeEvent, string sElt, XmlNamespaceManager nsmgr)
		{
			XmlNode node = nodeEvent.SelectSingleNode(sElt, nsmgr);

			if (node != null)
				return node.InnerText.Trim();

			return "";
		}

		/* S  B U I L D  R E S O U R C E  H A S H */
		/*----------------------------------------------------------------------------
			%%Function: SBuildResourceHash
			%%Qualified: yasc.MainForm.SBuildResourceHash
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private string SBuildResourceHash(string []rgs)
		{
			string []rgsSorted = (string [])rgs.Clone();
			string sHash = "";

			Array.Sort(rgsSorted);

			foreach (string s in rgsSorted)
				{
				sHash += "'" + s + "'";
				}

			return sHash;
		}


		/* R G S  F E T C H  F R O M  E V E N T  N O D E */
		/*----------------------------------------------------------------------------
			%%Function: RgsFetchFromEventNode
			%%Qualified: yasc.MainForm.RgsFetchFromEventNode
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private string[] RgsFetchFromEventNode(XmlNode nodeEvent, string sElt, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodes = nodeEvent.SelectNodes(sElt, nsmgr);
			string []rgs = null;

			if (nodes != null)
				{
				rgs = new string[nodes.Count];
				int i = 0;

				foreach (XmlNode node in nodes)
					{
					rgs[i] = node.InnerText.Trim();
					i++;
					}
				}

			return rgs;
		}

		/* F E T C H  C A L E N D A R */
		/*----------------------------------------------------------------------------
			%%Function: FetchCalendar
			%%Qualified: yasc.MainForm.FetchCalendar
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void FetchCalendar()
		{
//			string sResources = "";
//
//			if (m_clbResources.CheckedItems.Count > 0)
//				{
//				bool fFirst = true;
//
//				foreach (string s in m_clbResources.CheckedItems)
//					{
//					if (!fFirst)
//						sResources += ",";
//					
//					fFirst = false;
//					sResources += "'" + s + "'";
//					}
//				}

			Calendar cal = new Calendar();
			XmlNode nodeResult;
			XmlNodeList nodes;
			XmlNamespaceManager nsmgr = null;

			try
				{
				nodeResult = cal.QueryCalendar("", "", "", "", "", "", m_sResources);
				nsmgr = new XmlNamespaceManager(nodeResult.OwnerDocument.NameTable);

				nsmgr.AddNamespace("c", "http://www.thetasoft.com/schemas/calendar");

				nodes = nodeResult.SelectNodes("c:calEvent", nsmgr);
				}
			catch
				{
				nodeResult = null;
				nodes = null;
				nsmgr = null;
				}


			if (nodes != null && nodes.Count > 0)
				{
				m_cal = new Cal();

				foreach (XmlNode node in nodes)
					{
					string sEventID = SFetchFromEventNode(node, "c:eventID", nsmgr);
					string sName = SFetchFromEventNode(node, "c:name", nsmgr);
					string sStart = SFetchFromEventNode(node, "c:eventStart", nsmgr);
					string sEnd = SFetchFromEventNode(node, "c:eventEnd", nsmgr);
					string sOwner = SFetchFromEventNode(node, "c:owner", nsmgr);
					int nPrivateLevel = Int32.Parse(SFetchFromEventNode(node, "c:privateLevel", nsmgr));
					string sDescription = SFetchFromEventNode(node, "c:description", nsmgr);

					string []rgs = RgsFetchFromEventNode(node, "c:resources/c:resource", nsmgr);

					DateTime dttmStart = DateTime.Parse(sStart).ToLocalTime();
					DateTime dttmEnd = DateTime.Parse(sEnd).ToLocalTime();

					m_cal.AddItem(new CalItem(sEventID, sName, sDescription, m_cal.RgcrEnsure(rgs), dttmStart, dttmEnd, nPrivateLevel, sOwner));
					}
				}

			RedrawCalendarBox(m_pbCalendar, m_pbCalendar.CreateGraphics());
		}


		private void HandleRefresh(object sender, System.EventArgs e)
		{
			FetchCalendar();
//			m_cal = new Cal(true);
//			RedrawCalendarBox(m_pbCalendar, m_pbCalendar.CreateGraphics());
//			m_cal = new Cal();
//			Calendar cal = new Calendar();
//			XmlNode dom;
//			XmlDocument domQuery = new XmlDocument();

//			domQuery.LoadXml("<calQuery xmlns='http://www.thetasoft.com/schemas/calendar'/>");

//
//			dom = cal.QueryCalendar("", "", "", "", "", "", new string[] { "rlittle", "tonyah" });
//			PopulateResourceList();
		}

		/* H A N D L E  N E W  C L I C K */
		/*----------------------------------------------------------------------------
			%%Function: HandleNewClick
			%%Qualified: yasc.MainForm.HandleNewClick
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void HandleNewClick(object sender, System.EventArgs e)
		{
			if (m_frmNew == null)
				m_frmNew = new FrmNewItem(this, m_cal);

			m_frmNew.ShowDialog();
			m_frmNew = null;
			RedrawCalendarBox(m_pbCalendar, m_pbCalendar.CreateGraphics());
		}

		/* H A N D L E  F I L T E R  C L I C K */
		/*----------------------------------------------------------------------------
			%%Function: HandleFilterClick
			%%Qualified: yasc.MainForm.HandleFilterClick
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void HandleFilterClick(object sender, System.EventArgs e)
		{
			if (m_frmFilter == null)
				m_frmFilter = new FrmFilter(this);

			m_frmFilter.SetResources(m_sResources);
			m_frmFilter.ShowDialog();
			m_frmFilter = null;
			FetchCalendar();
			RedrawCalendarBox(m_pbCalendar, m_pbCalendar.CreateGraphics());
		}

		/* H O V E R  C A L */
		/*----------------------------------------------------------------------------
			%%Function: HoverCal
			%%Qualified: yasc.MainForm.HoverCal
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void HoverCal(object sender, System.EventArgs e)
		{
			PictureBox pb = (PictureBox)sender;

			if (m_htItems != null)
				{
				Point ptRaw = Cursor.Position;
				Point pt = pb.PointToClient(ptRaw);
				Rectangle rectHit;

				CalItem ciHover = (CalItem) m_htItems.DoContentHit(pt, out rectHit);

				if (ciHover != null)
					{
					if (m_ch == null)
						m_ch = new Hover();

					m_ch.ShowTip(ptRaw, ciHover);

					this.Focus();
					m_fTipShowing = true;
					m_rectTipHitRegion = rectHit;
					}
				}
		}

		/* S H O W  C A L  I T E M  I N S P E C T O R */
		/*----------------------------------------------------------------------------
			%%Function: ShowCalItemInspector
			%%Qualified: yasc.MainForm.ShowCalItemInspector
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void ShowCalItemInspector(DateTime dt, Point ptRaw)
		{
			if (m_cii == null)
				{
				m_cii = new CalItemInspector();
				m_cii.SetPrefs(new Font("Tahoma", 8), new Font("Tahoma", 8), new SolidBrush(Color.Black));
				}

			m_cii.ClearItems();

			// get all the items for this day
			m_cal.SetCalItem(dt);

			CalItem ci;
			DateTime dtEnd = DtLastForDt(dt);

			ci = m_cal.GetCurItem(dtEnd);
			while (ci != null)
				{
				m_cii.AddItem(ci);
				ci = m_cal.NextItem(dtEnd);
				}
			m_cii.SetTitle(dt.ToString("D"));
			m_cii.SetLocation(ptRaw);
			m_cii.ShowDialog();
		}

		/* P A I N T  B O X  D O U B L E  C L I C K */
		/*----------------------------------------------------------------------------
			%%Function: PaintBoxDoubleClick
			%%Qualified: yasc.MainForm.PaintBoxDoubleClick
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void PaintBoxDoubleClick(object sender, System.EventArgs e)
		{
			PictureBox pb = (PictureBox)sender;

			if (m_htDays != null)
				{
				Point ptRaw = Cursor.Position;
				Point pt = pb.PointToClient(ptRaw);
				Rectangle rectHit;

				object oHit = m_htDays.DoContentHit(pt, out rectHit);
				if (oHit != null)
					{
					DateTime dt = (DateTime) oHit;

					ShowCalItemInspector(dt, ptRaw);
					}
				}
		
		}

		/* H A N D L E  M O U S E */
		/*----------------------------------------------------------------------------
			%%Function: HandleMouse
			%%Qualified: yasc.MainForm.HandleMouse
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void HandleMouse(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (m_fTipShowing == false)
				return;

			if (m_rectTipHitRegion.Contains(new Point(e.X, e.Y)))
				return;

			m_fTipShowing = false;
			m_ch.Hide();
		}

		private void DoDateHitTest(Point pt, out bool fHit, out DateTime dtHit, out Rectangle rectDateHit)
		{
			dtHit = new DateTime();
			rectDateHit = Rectangle.Empty;
			fHit = false;
			Rectangle rectHit = Rectangle.Empty;
			object oHit = null;

			// do a hit test and see where we are
			if (m_htDays != null)
				{
				oHit = m_htDays.DoContentHit(pt, out rectHit);

				if (oHit != null)
					{
					fHit = true;
					dtHit = (DateTime) oHit;
					rectDateHit = rectHit;
					}
				}
		}

		/* H A N D L E  M O U S E  D O W N */
		/*----------------------------------------------------------------------------
			%%Function: HandleMouseDown
			%%Qualified: yasc.MainForm.HandleMouseDown
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void HandleMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Control ctl = (Control) sender;
			Point pt = new Point(e.X, e.Y);
			Point ptRaw = ctl.PointToScreen(pt);
			DateTime dtHit = new DateTime();
			Rectangle rectDateHit = Rectangle.Empty;
			bool fDateHit = false;
			Rectangle rectHit = Rectangle.Empty;

			CalItem ciHit = null;
			Rectangle rectCiHit = Rectangle.Empty;

			DoDateHitTest(pt, out fDateHit, out dtHit, out rectDateHit);

			if (m_htItems != null)
				{
				ciHit = (CalItem) m_htItems.DoContentHit(pt, out rectHit);

				if (ciHit != null)
					{
					rectCiHit = rectHit;
					}
				}

			if (e.Button == MouseButtons.Right)
				{

				// we're going to invoke the context menu -- enable/disable items
				// as appropriate
				m_cxts.ptRaw = ptRaw;
				m_cxtmiZoomDay.Enabled = false;
				if (fDateHit)
					{
					// check for a day-hit
					m_cxts.dtHit = (DateTime) dtHit;
					m_cxts.rectHitRegionDay = rectDateHit;
					m_cxtmiZoomDay.Enabled = true;
					}

				m_cxtmiEdit.Enabled = m_cxtmiDelete.Enabled = m_cxtmiCreateBased.Enabled = false;
				if (ciHit != null)
					{
					m_cxts.ciHit = ciHit;
					m_cxts.rectHitRegionItem = rectCiHit;
					m_cxtmiEdit.Enabled = m_cxtmiDelete.Enabled = m_cxtmiCreateBased.Enabled = true;
					}
				}
			else if (e.Button == MouseButtons.Left)
				{
				if (ciHit != null)
					{
					m_pbCalendar.DoDragDrop(ciHit, DragDropEffects.Copy | DragDropEffects.Move);
					}
				}
		}


		/* H A N D L E  M O N T H  C H A N G E */
		/*----------------------------------------------------------------------------
			%%Function: HandleMonthChange
			%%Qualified: yasc.MainForm.HandleMonthChange
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void HandleMonthChange(object sender, System.EventArgs e)
		{
			if (!m_fInhibitMonthChange)
				{
				PictureBox pb = m_pbCalendar;
			
				RedrawCalendarBox(pb, pb.CreateGraphics());
				}
		}

		/* I N V O K E  E D I T  I T E M */
		/*----------------------------------------------------------------------------
			%%Function: InvokeEditItem
			%%Qualified: yasc.MainForm.InvokeEditItem
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void InvokeEditItem(object sender, System.EventArgs e)
		{
			if (m_cxts.ciHit != null)
				{
				if (m_frmNew == null)
					m_frmNew = new FrmNewItem(this, m_cal);
			
				m_frmNew.SetCalItemForEdit(m_cxts.ciHit, false/*fEditOnly*/);
				m_frmNew.ShowDialog();
				m_frmNew = null;
				RedrawCalendarBox(m_pbCalendar, m_pbCalendar.CreateGraphics());
				}
		}

		/* I N V O K E  D E L E T E  I T E M */
		/*----------------------------------------------------------------------------
			%%Function: InvokeDeleteItem
			%%Qualified: yasc.MainForm.InvokeDeleteItem
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void InvokeDeleteItem(object sender, System.EventArgs e)
		{
			if (m_cxts.ciHit != null)
				{
				if (MessageBox.Show("Are you sure you want to delete '" + 
								    m_cxts.ciHit.GetTitle() + "'?", "Yet Another Shared Calendar", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
					string sID = m_cxts.ciHit.GetID();

					if (sID != null && sID.Length > 0)
						{
						string sReason;
						Calendar cal = new Calendar();

						if (!FParseCalendarResult(cal.DeleteCalendarEvent(sID), out sReason))
							MessageBox.Show("Server edit failed: " + sReason);
						else
							{
							m_cal.RemoveItem(m_cxts.ciHit);
							m_cxts.ciHit = null;
							RedrawCalendarBox(m_pbCalendar, m_pbCalendar.CreateGraphics());
							}
						}
					}
				}
		}


		/* I N V O K E  Z O O M  D A Y */
		/*----------------------------------------------------------------------------
			%%Function: InvokeZoomDay
			%%Qualified: yasc.MainForm.InvokeZoomDay
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void InvokeZoomDay(object sender, System.EventArgs e)
		{
			ShowCalItemInspector(m_cxts.dtHit, m_cxts.ptRaw);
		}

		/* H A N D L E  N E X T  M O N T H  C L I C K */
		/*----------------------------------------------------------------------------
			%%Function: HandleNextMonthClick
			%%Qualified: yasc.MainForm.HandleNextMonthClick
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void HandleNextMonthClick(object sender, System.EventArgs e)
		{
			if (m_cbMonth.SelectedIndex == 11)
				{
				int nYear = Int32.Parse(m_ebYear.Text);

				nYear++;
				m_ebYear.Text = nYear.ToString();
				m_cbMonth.SelectedIndex = 0;
				}
			else
				{
				m_cbMonth.SelectedIndex++;
				}

		}

		/* H A N D L E  P R E V  M O N T H  C L I C K */
		/*----------------------------------------------------------------------------
			%%Function: HandlePrevMonthClick
			%%Qualified: yasc.MainForm.HandlePrevMonthClick
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void HandlePrevMonthClick(object sender, System.EventArgs e)
		{
			if (m_cbMonth.SelectedIndex == 0)
				{
				int nYear = Int32.Parse(m_ebYear.Text);

				nYear--;
				m_ebYear.Text = nYear.ToString();
				m_cbMonth.SelectedIndex = 11;
				}
			else
				{
				m_cbMonth.SelectedIndex--;
				}
		
		}

		/* F  P A R S E  C A L E N D A R  R E S U L T */
		/*----------------------------------------------------------------------------
			%%Function: FParseCalendarResult
			%%Qualified: yasc.MainForm.FParseCalendarResult
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public bool FParseCalendarResult(XmlNode node, out string sReason)
		{
			string sEventID;

			return FParseCalendarResult(node, out sReason, out sEventID);
		}

		/* I N V O K E  C R E A T E  I T E M */
		/*----------------------------------------------------------------------------
			%%Function: InvokeCreateItem
			%%Qualified: yasc.MainForm.InvokeCreateItem
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void InvokeCreateItem(object sender, System.EventArgs e)
		{
			if (m_frmNew == null)
				m_frmNew = new FrmNewItem(this, m_cal);

			m_frmNew.SetDates(m_cxts.dtHit);
			m_frmNew.ShowDialog();
			m_frmNew = null;
			RedrawCalendarBox(m_pbCalendar, m_pbCalendar.CreateGraphics());
		
		}

		/* F  P A R S E  C A L E N D A R  R E S U L T */
		/*----------------------------------------------------------------------------
			%%Function: FParseCalendarResult
			%%Qualified: yasc.MainForm.FParseCalendarResult
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public bool FParseCalendarResult(XmlNode node, out string sReason, out string sEventID)
		{
			XmlNamespaceManager nsmgr = null;
			sReason = sEventID = null;

			try
				{
				nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);

				nsmgr.AddNamespace("c", "http://www.thetasoft.com/schemas/calendar");
				}
			catch
				{
				return false;
				}
			
			if (node.Name != "response")
				return false;

			string sType = node.Attributes.GetNamedItem("type").Value;

			if (sType != "success")
				return false;

			try
				{
				sEventID = node.Attributes.GetNamedItem("eventID").Value;
				}
			catch
				{
				sEventID = null;
				}

			if (sEventID != null)
				sEventID = String.Copy(sEventID);

			sReason = node.InnerText;

			return true;
		}

		/* S E T  R E S O U R C E S */
		/*----------------------------------------------------------------------------
			%%Function: SetResources
			%%Qualified: yasc.MainForm.SetResources
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		public void SetResources(string sResources)
		{
			m_sResources = sResources;
		}

		/* I N V O K E  C R E A T E  C O P Y */
		/*----------------------------------------------------------------------------
			%%Function: InvokeCreateCopy
			%%Qualified: yasc.MainForm.InvokeCreateCopy
			%%Contact: rlittle

		----------------------------------------------------------------------------*/
		private void InvokeCreateCopy(object sender, System.EventArgs e)
		{
			if (m_cxts.ciHit != null)
				{
				if (m_frmNew == null)
					m_frmNew = new FrmNewItem(this, m_cal);
				
				m_frmNew.SetCalItemForEdit(m_cxts.ciHit, true/*fCopyOnly*/);
				m_frmNew.ShowDialog();
				m_frmNew = null;
				RedrawCalendarBox(m_pbCalendar, m_pbCalendar.CreateGraphics());
				}
		}

		private void Test(object sender, System.Windows.Forms.QueryContinueDragEventArgs e)
		{   
//			MessageBox.Show("Continue drag?");
		}

		private void Test2(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
//			e.Effect = DragDropEffects.Copy | DragDropEffects.Move;
		    
//			MessageBox.Show("Feedback drag?");
	
		}

		private void Test3(object sender, System.EventArgs e)
		{
//			MessageBox.Show("DragLeave drag?");

		}

		private void Test4(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy | DragDropEffects.Move;
//					MessageBox.Show("DragOver drag?");
		}

		private void HandleCalendarDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			Control ctl = (Control) sender;

			if (e.Data.GetDataPresent(typeof(CalItem)))
				{
				CalItem ci = (CalItem) e.Data.GetData(typeof(CalItem));
				CalItem ciNew = ci.Clone(true/*fGenerateID*/);
				bool fHit;
				DateTime dtHit;
				Rectangle rectHit;

				DoDateHitTest(ctl.PointToClient(new Point(e.X, e.Y)), out fHit, out dtHit, out rectHit);

				if (fHit)
					{
					DateTime dtNewStart = DateTime.Parse(dtHit.ToString("d") + " " + ci.GetStart().ToString("T"));
					TimeSpan ts = dtNewStart.Subtract(ci.GetStart());

					int nDays = ts.Days;

					DateTime dtNewEnd = ci.GetEnd().AddDays(nDays);

					ciNew.SetStart(dtNewStart);
					ciNew.SetEnd(dtNewEnd);

					if (m_frmNew == null)
						m_frmNew = new FrmNewItem(this, m_cal);

					m_frmNew.SetCalItemForEdit(ciNew, true/*fCopyOnly*/);
					m_frmNew.ShowDialog();
					m_frmNew = null;
					RedrawCalendarBox(m_pbCalendar, m_pbCalendar.CreateGraphics());
					}
				}
		}

	}

}
