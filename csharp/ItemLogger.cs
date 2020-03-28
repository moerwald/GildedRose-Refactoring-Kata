using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    public sealed class ItemLogger
    {
        public ItemLogger(IEnumerable<Item> items, IOutputWriter writer)
        {
            Items = items;
            Writer = writer;
        }

        public IEnumerable<Item> Items { get; }
        public IOutputWriter Writer { get; }

        private string GetDayTemplate() => "-------- day {0} --------\r\nname, sellIn, quality";

        public void DumpAllItemsForDay(int day)
        {
            Writer.Write(string.Format(GetDayTemplate(), day));

            Items.ToList().ForEach(item =>
            {
                Writer.WriteLine(item.ToString());
            });

            Writer.Write("");
        }
    }
}
