﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp.test.GildedRose.Quality.Decrement.TestCaseData
{
    [TestFixture]
    public class QualityDecrement
    {
        [TestCaseSource(typeof(QualityDecreaseDataProvider), nameof(QualityDecreaseDataProvider.TestCases))]
        public void Test_Special_Quality_Descrease(
            Func<int, int> requriedQuality,
            int initalQuality,
            int sellIn,
            string itemName,
            string testDescription)
        {
            Console.WriteLine(testDescription);

            int actQuality = 0;
            
            IList<Item> Items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = initalQuality } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            Enumerable.Range(1, sellIn).ToList().ForEach(i =>
            {
                app.UpdateQuality();

                actQuality = requriedQuality(actQuality);
                Assert.AreEqual(actQuality, (int)Items[0].Quality);
            });
        }
    }
}
