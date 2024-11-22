namespace ColourSortSolver;

/// <summary>
/// Represents an exception that occurs during the processing of a Colour Sort puzzle.
/// </summary>
/// <param name="message">The message that describes the error.</param>
/// <param name="puzzle">The puzzle instance that caused the exception.</param>
public class PuzzleException(string message, Puzzle puzzle) : Exception(message)
{
    public Puzzle Puzzle { get; } = puzzle;
}