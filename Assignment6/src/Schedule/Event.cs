using System;

namespace Schedule
{
	public class Event : IEvent
	{
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
				if (DateTime.TryParse(value, out DateTime _))
					_startTime = value;
			}
		}

		private string _eventId;

		public string EventID
		{
			get => _eventId;
			set
			{
				if (value != null)
					_eventId = value;
			}
		}

		private string _endTime;
		public string EndTime
		{
			get => _endTime;
			set
			{
				if (value != null)
					_endTime = value;
			}
		}

		public DateTime Date { get; set; }

		public static int NumberOfInstances { get; set; }

		public Event(string eventID, string startTime, string endTime, string description, DateTime date)
		{
			if (eventID == null || startTime == null || endTime == null || description == null)
				throw new ArgumentNullException();

			if (!DateTime.TryParse(startTime, out _))
				throw new ArgumentException("Start time invalid.");

			if (!DateTime.TryParse(endTime, out _))
				throw new ArgumentException("End time invalid.");

			EventID = eventID;
			StartTime = startTime;
			EndTime = endTime;
			Description = description;
			Date = date;

			NumberOfInstances++;
		}

		public string GetSummaryInformation()
		{
			return $@"Event ID: {EventID}
{Description}
{StartTime} - {EndTime} on {Date}";
		}

		public override string ToString()
		{
			return GetSummaryInformation();
		}
	}
}