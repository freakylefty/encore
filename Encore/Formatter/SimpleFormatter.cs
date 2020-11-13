using System.Numerics;

namespace Encore.Formatter
{
    public class SimpleFormatter : AbstractFormatter
    {
        public override string Format(BigInteger value)
        {
            return value.ToString("#,##0");
        }
    }
}
