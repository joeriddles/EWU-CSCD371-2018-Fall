using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarItems.Test
{
	[TestClass]
	public class CalendarItemTest
	{
		[TestMethod]
		public void CalendarItem_CreateCalendarItem_Succeed()
		{
			CalendarItem ci = new CalendarItem("12:00 AM", "calendar item");
			Assert.AreEqual("12:00 AM", ci.StartTime);
			Assert.AreEqual("calendar item", ci.Description);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CalendarItem_CreateCalendarItemNull_ThrowException()
		{
			CalendarItem ci = new CalendarItem(null, null);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void CalendarItem_CreateCalendarItemInvalidStartTime_ThrowsException()
		{
			CalendarItem ci = new CalendarItem("invalid", "calendar item");
		}

		[TestMethod]
		[ExpectedException(typeof(NotImplementedException))]
		public void CalendarItem_GetSummaryInformation_ThrowsException()
		{
			CalendarItem ci = new CalendarItem("12:00 AM", "calendar item");
			ci.GetSummaryInformation();
		}
	}
}
