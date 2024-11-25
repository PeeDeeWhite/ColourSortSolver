using FluentAssertions;
using JetBrains.Annotations;
using System.Drawing;

namespace ColourSortSolver.Tests.PuzzleTests;

[TestSubject(typeof(Puzzle))]
public class GetAvailableMovesTests
{
    [Fact]
    public void ContainersEmpty_ReturnsEmptyList()
    {
        var puzzle = new Puzzle([
            new(2, 0, []),
            new(2, 1, [])
        ]);

        puzzle.GetAvailableMoves().Should().BeEmpty();
    }
    
    [Fact]
    public void ContainersFull_ReturnsEmptryList()
    {
        var puzzle = new Puzzle([
            new(2, 0, [KnownColor.Aqua, KnownColor.Blue]),
            new(2, 1, [KnownColor.Crimson, KnownColor.Aqua]),
            new(2, 2, [KnownColor.Blue, KnownColor.Crimson])
        ]);

        puzzle.GetAvailableMoves().Should().BeEmpty();
    }

    [Fact]
    public void ContainersSolved_ReturnsEmptyList()
    {
        var puzzle = new Puzzle([
            new(2, 0, [KnownColor.Aqua, KnownColor.Aqua]),
            new(2, 1, [KnownColor.Crimson, KnownColor.Crimson]),
            new(2, 2, [] )
        ]);

        puzzle.GetAvailableMoves().Should().BeEmpty();
    }

    [Fact]
    public void SingleColourMoveAvailableToEmptyContainer_ReturnsAvaialbleMove()
    {
        var puzzle = new Puzzle([
            new(2, 0, [KnownColor.Aqua]),
            new(2, 1, [] )
        ]);

        Move[] expectedMoves =
        [
            new (KnownColor.Aqua, 1, puzzle.Containers[0], puzzle.Containers[1])
        ];
        var availableMoves = puzzle.GetAvailableMoves();
        availableMoves.Should().BeEquivalentTo(expectedMoves);
    }

    [Fact]
    public void SingleColourMoveAvailableBetweenTwoContainer_ReturnsListOfMoves()
    {
        var puzzle = new Puzzle([
            new(2, 0, [KnownColor.Aqua]),
            new(2, 1, [KnownColor.Aqua] )
        ]);

        Move[] expectedMoves =
        [
            new (KnownColor.Aqua, 1, puzzle.Containers[0], puzzle.Containers[1]),
            new (KnownColor.Aqua, 1, puzzle.Containers[1], puzzle.Containers[0])
        ];
        var availableMoves = puzzle.GetAvailableMoves();
        availableMoves.Should().BeEquivalentTo(expectedMoves);
    }
}