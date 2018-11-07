using System;
using System.Collections.Generic;
using Schedule;

namespace EventConsole.Tests
{
	class TestConsole : IConsole
	{
		public List<Event> Events { get; set; }
		public List<Course> Courses { get; set; }

		public TestConsole()
		{
			Events = new List<Event>();
			Courses = new List<Course>();
		}

		public void CreateEvent()
		{
			string eventID = Console.ReadLine()?.Trim();
			string startTime = Console.ReadLine()?.Trim();
			string endTime = Console.ReadLine()?.Trim();
			string description = Console.ReadLine()?.Trim();
			DateTime date = DateTime.Parse(Console.ReadLine());
			Events.Add(new Event(eventID, startTime, endTime, description, date));
		}

		public void CreateCourse()
		{
			string courseID = Console.ReadLine()?.Trim();
			string startTime = Console.ReadLine()?.Trim();
			string description = Console.ReadLine()?.Trim();
			DateTime startDate = DateTime.Parse(Console.ReadLine());
			DateTime endDate = DateTime.Parse(Console.ReadLine());
			var daysOfWeek = ReadConsoleDays();
			Courses.Add(new Course(courseID, startTime, description, daysOfWeek, startDate, endDate));
		}

		public void ListEvents()
		{
			foreach (var evnt in Events)
				Console.WriteLine(evnt.EventID);
		}

		public void ListCourses()
		{
			foreach (var course in Courses)
				Console.WriteLine(course.CourseID);
		}

		private List<Days> ReadConsoleDays()
		{
			string userInput = Console.ReadLine()?.Trim();

			string[] stringDays = userInput?.Split(",");
			var days = new List<Days>();
			foreach (var str in stringDays)
			{
				string lower = str.ToLower();
				switch (lower)
				{
					case "m":
						days.Add(Days.Monday);
						break;
					case "t":
						days.Add(Days.Tuesday);
						break;
					case "w":
						days.Add(Days.Wednesday);
						break;
					case "th":
						days.Add(Days.Thursday);
						break;
					case "f":
						days.Add(Days.Friday);
						break;
					case "sat":
						days.Add(Days.Saturday);
						break;
					case "sun":
						days.Add(Days.Sunday);
						break;
				}
			}
			return days;
		}
	}
}
