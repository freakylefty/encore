using System;
using System.Numerics;

namespace Encore.Formatter
{
    class LetterFormatter : AbstractFormatter
    {
        public override string Format(BigInteger value)
        {
            string number = value.ToString();
            if (number.Length < 4)
            {
                return Formatters.Simple.Format(value);
            }
            string suffix = GetSuffixForNumber(number);
            if (suffix == "")
            {
                return Formatters.Scientific.Format(value);
            }
            int amountOfLeadingNumbers = (number.Length - 4) % 3 + 1;
            string leadingNumbers = number.Substring(0, amountOfLeadingNumbers);
            string decimals = number.Substring(amountOfLeadingNumbers, 3);

            return CreateNumericalFormat(leadingNumbers, decimals, suffix);
        }

        private string CreateNumericalFormat(string leadingNumbers, string decimals, string suffix)
        {
            return String.Format("{0}.{1}{2}", leadingNumbers, decimals, suffix);
        }

        private string GetSuffixForNumber(string number)
        {
            int numberOfThousands = (number.Length - 1) / 3;

            switch (numberOfThousands)
            {
                case 1:
                    return "K";
                case 2:
                    return "M";
                case 3:
                    return "B";
                case 4:
                    return "T";
                case 5:
                    return "q";
                case 6:
                    return "Q";
                case 7:
                    return "s";
                case 8:
                    return "S";
                case 9:
                    return "O";
                case 10:
                    return "N";
                case 11:
                    return "D";
                default:
                    return "";
            }
        }
    }
}
