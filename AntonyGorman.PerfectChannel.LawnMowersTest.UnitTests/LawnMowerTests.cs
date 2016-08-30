using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AntonyGorman.PerfectChannel.LawnMowersTest.UnitTests
{
    [TestFixture]
    public class LawnMowerTests
    {
        public static IEnumerable<TestCaseData> FactoryMethodExamples()
        {
            yield return new TestCaseData("1 1 S", new Position(1, 1), Orientation.South);
            yield return new TestCaseData("20 12 N", new Position(20, 12), Orientation.North);
            yield return new TestCaseData("3 5 E", new Position(3, 5), Orientation.East);
            yield return new TestCaseData("6 6 W", new Position(6, 6), Orientation.West);
        }

        [TestCaseSource(nameof(FactoryMethodExamples))]
        public void FactoryMethodCreatesLawnMowerAtSuppliedPositionAndOrientation(string positionAndOrientation,
            Position expectedPosition, Orientation expectedOrientation)
        {
            var lawnMower = LawnMower.CreateAt(positionAndOrientation);

            Assert.That(lawnMower, Is.Not.Null);
            Assert.That(lawnMower.Position, Is.EqualTo(expectedPosition));
            Assert.That(lawnMower.Orientation, Is.SameAs(expectedOrientation));
        }

        [TestCase("invalid")]
        [TestCase("-1 0 N")]
        [TestCase("0 0 G")]
        [TestCase("0 -1 W")]
        [TestCase("0 1 W E")]
        public void FactoryMethodThrowsArgumentExceptionForInvalidPositioAndOrientatioStrings(
            string invalidPositionAndOrientation)
        {
            Assert.Throws<ArgumentException>(() => LawnMower.CreateAt(invalidPositionAndOrientation));
        }

        [TestCase("0 10 W")]
        [TestCase("4 12 n")]
        [TestCase("0 1 E")]
        [TestCase("1 3 s")]
        public void OutputFormatsCurrentPositionAndOrientation(string positionAndOrientation)
        {
            Assert.That(LawnMower.CreateAt(positionAndOrientation).Output, Is.EqualTo(positionAndOrientation.ToUpper()));
        }

        [TestCase("1 2 N", "LMLMLMLMM", "1 3 N")]
        [TestCase("3 3 E", "MMRMMRMRRM", "5 1 E")]
        public void ExecuteMovesExecutesLeftRightAndMoveCommandsFromInputString(string initialPositionAndOrientation,
            string input, string expectedFinalOutput)
        {
            var lawnMower = LawnMower.CreateAt(initialPositionAndOrientation);

            lawnMower.ExecuteMoves(input);

            Assert.That(lawnMower.Output, Is.EqualTo(expectedFinalOutput));
        }
    }
}