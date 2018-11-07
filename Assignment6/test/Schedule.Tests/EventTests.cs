using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Schedule.Tests
{
	[TestClass]
	public class EventTests
	{
		[TestMethod]
		public void Days_ParseDayFromString_Succeed()
		{
			string dayString = "Monday";
			Days days = dayString.ParseDaysFromString();
			Assert.AreEqual(Days.Monday, days);
		}

		[TestMethod]
		public void Days_ParseDaysFromString_Succeed()
		{
			string dayString = "Monday, Wednesday";
			Days days = dayString.ParseDaysFromString();
			Assert.AreEqual(Days.Monday | Days.Wednesday, days);
		}

		[TestMethod]
		public void Days_ParseDayFromString_Fail()
		{
			string dayString = "Not a day";
			Days days = dayString.ParseDaysFromString();
			Assert.AreEqual(Days.None, days);
		}

		[TestMethod]
		public void Quarters_ParseQuarterFromString_Succeed()
		{
			string quarterString = "Spring";
			Quarters quarters = quarterString.ParseQuartersFromString();
			Assert.AreEqual(Quarters.Spring, quarters);
		}

		[TestMethod]
		public void Quarters_ParseQuartersFromString_Succeed()
		{
			string quarterString = "Winter, Fall";
			Quarters quarters = quarterString.ParseQuartersFromString();
			Assert.AreEqual(Quarters.Winter | Quarters.Fall, quarters);
		}

		[TestMethod]
		public void Quarters_ParseQuarterFromString_Fail()
		{
			string quarterString = "Not a quarter";
			Quarters quarters = quarterString.ParseQuartersFromString();
			Assert.AreEqual(Quarters.None, quarters);
		}

		[TestMethod]
		public void Time_Marshal_SizeOf()
		{
			int size = Marshal.SizeOf<Time>();
			Assert.IsTrue(size <= 16);
		}

		[TestMethod]
		public void Schedule_Marshal_SizeOf()
		{
			int size = Marshal.SizeOf<Schedule>();
			// My size is always 32 KB, this may have to with the way I set up `Schedule`
			Assert.IsTrue(size <= 32);
		}
	}
}