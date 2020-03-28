using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using csharp.Items;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var Items = ItemFactory.Instance.Create();

            var app = new GildedRose(Items);
            var logger = new ItemLogger(
                new List<Item>(Items),
                new OutputWriter());

            ForeachDay(
                day => logger.DumpAllItemsForDay(day),
                () => app.UpdateQuality());
        }
        private static void ForeachDay(
            Action<int> dumpAllItems,
            Action updateQuality
            )
            =>
            Enumerable.Range(0, 31).ToList().ForEach(d =>
             {
                 dumpAllItems(d);
                 updateQuality();
             });
    }
}
