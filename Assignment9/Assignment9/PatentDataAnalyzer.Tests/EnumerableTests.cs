using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatentData;

namespace PatentDataAnalyzer.Tests
{
	[TestClass]
	public class EnumerableTests
	{
		// Note: test may fail due to implementation of randomization algorithm.
		// This algorithm's random order of the list may end up being the original order.

		[TestMethod]
		public void Randomize_ListOfInts_IsRandomized()
		{
			// for loop to test randomization multiple times
			for (int i = 0; i < 5; i++)
			{
				List<int> intList = new List<int>{1, 2, 3};
				List<int> ranList = intList.Randomize().ToList();
				Assert.IsTrue(intList[0] != ranList[0] || intList[1] != ranList[1] || intList[2] != ranList[2]);
			}
		}

		[TestMethod]
		public void Randomize_ListOfStrings_IsRandomized()
		{
			for (int i = 0; i < 5; i++)
			{
				List<string> strList = new List<string> { "Fred", "Ted", "Alfred" };
				List<string> ranList = strList.Randomize().ToList();
				Assert.IsTrue(!strList[0].Equals(ranList[0]) || !strList[1].Equals(ranList[1]) || !strList[2].Equals(ranList[2]));
			}
		}
	}
}
