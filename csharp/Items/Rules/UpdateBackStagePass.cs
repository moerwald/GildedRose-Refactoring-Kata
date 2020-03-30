using System;

namespace csharp.Items.Rules
{
    public class UpdateBackStagePass : ChainableUpdateRule
    {
        public UpdateBackStagePass(IUpdateRule next)
            : base(next, item => item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
        }

        protected override Action<Item> HandleExecute()
            => item =>
            {
                ++item.Quality;

                if (item.SellIn <= 10)
                {
                    ++item.Quality;
                }

                if (item.SellIn <= 5)
                {
                    ++item.Quality;
                }

                --item.SellIn;

                if (item.SellIn < 0)
                {
                    item.Quality = 0;
                }
            };
    }
}