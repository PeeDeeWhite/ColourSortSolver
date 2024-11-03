namespace ColourSortSolver;

public class Solution
{
    public Solution(Puzzle puzzle)
    {
        Puzzle = puzzle;
        Moves = new List<Move>();
    }

    public bool IsSolved { get; set; }

    public Puzzle Puzzle { get; }
    public ICollection<Move> Moves {get;}
}