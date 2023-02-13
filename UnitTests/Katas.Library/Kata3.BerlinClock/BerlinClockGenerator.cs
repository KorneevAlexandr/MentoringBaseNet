namespace Katas.Library.Kata3.BerlinClock
{
	public static class BerlinClockGenerator
	{
		private const string Yellow = "Y";
		private const string Red = "R";
		private const string Off = "O";

		private const char TimeDelimeter = ':';

		private const int MaxHoursValue = 24;
		private const int MaxMinutesValue = 60;
		private const int MaxSecondsValue = 60;

		private const int LampStepValue = 5;
		private const int TopHoursLampCount = 4;
		private const int TopMinutesLampCount = 11;
		private const int BottomHoursLampCount = 4;
		private const int BottomMinutesLampCount = 4;

		private const string TopMinutesLampSolidFilling = $"{Yellow}{Yellow}{Yellow}";
		private const string TopMinutesLampCropFilling = $"{Yellow}{Yellow}{Red}";


		public static BerlinClock GenerateBerlinClock(string time)
		{
			if (string.IsNullOrWhiteSpace(time))
			{
				throw new ArgumentNullException(nameof(time));
			}

			int hours, minutes, seconds;

			try
			{
				var timeParts = time.Split(TimeDelimeter).Select(x => Convert.ToInt32(x)).ToArray();

				hours = timeParts[0];
				minutes = timeParts[1];
				seconds = timeParts[2];
			}
			catch
			{
				throw new ArgumentException("Input string does not match with time pattern (hh:mm:ss).");
			}

			return GenerateBerlinClock(hours, minutes, seconds);
		}

		public static BerlinClock GenerateBerlinClock(int hours, int minutes, int seconds)
		{
			if (hours < 0 || hours >= MaxHoursValue)
			{
				throw new ArgumentException("The hour value must be in the range [0; 23].");
			}

			if (minutes < 0 || minutes >= MaxMinutesValue)
			{
				throw new ArgumentException("The minute value must be in the range [0; 59].");
			}

			if (seconds < 0 || seconds >= MaxSecondsValue)
			{
				throw new ArgumentException("The second value must be in the range [0; 59].");
			}

			return GenerateBerlinClockInternal(hours, minutes, seconds);
		}

		private static BerlinClock GenerateBerlinClockInternal(int hours, int minutes, int seconds) =>
			new()
			{
				SecondsLamp = GetSecondsLamp(seconds),
				TopHoursLamps = GetTopHoursLamp(hours),
				BottomHoursLamps = GetBottomHoursLamp(hours),
				TopMinutesLamps = GetTopMinutesLamp(minutes),
				BottomMinutesLamps = GetBottomMinutesLamp(minutes)
			};

		private static string GetSecondsLamp(int seconds) => 
			seconds.IsEven() ? Off : Yellow;

		private static string GetTopHoursLamp(int hours) =>
			FillOff(string.Join(string.Empty, Enumerable.Repeat(Red, hours / LampStepValue)), TopHoursLampCount);

		private static string GetBottomHoursLamp(int hours) =>
			FillOff(string.Join(string.Empty, Enumerable.Repeat(Red, hours % LampStepValue)), BottomHoursLampCount);

		private static string GetTopMinutesLamp(int minutes) =>
			FillOff(string.Join(string.Empty, Enumerable.Repeat(Yellow, minutes / LampStepValue)), TopMinutesLampCount)
			.Replace(TopMinutesLampSolidFilling, TopMinutesLampCropFilling);

		private static string GetBottomMinutesLamp(int minutes) =>
			FillOff(string.Join(string.Empty, Enumerable.Repeat(Yellow, minutes % LampStepValue)), BottomMinutesLampCount);

		private static string FillOff(string value, int len) =>
			string.Concat(value, string.Join(string.Empty, Enumerable.Repeat(Off, len - value.Length)));
	}
}
