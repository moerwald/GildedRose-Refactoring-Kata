using System.Collections;
using System.Collections.Generic;
using csharp.Items;
using csharp.Items.Rules.Factories;

namespace csharp
{


    public class GildedRose
    {
        private ItemGroup Items { get; }

        public GildedRose(ItemGroup items) => Items = items; 


        public void UpdateQuality() => this.Items.Update();
    }
}
