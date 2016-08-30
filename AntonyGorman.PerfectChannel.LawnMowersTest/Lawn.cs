using System;

namespace AntonyGorman.PerfectChannel.LawnMowersTest
{
    public class Lawn
    {
        private Size size;

        internal Lawn(Size size)
        {
            this.size = size;
        }

        public int Width => size.Width;

        public int Height => size.Height;

        public static Lawn CreateWith(string dimensionsLiteral)
        {
            return new Lawn(DimensionsFor(dimensionsLiteral));
        }

        private static Size DimensionsFor(string dimensionsLiteral)
        {
            var dimensionParts = dimensionsLiteral?.Split(' ');

            if (dimensionParts.Length != 2)
            {
                throw new ArgumentException(
                    "The dimension string can only contain 2 dimensionsLiteral separated by a space.",
                    nameof(dimensionsLiteral));
            }

            return new Size(DimensionFor(dimensionParts[0]), DimensionFor(dimensionParts[1]));
        }

        private static int DimensionFor(string part)
        {
            int dimension;

            if (!int.TryParse(part, out dimension) || dimension < 1)
            {
                throw new ArgumentException($"Dimension part \"{part}\" is not a valid dimension.", nameof(part));
            }

            return dimension;
        }
    }
}