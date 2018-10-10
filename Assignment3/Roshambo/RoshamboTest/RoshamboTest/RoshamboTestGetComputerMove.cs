using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RoshamboTest
{
	[TestClass]
	public class RoshamboTestGetComputerMove
	{
		[TestMethod]
		public void TestGetComputerMoves()
		{
			Roshambo.Roshambo.RoshamboMove[] roshamboMoves = new[] {Roshambo.Roshambo.RoshamboMove.paper, Roshambo.Roshambo.RoshamboMove.rock , Roshambo.Roshambo.RoshamboMove.scissors };

			for (int i = 0; i < 100; i++)
				Assert.IsTrue(roshamboMoves.Contains(Roshambo.Roshambo.GetComputerMove()));
		}
	}
}