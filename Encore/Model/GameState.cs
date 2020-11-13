using System.Collections.Generic;
using System.Numerics;

namespace Encore.Model
{
    class GameState
    {
        public BigInteger Ops = 100000;
        public List<Core> Cores = new List<Core>();

        private static BigInteger[] CoreCosts = new[] {
            new BigInteger(0),
            new BigInteger(1000),
            new BigInteger(1000000),
            new BigInteger(1000000000),
            new BigInteger(1000000000000),
            new BigInteger(1000000000000000),
            new BigInteger(1000000000000000000),
            BigInteger.Parse("1000000000000000000000")
        };

        public void AddCore()
        {
            if (Cores.Count >= CoreCosts.Length)
            {
                return;
            }
            BigInteger cost = CoreCosts[Cores.Count];
            if (Ops < cost)
            {
                return;
            }
            Ops -= cost;
            Core core = new Core();
            if (Cores.Count == 0)
            {
                core.Bus = new Bus.Null();
            }
            Cores.Add(core);
        }

        public void Tick()
        {
            BigInteger total = 0;
            foreach (Core core in Cores)
            {
                BigInteger roll = core.Roll();
                total = core.Bus.Combine(total, roll);
            }
            Ops += total;
        }
    }
}
