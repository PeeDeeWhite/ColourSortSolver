using FluentAssertions;
using JetBrains.Annotations;
using System.Drawing;

namespace ColourSortSolver.Tests.ContainerTests
{
    [TestSubject(typeof(Container))]
    public class CloneTests
    {
        [Fact]
        public void IsCopyOfOriginal()
        {
            var container = new Container(1, 0);
            container.AddColour(KnownColor.Red);

            var clone = container.Clone();

            clone.Should().NotBeSameAs(container);
            clone.Size.Should().Be(container.Size);
            clone.Position.Should().Be(container.Position);
            clone.Slots.Should().Equal(container.Slots);
        }
    }
}
