using System;
using System.Collections.Generic;
using System.Linq;
using Schedule;

namespace EventConsole
{
	public class EventConsole : IConsole
	{
		private List<Event> Events { get; set; }
		private List<Course> Courses { get; set; }

		public EventConsole()
		{
			Events = new List<Event>();
			Courses = new List<Course>();
		}

		public static void Main(string[] args)
		{
			var console = new EventConsole();
			console.PrintWelcome();
			bool exit = false;
			while (!exit)
			{
				exit = console.GetUserInput();
			}
		}

		private void PrintWelcome()
		{
			Console.WriteLine($@"Welcome to Event Manager
Options include 'create event', 'create course', 'list events', 'list courses', and 'list all'");
		}

		private bool GetUserInput()
		{
			bool exit = false;
			Console.Write(">");
			string userInput = Console.ReadLine()?.Trim();
			switch (userInput)
			{
				case "exit":
					exit = true;
					break;
				case "create event":
					CreateEvent();
					break;
				case "create course":
					CreateCourse();
					break;
				case "list events":
					ListEvents();
					break;
				case "list courses":
					ListCourses();
					break;
				case "list all":
					ListEvents();
					ListCourses();
					break;
			}
			return exit;
		}

		public void CreateEvent()
		{
			string eventID = ReadConsole("Event ID");
			string startTime = ReadConsoleTime("Start Time");
			string endTime = ReadConsoleTime("End Time");
			string description = ReadConsole("Description");
			DateTime date = ReadConsoleDate("Date");

			Events.Add(new Event(eventID, startTime, endTime, description, date));
			Console.WriteLine($"{eventID} successfully created.");
		}

		public void CreateCourse()
		{
			string courseID = ReadConsole("Course ID");
			string startTime = ReadConsoleTime("Start Time");
			string description = ReadConsole("Description");
			List<Days> daysOfWeek = ReadConsoleDays("Days of Week");
			DateTime startDate = ReadConsoleDate("Start Date");
			DateTime endDate = ReadConsoleDate("End Date");

			Courses.Add(new Course(courseID, startTime, description, daysOfWeek, startDate, endDate));
			Console.WriteLine($"{courseID} successfully created.");
		}

		public void ListEvents()
		{
			Console.WriteLine("Events:");
			foreach (var evnt in Events)
				Console.WriteLine(evnt + Environment.NewLine);
		}

		public void ListCourses()
		{
			Console.WriteLine("Courses:");
			foreach (var course in Courses)
				Console.WriteLine(course + Environment.NewLine);
		}

		private string ReadConsole(string attribute)
		{
			string useAn = "a";
			if (new List<char> {'a', 'e', 'i', 'o', 'u'}.Contains(attribute[0]))
				useAn = "an";

			Console.Write($@"Enter {useAn} {attribute}:
>");
			string userInput = Console.ReadLine()?.Trim();

			while (userInput == null || !userInput.Any())
			{
				Console.Write($@"Please enter a valid {attribute}:
>");
				userInput = Console.ReadLine()?.Trim();
			}

			return userInput;
		}

		private string ReadConsoleTime(string attribute)
		{
			var time = ReadConsole(attribute);

			while (DateTime.TryParse(time, out _) == false)
			{
				Console.Write("Invalid time. ");
				time = ReadConsole(attribute);
			}

			return time;
		}

		private DateTime ReadConsoleDate(string attribute)
		{
			string date = ReadConsole(attribute);

			while (DateTime.TryParse(date, out _) == false)
			{
				Console.Write("Invalid date. ");
				date = ReadConsole("Date");
			}

			return DateTime.Parse(date);
		}

		private List<Days> ReadConsoleDays(string attribute)
		{
			Console.WriteLine("Enter Days of Week (M,T,W,TH,F,SAT,SUN)");
			string userInput = Console.ReadLine()?.Trim();

			string[] stringDays = userInput?.Split(",");
			if (stringDays == null)
				return new List<Days>();

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
