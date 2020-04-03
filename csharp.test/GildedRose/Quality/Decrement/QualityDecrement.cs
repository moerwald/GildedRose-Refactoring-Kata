using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using csharp.Items;
using csharp.Items.Rules.Factories;
using csharp.test.GildedRose.Quality.Decrement.TestCaseData;

namespace csharp.test.GildedRose.Quality.Decrement
{
    [TestFixture]
    public class QualityDecrement
    {
        [TestCaseSource(typeof(QualityDecreaseDataProvider), nameof(QualityDecreaseDataProvider.TestCases))]
        public void Test_Special_Quality_Descrease(
            Func<int, csharp.Quality> requiredQuality,
            Item item,
            string testDescription)
        {
            Console.WriteLine(testDescription);

            var app = new csharp.GildedRose(
                new ItemGroup(new List<Item>{item},
                    CreateDefaultRules.CreateWithConjuredRule()));

            var actQuality = new csharp.Quality(item.Quality);
            Enumerable.Range(1, item.SellIn).ToList().ForEach(i =>
            {
                app.UpdateQuality();

                actQuality = requiredQuality(actQuality);
                Assert.AreEqual(actQuality, (int)item.Quality);
            });
        }

        [Test]
        [Description("The Quality of an item is never negative")]
        public void Quality_Of_An_Item_Never_Gets_Negative()
        {
            var quality = new csharp.Quality(1);

            --quality;
            --quality;
            Assert.That(quality.Equals(0));
        }
    }
}
