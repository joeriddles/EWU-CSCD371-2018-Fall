using System;

namespace Schedule
{
	public interface IEvent
	{
		string Description { get; set; }
		string StartTime { get; set; }
		string GetSummaryInformation();
	}

	[Flags]
	public enum Days
	{
		None = 0,
		Monday = 1,
		Tuesday = 1 << 2,
		Wednesday = 1 << 3,
		Thursday = 1 << 4,
		Friday = 1 << 5,
		Saturday = 1 << 6,
		Sunday = 1 << 7
	}

	[Flags]
	public enum Quarters
	{
		None = 0,
		Spring = 1,
		Summer = 1 << 2,
		Fall = 1 << 3,
		Winter = 1 << 4
	}

	public readonly struct Time
	{
		public int Hours { get; }
		public int Minutes { get; }
		public int Seconds { get; }
	}

	public readonly struct Schedule
	{
		public Days Day { get; }
		public Quarters Quarter { get; }
		public Time StartTime { get; }
		public TimeSpan Duration { get; }
	}
}