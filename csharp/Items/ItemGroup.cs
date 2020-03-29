using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp.Items.Rules;

namespace csharp.Items
{
    public class ItemGroup : IItem
    {
        private IEnumerable<Item> Items { get; }

        public ItemGroup(IEnumerable<Item> items)
        {
            Items = items;
        }

        public void Update(IUpdateRule rule)
        {

#if false
            foreach (var item in this.Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }

                // SellIn not reached
                if (item.Name == "Aged Brie")
                {
                    // Either Aged Brie or Backstage pass
                    ++item.Quality;

                    --item.SellIn;

                    if (item.SellIn < 0)
                    {
                        ++item.Quality;
                    }

                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    // Either Aged Brie or Backstage pass
                    ++item.Quality;

                    if (item.SellIn < 11)
                    {
                        ++item.Quality;
                    }

                    if (item.SellIn < 6)
                    {
                        ++item.Quality;
                    }

                    --item.SellIn;

                    if (item.SellIn < 0)
                    {
                        item.Quality = 0;
                    }
                }
                else
                {
                    // Any other item
                    --item.Quality;
                    --item.SellIn;
                    if (item.SellIn < 0)
                        --item.Quality;
                }
            }
#else
            _ = rule ?? throw new ArgumentNullException(nameof(rule));
            this.Items.ToList().ForEach(i =>  rule.GetRule(i)
                                                       .Invoke(i) );
#endif
        }
    }
}


