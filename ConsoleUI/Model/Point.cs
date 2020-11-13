namespace ConsoleUI.Model
{
    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point Offset(int offX, int offY)
        {
            return new Point(X + offX, Y + offY);
        }
    }
}
