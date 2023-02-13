using System.Text.RegularExpressions;

namespace Katas.Library.Kata1.LCD_Digits
{
	public static class LcdGenerator
	{
		private readonly static Regex DigitRegex = new("^\\d+$");
		private readonly static Dictionary<char, LcdDigit> LcdDigits = new()
		{
			{ 
				'0', new LcdDigit
				{
					FirstRow  = "._.",
					SecondRow = "|.|",
					ThirdRow  = "|_|"
				}
			},
			{
				'1', new LcdDigit
				{
					FirstRow  = "...",
					SecondRow = "..|",
					ThirdRow  = "..|"
				}
			},
			{
				'2', new LcdDigit
				{
					FirstRow  = "._.",
					SecondRow = "._|",
					ThirdRow  = "|_."
				}
			},
			{
				'3', new LcdDigit
				{
					FirstRow  = "._.",
					SecondRow = "._|",
					ThirdRow  = "._|"
				}
			},
			{
				'4', new LcdDigit
				{
					FirstRow  = "...",
					SecondRow = "|_|",
					ThirdRow  = "..|"
				}
			},
			{
				'5', new LcdDigit
				{
					FirstRow  = "._.",
					SecondRow = "|_.",
					ThirdRow  = "._|"
				}
			},
			{
				'6', new LcdDigit
				{
					FirstRow  = "._.",
					SecondRow = "|_.",
					ThirdRow  = "|_|"
				}
			},
			{
				'7', new LcdDigit
				{
					FirstRow  = "._.",
					SecondRow = "..|",
					ThirdRow  = "..|"
				}
			},
			{
				'8', new LcdDigit
				{
					FirstRow  = "._.",
					SecondRow = "|_|",
					ThirdRow  = "|_|"
				}
			},
			{
				'9', new LcdDigit
				{
					FirstRow  = "._.",
					SecondRow = "|_|",
					ThirdRow  = "..|"
				}
			}
		};

		public static string GenerateLcdString(string digitsLine)
		{
			if (string.IsNullOrWhiteSpace(digitsLine))
			{
				throw new ArgumentNullException(nameof(digitsLine));
			}

			if (!DigitRegex.IsMatch(digitsLine))
			{
				throw new ArgumentException("Input line must have only digits.");
			}

			LcdDigit digit = LcdDigits[digitsLine[0]];

			for (int i = 1; i < digitsLine.Length; i++)
			{
				digit += LcdDigits[digitsLine[i]];
			}

			return digit.ToString();
		}
	}
}
