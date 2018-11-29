using System.Collections.Generic;
using System.Linq;
using Assignment9;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PatentDataAnalyzer.Tests
{
	[TestClass]
	public class PatentDataAnalyzerTests
	{
		[TestMethod]
		public void InventorNames_UK_Success()
		{
			List<string> inventorNames = Assignment9.PatentDataAnalyzer.InventorNames("UK");
			Assert.AreEqual(1, inventorNames.Count);
			Assert.AreEqual("George Stephenson", inventorNames.Single());
		}

		[TestMethod]
		public void InventoryLastNames_All_Success()
		{
			List<string> inventorLastNames = Assignment9.PatentDataAnalyzer.InventoryLastNames();
			Assert.AreEqual(7, inventorLastNames.Count);
			Assert.AreEqual("Jacob", inventorLastNames.First());
			Assert.AreEqual("Franklin", inventorLastNames.Last());
		}

		[TestMethod]
		public void LocationsWithInventors_All_Success()
		{
			var locationsWithInventors = Assignment9.PatentDataAnalyzer.LocationsWithInventors();
			Assert.AreEqual(
				"PA-USA,NC-USA,NY-USA,Northumberland-UK,IL-USA",
				locationsWithInventors
			);
		}

		[TestMethod]
		public void GetInventorsWithMultiplePatents_ThreePatents_Success()
		{
			List<Inventor> inventors = Assignment9.PatentDataAnalyzer.GetInventorsWithMultiplePatents(3);
			Assert.AreEqual(1, inventors.Count);
			Assert.AreEqual(1, inventors.Single().Id);
		}
	}
}
