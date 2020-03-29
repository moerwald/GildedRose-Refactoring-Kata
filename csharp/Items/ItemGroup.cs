using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp.Items.Rules;

namespace csharp.Items
{
    public class ItemGroup : IItem
    {
        private IEnumerable<Item> Items { get; }
        private IUpdateRule Rule { get; }

        public ItemGroup(IEnumerable<Item> items, IUpdateRule rule)
        {
            Items = items;
            Rule = rule;
        }

        public void Update() => this.Items.ToList().ForEach(i => Rule.GetRule(i) .Invoke(i) );
    }
}


