using System.Drawing;
using FluentAssertions;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.PuzzleTests;

[TestSubject(typeof(Puzzle))]
public class MoveColourTests
{
    [Fact]
    public void NullMove_ThrowsArgumentException()
    {
        var puzzle = new Puzzle();

        var act = () => puzzle.MoveColour(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ValidMoveSingleColour_UpdatesContainers()
    {
        var puzzle = new Puzzle([
            new(2, 0, [KnownColor.Red]),
            new(2, 1, [KnownColor.Red])
        ]);

        puzzle.MoveColour(new Move(KnownColor.Red, 1, puzzle.Containers[0], puzzle.Containers[1]));

        puzzle.Containers[0].Slots.Should().BeEmpty();
        puzzle.Containers[1].Slots.Should().BeEquivalentTo([KnownColor.Red, KnownColor.Red]);
    }

    [Fact]
    public void ValidMoveMultipleColours_UpdatesContainers()
    {
        var puzzle = new Puzzle([
            new(3, 0, [KnownColor.Red, KnownColor.Red]),
            new(3, 1)
        ]);

        puzzle.MoveColour(new Move(KnownColor.Red, 2, puzzle.Containers[0], puzzle.Containers[1]));

        puzzle.Containers[0].Slots.Should().BeEmpty();
        puzzle.Containers[1].Slots.Should().BeEquivalentTo(new List<KnownColor> { KnownColor.Red, KnownColor.Red });
    }
}