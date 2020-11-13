using System.Text.RegularExpressions;

using ConsoleUI.Model;

namespace ConsoleUI.Elements
{
    public class ActionButton : AbstractElement
    {
        public bool Enabled;
        private string Prefix;
        private string Shortcut;
        private string Suffix;

        public ActionButton(string id, bool visible, Point anchor, string text) : base(id, visible, anchor)
        {
            SetText(text);
        }

        public void SetText(string text)
        {
            Regex regex = new Regex(@"^([^[]*)\[([^]])](.*)$");
            MatchCollection matches = regex.Matches(text);
            Prefix = matches[0].Groups[1].Value + "[";
            Shortcut = matches[0].Groups[2].Value;
            Suffix = "]" + matches[0].Groups[3].Value;
        }

        public override void Render(Theme theme)
        {
            ConsoleUtil.WriteText(Prefix, Anchor, theme.Text, theme.Background);
            ConsoleUtil.WriteText(Suffix, Anchor.Offset(Prefix.Length + 1, 0), theme.Text, theme.Background);
            ConsoleUtil.WriteText(Shortcut, Anchor.Offset(Prefix.Length, 0), Enabled ? theme.ActionEnabled : theme.ActionDisabled, theme.Background);
        }
    }
}
