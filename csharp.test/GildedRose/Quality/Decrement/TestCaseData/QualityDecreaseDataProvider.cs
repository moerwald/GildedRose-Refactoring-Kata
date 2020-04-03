using System.Collections.Generic;
using System.Collections;
using csharp.Items;

namespace csharp.test.GildedRose.Quality.Decrement.TestCaseData
{
    public class QualityDecreaseDataProvider
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new SpecialQualityDecrease(
                    (quality) => 50,
              new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 8, Quality = 50 },
                "Sulfuras, being a legendary item, never has to be sold or decreases in Quality");

                yield return new SpecialQualityDecrease(
                    (quality) => quality - 2,
              new Item { Name = "Some item", SellIn = 0, Quality = 50 },
                    "Once the sell by date has passed, Quality degrades twice as fast");

                yield return new SpecialQualityDecrease(
                    (quality) => 0,
              new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 50 },
                    "Backstage Passes Quality Falls To Zero After SellIn Was Reached");

                yield return new SpecialQualityDecrease(
                    (quality) => quality - 2,
              new ConjuredItem { Name = "Conjured Item", SellIn = 50, Quality = 50 },
                    "Quality of conjured items decreases twice as fast");
            }
        }
    }
}
