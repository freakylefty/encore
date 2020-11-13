using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encore.Formatter
{
    public class Formatters
    {
        public static IFormatter Simple = new SimpleFormatter();
        public static IFormatter Scientific = new ScientificFormatter();
        public static IFormatter Letter = new LetterFormatter();
    }
}
