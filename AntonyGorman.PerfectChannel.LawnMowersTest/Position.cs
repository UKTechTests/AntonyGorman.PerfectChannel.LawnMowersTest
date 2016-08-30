namespace AntonyGorman.PerfectChannel.LawnMowersTest
{
    public struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public override bool Equals(object obj)
        {
            return obj is Position &&
                   GetHashCode().Equals(obj.GetHashCode());
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashcode = X.GetHashCode();

                hashcode = hashcode*13 + Y.GetHashCode();

                return hashcode;
            }
        }

        public override string ToString()
        {
            return $"{X} {Y}";
        }
    }
}