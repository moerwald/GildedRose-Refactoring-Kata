using System;

namespace csharp.Items.Rules
{
    public sealed class UpdateConjuredItem : ChainableUpdateRule
    {
        public UpdateConjuredItem(IUpdateRule next) 
            : base(next, item => item is ConjuredItem)
        {
        }

        protected override Action<Item> HandleExecute()
            => item =>
            {
                --item.Quality;
                --item.Quality;

                --item.SellIn;

                if (item.SellIn >= 0) return;
                
                --item.Quality;
                --item.Quality;
            };

    }
}