namespace ColourSortSolver;
/// <summary>
/// Solution to the puzzle. Contains the <see cref="Puzzle"/> and <see cref="Move">Moves</see> to solve it, if possible.
/// Provides out of the solution results
/// </summary>
/// <param name="puzzle"></param>
public class Solution(Puzzle puzzle)
{
    public bool IsSolved => Puzzle.IsSolved;
    public Puzzle Puzzle { get; } = puzzle;
    public ICollection<Move> Moves {get;} = new List<Move>();

    public void OutputResults(IWriter writer)
    {
        if (!Puzzle.IsValid)
        {
            writer.WriteLine("Puzzle is invalid due to the following errors:");
            foreach (var error in Puzzle.Errors)
            {
                writer.WriteLine($"- {error.Message}");
            }

            return;
        }

        writer.WriteLine("Puzzle is valid.");
        writer.WriteLine($"Puzzle solved: {IsSolved} in {Moves.Count}");
        writer.WriteLine("Moves:");

        foreach (var move in Moves)
        {
            writer.WriteLine($"Move {move.NoOfColours} {move.Colour}(s) from container {move.SourceIndex} to container {move.DestinationIndex}.");
        }
    }

}