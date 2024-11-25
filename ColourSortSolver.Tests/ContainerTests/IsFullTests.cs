using FluentAssertions;
using System.Drawing;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.ContainerTests
{
    [TestSubject(typeof(Container))]
    public class IsFullTests
    {
        [Fact]
        public void SlotsCountEqualsSize_ReturnTrue()
        {
            List<KnownColor> initialColors = [KnownColor.Red, KnownColor.Blue, KnownColor.Green];
            var container = new Container(3, 0, initialColors);
            container.IsFull.Should().BeTrue();
        }

        [Fact]
        public void SlotsCountLessThanSize_ReturnFalse()
        {
            List<KnownColor> initialColors = [KnownColor.Red, KnownColor.Blue];
            var container = new Container(3, 0, initialColors);
            container.IsFull.Should().BeFalse();
        }
    }
}