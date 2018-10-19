using System;

namespace CalendarItems
{
	public class Event : CalendarItem
	{
		private string eventID;

		public string EventID
		{
			get { return eventID; }
			set
			{
				if (value != null)
					eventID = value;
			}
		}

		private string endTime;
		public string EndTime
		{
			get { return endTime; }
			set
			{
				if (value != null)
					endTime = value;
			}
		}

		public DateTime Date { get; set; }

		public static int NumberOfInstances { get; set; }

		public Event(string eventID, string startTime, string endTime, string description, DateTime date) : base(
			startTime, description)
		{
			if (eventID == null || endTime == null)
				throw new ArgumentNullException();
			
			if (!DateTime.TryParse(endTime, out DateTime result))
				throw new ArgumentException("End time invalid.");

			EventID = eventID;
			EndTime = endTime;
			Date = date;

			NumberOfInstances++;
		}

		public override string GetSummaryInformation()
		{
			return $@"Event ID: {EventID}
Schedule: {StartTime} - {EndTime}, {Date}";
		}
	}
}
