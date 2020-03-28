using System;

namespace csharp.test.GildedRose.Quality.Decrement.TestCaseData
{
    public class SpecialQualityDecrease : NUnit.Framework.TestCaseData
    {
        public SpecialQualityDecrease(
            Func<int, int> getRequiredQuality,
            int initialQuality,
            int sellIn,
            string itemName,
            string testCaseDescription)
            : base(getRequiredQuality, initialQuality, sellIn, itemName, testCaseDescription)
        {
        }
    }
}
