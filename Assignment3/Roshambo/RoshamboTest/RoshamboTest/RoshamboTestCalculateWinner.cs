using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoshamboTest
{
	[TestClass]
	public class RoshamboTestCalculateWinner
	{
		[TestMethod]
		public void TestPlayerRockComputerRock()
		{
			Assert.AreEqual((winner: 0, damage: 0), Roshambo.Roshambo.CalculateWinner(Roshambo.Roshambo.RoshamboMove.rock, Roshambo.Roshambo.RoshamboMove.rock));
		}

		[TestMethod]
		public void TestPlayerRockComputerPaper()
		{
			Assert.AreEqual((winner: 1, damage: Roshambo.Roshambo.paperDamage), Roshambo.Roshambo.CalculateWinner(Roshambo.Roshambo.RoshamboMove.rock, Roshambo.Roshambo.RoshamboMove.paper));
		}

		[TestMethod]
		public void TestPlayerRockComputerScissors()
		{
			Assert.AreEqual((winner: -1, damage: Roshambo.Roshambo.rockDamage), Roshambo.Roshambo.CalculateWinner(Roshambo.Roshambo.RoshamboMove.rock, Roshambo.Roshambo.RoshamboMove.scissors));
		}

		[TestMethod]
		public void TestPlayerPaperComputerRock()
		{
			Assert.AreEqual((winner: -1, damage: Roshambo.Roshambo.paperDamage), Roshambo.Roshambo.CalculateWinner(Roshambo.Roshambo.RoshamboMove.paper, Roshambo.Roshambo.RoshamboMove.rock));
		}

		[TestMethod]
		public void TestPlayerPaperComputerPaper()
		{
			Assert.AreEqual((winner: 0, damage: 0), Roshambo.Roshambo.CalculateWinner(Roshambo.Roshambo.RoshamboMove.paper, Roshambo.Roshambo.RoshamboMove.paper));
		}

		[TestMethod]
		public void TestPlayerPaperComputerScissors()
		{
			Assert.AreEqual((winner: 1, damage: Roshambo.Roshambo.scissorsDamage), Roshambo.Roshambo.CalculateWinner(Roshambo.Roshambo.RoshamboMove.paper, Roshambo.Roshambo.RoshamboMove.scissors));
		}

		[TestMethod]
		public void TestPlayerScissorsComputerRock()
		{
			Assert.AreEqual((winner: 1, damage: Roshambo.Roshambo.rockDamage), Roshambo.Roshambo.CalculateWinner(Roshambo.Roshambo.RoshamboMove.scissors, Roshambo.Roshambo.RoshamboMove.rock));
		}

		[TestMethod]
		public void TestPlayerScissorsComputerPaper()
		{
			Assert.AreEqual((winner: -1, damage: Roshambo.Roshambo.scissorsDamage), Roshambo.Roshambo.CalculateWinner(Roshambo.Roshambo.RoshamboMove.scissors, Roshambo.Roshambo.RoshamboMove.paper));
		}

		[TestMethod]
		public void TestPlayerScissorsComputerScissors()
		{
			Assert.AreEqual((winner: 0, damage: 0), Roshambo.Roshambo.CalculateWinner(Roshambo.Roshambo.RoshamboMove.scissors, Roshambo.Roshambo.RoshamboMove.scissors));
		}
	}
}
