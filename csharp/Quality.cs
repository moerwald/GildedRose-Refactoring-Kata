using System;

namespace csharp
{
    public sealed class Quality : IEquatable<Quality>
    {
        public int Value { get; private set; }

        private const int MinQuality = 0;
        private const int MaxQuality = 80;
        public Quality(int initalValue)
        => Value = initalValue < MinQuality
            ? throw new ArgumentException($"{nameof(initalValue)} must be > {MinQuality}")
            : initalValue > MaxQuality
                ? throw new ArgumentException($"{nameof(initalValue)} must be < {MaxQuality}")
                : initalValue;

        // Below operators can bre removed after refactoring
        public static int operator +(Quality a, int b) => new Quality(a.Value + b).Value;
        public static int operator -(Quality a, int b) => new Quality(a.Value - b).Value;
        public static int operator -(int a, Quality b) => new Quality(a - b.Value).Value;
        public static int operator -(Quality a, Quality b) => new Quality(a.Value - b.Value).Value;

        public static Quality operator --(Quality quality)
            => new Quality(--quality.Value < 0 ? quality.Value : 0);
        public static Quality operator ++(Quality quality)
            => new Quality(++quality.Value);

        public static implicit operator int(Quality quality) => quality.Value;

        public static implicit operator Quality(int quality) => new Quality(quality);

        public override string ToString() => this.Value.ToString();


        public override bool Equals(object other)
        {
            if (other is Quality q)
                return this.Equals(q);

            if (other is int qInt)
                return this.Equals(qInt);

            return false;
        }

        public bool Equals(Quality other) =>
            other != null &&
            this.Value == other.Value;
        public bool Equals(int other) => this.Value == other;

        public override int GetHashCode() => this.Value.GetHashCode();
    }
}
