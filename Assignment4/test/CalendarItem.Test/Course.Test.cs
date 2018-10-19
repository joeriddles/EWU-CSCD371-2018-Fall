using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarItems.Test
{
	[TestClass]
	public class CourseTest
	{
		private List<CalendarItem.Days> validCalendarDays = new List<CalendarItem.Days> { CalendarItem.Days.Tuesday, CalendarItem.Days.Thursday};
		private readonly string validGetSummaryInformation = $@"Course ID: CSCD371
Schedule: 2:00 PM -  Tuesday, Thursday
Dates: 9/1/2018 - 12/1/2018";

		[TestMethod]
		public void Course_CreateCourse_Success()
		{
			Course course = new Course("CSCD371", "2:00 PM", "C#", new List<CalendarItem.Days>{ CalendarItem.Days.Tuesday, CalendarItem.Days.Thursday }, new DateTime(2018, 9, 1), new DateTime(2018, 12, 1));
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
			Course course = new Course(null, null, null, null , new DateTime(1, 1, 1), new DateTime(1, 1, 1));
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
			Course course = new Course("CSCD371", "2:00 PM", "C#", new List<CalendarItem.Days>(), new DateTime(1, 1, 1), new DateTime(1, 1, 1));
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
			Course course = new Course("CSCD371", "2:00 PM", "C#", new List<CalendarItem.Days> { CalendarItem.Days.Tuesday, CalendarItem.Days.Thursday }, new DateTime(2018, 9, 1), new DateTime(2018, 12, 1));
			Assert.AreEqual(validGetSummaryInformation, course.GetSummaryInformation());
		}

		[TestMethod]
		public void Course_NumberOfInstances_Succeed()
		{
			Course.NumberOfInstances = 0;
			Course course1 = new Course("CSCD371", "2:00 PM", "C#", new List<CalendarItem.Days> { CalendarItem.Days.Tuesday, CalendarItem.Days.Thursday }, new DateTime(2018, 9, 1), new DateTime(2018, 12, 1));
			Course course2 = new Course("CSCD371", "2:00 PM", "C#", new List<CalendarItem.Days> { CalendarItem.Days.Tuesday, CalendarItem.Days.Thursday }, new DateTime(2018, 9, 1), new DateTime(2018, 12, 1));
			Course course3 = new Course("CSCD371", "2:00 PM", "C#", new List<CalendarItem.Days> { CalendarItem.Days.Tuesday, CalendarItem.Days.Thursday }, new DateTime(2018, 9, 1), new DateTime(2018, 12, 1));
			Assert.AreEqual(3, Course.NumberOfInstances);
		}
	}
}
