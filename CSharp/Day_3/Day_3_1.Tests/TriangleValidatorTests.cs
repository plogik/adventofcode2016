using NUnit.Framework;
using Day_3_1;
namespace Day_3_1.Tests
{
	[TestFixture]
    public class TriangleValidatorTests
    {
		[Test]
		public void TriangleValidator_Valid_1()
		{
			Assert.AreEqual(true, TriangleValidator.IsValid(3, 4, 5));
		}
		[Test]
		public void TriangleValidator_Valid_2()
		{
			Assert.AreEqual(true, TriangleValidator.IsValid(5, 4, 3));
		}
		[Test]
		public void TriangleValidator_Valid_3()
		{
			Assert.AreEqual(true, TriangleValidator.IsValid(4, 5, 3));
		}
		[Test]
		public void TriangleValidator_Invalid_1()
		{
			Assert.AreEqual(false, TriangleValidator.IsValid(5, 10, 25));
		}
		[Test]
		public void TriangleValidator_Invalid_2()
		{
			Assert.AreEqual(false, TriangleValidator.IsValid(10, 25, 5));
		}
		[Test]
		public void TriangleValidator_Invalid_3()
		{
			Assert.AreEqual(false, TriangleValidator.IsValid(25, 5, 10));
		}
	}
}
