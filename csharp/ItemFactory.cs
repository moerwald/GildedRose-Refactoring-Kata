using System.Collections.Generic;
using csharp.Items;

namespace csharp
{
    public class ItemFactory
    {
        public static ItemFactory Instance => new ItemFactory();

        public IEnumerable<Item> Create()
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = new Quality(80, 80)},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality =new Quality(80, 80)},
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
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
                new ConjuredItem {Name = "Conjured Item", SellIn = 10, Quality = 20},
            };
            return items;
        }
    }
}