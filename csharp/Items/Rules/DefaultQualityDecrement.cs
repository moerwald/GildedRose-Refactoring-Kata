namespace csharp.Items.Rules
{
    public class DefaultQualityDecrement : ChainableUpdateRule
    {
        public DefaultQualityDecrement(IUpdateRule next) : base(next)
        {
        }

        protected override void HandleExecute(Item item)
        {
            if (item.Name == "Aged Brie" ||
                item.Name == "Backstage passes to a TAFKAL80ETC concert" ||
                item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return;
            }

            item.Quality--;
        }
    }
}