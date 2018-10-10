using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoshamboTest
{
	[TestClass]
	public class RoshamboTestGetPlayerMove
	{
		[TestMethod]
		public void TestPlayerMoveRock()
		{
			Assert.AreEqual(Roshambo.Roshambo.RoshamboMove.rock, Roshambo.Roshambo.GetPlayerMove("rock"));
		}

		[TestMethod]
		public void TestPlayerMovePaper()
		{
			Assert.AreEqual(Roshambo.Roshambo.RoshamboMove.paper, Roshambo.Roshambo.GetPlayerMove("paper"));
		}

		[TestMethod]
		public void TestPlayerMoveScissors()
		{
			Assert.AreEqual(Roshambo.Roshambo.RoshamboMove.scissors, Roshambo.Roshambo.GetPlayerMove("scissors"));
		}
	}
}
