using FluentAssertions;
using System.Drawing;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.ContainerTests
{
    [TestSubject(typeof(Container))]
    public class IsFullTests
    {
        [Fact]
        public void IsFull_ShouldReturnTrue_WhenSlotsCountEqualsSize()
        {
            var initialColors = new List<KnownColor> { KnownColor.Red, KnownColor.Blue, KnownColor.Green };
            var container = new Container(3, 0, initialColors);
            container.IsFull.Should().BeTrue();
        }

        [Fact]
        public void IsFull_ShouldReturnFalse_WhenSlotsCountLessThanSize()
        {
            var initialColors = new List<KnownColor> { KnownColor.Red, KnownColor.Blue };
            var container = new Container(3, 0, initialColors);
            container.IsFull.Should().BeFalse();
        }
    }
}