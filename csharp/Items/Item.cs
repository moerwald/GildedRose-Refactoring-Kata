using System;
using csharp.Items.Rules;

namespace csharp.Items
{
    /// <summary>
    ///  Data object only, no behaviour
    /// </summary>
    public class Item : IEquatable<Item>
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public Quality Quality { get; set; }

        public override string ToString() => this.Name + ", " + this.SellIn + ", " + this.Quality;

        public bool Equals(Item other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && SellIn == other.SellIn && Equals(Quality, other.Quality);
        }

        public override bool Equals(object obj) => ReferenceEquals(this, obj) || obj is Item other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ this.SellIn;
                hashCode = (hashCode * 397) ^ Quality?.GetHashCode() ?? 0;
                return hashCode;
            }
        }

        public static bool operator ==(Item left, Item right) =>  Equals(left, right);

        public static bool operator !=(Item left, Item right) => !Equals(left, right);
    }
}

