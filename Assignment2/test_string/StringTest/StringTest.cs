using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringTest
{
	[TestClass]
	public class StringTest
	{
		[TestMethod]
		public void TestStringLength()
		{
			Assert.AreEqual(testStringLength, testString.Length);
		}

		[TestMethod]
		public void TestStringSplit()
		{
			Assert.AreEqual(2, testString.Split(" ").Length);
		}

		[TestMethod]
		public void TestStringImmutability()
		{
			string immutableString1 = "Immutable string.";
			string immutableString2 = immutableString1;

			immutableString2 += " Are you sure this is immutable?";

			Assert.AreNotEqual(immutableString1, immutableString2);
		}

		[TestMethod]
		public void TestStringJoin()
		{
			Assert.AreEqual(stringArrayJoined, string.Join("!", stringArray));
		}

		private readonly string testString = "Hello World!";
		private readonly string[] stringArray = new[] {"stringArray[0]", "stringArray[1]"};
		private readonly string stringArrayJoined = "stringArray[0]!stringArray[1]";
		private readonly int testStringLength = 12;
	}
}
