using System;

namespace CalendarItems
{
	public class CalendarItem
	{
		private string description;
		public string Description
		{
			get { return description; }
			set
			{
				if (value != null)
					description = value;
			}
		}

		private string startTime;
		public string StartTime
		{
			get { return startTime; }
			set
			{
				if (DateTime.TryParse(value, out DateTime result))
					startTime = value;
			}
		}
		public CalendarItem(string startTime, string description)
		{
			if (startTime == null || description == null)
				throw new ArgumentNullException();

			if (!DateTime.TryParse(startTime, out DateTime result))
				throw new ArgumentException("Start time invalid");

			StartTime = startTime;
			Description = description;
		}

		public void Deconstruct(out string startTime, out string description)
		{
			startTime = StartTime;
			description = Description;
		}

		public virtual string GetSummaryInformation()
		{
			throw new NotImplementedException();
		}

		public enum Days
		{
			Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		}
	}
}
