using FluentAssertions;
using System.Drawing;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.ContainerTests
{
    [TestSubject(typeof(ColourContainer))]
    public class ConstructorTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void ConstructorShouldInitializeSize(int size)
        {
            var container = new ColourContainer(size, 0);
            container.Size.Should().Be(size);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void ConstructorShouldInitializePosition(int position)
        {
            var container = new ColourContainer(1, position);
            container.Position.Should().Be(position);
        }

        [Fact]
        public void ConstructorShouldInitializeSlots()
        {
            var container = new ColourContainer(5, 1);
            container.Slots.Should().BeEmpty();
        }

        [Fact]
        public void ConstructorWithInitialColorsShouldInitializeSlots()
        {
            var initialColors = new List<KnownColor> { KnownColor.Red, KnownColor.Blue };
            var container = new ColourContainer(5, 0, initialColors);
            container.Slots.Should().BeEquivalentTo(initialColors);
        }
    }
}