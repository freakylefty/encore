using ConsoleUI.Model;

namespace ConsoleUI.Elements
{
    public class Spinner : AbstractElement
    {
        public enum SpinnerStyle { Clock, Fade };
        public int Percent;

        private string[] Values;
        private int[] Breaks;

        private static string[] FadeValues = new[] { " ", "░", "▒", "▓", "█" };
        private static int[] FadeBreaks = new[] { 20, 40, 60, 80 };
        private static string[] ClockValues = new[] { "/", "-", "\\", "|" };
        private static int[] ClockBreaks = new[] { 25, 50, 75 };

        public Spinner(string id, bool visible, Point anchor, int percent, SpinnerStyle style = SpinnerStyle.Fade) : base(id, visible, anchor)
        {
            Percent = percent;
            Values = style == SpinnerStyle.Clock ? ClockValues : FadeValues;
            Breaks = style == SpinnerStyle.Clock ? ClockBreaks : FadeBreaks;
        }

        public override void Render(Theme theme)
        {
            ConsoleUtil.WriteText(GetChar(), Anchor, theme.Text, theme.Background);
        }

        private string GetChar()
        {
            for (int index = 0; index < Breaks.Length; index++)
            {
                if (Percent < Breaks[index])
                {
                    return Values[index];
                }
            }
            return Values[Breaks.Length];
        }
    }
}
