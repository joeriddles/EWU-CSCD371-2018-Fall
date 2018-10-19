using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarItems.Test
{
	[TestClass]
	public class EventTest
	{
		private readonly string validGetSummaryInformation = $@"Event ID: E1
Schedule: 12:00 AM - 1:00 AM, 1/1/2018 12:00:00 AM";

		[TestMethod]
		public void Event_CreateEvent_Succeed()
		{
			Event evnt = new Event("E1", "12:00 AM", "1:00 AM", "event description", new DateTime(2018, 1, 1));
			Assert.AreEqual("E1", evnt.EventID);
			Assert.AreEqual("12:00 AM", evnt.StartTime);
			Assert.AreEqual("1:00 AM", evnt.EndTime);
			Assert.AreEqual("event description", evnt.Description);
			Assert.AreEqual(new DateTime(2018, 1, 1), evnt.Date);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Event_CreateEventNull_ThrowsException()
		{
			Event evnt = new Event(null, "12:00", null, "event description", new DateTime(1, 1, 1));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Event_CreateEventInvalidDate_ThrowsException()
		{
			Event evnt = new Event("E1", "12:00", "invalid", "event description", new DateTime(1, 1, 1));
		}

		[TestMethod]
		public void Event_GetSummaryInformation_Success()
		{
			Event evnt = new Event("E1", "12:00 AM", "1:00 AM", "event description", new DateTime(2018, 1, 1));
			Assert.AreEqual(validGetSummaryInformation, evnt.GetSummaryInformation());
		}

		[TestMethod]
		public void Event_NumberOfInstances_Succeed()
		{
			Event.NumberOfInstances = 0;
			Event evnt1 = new Event("E1", "12:00 AM", "1:00 AM", "event description", new DateTime(2018, 1, 1));
			Event evnt2 = new Event("E1", "12:00 AM", "1:00 AM", "event description", new DateTime(2018, 1, 1));
			Event evnt3 = new Event("E1", "12:00 AM", "1:00 AM", "event description", new DateTime(2018, 1, 1));
			Assert.AreEqual(3, Event.NumberOfInstances);
		}
	}
}
