using NUnit.Framework;

namespace Day_2_2.Tests
{
	[TestFixture]
	class KeypadDecoderTests
	{
		[Test]
		public void KeypadDecode_Initially_At_5()
		{
			Assert.AreEqual(5, new KeypadDecoder().CurrentKey);
		}
	
		[Test]
		public void KeypadDecoder_U_Eq_5()
		{
			var decoder = new KeypadDecoder();

			decoder.Play("U");

			Assert.AreEqual(5, decoder.CurrentKey);
		}

		[Test]
		public void KeypadDecoder_D_EQ_5()
		{
			var decoder = new KeypadDecoder();

			decoder.Play("D");

			Assert.AreEqual(5, decoder.CurrentKey);
		}

		[Test]
		public void KeypadDecoder_Scenario_1()
		{
			var decoder = new KeypadDecoder();

			// Digit 1 - 1
			decoder.Play("ULL");
			Assert.AreEqual(5, decoder.CurrentKey);

			// Digit 2 - 9
			decoder.Play("RRDDD");
			Assert.AreEqual(0xD, decoder.CurrentKey);

			// Digit 3 - 8
			decoder.Play("LURDL");
			Assert.AreEqual(0xB, decoder.CurrentKey);

			// Digit 4 - 5
			decoder.Play("UUUUD");
			Assert.AreEqual(3, decoder.CurrentKey);
		}
	}
}
