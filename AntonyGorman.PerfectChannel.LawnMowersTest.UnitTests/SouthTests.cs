using NUnit.Framework;

namespace AntonyGorman.PerfectChannel.LawnMowersTest.UnitTests
{
    [TestFixture]
    public class SouthTests
    {
        [TestCase(0, 1, 0, 0)]
        [TestCase(10, 3, 10, 2)]
        [TestCase(3, 6, 3, 5)]
        public void MoveSubtracts1FromPositionYAxis(int startingX, int startingY, int expectedX, int expectedY)
        {
            Assert.That(Orientation.South.Move(new Position(startingX, startingY)),
                Is.EqualTo(new Position(expectedX, expectedY)));
        }

        [TestCase("s", true)]
        [TestCase("S", true)]
        [TestCase("E", false)]
        [TestCase("W", false)]
        [TestCase("N", false)]
        public void IsMatchForTheLetterS(string literal, bool expectedIsMatchFor)
        {
            Assert.That(Orientation.South.IsMatchFor(literal), Is.EqualTo(expectedIsMatchFor));
        }

        [Test]
        public void LeftTurnsEast()
        {
            Assert.That(Orientation.South.Left(), Is.SameAs(Orientation.East));
        }

        [Test]
        public void RightTurnsẀest()
        {
            Assert.That(Orientation.South.Right(), Is.SameAs(Orientation.West));
        }
    }
}