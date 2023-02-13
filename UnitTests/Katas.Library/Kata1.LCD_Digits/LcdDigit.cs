namespace Katas.Library.Kata1.LCD_Digits
{
	public class LcdDigit
	{
		public string FirstRow { get; set; }

		public string SecondRow { get; set; }

		public string ThirdRow { get; set; }

		public static LcdDigit operator +(LcdDigit left, LcdDigit right) =>
			new()
			{
				FirstRow  = $"{left.FirstRow} {right.FirstRow}",
				SecondRow = $"{left.SecondRow} {right.SecondRow}",
				ThirdRow  = $"{left.ThirdRow} {right.ThirdRow}",
			};

		public override string ToString() => $"{FirstRow}\n{SecondRow}\n{ThirdRow}";
	}
}
