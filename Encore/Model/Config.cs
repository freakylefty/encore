using System.Numerics;
using Encore.Formatter;

namespace Encore.Model
{
    class Config
    {
        public int MaxMessages;
        public IFormatter Formatter;
        public int InputRate;
        public int RollRate;

        public Config()
        {
            MaxMessages = 4;
            Formatter = Formatters.Letter;
            InputRate = 200;
            RollRate = 1000;
        }

        public Config(int maxMessages, IFormatter formatter, int inputRate)
        {
            MaxMessages = maxMessages;
            Formatter = formatter;
            InputRate = inputRate;
        }
    }
}
