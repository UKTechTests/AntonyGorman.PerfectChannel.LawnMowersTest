using NUnit.Framework;

namespace AntonyGorman.PerfectChannel.LawnMowersTest.UnitTests
{
    [TestFixture]
    public class WestTests
    {
        [TestCase(1, 1, 0, 1)]
        [TestCase(10, 3, 9, 3)]
        [TestCase(3, 6, 2, 6)]
        public void MoveSubtracts1FromPositionXAxis(int startingX, int startingY, int expectedX, int expectedY)
        {
            Assert.That(Orientation.West.Move(new Position(startingX, startingY)),
                Is.EqualTo(new Position(expectedX, expectedY)));
        }

        [TestCase("W", true)]
        [TestCase("w", true)]
        [TestCase("E", false)]
        [TestCase("S", false)]
        [TestCase("N", false)]
        public void IsMatchForTheLetterW(string literal, bool expectedIsMatchFor)
        {
            Assert.That(Orientation.West.IsMatchFor(literal), Is.EqualTo(expectedIsMatchFor));
        }

        [Test]
        public void LeftTurnsSouth()
        {
            Assert.That(Orientation.West.Left(), Is.SameAs(Orientation.South));
        }

        [Test]
        public void RightTurnsNorth()
        {
            Assert.That(Orientation.West.Right(), Is.SameAs(Orientation.North));
        }
    }
}