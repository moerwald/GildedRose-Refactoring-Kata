using csharp.Items;

namespace csharp
{


    public class GildedRose
    {
        private ItemGroup Items { get; }

        public GildedRose(ItemGroup items) => Items = items; 


        public void UpdateQuality() => this.Items.Update();
    }
}
