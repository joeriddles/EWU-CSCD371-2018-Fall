using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace CalendarItems
{
	public class Course : CalendarItem
	{
		private readonly string college = "EWU";
		public string College => college;

		private string courseID;
		public string CourseID
		{
			get { return courseID; }
			set
			{
				if (value != null && courseIdRegex.IsMatch(value))
					courseID = value;
			}
		}

		private List<Days> daysOfWeek;
		public List<Days> DaysOfWeek
		{
			get { return daysOfWeek;}
			set
			{
				if (value.Any())
					daysOfWeek = value;
			}
		}

		private string endTime;
		public string EndTime
		{
			get { return endTime;}
			set
			{
				if (DateTime.TryParse(value, out DateTime result))
					endTime = value;
			}
		}

		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		private TimeSpan timeSpan;
		public TimeSpan TimeSpan {
			get { return timeSpan; }
			set { timeSpan = EndDate - StartDate; }
		} 

		private readonly Regex courseIdRegex = new Regex("^[a-zA-Z]{4}[0-9]{3}$");
		public Regex CourseIdRegex => courseIdRegex;

		public static int NumberOfInstances { get; set; }

		public Course(string courseID, string startTime, string description, List<Days> daysOfWeek, DateTime startDate, DateTime endDate) : base(startTime, description)
		{
			if (courseID == null || startTime == null || description == null || daysOfWeek == null)
				throw new ArgumentNullException();

			if (!courseIdRegex.IsMatch(courseID))
				throw new ArgumentException("Course ID invalid.");

			if (!DateTime.TryParse(startTime, out DateTime result))
				throw new ArgumentException("Start Time invalid.");

			if (!daysOfWeek.Any())
				throw new ArgumentException("Days of week invalid.");

			if (DateTime.Compare(startDate, endDate) > 0)
				throw new ArgumentException("Start date is after end Date");

			CourseID = courseID;
			DaysOfWeek = daysOfWeek;
			StartDate = startDate;
			EndDate = endDate;

			NumberOfInstances++;
		}

		public override string GetSummaryInformation()
		{
			return $@"Course ID: {CourseID}
Schedule: {StartTime} - {EndTime} {string.Join(", ", DaysOfWeek)}
Dates: {StartDate.ToShortDateString()} - {EndDate.ToShortDateString()}";
		}
	}
}
