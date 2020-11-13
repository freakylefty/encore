using ConsoleUI.Model;

namespace ConsoleUI.Elements
{
    public interface IConsoleElement
    {
        string Id { get; }
        Point Anchor { get; }
        bool Visible { get; set; }
        void Render(Theme theme);
    }
}
