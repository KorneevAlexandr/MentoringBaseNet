namespace Katas.Library.Kata3.BerlinClock
{
	public class BerlinClock
	{
		public string SecondsLamp { get; set; }

		public string TopHoursLamps { get; set; }

		public string BottomHoursLamps { get; set; }

		public string TopMinutesLamps { get; set; }

		public string BottomMinutesLamps { get; set; }

		public override string ToString() => 
			$"{SecondsLamp}\n{TopHoursLamps}\n{BottomHoursLamps}\n{TopMinutesLamps}\n{BottomMinutesLamps}";
	}
}
