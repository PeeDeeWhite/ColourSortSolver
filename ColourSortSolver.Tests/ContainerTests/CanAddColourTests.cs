using FluentAssertions;
using System.Drawing;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.ContainerTests
{
    [TestSubject(typeof(Container))]
    public class CanAddColourTests
    {
        [Theory]
        [InlineData(KnownColor.Red)]
        [InlineData(KnownColor.Blue)]
        public void ContainerIsEmpty_CanAddAnyColour(KnownColor colour)
        {
            var container = new Container(3, 0);
            container.CanAddColour(colour).Should().BeTrue();
        }

        [Theory]
        [InlineData(KnownColor.Red, true)]
        [InlineData(KnownColor.Blue, false)]
        public void ContainerIsNotFull_AddOnlyMatchingColour(KnownColor colour, bool expected)
        {
            List<KnownColor> initialColors = [KnownColor.Red];
            var container = new Container(3, 0, initialColors);
            container.CanAddColour(colour).Should().Be(expected);
        }

        [Fact]
        public void ContainerIsFull_CannotAddColour()
        {
            List<KnownColor> initialColors = [KnownColor.Red, KnownColor.Red, KnownColor.Red];
            var container = new Container(3, 0, initialColors);
            container.CanAddColour(KnownColor.Red).Should().BeFalse();
        }
    }
}