using System;

namespace csharp.Items.Rules
{
    public class UpdateDefaultImplementation : ChainableUpdateRule
    {
        public UpdateDefaultImplementation(IUpdateRule next) : base(next, item => true)
        {
        }

        protected override Action<Item> HandleExecute()
            => item =>
            {
                --item.Quality;
                --item.SellIn;
                if (item.SellIn < 0)
                {
                    --item.Quality;
                }
            };
    }
}