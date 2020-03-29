using System;

namespace csharp.Items.Rules
{
    public class DummyRule : ChainableUpdateRule
    {

        protected override void HandleExecute(Item item)
        {
        }

        public DummyRule(IUpdateRule next) : base(next)
        {
        }
    }
}