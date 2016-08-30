using System;
using NUnit.Framework;

namespace AntonyGorman.PerfectChannel.LawnMowersTest.UnitTests
{
    [TestFixture]
    public class FleetTests
    {
        [Test]
        public void InputsAreInterpretedAsGridSizeThenPairsOfLawnMowerInputs()
        {
            var input = "5 5" + Environment.NewLine +
                        "1 2 N" + Environment.NewLine +
                        "LMLMLMLMM" + Environment.NewLine +
                        "3 3 E" + Environment.NewLine +
                        "MMRMMRMRRM";

            var fleet = new Fleet(input);

            Assert.That(fleet.Lawn.Width, Is.EqualTo(5));
            Assert.That(fleet.Lawn.Height, Is.EqualTo(5));

            fleet.MowLawn();

            var expectedOutput = "1 3 N" + Environment.NewLine +
                                 "5 1 E";

            Assert.That(fleet.Output, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void ThrowsArgumentExceptionIfInputStringIsNotValid()
        {
            var invalidInput = "5 5" + Environment.NewLine +
                        "1 2 N" + Environment.NewLine;
            
            Assert.Throws<ArgumentException>(() => new Fleet(invalidInput));
        }
    }
}