using System.Drawing;
using FluentAssertions;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.PuzzleTests;

[TestSubject(typeof(Puzzle))]
public class HasValidMoveTests
{
    [Fact]
    public void ContainerNotFull_ReturnsTrue()
    {
        var puzzle = new Puzzle(
        [
            new(2, 0, [KnownColor.Aqua]),
            new(2, 1, [KnownColor.Aqua])
        ]);

        puzzle.HasValidMove().Should().BeTrue();
    }

    [Fact]
    public void ContainerIsEmpty_ReturnsTrue()
    {
        var puzzle = new Puzzle([
            new(2, 0, [KnownColor.Red, KnownColor.Red]),
            new(2, 1, [])
        ]);

        puzzle.HasValidMove().Should().BeTrue();
    }


    [Fact]
    public void NoSlotsOfMatchingColour_ReturnsFalse()
    {
        var puzzle = new Puzzle([
            new (2, 0, [KnownColor.Red]),
            new (2, 1, [KnownColor.Aqua]),
            new (2, 2, [KnownColor.DarkBlue])
        ]);

        puzzle.HasValidMove().Should().BeFalse();
    }

    [Fact]
    public void MultipleValidLocations_ReturnsTrue()
    {
        var puzzle = new Puzzle([
            new (2, 0, [KnownColor.Aqua]),
            new (2, 1, [KnownColor.Blue]),
            new (2, 2, [KnownColor.Aqua]),
            new (2, 3, [KnownColor.Blue])
        ]);

        puzzle.HasValidMove().Should().BeTrue();
    }

    [Fact]
    public void WhenSolved_ReturnsFalse()
    {
        var puzzle = TestHelpers.CreateValidPuzzle();
        puzzle.CheckIsValid();
        puzzle.HasValidMove().Should().BeFalse();
    }
}