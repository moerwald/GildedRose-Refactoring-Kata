using System;

namespace csharp.Items.Rules
{
    public class UpdateAgedBrie : ChainableUpdateRule
    {
        public UpdateAgedBrie(IUpdateRule next) : base(next, item => item.Name == "Aged Brie")
        {
        }

        protected override Action<Item> HandleExecute()
            => item =>
            {
                ++item.Quality;

                --item.SellIn;

                if (item.SellIn < 0)
                {
                    ++item.Quality;
                }
            };
    }
}