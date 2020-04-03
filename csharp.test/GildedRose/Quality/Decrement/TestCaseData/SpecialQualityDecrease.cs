using System;
using System.Collections;
using System.Collections.Generic;
using csharp.Items;

namespace csharp.test.GildedRose.Quality.Decrement.TestCaseData
{
    public class SpecialQualityDecrease : NUnit.Framework.TestCaseData
    {

#if false
        public SpecialQualityDecrease(
            Func<int, int> getRequiredQuality,
            int initialQuality,
            int sellIn,
            string itemName,
            string testCaseDescription)
            : base(getRequiredQuality, initialQuality, sellIn, itemName, testCaseDescription)
        {
        }
#endif

        public SpecialQualityDecrease(
            Func<int, csharp.Quality> getRequiredQuality,
            Item item,
            string testCaseDescription)
            : base(getRequiredQuality, item, testCaseDescription)
        {
        }
    }
}
