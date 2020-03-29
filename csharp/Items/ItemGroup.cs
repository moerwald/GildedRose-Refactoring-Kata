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
        private IEnumerable<Item> Items { get;  }

        public ItemGroup(IEnumerable<Item> items)
        {
            Items = items;
        }

        public void Update(IUpdateRule rule) 
        {
            foreach (var item in this.Items) item.Update(rule);
        }
    }
}
