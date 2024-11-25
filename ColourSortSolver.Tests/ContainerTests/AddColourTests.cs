using FluentAssertions;
using System.Drawing;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.ContainerTests
{
    [TestSubject(typeof(Container))]
    public class AddColourTests
    {
        [Theory]
        [InlineData(KnownColor.Red)]
        [InlineData(KnownColor.Blue)]
        public void ContainerIsEmpty_AnyColourAdded(KnownColor colour)
        {
            var container = new Container(3, 0);
            container.AddColour(colour);
            container.TopColour.Should().Be(colour);
        }

        [Theory]
        [InlineData(KnownColor.Red, KnownColor.Red, 2 )]
        [InlineData(KnownColor.Blue, KnownColor.Red, 1)]
        public void ContainerIsNotFull_AddOnlyMatchingColour(KnownColor colour, KnownColor topColour, int noOfColours)
        {
            List<KnownColor> initialColors = [KnownColor.Red];
            var container = new Container(3, 0, initialColors);
            container.AddColour(colour);
            container.MoveableColours.Should().BeEquivalentTo(Enumerable.Repeat(topColour, noOfColours));
        }

        [Fact]
        public void ContainerIsFull_CannotAddColour()
        {
            List<KnownColor> initialColors = [KnownColor.Red, KnownColor.Red, KnownColor.Red];
            var container = new Container(3, 0, initialColors);
            container.AddColour(KnownColor.Red);
            container.Slots.Should().BeEquivalentTo(initialColors);
        }

    }
}