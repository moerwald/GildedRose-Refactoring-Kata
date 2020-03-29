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

        public void Update( IUpdateRule rule )
        {
            rule.Execute(this);
#if useOldCode
            // SellIn not reached
            // Default quality decrement
            if (this.Name != "Aged Brie" && this.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
//                if (this.Quality > 0)
                {
                    if (this.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        this.Quality = this.Quality - 1;
                    }
                }
            }
            else
            {
                // Increment quality
                if (this.Quality < 50)
                {
                    this.Quality = this.Quality + 1;

                    if (this.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (this.SellIn < 11)
                        {
                            if (this.Quality < 50)
                            {
                                this.Quality = this.Quality + 1;
                            }
                        }

                            if (this.SellIn < 6)
                            {
                                if (this.Quality < 50)
                                {
                                    this.Quality = this.Quality + 1;
                                }
                            }
                    }
                }
            }

            // SellIn releated command
            if (this.Name != "Sulfuras, Hand of Ragnaros")
            {
                this.SellIn = this.SellIn - 1;
            }

            // SellIn reached
            if (this.SellIn < 0)
            {
                if (this.Name != "Aged Brie")
                {
                    if (this.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (this.Quality > 0)
                        {
                            if (this.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                this.Quality = this.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        this.Quality = this.Quality - this.Quality;
                    }
                }
                else
                {
                    if (this.Quality < 50)
                    {
                        this.Quality = this.Quality + 1;
                    }
                }
            }
#endif
        }
    }
}

