using Katas.Library.Kata2.CalcStats;
using NUnit.Framework;

namespace Katas.UnitTests.Kata2.CalcStats
{
	[TestFixture]
	public class CalcStatsGeneratorTests
	{
		[Test]
		public void CreateCalcStats_WhenInputSequenceIsNull_ShouldThrows()
		{
			var exception = Assert.Throws<ArgumentNullException>(() => CalcStatsGenerator.CreateCalcStats<int>(null));
			Assert.That(exception.ParamName, Is.EqualTo("sequence"));
		}

		[Test]
		public void CreateCalcStats_WhenInputSequenceIsEmpty_ShouldThrows()
		{
			var exception = Assert.Throws<ArgumentException>(() => CalcStatsGenerator.CreateCalcStats(Array.Empty<double>()));
			Assert.That(exception.Message, Is.EqualTo("Sequence can not be empty."));
		}

		public static IEnumerable<object> StatsParams => new List<object>
		{
			new object[] { new int[] { 1, 2, 3 }, 1, 3, 3, 2.0m },
			new object[] { new int[] { 10, 10, 10 }, 10, 10, 3, 10.0m },
			new object[] { new int[] { 0, 0, 0, 0 }, 0, 0, 4, 0.0m },
			new object[] { new double[] { -1.0, 5.0, 8.0 }, -1.0, 8.0, 3, 4.0m },
			new object[] { new float[] { 10.0f, 15.0f }, 10f, 15f, 2, 12.5m }
		};

		[TestCaseSource(nameof(StatsParams))]
		public void GenerateStats_WhenSequenceCorrect_ShouldReturnCorrectStats<T>(IEnumerable<T> sequence, T minimum, T maximum, int count, decimal average)
			where T : struct
		{
			// Arrange, Act
			var actual = CalcStatsGenerator.CreateCalcStats(sequence);

			// Assert
			Assert.That(actual.Minimum, Is.EqualTo(minimum));
			Assert.That(actual.Maximum, Is.EqualTo(maximum));
			Assert.That(actual.NumberOfElements, Is.EqualTo(count));
			Assert.That(actual.AverageValue, Is.EqualTo(average));
		}
	}
}
