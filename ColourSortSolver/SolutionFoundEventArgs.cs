namespace ColourSortSolver;

public class SolutionFoundEventArgs(int moves, TimeSpan timeTaken, int totalMoves) : EventArgs
{
    public int Moves { get; } = moves;
    public TimeSpan TimeTaken { get; } = timeTaken;
    public int TotalMoves { get; } = totalMoves;
}