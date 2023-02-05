namespace Katas.Library.Kata2.CalcStats
{
	public static class CalcStatsGenerator
	{
		public static CalcStats<T> CreateCalcStats<T>(IEnumerable<T> sequence)
			where T : struct
		{
			if (sequence == null)
			{
				throw new ArgumentNullException(nameof(sequence));
			}

			if (!sequence.Any())
			{
				throw new ArgumentException("Sequence can not be empty.");
			}

			return new CalcStats<T>
			{
				Minimum = sequence.Min(),
				Maximum = sequence.Max(),
				AverageValue = sequence.Average(x => Convert.ToDecimal(x)),
				NumberOfElements= sequence.Count()
			};
		}
	}
}
