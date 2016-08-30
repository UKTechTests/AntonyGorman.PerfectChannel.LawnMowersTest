namespace AntonyGorman.PerfectChannel.LawnMowersTest
{
    public class South : Orientation
    {
        public South() : base("s")
        {
        }

        public override Orientation Left() => East;

        public override Orientation Right() => West;

        public override Position Move(Position position) => new Position(position.X, position.Y - 1);
    }
}