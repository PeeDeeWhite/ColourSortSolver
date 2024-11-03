namespace ColourSortSolver;

public class PuzzleException(string message, Puzzle puzzle) : Exception(message)
{
    public Puzzle Puzzle { get; } = puzzle;
}