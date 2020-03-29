using System;

namespace csharp.Items.Rules
{
    public class ConditionalRule : ChainableUpdateRule
    {
        private readonly Func<Item, bool> _condition;
        private readonly Action<Item> _action;

        public ConditionalRule(IUpdateRule next, Func<Item, bool> condition, Action<Item> action) : base(next)
        {
            _condition = condition;
            _action = action;
        }

        protected override void HandleExecute(Item item)
        {
            if (_condition(item)) _action(item);
        }
    }
}