using System.Collections.Generic;

using ConsoleUI.Model;

namespace ConsoleUI.Elements
{
    public class MessageList : AbstractElement
    {
        private List<string> Messages;
        private int Width;
        private Align VerticalAlign;

        public MessageList(string id, bool visible, Point anchor, List<string> source, Align verticalAlign = Align.Bottom, int width = -1) : base(id, visible, anchor)
        {
            VerticalAlign = verticalAlign;
            Messages = source;
            Width = GetWidth(width, anchor);
        }

        public override void Render(Theme theme)
        {
            for (int index = 0; index < Messages.Count; index++)
            {
                string text = ConsoleUtil.FitString(Messages[index], Width);
                Point currPos = Anchor.Offset(0, VerticalAlign == Align.Bottom ? 0 - index : index);
                ConsoleUtil.WriteText(text, currPos, index == 0 ? theme.Text : theme.DarkText, theme.Background);
            }
        }
    }
}
