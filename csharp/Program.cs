using System;
using System.Collections.Generic;
using System.Linq;
using csharp.Items;
using csharp.Items.Rules.Factories;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var Items = ItemFactory.Instance.Create();

            var enumerable = Items.ToList();
            var app = new GildedRose( new ItemGroup(enumerable, CreateDefaultRules.Create()));
            var logger = new ItemLogger(
                new List<Item>(enumerable),
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
