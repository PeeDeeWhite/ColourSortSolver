using FluentAssertions;
using System.Drawing;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.ContainerTests
{
    [TestSubject(typeof(Container))]
    public class ConstructorTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void SizeInitialized(int size)
        {
            var container = new Container(size, 0);
            container.Size.Should().Be(size);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void PositionInitialized(int position)
        {
            var container = new Container(1, position);
            container.Position.Should().Be(position);
        }

        [Fact]
        public void InitialColoursNotSupplied_InitializeEmptySlots()
        {
            var container = new Container(5, 1);
            container.Slots.Should().BeEmpty();
        }

        [Fact]
        public void InitialColorsSupplied_InitializeSlotsWitColours()
        {
            List<KnownColor> initialColors = [KnownColor.Red, KnownColor.Blue];
            var container = new Container(5, 0, initialColors);
            container.Slots.Should().BeEquivalentTo(initialColors);
        }
    }
}