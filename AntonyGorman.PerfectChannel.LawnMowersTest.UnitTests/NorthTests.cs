using NUnit.Framework;

namespace AntonyGorman.PerfectChannel.LawnMowersTest.UnitTests
{
    [TestFixture]
    public class NorthTests
    {
        [TestCase(0, 0, 0, 1)]
        [TestCase(10, 3, 10, 4)]
        [TestCase(3, 6, 3, 7)]
        public void MoveAdds1ToPositionYAxis(int startingX, int startingY, int expectedX, int expectedY)
        {
            Assert.That(Orientation.North.Move(new Position(startingX, startingY)),
                Is.EqualTo(new Position(expectedX, expectedY)));
        }

        [TestCase("N", true)]
        [TestCase("n", true)]
        [TestCase("E", false)]
        [TestCase("W", false)]
        [TestCase("S", false)]
        public void IsMatchForTheLetterN(string literal, bool expectedIsMatchFor)
        {
            Assert.That(Orientation.North.IsMatchFor(literal), Is.EqualTo(expectedIsMatchFor));
        }

        [Test]
        public void LeftTurnsWest()
        {
            Assert.That(Orientation.North.Left(), Is.SameAs(Orientation.West));
        }

        [Test]
        public void RightTurnsEast()
        {
            Assert.That(Orientation.North.Right(), Is.SameAs(Orientation.East));
        }
    }
}