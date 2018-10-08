using System;
using System.Data;
using System.Linq;

namespace Calculator
{
	public class Calculator
	{
		public static void Main(string[] args)
		{
			string userInput = "";

			if (args.Length > 1)
			{
				Console.WriteLine($"Passed in expression: {string.Join(" ", args)}");
				userInput = string.Join(" ", args);
			}
			else
			{
				Console.WriteLine($"Welcome to Calculator!{Environment.NewLine}Enter a mathematical expression or type 'help' for available operations.");
				userInput = Console.ReadLine();
			}

			while (!userInput.Trim().Equals("n"))
			{
				bool validExpression = true;
				var userInputArray = userInput.Split(" ");

				if (userInputArray.Length != 3)
				{
					if (userInputArray[0] == "h" || userInputArray[0] == "help")
						PrintHelp();
					else
					{
						Console.WriteLine("Expression is not properly formatted.");
						validExpression = false;
					}
				}
				else
				{
					if (!Decimal.TryParse(userInputArray[0], out decimal leftOperand))
					{
						Console.WriteLine("Left operand is not a valid number.");
						validExpression = false;
					}

					if (!Decimal.TryParse(userInputArray[2], out decimal rightOperand))
					{
						Console.WriteLine("Right operand is not a valid number.");
						validExpression = false;
					}

					if (!TryParseOperator(userInputArray[1], out string expressionOperator))
					{
						Console.WriteLine("Passed in operator is not a valid operator.");
						validExpression = false;
					}

					if (validExpression)
					{
						validExpression = !(expressionOperator == "/" && rightOperand == 0);
						if (!validExpression)
							Console.WriteLine("Cannot divide by zero.");
					}

					if (validExpression)
						Console.WriteLine($"Answer: {SolveExpression(leftOperand, rightOperand, expressionOperator)}");
				}

				Console.WriteLine($"{Environment.NewLine}Type 'n' to end program, type new expression to continue.{Environment.NewLine}");
				userInput = Console.ReadLine();
			}

		}

		private static decimal SolveExpression(decimal leftOperand, decimal rightOperand, string expressionOperator)
		{
			switch (expressionOperator)
			{
				case "+": return leftOperand + rightOperand;
				case "-": return leftOperand - rightOperand;
				case "*": return leftOperand * rightOperand;
				case "x": return leftOperand * rightOperand;
				case "/": return leftOperand / rightOperand;
				case "**": return (decimal) Math.Pow((double) leftOperand, (double) rightOperand);
				default: throw new ArgumentException("Passed in operator is not a valid operator.");
			}
		}

		private static bool TryParseOperator(string stringOperator, out string expressionOperator)
		{
			if (new[] {"+", "-", "*", "/", "x", "**"}.Contains(stringOperator))
			{
				expressionOperator = stringOperator.Trim();
				return true;
			}

			expressionOperator = "";
			return false;
		}

		private static void PrintHelp()
		{
			Console.WriteLine($@"Available expressions:

Addition:
	Operator: '+'
	Examples: 2 + 2, 1.5 + 2.75

Subtraction:
	Operator: '-'
	Examples: 2 - 2, 3.45 - -16

Multiplication:
	Operators: '*' or 'x'
	Examples: 2 * 2, 2 x 2, 10.1 * 50.1

Division:
	Operator: '/'
	Examples: 2 / 2, 4.5 / 2

Power:
	Operator: '**'
	Examples: 2 ** 2, 9.5 ** 3
");
		}
	}
}
