using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringTest
{
	[TestClass]
	public class StringTest
	{
		[TestMethod]
		public void TestStringLength()
		{
			Assert.AreEqual(12, testString.Length);
		}

		[TestMethod]
		public void TestStringSplit()
		{
			var testStringSplit = testString.Split(" ");

			Assert.AreEqual(2, testString.Split(" ").Length);
			Assert.AreEqual("Hello", testStringSplit[0]);
			Assert.AreEqual("World!", testStringSplit[1]);
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
			string[] stringArray = new[] { "Hello", "World!" };

			Assert.AreEqual("Hello World!", string.Join(" ", stringArray));
		}

		private readonly string testString = "Hello World!";
	}
}
