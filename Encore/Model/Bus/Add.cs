using System.Numerics;

namespace Encore.Model.Bus
{
    class Add : IBus
    {
        public BigInteger Combine(BigInteger input, BigInteger output)
        {
            return input + output;
        }

        public override string ToString()
        {
            return "+";
        }
    }
}
