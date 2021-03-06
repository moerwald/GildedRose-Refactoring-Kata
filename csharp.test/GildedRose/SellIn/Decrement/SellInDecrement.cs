﻿using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using csharp.Items;
using csharp.Items.Rules.Factories;

namespace csharp.test.GildedRose.SellIn.Decrement
{
    [TestFixture]
    public class SellInDecrement
    {
        [Test]
        public void SellIn_Decreases_Over_Time()
        {
            var sellIn = 3;
            IList<Item> items = new List<Item>
                {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 50}};
            var app = new csharp.GildedRose(new ItemGroup(items, CreateDefaultRules.CreateWithConjuredRule()));
            Enumerable.Range(1, sellIn).ToList().ForEach(i =>
            {
                app.UpdateQuality();
                Assert.AreEqual(--sellIn, items[0].SellIn);
            });
        }
    }
}
