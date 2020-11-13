using System.Numerics;

using Encore.Formatter;
using Encore.Model.Bus;

namespace Encore.Model
{
    class Core
    {
        public BigInteger Min = 1;
        public BigInteger Max = 5;
        public IBus Bus = new Add();
        public BigInteger LastRoll = 0;

        public BigInteger Roll()
        {
            LastRoll = RandomBigInteger.Instance.NextBigInteger(Min, Max);
            return LastRoll;
        }

        public string Format(IFormatter formatter)
        {
            return "(" + formatter.Format(Min) + "->" + formatter.Format(Max) + "): " + formatter.Format(LastRoll);
        }
    }
}
