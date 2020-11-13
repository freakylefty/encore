using ConsoleUI.Model;

namespace ConsoleUI.Elements
{
    public class Text : AbstractElement
    {
        public string Value;
        private int Width;

        public Text(string id, bool visible, Point anchor, string value, int width = -1) : base(id, visible, anchor)
        {
            Width = GetWidth(width, anchor);
            Value = value;
        }

        public override void Render(Theme theme)
        {
            ConsoleUtil.WriteText(ConsoleUtil.FitString(Value, Width), Anchor, theme.Text, theme.Background);
        }
    }
}
