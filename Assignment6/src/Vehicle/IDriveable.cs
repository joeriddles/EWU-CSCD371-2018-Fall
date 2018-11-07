namespace Vehicle
{
	public interface IDriveable
	{
		bool Driving { get; set; }
		string Drive();
	}
}
