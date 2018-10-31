using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntelliTect.TestTools.Console;
using Microsoft.Extensions.DependencyModel.Resolution;
using Schedule;

namespace EventConsole.Tests
{
	[TestClass]
	public class EventConsoleTest
	{
		[TestMethod]
		public void TestConsole_CreateConsole_Succeed()
		{
			Assert.IsNotNull(new TestConsole());
		}

		[TestMethod]
		public void TestConsole_CreateEvent_Succeed()
		{
			var console = new TestConsole();
			ConsoleAssert.Expect($@"<<ID
<<1:00 AM
<<2:00 AM
<<description
<<11/1/2018", console.CreateEvent);
			Assert.AreEqual(1, console.Events.Count);
		}

		[TestMethod]
		public void TestConsole_CreateCourse_Succeed()
		{
			var console = new TestConsole();
			ConsoleAssert.Expect($@"<<CSCD123
<<1:00 AM
<<description
<<11/1/2018
<<11/2/2018
<<M,T,W,SUN", console.CreateCourse);
			Assert.AreEqual(1, console.Courses.Count);
		}

		[TestMethod]
		public void TestConsole_ListCourses_Succeed()
		{
			var console = new TestConsole();
			console.Events.Add(new Event("ID", "1:00 AM", "2:00 AM", "description", new DateTime(2018,11,1)));
			ConsoleAssert.Expect("ID", console.ListEvents);
		}

		[TestMethod]
		public void TestConsole_ListEvents_Succeed()
		{
			var console = new TestConsole();
			console.Courses.Add(new Course("CSCD123", "1:00 AM", "description", new List<Days>{Days.Monday}, new DateTime(2018, 11, 1), new DateTime(2018, 11, 2)));
			ConsoleAssert.Expect("CSCD123", console.ListCourses);
		}
	}
}
