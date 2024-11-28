using System.Drawing;

namespace ColourSortSolver.Tests;

public static class TestHelpers
{

    public static Puzzle CreatePuzzleEmptyContainers()
    {
        var puzzle =new Puzzle();
        puzzle.Containers.Add(new(4, 0));
        puzzle.Containers.Add(new(4, 1));
        return puzzle;
    }

    public static Puzzle CreatePuzzleMismatchedContainers()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new(4, 0));
        puzzle.Containers.Add(new(3, 1));
        puzzle.Containers.Add(new(5, 1));
        return puzzle;
    }

    public static Puzzle CreatePuzzleOneMoveToComplete()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new(3, 0, [KnownColor.Green, KnownColor.Green]));
        puzzle.Containers.Add(new(3, 1, [KnownColor.Yellow, KnownColor.Yellow, KnownColor.Yellow]));
        puzzle.Containers.Add(new(3, 2, [KnownColor.Crimson, KnownColor.Crimson, KnownColor.Crimson]));
        puzzle.Containers.Add(new(3, 3, [KnownColor.Green]));
        return puzzle;
    }

    public static Puzzle CreateSimplePuzzleMultipleMovesToComplete()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new(3, 0, [KnownColor.Green, KnownColor.Green]));
        puzzle.Containers.Add(new(3, 1, [KnownColor.Yellow, KnownColor.Yellow]));
        puzzle.Containers.Add(new(3, 2, [KnownColor.Crimson, KnownColor.Crimson]));
        puzzle.Containers.Add(new(3, 3, [KnownColor.Green, KnownColor.Yellow, KnownColor.Crimson]));
        return puzzle;
    }

    public static Puzzle CreateValidSolvedPuzzle()
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

    public static Puzzle CreatePuzzleNoAvailableMoves()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new(3, 0, [KnownColor.Green, KnownColor.Green, KnownColor.Yellow]));
        puzzle.Containers.Add(new(3, 1, [KnownColor.Yellow, KnownColor.Yellow, KnownColor.Crimson]));
        puzzle.Containers.Add(new(3, 2, [KnownColor.Crimson, KnownColor.Crimson, KnownColor.Green]));

        return puzzle;
    }
}