namespace AntonyGorman.PerfectChannel.LawnMowersTest
{
    public class East : Orientation
    {
        public East() : base("e")
        {
        }

        public override Orientation Left() => North;

        public override Orientation Right() => South;

        public override Position Move(Position position) => new Position(position.X + 1, position.Y);
    }
}