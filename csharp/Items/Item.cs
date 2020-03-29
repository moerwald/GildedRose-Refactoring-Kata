using csharp.Items.Rules;

namespace csharp.Items
{
    /// <summary>
    ///  Data object only, no behaviour
    /// </summary>
    public sealed class Item : IItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public Quality Quality { get; set; }

        public override string ToString() => this.Name + ", " + this.SellIn + ", " + this.Quality;

        public void Update( ) { }
    }
}

