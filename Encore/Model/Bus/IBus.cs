using System.Numerics;

namespace Encore.Model.Bus
{
    interface IBus
    {
        BigInteger Combine(BigInteger input, BigInteger output);
    }
}
