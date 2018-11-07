using System;

namespace Schedule
{
	public static class Extension
	{
		public static string AutoGenerateOneHourEvent(this IEvent iEvent)
		{
			DateTime start = DateTime.Parse(iEvent.StartTime);
			return start.AddHours(1).ToShortTimeString();
		}
	}
}