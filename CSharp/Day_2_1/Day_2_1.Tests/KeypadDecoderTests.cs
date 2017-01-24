using NUnit.Framework;

namespace Day_2_1.Tests
{
	[TestFixture]
	class KeypadDecoderTests
	{
		[Test]
		public void KeypadDecoder_U_Eq_2()
		{
			var decoder = new KeypadDecoder();

			decoder.Play("U");

			Assert.AreEqual(2, decoder.CurrentKey);
		}
		[Test]
		public void KeypadDecoder_UU_Eq_2()
		{
			var decoder = new KeypadDecoder();

			decoder.Play("UU");

			Assert.AreEqual(2, decoder.CurrentKey);
		}

		[Test]
		public void KeypadDecoder_D_EQ_8()
		{
			var decoder = new KeypadDecoder();

			decoder.Play("D");

			Assert.AreEqual(8, decoder.CurrentKey);
		}

		[Test]
		public void KeypadDecoder_Scenario_1()
		{
			var decoder = new KeypadDecoder();

			// Digit 1 - 1
			decoder.Play("ULL");
			Assert.AreEqual(1, decoder.CurrentKey);

			// Digit 2 - 9
			decoder.Play("RRDDD");
			Assert.AreEqual(9, decoder.CurrentKey);

			// Digit 3 - 8
			decoder.Play("LURDL");
			Assert.AreEqual(8, decoder.CurrentKey);

			// Digit 4 - 5
			decoder.Play("UUUUD");
			Assert.AreEqual(5, decoder.CurrentKey);
		}
	}
}
