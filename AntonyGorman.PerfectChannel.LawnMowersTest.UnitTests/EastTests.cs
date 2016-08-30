using NUnit.Framework;

namespace AntonyGorman.PerfectChannel.LawnMowersTest.UnitTests
{
    [TestFixture]
    public class EastTests
    {
        [TestCase(0, 0, 1, 0)]
        [TestCase(10, 3, 11, 3)]
        [TestCase(3, 6, 4, 6)]
        public void MoveAdds1ToPositionXAxis(int startingX, int startingY, int expectedX, int expectedY)
        {
            Assert.That(Orientation.East.Move(new Position(startingX, startingY)),
                Is.EqualTo(new Position(expectedX, expectedY)));
        }

        [TestCase("E", true)]
        [TestCase("e", true)]
        [TestCase("W", false)]
        [TestCase("S", false)]
        [TestCase("N", false)]
        public void IsMatchForTheLetterE(string literal, bool expectedIsMatchFor)
        {
            Assert.That(Orientation.East.IsMatchFor(literal), Is.EqualTo(expectedIsMatchFor));
        }

        [Test]
        public void LeftTurnsNorth()
        {
            Assert.That(Orientation.East.Left(), Is.SameAs(Orientation.North));
        }

        [Test]
        public void RightTurnsSouth()
        {
            Assert.That(Orientation.East.Right(), Is.SameAs(Orientation.South));
        }
    }
}