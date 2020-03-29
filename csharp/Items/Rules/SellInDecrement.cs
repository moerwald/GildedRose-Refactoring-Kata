using System;

namespace csharp.Items.Rules
{
    public class SellInDecrement : ConditionalRule
    {
        public SellInDecrement(IUpdateRule next)
            : base(
                next,
                item => item.Name != "Sulfuras, Hand of Ragnaros",
                item => item.SellIn -= 1)
        {
        }
    }
}