using System;
using System.Collections.Generic;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        private const char Plus = '+';
        private const char Minus = '-';

        private readonly static Dictionary<char, int> ValidNumbers = new Dictionary<char, int>
        {
            { '0', 0 },
            { '1', 1 },
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 }
        };

        public int Parse(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException(nameof(stringValue));
            }

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                throw new FormatException("Input value is empty.");
            }

            var isMinus = false;
            long numericValue = 0;
            var trimeredStringValue = stringValue.Trim();

            for (int i = 0; i < trimeredStringValue.Length; i++)
            {
                var symbol = trimeredStringValue[i];

                if (i == 0 && symbol.Equals(Minus))
                {
                    isMinus = true;
                    continue;
                }
                
                if (i == 0 && symbol.Equals(Plus))
                {
                    continue;
                }

                var isValidNumber = ValidNumbers.TryGetValue(symbol, out int value);

                if (!isValidNumber)
                {
                    throw new FormatException("Input value is not correct.");
                }

                numericValue = numericValue * 10 + value;
            }

            numericValue *= isMinus ? -1 : 1;
            
            if (numericValue > int.MaxValue || numericValue < int.MinValue)
            {
                throw new OverflowException("Input value less or big than possible.");
            }

            return (int)numericValue;
        }
    }
}