using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Schedule.Tests
{
	[TestClass]
	public class ExtensionTests
	{
		[TestMethod]
		public void AutoGenerateOneHourEvent_FromNoon_Success()
		{
			var evnt = new Event("ID", "1:00 AM", "3:00 PM", "description", new DateTime(2018, 11, 1));
			string oneHourAfterStart = evnt.AutoGenerateOneHourEvent();
			evnt.EndTime = oneHourAfterStart;
			Assert.AreEqual("2:00 AM", evnt.EndTime);
		}
	}
}
