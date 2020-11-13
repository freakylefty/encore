using System.Collections.Generic;

namespace Encore.Model
{
    class TextList
    {
        public int MaxItems = 4;
        public List<string> Items = new List<string>();

        public void Add(string value)
        {
            if (Items.Count >= MaxItems)
            {
                Items.RemoveAt(MaxItems - 1);
            }
            Items.Insert(0, value);
        }
    }
}
