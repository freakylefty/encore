using System.Numerics;

namespace Encore.Model.Bus
{
    class Null : IBus
    {
        public BigInteger Combine(BigInteger input, BigInteger output)
        {
            return output;
        }

        public override string ToString()
        {
            return " ";
        }
    }
}
