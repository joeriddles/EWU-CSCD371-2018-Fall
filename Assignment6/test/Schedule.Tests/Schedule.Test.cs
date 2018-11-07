using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Schedule.Tests
{
	[TestClass]
	public class ScheduleTests
	{
		private readonly string validEventGetSummaryInformation = $@"Event ID: E1
event description
12:00 AM - 1:00 AM on 1/1/2018 12:00:00 AM";

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
			Assert.AreEqual(validEventGetSummaryInformation, evnt.GetSummaryInformation());
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

		private readonly List<Days> validCalendarDays = new List<Days> { Days.Tuesday, Days.Thursday };
		private readonly string validCourseGetSummaryInformation = $@"Course ID: CSCD371
Schedule: 2:00 PM - Tuesday, Thursday
Dates: 9/1/2018 - 12/1/2018";

		[TestMethod]
		public void Course_CreateCourse_Success()
		{
			Course course = new Course("CSCD371", "2:00 PM", "C#", new List<Days> { Days.Tuesday, Days.Thursday }, new DateTime(2018, 9, 1), new DateTime(2018, 12, 1));
			Assert.AreEqual("CSCD371", course.CourseID);
			Assert.AreEqual("2:00 PM", course.StartTime);
			Assert.AreEqual("C#", course.Description);
			Assert.AreEqual(validCalendarDays[0], course.DaysOfWeek[0]);
			Assert.AreEqual(validCalendarDays[1], course.DaysOfWeek[1]);
			Assert.AreEqual(new DateTime(2018, 9, 1), course.StartDate);
			Assert.AreEqual(new DateTime(2018, 12, 1), course.EndDate);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Course_CreateCourseNull_ThrowsException()
		{
			Course course = new Course(null, null, null, null, new DateTime(1, 1, 1), new DateTime(1, 1, 1));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Course_CreateInvalidCourseId_ThrowsException()
		{
			Course course = new Course("invalid", "2:00 PM", "C#", validCalendarDays, new DateTime(1, 1, 1), new DateTime(1, 1, 1));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Course_CreateInvalidStartTime_ThrowsException()
		{
			Course course = new Course("CSCD371", "invalid", "C#", validCalendarDays, new DateTime(1, 1, 1), new DateTime(1, 1, 1));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Course_CreateInvalidEmptyDaysOfWeek_ThrowsException()
		{
			Course course = new Course("CSCD371", "2:00 PM", "C#", new List<Days>(), new DateTime(1, 1, 1), new DateTime(1, 1, 1));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Course_CreateInvalidStartDateAfterEndDate_ThrowsException()
		{
			Course course = new Course("CSCD371", "2:00 PM", "C#", validCalendarDays, new DateTime(2018, 12, 1), new DateTime(2018, 9, 1));
		}

		[TestMethod]
		public void Course_GetSummaryInformation_Success()
		{
			Course course = new Course("CSCD371", "2:00 PM", "C#", new List<Days> { Days.Tuesday, Days.Thursday }, new DateTime(2018, 9, 1), new DateTime(2018, 12, 1));
			Assert.AreEqual(validCourseGetSummaryInformation, course.GetSummaryInformation());
		}

		[TestMethod]
		public void Course_NumberOfInstances_Succeed()
		{
			Course.NumberOfInstances = 0;
			Course course1 = new Course("CSCD371", "2:00 PM", "C#", new List<Days> { Days.Tuesday, Days.Thursday }, new DateTime(2018, 9, 1), new DateTime(2018, 12, 1));
			Course course2 = new Course("CSCD371", "2:00 PM", "C#", new List<Days> { Days.Tuesday, Days.Thursday }, new DateTime(2018, 9, 1), new DateTime(2018, 12, 1));
			Course course3 = new Course("CSCD371", "2:00 PM", "C#", new List<Days> { Days.Tuesday, Days.Thursday }, new DateTime(2018, 9, 1), new DateTime(2018, 12, 1));
			Assert.AreEqual(3, Course.NumberOfInstances);
		}
	}
}
