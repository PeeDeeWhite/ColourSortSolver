using FluentAssertions;
using System.Drawing;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.ContainerTests
{
    [TestSubject(typeof(Container))]
    public class IsEmptyTests
    {
        [Fact]
        public void SlotsCountIsZero_ReturnTrue()
        {
            var container = new Container(3, 0);
            container.IsEmpty.Should().BeTrue();
        }

        [Fact]
        public void SlotsCountIsGreaterThanZero_ReturnFalse()
        {
            List<KnownColor> initialColors = [KnownColor.Red];
            var container = new Container(3, 0, initialColors);
            container.IsEmpty.Should().BeFalse();
        }

    }
}