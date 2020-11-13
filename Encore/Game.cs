using System;
using System.Diagnostics;

using ConsoleUI;
using ConsoleUI.Elements;
using ConsoleUI.Model;

using Encore.Formatter;
using Encore.Model;

namespace Encore
{
    class Game
    {
        private Context context;
        private Stopwatch inputTimer;
        private Stopwatch rollTimer;
        private UI ui;

        public Game(Context context)
        {
            this.context = context;
            context.State.AddCore();
            context.State.AddCore();
            inputTimer = new Stopwatch();
            rollTimer = new Stopwatch();
            inputTimer.Start();
            rollTimer.Start();
            ui = new UI();
            ui.Theme = context.Theme;
            ui.Elements.Add(new Header("header", true, new Point(0, 0), "Encore", Decoration.Underline, 6));
            ui.Elements.Add(new Spinner("rollSpinner", true, new Point(0, 3), 0, Spinner.SpinnerStyle.Clock));
            ui.Elements.Add(new Text("rollText", true, new Point(2, 3), "Rolling every " + Formatters.Simple.Format(context.Config.RollRate) + "ms"));
            ui.Elements.Add(new MessageList("messages", true, new Point(0, Console.WindowHeight - 2), context.Messages.Items, Align.Bottom));
            ui.Elements.Add(new Text("opsText", true, new Point(0, 4), "Ops: " + context.Config.Formatter.Format(context.State.Ops)));
            ui.Elements.Add(new Header("coresHeader", true, new Point(0, 6), "Cores", Decoration.Strike, 10));
            ui.Elements.Add(new Text("bus1Text", true, new Point(0, 7), context.State.Cores[0].Bus + "", 1));
            ui.Elements.Add(new ActionButton("core1Button", true, new Point(2, 7), "[1]"));
            ui.Elements.Add(new Text("bus2Text", true, new Point(0, 8), context.State.Cores[1].Bus + "", 1));
            ui.Elements.Add(new ActionButton("core2Button", true, new Point(2, 8), "[2]"));
        }

        public void Input(ConsoleKey key)
        {
            if (key == ConsoleKey.Q || key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            if (inputTimer.ElapsedMilliseconds < context.Config.InputRate)
            {
                return;
            }
            inputTimer.Restart();
        }

        public void Tick()
        {
            if (rollTimer.ElapsedMilliseconds >= context.Config.RollRate)
            {
                rollTimer.Restart();
                context.State.Tick();
                ui.SetTextElement("opsText", "Ops: " + context.Config.Formatter.Format(context.State.Ops));
                ((ActionButton)ui.GetElement("core1Button")).SetText("[1] " + context.State.Cores[0].Format(context.Config.Formatter));
                ((ActionButton)ui.GetElement("core2Button")).SetText("[2] " + context.State.Cores[1].Format(context.Config.Formatter));
            }
            Render();
        }

        private void Render()
        {
            ui.SetSpinnerProgress("rollSpinner", (int)rollTimer.ElapsedMilliseconds, context.Config.RollRate);
            ui.Render();
        }

    }
}
