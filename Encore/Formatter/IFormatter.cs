using System.Numerics;

namespace Encore.Formatter
{
    public interface IFormatter
    {
        string Format(BigInteger value);
        string Format(int value);
    }
}
