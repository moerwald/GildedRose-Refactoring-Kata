using System;

namespace csharp.Items.Rules
{
    public class UpdateSulfuras : ChainableUpdateRule
    {
        public UpdateSulfuras(IUpdateRule next)
            : base(next, item => item.Name == "Sulfuras, Hand of Ragnaros")
        {
        }

        protected override Action<Item> HandleExecute() =>  i => { };
    }
}