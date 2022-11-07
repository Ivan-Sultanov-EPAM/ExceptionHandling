using System;
using System.Linq;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
                throw new ArgumentNullException(nameof(stringValue));

            stringValue = stringValue.Trim();

            if (stringValue.Length == 0)
                throw new FormatException(nameof(stringValue));

            var sign = stringValue.ElementAt(0) == '-' ? -1 : 1;

            stringValue = stringValue.ElementAt(0) == '-' || stringValue.ElementAt(0) == '+' ?
                stringValue.Remove(0, 1) : stringValue;

            stringValue = stringValue.TrimStart('0');

            var value = 0;
            var multiplier = 1 * sign;

            foreach (var ch in stringValue.Reverse())
            {
                value = checked(value + ParseInt(ch) * multiplier);
                multiplier *= multiplier < 1000000000 ? 10 : 1;
            }

            int ParseInt(char ch)
            {
                switch (ch)
                {
                    case '0':
                        return 0;
                    case '1':
                        return 1;
                    case '2':
                        return 2;
                    case '3':
                        return 3;
                    case '4':
                        return 4;
                    case '5':
                        return 5;
                    case '6':
                        return 6;
                    case '7':
                        return 7;
                    case '8':
                        return 8;
                    case '9':
                        return 9;
                    default: throw new FormatException(nameof(ch));
                }
            }

            return value;
        }
    }
}