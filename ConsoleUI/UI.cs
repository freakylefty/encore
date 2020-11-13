using System;
using System.Collections.Generic;

using ConsoleUI.Elements;

namespace ConsoleUI
{
    public class UI
    {
        public List<IConsoleElement> Elements;
        public Theme Theme;

        public UI()
        {
            Elements = new List<IConsoleElement>();
        }

        public IConsoleElement GetElement(string id)
        {
            foreach (IConsoleElement element in Elements)
            {
                if (id == element.Id)
                {
                    return element;
                }
            }
            return null;
        }

        public void SetTextElement(string id, string text)
        {
            foreach (IConsoleElement element in Elements)
            {
                if (id == element.Id && element is Text)
                {
                    ((Text)element).Value = text;
                    return;
                }
            }
        }

        public void SetSpinnerProgress(string id, int percent)
        {
            foreach (IConsoleElement element in Elements)
            {
                if (id == element.Id && element is Spinner)
                {
                    ((Spinner)element).Percent = percent;
                    return;
                }
            }
        }

        public void SetSpinnerProgress(string id, int curr, int max)
        {
            //(int)Math.Round(((double)rollTimer.ElapsedMilliseconds / (double)context.Config.RollRate) * 100.0)
            SetSpinnerProgress(id, (int)Math.Round(((double)curr / (double)max) * 100.0));
        }

        public void UpdateActionButton(string id, bool state)
        {
            foreach (IConsoleElement element in Elements)
            {
                if (id == element.Id && element is ActionButton)
                {
                    ((ActionButton)element).Enabled = state;
                    return;
                }
            }
        }

        public void SetVisible(string id, bool state)
        {
            foreach (IConsoleElement element in Elements)
            {
                if (id == element.Id)
                {
                    element.Visible = state;
                }
            }
        }

        public void Render()
        {
            foreach (IConsoleElement element in Elements)
            {
                if (element.Visible)
                {
                    element.Render(Theme);
                }
            }
        }
    }
}
