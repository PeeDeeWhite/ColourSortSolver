namespace ColourSortSolver;

/// <summary>
/// A Solution to a puzzle. Contains the <see cref="Puzzle"/> and <see cref="Move">Moves</see> to solve it, if possible.
/// Provides output of the solution results
/// </summary>
public class Solution
{
    private readonly Puzzle _startingPosition; // keep copy of original puzzle


    public Solution(Puzzle puzzle) : this (puzzle, puzzle)
    {
    }

    /// <summary>
    /// Used to create a clone of the current state of a solution.
    /// For pursuing a different solution from a previous branch in the move history
    /// </summary>
    /// <param name="puzzle">Current progress of solution</param>
    /// <param name="startingPuzzle">original starting position of puzzle</param>
    private Solution(Puzzle puzzle, Puzzle startingPuzzle)
    {
        _startingPosition = startingPuzzle;
        Puzzle = puzzle;
    }

    public bool IsSolved => Puzzle.IsSolved;
    public Puzzle Puzzle { get; }
    public List<Move> Moves {get;} = new List<Move>();

    public void RevertLastMove()
    {
        var lastMove= Moves[^1];
        Puzzle.MoveColour(lastMove.Invert());
        Moves.RemoveAt(Moves.Count - 1);
    }
    
    public void OutputResults(IWriter writer)
    {
        if (!Puzzle.IsValid)
        {
            writer.WriteLine(Properties.Resources.PuzzleInvalidWithErrors);
            foreach (var error in Puzzle.Errors)
            {
                writer.WriteLine($"- {error.Message}");
            }

            return;
        }

        writer.WriteLine(Properties.Resources.PuzzleValid);
        if (IsSolved)
        {
            writer.WriteLine(Properties.Resources.PuzzleSolvedMoves, IsSolved, Moves.Count);
            writer.WriteLine(Properties.Resources.Moves);

            foreach (var move in Moves)
            {
                writer.WriteLine(move.ToString());
            }
        }
        else
        {
            writer.WriteLine(Properties.Resources.PuzzleFailedToSolve);
        }
    }

    public Solution Clone()
    {
        var clonedPuzzle = Puzzle.Clone();
        var solution = new Solution(clonedPuzzle, _startingPosition);
        solution.Moves.AddRange(Moves);
        return solution;
    }
}