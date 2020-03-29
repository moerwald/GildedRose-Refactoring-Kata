using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using csharp.Items;
using csharp.Items.Rules.Factories;

namespace csharp.test.GildedRose.Quality.Increment
{
    [TestFixture]
    public class QualityIncrement
    {
        [Test]
        [Description("Aged Brie actually increases in Quality the older it gets")]
        public void AgedBrie_Quality_Increases_Over_Time()
        {
            const int sellIn = 8;
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellIn, Quality = 0 } };
            csharp.GildedRose app = new csharp.GildedRose(new ItemGroup(items, CreateDefaultRules.Create()));
            Enumerable.Range(1, sellIn).ToList().ForEach(i =>
            {
                app.UpdateQuality();
                Assert.AreEqual(i, (int)items[0].Quality);
            }
            );
        }

        [Test]
        [TestCase(5, 10, 3, "Back stage passes increases by three")]
//        [TestCase(10, 10, 2, "Back stage passes increases by two")]
        public void BackStage_Passes_Increment_When_SellIn_Is_Lower_10(int sellIn, int quality, int qualityIncrement, string description)
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };
            csharp.GildedRose app = new csharp.GildedRose( new ItemGroup(items, CreateDefaultRules.Create()));
            Enumerable.Range(1, 4).Reverse().ToList().ForEach(i =>
            {
                app.UpdateQuality();
                quality += qualityIncrement;
                Assert.AreEqual(quality, (int)items[0].Quality);
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
