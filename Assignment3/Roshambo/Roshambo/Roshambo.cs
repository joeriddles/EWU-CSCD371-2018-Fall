using System;
using System.Linq;

namespace Roshambo
{
	public class Roshambo
	{
		private static void Main(string[] args)
		{
			string playAgain = "y";
			while (playAgain.Equals("y"))
			{
				LaunchGame();
				Console.WriteLine("Play again? (y/n)");
				playAgain = Console.ReadLine().Trim();
			}
		}

		public static (int playerHealth, int computerHealth) LaunchGame()
		{
			playerHealth = computerHealth = 100;

			while (playerHealth > 0 && computerHealth > 0)
			{
				RoshamboMove playerMove = GetPlayerMove();
				RoshamboMove computerMove = GetComputerMove();

				Console.WriteLine($"Computer used {computerMove}!");

				CalculateWinner(playerMove, computerMove);

				Console.WriteLine($"Player Health: {playerHealth}, Computer Health: {computerHealth}");
			}

			if (playerHealth <= 0 && computerHealth <= 0)
				Console.WriteLine($"It's a tie!");
			else if (playerHealth <= 0)
				Console.WriteLine("Computer wins!");
			else if (computerHealth <= 0)
				Console.WriteLine("Player wins!");

			return (playerHealth, computerHealth);
		}

		public static RoshamboMove GetPlayerMove(string playerMove = "")
		{
			string[] validInput = new string[] { "rock", "r", "scissors", "s", "paper", "p" };

			while (!validInput.Contains(playerMove))
			{
				Console.WriteLine("'Rock', 'Scissors', or 'Paper'?");
				playerMove = Console.ReadLine().Trim();
			}

			switch (playerMove)
			{
				case "rock":		return RoshamboMove.rock;
				case "r":		return RoshamboMove.rock;
				case "scissors":	return RoshamboMove.scissors;
				case "s":		return RoshamboMove.scissors;
				case "paper":	return RoshamboMove.paper;
				case "p":		return RoshamboMove.paper;
				default: throw new ArgumentException();
			}
		}

		public static RoshamboMove GetComputerMove()
		{
			Random rand = new Random();
			var randNum = rand.Next(0, 3);

			switch (randNum)
			{
				case 0: return RoshamboMove.rock;
				case 1: return RoshamboMove.paper;
				case 2: return RoshamboMove.scissors;
			}

			throw new ArgumentException();
		}

		public static (int winner, int damage) CalculateWinner(RoshamboMove playerMove, RoshamboMove computerMove)
		{
			switch (computerMove)
			{
				case RoshamboMove.rock:
					switch (playerMove)
					{
						case RoshamboMove.paper:
							computerHealth -= paperDamage;
							return (-1, paperDamage);
						case RoshamboMove.scissors:
							playerHealth -= rockDamage;
							return (1, rockDamage);
						default: return (0, 0);
					}
				case RoshamboMove.paper:
					switch (playerMove)
					{
						case RoshamboMove.rock:
							playerHealth -= paperDamage;
							return (1, paperDamage);
						case RoshamboMove.scissors:
							computerHealth -= scissorsDamage;
							return (-1, scissorsDamage);
						default: return (0, 0);
					}
				case RoshamboMove.scissors:
					switch (playerMove)
					{
						case RoshamboMove.rock:
							computerHealth -= rockDamage;
							return (-1, rockDamage);
						case RoshamboMove.paper:
							playerHealth -= scissorsDamage;
							return (1, scissorsDamage);
						default: return (0, 0);
					}
				default: throw new ArgumentException();
			}
		}

		public enum RoshamboMove
		{
			rock,
			paper,
			scissors
		};

		private static int playerHealth, computerHealth;
		public const int rockDamage = 20, scissorsDamage = 15, paperDamage = 10;
	}
}
