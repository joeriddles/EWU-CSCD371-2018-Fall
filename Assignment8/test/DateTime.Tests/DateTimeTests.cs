using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateTime.Tests
{
	[TestClass]
	public class DateTimeTests
	{
		[TestMethod]
		public void DateTime_NewDateTime_Success()
		{
			TimeManagerTests.DateTimeTest datetime = new TimeManagerTests.DateTimeTest();
			Assert.IsNotNull(datetime);
		}

		[TestMethod]
		public void DateTime_Now_Success()
		{
			TimeManagerTests.DateTimeTest datetime = new TimeManagerTests.DateTimeTest();
			Assert.AreEqual("12:00:00 PM", datetime.Now());
		}
	}
}
