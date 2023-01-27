using Katas.Library.Kata1.LCD_Digits;
using NUnit.Framework;

namespace Katas.UnitTests.Kata1.Lcd_Digits
{
	[TestFixture]
	public class LcdGeneratorTests
	{
		[TestCase(null)]
		[TestCase("")]
		[TestCase("   ")]
		public void GenerateLcdString_WhenInputStringIsNullOrWhiteSpace_ShouldThrows(string digitsLine)
		{
			var exception = Assert.Throws<ArgumentNullException>(() => LcdGenerator.GenerateLcdString(digitsLine));
			Assert.That(exception.ParamName, Is.EqualTo(nameof(digitsLine)));
		}

		[TestCase("qwe")]
		[TestCase("123_")]
		[TestCase("1q2")]
		[TestCase("ooo0o")]
		[TestCase("1+1")]
		public void GenerateLcdString_WhenInputStringIncorrect_ShouldThrows(string digitsLine)
		{
			var exception = Assert.Throws<ArgumentException>(() => LcdGenerator.GenerateLcdString(digitsLine));
			Assert.That(exception.Message, Is.EqualTo("Input line must have only digits."));
		}

		public static IEnumerable<object> LcdStringParams => new List<object>
		{
			new[] { "2", "._.\n" +
						 "._|\n" +
						 "|_." },
			new[] { "910", "._. ... ._.\n" +
						   "|_| ..| |.|\n" +
						   "..| ..| |_|" },
			new[] { "55707", "._. ._. ._. ._. ._.\n" +
							 "|_. |_. ..| |.| ..|\n" +
							 "._| ._| ..| |_| ..|" },
			new[] { "0123456789", "._. ... ._. ._. ... ._. ._. ._. ._. ._.\n" +
								  "|.| ..| ._| ._| |_| |_. |_. ..| |_| |_|\n" +
								  "|_| ..| |_. ._| ..| ._| |_| ..| |_| ..|" }
		};

		[TestCaseSource(nameof(LcdStringParams))]
		public void GenerateLcdString_WhenInputStringCorrect_ShouldReturnCorrectLcdStrings(string digitsLine, string expected)
		{
			// Arrange, Act
			var actual = LcdGenerator.GenerateLcdString(digitsLine);

			// Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
