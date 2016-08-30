namespace AntonyGorman.PerfectChannel.LawnMowersTest
{
    public class North : Orientation
    {
        public North() : base("n")
        {
        }

        public override Orientation Left() => West;

        public override Orientation Right() => East;

        public override Position Move(Position position) => new Position(position.X, position.Y + 1);
    }
}