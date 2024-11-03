using FluentAssertions;
using System.Drawing;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.ContainerTests
{
    [TestSubject(typeof(ColourContainer))]
    public class AddColourTests
    {
        [Fact]
        public void AddColourShouldAddWhenCanAddColourReturnsTrue()
        {
            var container = new ColourContainer(3, 1);
            container.AddColour(KnownColor.Red);
            container.Slots.Should().ContainSingle().Which.Should().Be(KnownColor.Red);
        }

        [Fact]
        public void AddColourShouldNotAddColourWhenCanAddColourReturnsFalse()
        {
            var initialColors = new List<KnownColor> { KnownColor.Red, KnownColor.Blue };
            var container = new ColourContainer(3, 0, initialColors);
            container.AddColour(KnownColor.Green);
            container.Slots.Should().BeEquivalentTo(initialColors);
        }
    }
}