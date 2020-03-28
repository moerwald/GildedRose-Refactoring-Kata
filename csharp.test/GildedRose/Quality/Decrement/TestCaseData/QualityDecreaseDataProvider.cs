using System;
using System.Collections;

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
                    50, 
                    8, 
                    "Sulfuras, Hand of Ragnaros",
                    "Sulfuras quality never decreases");
                yield return new SpecialQualityDecrease(
                    (quality) => quality - 2,
                    50,
                    0,
                    "Some item",
                    "Quality Shall Degrade Twice As Fast After SellIn Has Passed"); 
                yield return new SpecialQualityDecrease(
                    (quality) => 0,
                    50,
                    0,
                    "Backstage passes to a TAFKAL80ETC concert",
                    "Backstage Passes Quality Falls To Zero After SellIn Was Reached"); 
            }
        }
    }
}
