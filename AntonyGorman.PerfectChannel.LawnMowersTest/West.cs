namespace AntonyGorman.PerfectChannel.LawnMowersTest
{
    public class West : Orientation
    {
        public West() : base("w")
        {
        }

        public override Orientation Left() => South;

        public override Orientation Right() => North;

        public override Position Move(Position position) => new Position(position.X - 1, position.Y);
    }
}