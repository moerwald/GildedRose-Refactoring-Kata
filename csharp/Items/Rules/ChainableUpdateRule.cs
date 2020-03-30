using System;

namespace csharp.Items.Rules
{
    public abstract class ChainableUpdateRule : IUpdateRule
    {
        private readonly IUpdateRule _next;
        private readonly Func<Item, bool> _predicate;

        protected ChainableUpdateRule(IUpdateRule next, Func<Item, bool> predicate)
        {
            _next = next;
            _predicate = predicate;
        }

        protected void Forward(Item item) => this._next.GetRule(item);

        public Action<Item> GetRule(Item item) => this._predicate(item) ? this.HandleExecute() : this._next.GetRule(item);

        protected abstract Action<Item> HandleExecute();
    }
}