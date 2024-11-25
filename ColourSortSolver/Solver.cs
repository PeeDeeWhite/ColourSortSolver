namespace ColourSortSolver
{
    /// <summary>
    /// Provides functionality to solve a given <see cref="Puzzle"/> by making valid moves until it is solved.
    /// And returns the most efficient solution.
    /// </summary>
    public class Solver
    {
        private readonly Puzzle _origPuzzle;
        private Solution _currentSolution = null!;
        private Puzzle _workingPuzzle = null!;
        private readonly List<MoveHistoryItem> _moveHistory;
        private int _minNoOfMoves = Int32.MaxValue;

        public Solver(Puzzle puzzle)
        {
            if (puzzle == null) throw new ArgumentNullException(nameof(puzzle));
            
            _origPuzzle = puzzle.Clone(); // store copy of original puzzle to initialise each solution
            _moveHistory = new List<MoveHistoryItem>();
        }

        public Solution Solution { get; private set; } = null!;

        public void TryAndSolve()
        {
            _workingPuzzle = _origPuzzle.Clone();
            _currentSolution = new Solution(_workingPuzzle);
            if (!_workingPuzzle.CheckIsValid() || _workingPuzzle.IsSolved)
            {
                Solution = _currentSolution;
                return;
            }

            ApplyMovesRecursively();
        }

        private void ApplyMovesRecursively()
        {
            var availableMoves = _workingPuzzle.GetAvailableMoves();
            foreach (var move in availableMoves)
            {
                if (_moveHistory.Count >= _minNoOfMoves)
                {
                    BackTrackTwoMoves();
                    return;
                }
                
                MoveColour(move, availableMoves);
                
                if (_workingPuzzle.IsSolved)
                {
                    if (Solution == null || _currentSolution.Moves.Count < Solution.Moves.Count)
                    {
                        Solution = _currentSolution;
                        _minNoOfMoves = Solution.Moves.Count;
                    }

                    // Not possible to find a quicker solution so quit
                    if (_moveHistory.Count < 2) return;
                    BackTrackTwoMoves();
                    _currentSolution = new Solution(_workingPuzzle);
                    _workingPuzzle = _workingPuzzle.Clone();
                    return;
                }
                ApplyMovesRecursively();
            }
        }

        private void BackTrackTwoMoves()
        {
            for (var i = 0; i < 2; i++)
            {
                var lastMove = _moveHistory[^1];
                _moveHistory.RemoveAt(_moveHistory.Count - 1);
                _workingPuzzle.MoveColour(new(lastMove.Move.Colour, lastMove.Move.NoOfColours, lastMove.Move.DestinationIndex, lastMove.Move.SourceIndex));
                Solution.Moves.RemoveAt(Solution.Moves.Count - 1);
            }
        }

        private void MoveColour(Move move, IList<Move> availableMoves)
        {
            _workingPuzzle.MoveColour(move);
            _currentSolution.Moves.Add(move);
            _moveHistory.Add(new MoveHistoryItem(move, availableMoves.Where(x => !x.Equals(move)).ToList()));
        }

        /// <summary>
        /// Represents a <see cref="Move"/> as part of a solution and the other moves that were available at that point.
        /// Used for back tracking.
        /// </summary>
        private class MoveHistoryItem(Move move, List<Move> availableMoves)
        {
            public Move Move { get; } = move;

            public List<Move> AvailableMoves { get; } = availableMoves;
        }
    }
}
