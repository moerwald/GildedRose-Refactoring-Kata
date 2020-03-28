using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace csharp.test.GildedRose.Quality.Increment.TestCaseData
{
    [TestFixture]
    public class QualityIncrement
    {
        [Test]
        [Description("Aged Brie actually increases in Quality the older it gets")]
        public void AgedBrie_Quality_Increases_Over_Time()
        {
            const int SellIn = 8;
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = SellIn, Quality = 0 } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            Enumerable.Range(1, SellIn).ToList().ForEach(i =>
            {
                app.UpdateQuality();
                Assert.AreEqual(i, (int)Items[0].Quality);
            }
            );
        }

        [Test]
        [TestCase(5, 10, 3, "Back stage passes increases by three")]
        [TestCase(10, 10, 2, "Back stage passes increases by two")]
        public void BackStage_Passes_Increment_When_SellIn_Is_Lower_10(int sellIn, int quality, int qualityIncrement, string description)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            Enumerable.Range(1, 4).Reverse().ToList().ForEach(i =>
            {
                app.UpdateQuality();
                quality += qualityIncrement;
                Assert.AreEqual(quality, (int)Items[0].Quality);
            });
        }


        [Test]
        [Description("The Quality of an item is never more than 50")]
        public void Quality_Never_Increases_Over_50()
        {
            var quality = new csharp.Quality(50);
            ++quality;
            Assert.That(quality.Equals(50));
        }

    }
}
