using System;

namespace csharp.Items.Rules
{
    public abstract class ChainableUpdateRule : IUpdateRule
    {
        private readonly IUpdateRule _next;

        protected Action<Item> actionToInvoke;

        protected ChainableUpdateRule(IUpdateRule next)
        {
            _next = next;
        }

        protected void Forward(Item item) => this._next.GetRule(item);

        public Action<Item> GetRule(Item item)
        {
            actionToInvoke = null;
            this.HandleExecute(item);
            return actionToInvoke ?? (actionToInvoke = this._next.GetRule(item));
        }

        protected abstract void HandleExecute(Item item);
    }

    public class UpdateSulfuras : ChainableUpdateRule
    {
        public UpdateSulfuras(IUpdateRule next) : base(next)
        {
        }

        protected override void HandleExecute(Item item)
        {

            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                // Nothing to do
                actionToInvoke = i => { };
            }
        }
    }

    public class UpdateAgedBrie : ChainableUpdateRule
    {
        public UpdateAgedBrie(IUpdateRule next) : base(next)
        {
        }

        protected override void HandleExecute(Item item)
        {

            if (item.Name == "Aged Brie")
            {
                actionToInvoke = i =>
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
    }

    public class UpdateBackStagePass : ChainableUpdateRule
    {
        public UpdateBackStagePass(IUpdateRule next) : base(next)
        {
        }

        protected override void HandleExecute(Item item)
        {
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                actionToInvoke = i =>
                {
                    // Either Aged Brie or Backstage pass
                    ++item.Quality;

                    if (item.SellIn < 11)
                    {
                        ++item.Quality;
                    }

                    if (item.SellIn < 6)
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
    }

    public class UpdateDefaultImplementation : ChainableUpdateRule
    {
        public UpdateDefaultImplementation(IUpdateRule next) : base(next)
        {
        }

        protected override void HandleExecute(Item item)
        {
            actionToInvoke = i =>
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
}