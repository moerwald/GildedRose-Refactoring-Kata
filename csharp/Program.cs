﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

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
