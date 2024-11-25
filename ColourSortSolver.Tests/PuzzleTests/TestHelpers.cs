using System.Drawing;

namespace ColourSortSolver.Tests.PuzzleTests;

public static class TestHelpers
{
    public static Puzzle CreateValidPuzzle()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new(3, 0, [KnownColor.Green, KnownColor.Green, KnownColor.Green]));
        puzzle.Containers.Add(new(3, 1, [KnownColor.Yellow, KnownColor.Yellow, KnownColor.Yellow]));
        puzzle.Containers.Add(new(3, 2, [KnownColor.Crimson, KnownColor.Crimson, KnownColor.Crimson]));
        puzzle.Containers.Add(new(3, 3, [KnownColor.Blue, KnownColor.Blue, KnownColor.Blue]));
        puzzle.Containers.Add(new(3, 4));
        puzzle.Containers.Add(new(3, 5));

        return puzzle;
    }

}