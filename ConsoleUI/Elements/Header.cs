using ConsoleUI.Model;

namespace ConsoleUI.Elements
{
    public class Header : AbstractElement
    {
        private string Text;
        private Decoration Style;
        private int Width;

        public Header(string id, bool visible, Point anchor, string text, Decoration style, int width = -1) : base(id, visible, anchor)
        {
            Width = GetWidth(width, anchor);
            Text = text;
            Style = style;
            if (Style == Decoration.Strike)
            {
                Text = "-" + ConsoleUtil.FitString(Text, Width - 1, '-');
            }
        }

        public override void Render(Theme theme)
        {
            ConsoleUtil.WriteText(Text, Anchor, theme.Text, theme.Background);
            if (Style == Decoration.Underline)
            {
                ConsoleUtil.WriteText(new string('-', Width), Anchor.Offset(0, 1), theme.Text, theme.Background);
            }
        }
    }
}
