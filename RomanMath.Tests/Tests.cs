using NUnit.Framework;
using RomanMath.Impl;

namespace RomanMath.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			var result = Service.Evaluate("IV+II/V");
			Assert.AreEqual(0, result);
		}
		[Test]
		public void Test_CorrectInput()
		{
			var result = Service.Evaluate("IV+VX*XVIII-X");
			Assert.AreEqual(84, result);
		}
		[Test]
		public void Test_InputWithWhiteSpaces()
		{
			var result = Service.Evaluate("IV + VX * XVIII - X");
			Assert.AreEqual(84, result);
		}
		[Test]
		public void Test_IpnutWithParentheses()
		{
			var result = Service.Evaluate("IV+VX*(XVIII-X)");
			Assert.AreEqual(0, result);
		}
		[Test]
		public void Test_IpnutWithParenthesesAndDigits()
		{
			var result = Service.Evaluate("IV+VX*(16-10)-VIII");
			Assert.AreEqual(0, result);
		}
		[Test]
		public void Test_IpnutWithDigits()
		{
			var result = Service.Evaluate("IV+VX*16-10-VIII");
			Assert.AreEqual(0, result);
		}
		[Test]
		public void Test_InputInLowerCase()
		{
			var result = Service.Evaluate("iv+Vx*xvi-VIII");
			Assert.AreEqual(0, result);
		}
	}
}