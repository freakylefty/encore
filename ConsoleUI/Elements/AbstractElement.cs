using System;

using ConsoleUI.Model;

namespace ConsoleUI.Elements
{
    public abstract class AbstractElement : IConsoleElement
    {
        public string Id { get; set; }
        public bool Visible { get; set; }
        public Point Anchor { get; set; }

        protected AbstractElement(string id, bool visible, Point anchor)
        {
            Id = id;
            Visible = visible;
            Anchor = anchor;
        }

        public abstract void Render(Theme theme);
        
        protected static int GetWidth(int width, Point anchor)
        {
            return (width > 0 ? width : Console.WindowWidth) - anchor.X;
        }
    }
}
