namespace DateTime
{
	public class TimeManager
	{
		public bool Running { get; private set; }
		public IDateTime DateTime { get; }

		public TimeManager(IDateTime dateTimeInterface)
		{
			DateTime = dateTimeInterface;
		}

		public string StartTimer()
		{
			Running = true;
			return DateTime.Now();
		}

		public string EndTimer()
		{
			if (!Running)
				return "CANNOT STOP TIMER THAT IS ALREADY STOPPED";
			Running = false;
			return DateTime.Now();
		}
	}
}
