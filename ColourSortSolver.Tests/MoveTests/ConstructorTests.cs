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
    public void PropertiesCorrectlyInitialized(KnownColor colour, int sourceIndex, int destinationIndex, int noOfColours)
    {

        var move = new Move(colour, noOfColours, sourceIndex, destinationIndex);

        move.Colour.Should().Be(colour);
        move.NoOfColours.Should().Be(noOfColours);
        move.SourceIndex.Should().Be(sourceIndex);
        move.DestinationIndex.Should().Be(destinationIndex);
    }
}