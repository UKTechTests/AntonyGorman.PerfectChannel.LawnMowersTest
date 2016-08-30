using System;
using System.Collections.Generic;
using System.Linq;

namespace AntonyGorman.PerfectChannel.LawnMowersTest
{
    public abstract class Orientation
    {
        public static readonly Orientation North = new North();
        public static readonly Orientation East = new East();
        public static readonly Orientation South = new South();
        public static readonly Orientation West = new West();

        private static readonly IEnumerable<Orientation> Orientations = new[]
                                                                        {
                                                                            North,
                                                                            East,
                                                                            South,
                                                                            West
                                                                        };

        private readonly string literal;

        protected Orientation(string literal)
        {
            this.literal = literal;
        }

        public abstract Orientation Left();
        public abstract Orientation Right();
        public abstract Position Move(Position position);

        public bool IsMatchFor(string literal)
        {
            return (literal?.ToLowerInvariant().Equals(this.literal)).GetValueOrDefault();
        }

        public static Orientation Matching(string literal)
        {
            var orientation = Orientations.SingleOrDefault(or => or.IsMatchFor(literal));

            if (orientation == null)
            {
                throw new ArgumentException($"\"{literal}\" is not a valid Orientation");
            }

            return orientation;
        }

        public override string ToString() => literal.ToUpper();
    }
}