using JetBrains.Annotations;
using System.Drawing;
using FluentAssertions;

namespace ColourSortSolver.Tests.MoveTests;

[TestSubject(typeof(Move))]
public class ConstructorTests
{
    [Theory]
    [InlineData(KnownColor.Red, 0, 1, 5)]
    [InlineData(KnownColor.Blue, 2, 3, 10)]
    [InlineData(KnownColor.Green, 4, 5, 15)]
    [InlineData(KnownColor.Yellow, 6, 7, 20)]
    [InlineData(KnownColor.Black, 8, 9, 25)]
    public void ConstructorShouldInitializePropertiesCorrectly(KnownColor colour, int sourceIndex, int destinationIndex, int noOfColours)
    {
        var source = new Container(10, 1);
        var destination = new Container(10, 2);

        var move = new Move(colour, source, sourceIndex, destination, destinationIndex, noOfColours);

        move.Colour.Should().Be(colour);
        move.Source.Should().NotBeSameAs(source);
        move.Source.Size.Should().Be(source.Size);
        move.Source.Position.Should().Be(source.Position);
        move.SourceIndex.Should().Be(sourceIndex);
        move.Destination.Should().NotBeSameAs(destination);
        move.Destination.Size.Should().Be(destination.Size);
        move.Destination.Position.Should().Be(destination.Position);
        move.DestinationIndex.Should().Be(destinationIndex);
        move.NoOfColours.Should().Be(noOfColours);
    }

    [Fact]
    public void ConstructorShouldCloneContainers()
    {
        var source = new Container(10, 1, new List<KnownColor> { KnownColor.Red });
        var destination = new Container(10, 2, new List<KnownColor> { KnownColor.Blue });

        var move = new Move(KnownColor.Red, source, 0, destination, 1, 5);

        move.Source.Should().NotBeSameAs(source);
        move.Destination.Should().NotBeSameAs(destination);
    }
}