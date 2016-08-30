using System;
using NUnit.Framework;

namespace AntonyGorman.PerfectChannel.LawnMowersTest.UnitTests
{
    [TestFixture]
    public class LawnTests
    {
        [TestCase("1 10", 1, 10)]
        [TestCase("5 4", 5, 4)]
        [TestCase("4 5", 4, 5)]
        public void FactoryMethodCreatesLawnWithWidthAndHeightMatchingSuppliedSizeString(string size,
            int expectedWidth,
            int expectedHeight)
        {
            var lawn = Lawn.CreateWith(size);

            Assert.That(lawn, Is.Not.Null);
            Assert.That(lawn.Width, Is.EqualTo(expectedWidth));
            Assert.That(lawn.Height, Is.EqualTo(expectedHeight));
        }

        [TestCase("123")]
        [TestCase("0 0")]
        [TestCase("")]
        [TestCase("-1 1")]
        [TestCase("1 -1")]
        [TestCase("-1 -1")]
        [TestCase("1 1 0")]
        [TestCase("not number")]
        public void FactoryMethodThrowsArgumentExceptionIfSizeStringInvalid(string invalidSize)
        {
            Assert.Throws<ArgumentException>(() => Lawn.CreateWith(invalidSize));
        }
    }
}