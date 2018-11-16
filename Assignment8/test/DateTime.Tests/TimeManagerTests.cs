using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateTime.Tests
{
	[TestClass]
	public class TimeManagerTests
	{
		public class DateTimeTest : IDateTime
		{
			public string Now()
			{
				return "12:00:00 PM";
			}
		}

		[TestMethod]
		public void TimeManager_New_Success()
		{
			IDateTime testDateTimeInterface = new DateTimeTest();
			TimeManager manager = new TimeManager(testDateTimeInterface);
			Assert.IsNotNull(manager);
			Assert.AreEqual(typeof(DateTimeTest).ToString(), manager.DateTime.ToString());
		}

		[TestMethod]
		public void TimeManger_StartTimer_Succeed()
		{
			IDateTime testDateTimeInterface = new DateTimeTest();
			TimeManager manager = new TimeManager(testDateTimeInterface);
			string timerResponse = manager.StartTimer();
			Assert.AreEqual("12:00:00 PM", timerResponse);
			Assert.IsTrue(manager.Running);
		}

		[TestMethod]
		public void TimeManger_EndTimer_Succeed()
		{
			IDateTime testDateTimeInterface = new DateTimeTest();
			TimeManager manager = new TimeManager(testDateTimeInterface);
			manager.StartTimer();
			string timerResponse = manager.EndTimer();
			Assert.AreEqual("12:00:00 PM", timerResponse);
			Assert.IsFalse(manager.Running);
		}

		[TestMethod]
		public void TimeManger_StopTimerBeforeStarting_ErrorResponseMessage()
		{
			IDateTime testDateTimeInterface = new DateTimeTest();
			TimeManager manager = new TimeManager(testDateTimeInterface);
			string timerResponse = manager.EndTimer();
			Assert.AreEqual("CANNOT STOP TIMER THAT IS ALREADY STOPPED", timerResponse);
			Assert.IsFalse(manager.Running);
		}
	}
}
