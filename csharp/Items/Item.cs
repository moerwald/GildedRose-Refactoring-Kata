namespace csharp.Items
{

    public sealed class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public Quality Quality { get; set; }

        public override string ToString() => this.Name + ", " + this.SellIn + ", " + this.Quality;
    }
}

