using FluentAssertions;
using System.Drawing;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.ContainerTests
{
    [TestSubject(typeof(ColourContainer))]
    public class IsEmptyTests
    {
        [Fact]
        public void IsEmptyShouldReturnTrueWhenSlotsCountIsZero()
        {
            var container = new ColourContainer(3, 0);
            container.IsEmpty.Should().BeTrue();
        }

        [Fact]
        public void IsEmptyShouldReturnFalseWhenSlotsCountIsGreaterThanZero()
        {
            var initialColors = new List<KnownColor> { KnownColor.Red };
            var container = new ColourContainer(3, 0, initialColors);
            container.IsEmpty.Should().BeFalse();
        }

    }
}