using System;
using System.Numerics;

namespace Encore.Formatter
{
    class ScientificFormatter : AbstractFormatter
    {
        public override string Format(BigInteger value)
        {
            string numberString = value.ToString();
            if (numberString.Length < 4)
            {
                return numberString;
            }
            int exponent = numberString.Length - 1;
            string leadingDigit = numberString.Substring(0, 1);
            string decimals = numberString.Substring(1, 3);

            return String.Format("{0}.{1}e{2}", leadingDigit, decimals, exponent);
        }
    }
}
