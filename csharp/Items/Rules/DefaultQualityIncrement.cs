namespace csharp.Items.Rules
{
    public class DefaultQualityIncrement : ChainableUpdateRule
    {
        public DefaultQualityIncrement(IUpdateRule next) : base(next)
        {
        }

        protected override void HandleExecute(Item item)
        {
            if (item.Quality >= 50) return;

            item.Quality++;

            if (item.Name != "Backstage passes to a TAFKAL80ETC concert") return;

            if (item.SellIn < 11)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
            }
            if (item.SellIn < 6)
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }
        }
    }
}