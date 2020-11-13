using System;

using ConsoleUI;

using Encore.Model;

namespace Encore
{
    class Program
    {
        static void Main(string[] args)
        {
            /*if (args.Length > 0 && args[0] == "debug")
            {
                Config.Active = Config.Debug;
            }*/
            Context context = new Context
            {
                Theme = new Theme(),
                Config = new Config(),
                State = new GameState(),
                Messages = new TextList()
            };
            Game game = new Game(context);
            Console.BackgroundColor = context.Theme.Background;
            Console.Clear();
            Console.CursorVisible = false;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    game.Input(key.Key);
                }
                game.Tick();
            }
        }
    }
}
