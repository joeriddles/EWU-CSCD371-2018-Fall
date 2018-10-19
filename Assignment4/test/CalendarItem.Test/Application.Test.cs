using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarItems.Test
{
	[TestClass]
	public class ApplicationTest
	{
		private readonly string validCourseGetSummaryInformation = $@"Course ID: CSCD371
Schedule: 2:00 PM -  Tuesday, Thursday
Dates: 9/1/2018 - 12/1/2018";

		private readonly string validEventGetSummaryInformation = $@"Event ID: E1
Schedule: 12:00 AM - 1:00 AM, 1/1/2018 12:00:00 AM";

		[TestMethod]
		[ExpectedException(typeof(NotImplementedException))]
		public void Application_DisplayCalendarItem_ThrowsException()
		{
			CalendarItem ci = new CalendarItem("12:00 AM", "calendar item");
			Application.Display(ci);
		}

		[TestMethod]
		public void Application_DisplayCourse_Succeed()
		{
			Course course = new Course("CSCD371", "2:00 PM", "C#", new List<CalendarItem.Days> { CalendarItem.Days.Tuesday, CalendarItem.Days.Thursday }, new DateTime(2018, 9, 1), new DateTime(2018, 12, 1));
			Assert.AreEqual(validCourseGetSummaryInformation, Application.Display(course));
		}

		[TestMethod]
		public void Application_DisplayEvent_Succeed()
		{
			Event evnt = new Event("E1", "12:00 AM", "1:00 AM", "event description", new DateTime(2018, 1, 1));
			Assert.AreEqual(validEventGetSummaryInformation, Application.Display(evnt));
		}

		[TestMethod]
		public void Application_DisplayObject_Succeed()
		{
			Object obj = new Object();
			Assert.AreEqual("System.Object", Application.Display(obj));
		}
	}
}
