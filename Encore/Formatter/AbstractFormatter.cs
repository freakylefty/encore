using System.Numerics;

namespace Encore.Formatter
{
    public abstract class AbstractFormatter : IFormatter
    {
        public string Format(int value)
        {
            return Format(new BigInteger(value));
        }

        public abstract string Format(BigInteger value);
    }
}
