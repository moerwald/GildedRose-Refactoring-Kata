using System;

namespace csharp
{
    public sealed class Quality : IEquatable<Quality>
    {
        private int Value { get; set; }

        private const int MinQuality = -1;
        private int MaxQuality;

        public Quality(int initialValue, int maxQuality)
        {
            MaxQuality = maxQuality + 1;
            Value = initialValue < MinQuality
                ? throw new ArgumentException($"{nameof(initialValue)} must be > {MinQuality}. Act value: {initialValue}")
                : initialValue > MaxQuality
                    ? throw new ArgumentException($"{nameof(initialValue)} must be < {MaxQuality}")
                    : initialValue;
        }

        public Quality(int initialValue)
            : this(initialValue, 50)
        {
        }

        public static Quality operator --(Quality quality)
            => new Quality(--quality.Value < 0 ? 0 : quality.Value);
        public static Quality operator ++(Quality quality)
            => new Quality(++quality.Value >= 50 ? 50 : quality.Value);

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
