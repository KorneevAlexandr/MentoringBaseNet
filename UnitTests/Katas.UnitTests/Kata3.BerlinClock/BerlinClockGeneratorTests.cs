using Katas.Library.Kata3.BerlinClock;
using NUnit.Framework;

namespace Katas.UnitTests.Kata3.BerlinClock
{
	[TestFixture]
	public class BerlinClockGeneratorTests
	{
		[TestCase(null)]
		[TestCase("")]
		[TestCase("   ")]
		public void CreateBerlinClock_WhenInputTimeIsNull_ShouldThrows(string time)
		{
			var exception = Assert.Throws<ArgumentNullException>(() => BerlinClockGenerator.GenerateBerlinClock(time));
			Assert.That(exception.ParamName, Is.EqualTo(nameof(time)));
		}

		[TestCase(":10:10", "Input string does not match with time pattern (hh:mm:ss).")]
		[TestCase("12:a:10", "Input string does not match with time pattern (hh:mm:ss).")]
		[TestCase("121212", "Input string does not match with time pattern (hh:mm:ss).")]
		[TestCase("::", "Input string does not match with time pattern (hh:mm:ss).")]
		[TestCase("25:10:10", "The hour value must be in the range [0; 23].")]
		[TestCase("21:98:10", "The minute value must be in the range [0; 59].")]
		[TestCase("21:18:100", "The second value must be in the range [0; 59].")]
		public void CreateBerlinClock_WhenInputTimeIsIncorrect_ShouldThrows(string time, string errorMessage)
		{
			var exception = Assert.Throws<ArgumentException>(() => BerlinClockGenerator.GenerateBerlinClock(time));
			Assert.That(exception.Message, Is.EqualTo(errorMessage));
		}

		public static IEnumerable<object> TimeParams => new List<object>
		{
			new object[] { "12:44:05", "Y\n" +
									   "RROO\n" +
									   "RROO\n" +
									   "YYRYYRYYOOO\n" +
									   "YYYY" },
			new object[] { "15:03:04", "O\n" +
									   "RRRO\n" +
									   "OOOO\n" +
									   "OOOOOOOOOOO\n" +
									   "YYYO" },
			new object[] { "03:58:55", "Y\n" +
									   "OOOO\n" +
									   "RRRO\n" +
									   "YYRYYRYYRYY\n" +
									   "YYYO" },
			new object[] { "00:30:10", "O\n" +
									   "OOOO\n" +
									   "OOOO\n" +
									   "YYRYYROOOOO\n" +
									   "OOOO" },
			new object[] { "09:01:01", "Y\n" +
									   "ROOO\n" +
									   "RRRR\n" +
									   "OOOOOOOOOOO\n" +
									   "YOOO" },
			new object[] { "00:00:00", "O\n" +
									   "OOOO\n" +
									   "OOOO\n" +
									   "OOOOOOOOOOO\n" +
									   "OOOO" },
			new object[] { "23:59:59", "Y\n" +
									   "RRRR\n" +
									   "RRRR\n" +
									   "YYRYYRYYRYY\n" +
									   "YYYY" }
		};

		[TestCaseSource(nameof(TimeParams))]
		public static void GenerateBerlinClock_WhenInputTimeCorrect_ShouldReturnCorrectTime(string time, string expected)
		{
			// Arrange, Act
			var actual = BerlinClockGenerator.GenerateBerlinClock(time);

			// Assert
			Assert.That(actual.ToString(), Is.EqualTo(expected));
		}
	}
}
