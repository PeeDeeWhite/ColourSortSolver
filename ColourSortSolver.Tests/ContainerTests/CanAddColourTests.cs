using FluentAssertions;
using System.Drawing;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.ContainerTests
{
    [TestSubject(typeof(Container))]
    public class CanAddColourTests
    {
        [Theory]
        [InlineData(KnownColor.Red, true)]
        [InlineData(KnownColor.Blue, true)]
        public void CanAddColourShouldReturnExpectedResultWhenContainerIsEmpty(KnownColor colour, bool expected)
        {
            var container = new Container(3, 0);
            container.CanAddColour(colour).Should().Be(expected);
        }

        [Theory]
        [InlineData(KnownColor.Red, true)]
        [InlineData(KnownColor.Blue, false)]
        public void CanAddColourShouldReturnExpectedResultWhenContainerIsNotFullAndLastColourMatches(KnownColor colour, bool expected)
        {
            var initialColors = new List<KnownColor> { KnownColor.Red };
            var container = new Container(3, 0, initialColors);
            container.CanAddColour(colour).Should().Be(expected);
        }

        [Fact]
        public void CanAddColourShouldReturnFalse_WhenContainerIsFull()
        {
            var initialColors = new List<KnownColor> { KnownColor.Red, KnownColor.Red, KnownColor.Red };
            var container = new Container(3, 0, initialColors);
            container.CanAddColour(KnownColor.Red).Should().BeFalse();
        }
    }
}