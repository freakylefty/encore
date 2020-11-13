using System;

using ConsoleUI.Model;

namespace ConsoleUI
{
    public class ConsoleUtil
    {
        public static void WriteText(string text, Point anchor, ConsoleColor colour, ConsoleColor background)
        {
            Console.ForegroundColor = colour;
            Console.BackgroundColor = background;
            Console.SetCursorPosition(anchor.X, anchor.Y);
            Console.Write(text);
        }

        public static string FitString(string text, int width, char pad, Align align)
        {
            if (text.Length > width)
            {
                return text.Substring(0, width);
            }
            if (text.Length < width)
            {
                switch (align)
                {
                    case Align.Right:
                        return new string(pad, width - text.Length) + text;
                    case Align.Centre:
                        int toPad = width - text.Length;
                        int leftPad = toPad / 2;
                        int rightPad = (toPad % 2 == 0) ? leftPad : leftPad + 1;
                        return new string(pad, leftPad) + text + new string(pad, rightPad);
                    default: return text + new string(pad, width - text.Length);
                }
            }
            return text;
        }

        public static string FitString(string text, int width, Align align)
        {
            return FitString(text, width, ' ', align);
        }

        public static string FitString(string text, int width)
        {
            return FitString(text, width, ' ', Align.Left);
        }

        public static string FitString(string text, int width, char pad)
        {
            return FitString(text, width, pad, Align.Left);
        }
    }
}
