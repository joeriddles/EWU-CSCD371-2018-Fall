namespace Schedule
{
	public interface IEvent
	{
		string Description { get; set; }
		string StartTime { get; set; }
		string GetSummaryInformation();
	}
}