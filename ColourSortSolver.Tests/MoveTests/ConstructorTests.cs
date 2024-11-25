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
    public void PropertiesCorrectlyInitialized(KnownColor colour, int sourcePosition, int destinationPosition, int noOfColours)
    {
        var source = new Container(10, sourcePosition);
        var destination = new Container(10, destinationPosition);

        var move = new Move(colour, noOfColours, source, destination);

        move.Colour.Should().Be(colour);
        move.NoOfColours.Should().Be(noOfColours);
        move.Source.Should().NotBeSameAs(source);
        move.Source.Size.Should().Be(source.Size);
        move.Source.Position.Should().Be(sourcePosition);
        move.Destination.Should().NotBeSameAs(destination);
        move.Destination.Size.Should().Be(destination.Size);
        move.Destination.Position.Should().Be(destinationPosition);
    }

    [Fact]
    public void ClonesContainers()
    {
        var source = new Container(10, 1, [KnownColor.Red]);
        var destination = new Container(10, 2, [KnownColor.Blue]);

        var move = new Move(KnownColor.Red, 5, source, destination);

        move.Source.Should().NotBeSameAs(source);
        move.Destination.Should().NotBeSameAs(destination);
    }
}