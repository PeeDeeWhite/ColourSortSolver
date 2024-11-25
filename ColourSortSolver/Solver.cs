namespace ColourSortSolver
{
    /// <summary>
    /// Provides functionality to solve a given <see cref="Puzzle"/> by making valid moves until it is solved.
    /// </summary>
    public class Solver
    {
        public Solver(Puzzle puzzle)
        {
            Puzzle = puzzle ?? throw new ArgumentNullException(nameof(puzzle));
            Solution = new Solution(Puzzle);
        }

        public Puzzle Puzzle { get; }

        public Solution Solution { get; }

        public Solution TryAndSolve()
        {
            if (Puzzle.CheckIsValid())
            {
                MoveRecursively();
            }
            return Solution;
        }

        private void MoveRecursively()
        {
            var availableMoves = Puzzle.GetAvailableMoves();
            foreach (var move in availableMoves)
            {
                if (Puzzle.IsSolved) return;
                MoveColour(move);
                MoveRecursively();
            }
        }
        
        private void MoveColour(Move move)
        {
            Puzzle.MoveColour(move);
            Solution.Moves.Add(move);
        }
    }
}
