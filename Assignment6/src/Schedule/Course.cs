using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Schedule
{
	public class Course : IEvent
	{
		public string College { get; } = "EWU";

		private string _courseID;
		public string CourseID
		{
			get => _courseID;
			set
			{
				if (value != null && _courseIdRegex.IsMatch(value))
					_courseID = value;
			}
		}

		private List<Days> _daysOfWeek;
		public List<Days> DaysOfWeek
		{
			get { return _daysOfWeek; }
			set
			{
				if (value.Any())
					_daysOfWeek = value;
			}
		}

		private string _description;
		public string Description
		{
			get => _description;
			set
			{
				if (value != null)
					_description = value;
			}
		}

		private string _startTime;
		public string StartTime
		{
			get => _startTime;
			set
			{
				if (DateTime.TryParse(value, out DateTime result))
					_startTime = value;
			}
		}

		private string _endTime;
		public string EndTime
		{
			get => _endTime;
			set
			{
				if (DateTime.TryParse(value, out DateTime result))
					_endTime = value;
			}
		}

		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		private TimeSpan _timeSpan;
		public TimeSpan TimeSpan
		{
			get => _timeSpan;
			set => _timeSpan = EndDate - StartDate;
		}

		private readonly Regex _courseIdRegex = new Regex("^[a-zA-Z]{4}[0-9]{3}$");
		public Regex CourseIdRegex => _courseIdRegex;

		public static int NumberOfInstances { get; set; }

		public Course(string courseID, string startTime, string description, List<Days> daysOfWeek, DateTime startDate, DateTime endDate)
		{
			if (courseID == null || startTime == null || description == null || daysOfWeek == null)
				throw new ArgumentNullException();

			if (!CourseIdRegex.IsMatch(courseID))
				throw new ArgumentException("Course ID invalid.");

			if (!DateTime.TryParse(startTime, out DateTime result))
				throw new ArgumentException("Start Time invalid.");

			if (!daysOfWeek.Any())
				throw new ArgumentException("Days of week invalid.");

			if (DateTime.Compare(startDate, endDate) > 0)
				throw new ArgumentException("Start date is after end Date");

			CourseID = courseID;
			StartTime = startTime;
			Description = description;
			DaysOfWeek = daysOfWeek;
			StartDate = startDate;
			EndDate = endDate;

			NumberOfInstances++;
		}

		public string GetSummaryInformation()
		{
			return $@"Course ID: {CourseID}
Schedule: {StartTime} - {string.Join(", ", DaysOfWeek)}
Dates: {StartDate.ToShortDateString()} - {EndDate.ToShortDateString()}";
		}

		public override string ToString()
		{
			return GetSummaryInformation();
		}
	}
}
