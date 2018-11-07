namespace Schedule
{
	public static class EventExtensions
	{
		public static Days ParseDaysFromString(this string daysString)
		{
			Days days = Days.None;

			if (daysString.Contains("Monday"))
				days |= Days.Monday;
			if (daysString.Contains("Tuesday"))
				days |= Days.Tuesday;
			if (daysString.Contains("Wednesday"))
				days |= Days.Wednesday;
			if (daysString.Contains("Thursday"))
				days |= Days.Thursday;
			if (daysString.Contains("Friday"))
				days |= Days.Friday;
			if (daysString.Contains("Saturday"))
				days |= Days.Saturday;
			if (daysString.Contains("Sunday"))
				days |= Days.Sunday;

			return days;
		}

		public static Quarters ParseQuartersFromString(this string quartersString)
		{
			Quarters quarters = Quarters.None;

			if (quartersString.Contains("Spring"))
				quarters |= Quarters.Spring;
			if (quartersString.Contains("Summer"))
				quarters |= Quarters.Summer;
			if (quartersString.Contains("Fall"))
				quarters |= Quarters.Fall;
			if (quartersString.Contains("Winter"))
				quarters |= Quarters.Winter;

			return quarters;
		}
	}
}
