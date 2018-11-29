using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatentData;

namespace PatentDataAnalyzer.Tests
{
	[TestClass]
	public class PatentDataAnalyzerTests
	{
		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void InventorNames_Null_ThrowsException()
		{
			PatentData.PatentDataAnalyzer.InventorNames(null);
		}

		[TestMethod]
		[DataRow("UK", "George Stephenson")]
		public void InventorNames_UK_Success(string input, string expectedOutput)
		{
			List<string> inventorNames = PatentData.PatentDataAnalyzer.InventorNames(input);
			Assert.AreEqual(1, inventorNames.Count);
			Assert.AreEqual(expectedOutput, inventorNames.Single());
		}

		[TestMethod]
		public void InventoryLastNames_All_Success()
		{
			List<string> inventorLastNames = PatentData.PatentDataAnalyzer.InventoryLastNames();
			Assert.AreEqual(7, inventorLastNames.Count);
			Assert.AreEqual("Jacob", inventorLastNames.First());
			Assert.AreEqual("Franklin", inventorLastNames.Last());
		}

		[TestMethod]
		public void LocationsWithInventors_All_Success()
		{
			var locationsWithInventors = PatentData.PatentDataAnalyzer.LocationsWithInventors();
			Assert.AreEqual(
				"PA-USA,NC-USA,NY-USA,Northumberland-UK,IL-USA",
				locationsWithInventors
			);
		}

		[TestMethod]
		[DataRow(3, 1, 1)]
		[DataRow(2, 1, 1)]
		[DataRow(1, 7, 7)]
		public void GetInventorsWithMultiplePatents_ThreePatents_Success(int input, int expectedNumInventors, long expectedLastInventorId)
		{
			List<Inventor> inventors = PatentData.PatentDataAnalyzer.GetInventorsWithMultiplePatents(input);
			Assert.AreEqual(expectedNumInventors, inventors.Count);
			Assert.AreEqual(expectedLastInventorId, inventors.Last().Id);
		}
	}
}
