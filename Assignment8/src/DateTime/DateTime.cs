namespace DateTime
{
	public class DateTime : IDateTime
	{
		public string Now()
		{
			return System.DateTime.Now.ToLongTimeString();
		}
	}
}
