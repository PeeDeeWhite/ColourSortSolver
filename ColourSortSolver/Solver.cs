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
        private readonly List<(Move Move, List<Move> Moves)> _moveHistory;
        private int _minNoOfMoves = int.MaxValue;

        public event EventHandler<SolutionFoundEventArgs> SolutionFound = null!;

        public Solver(Puzzle puzzle)
        {
            ArgumentNullException.ThrowIfNull(puzzle, nameof(puzzle));
            
            _origPuzzle = puzzle.Clone(); // store copy of original puzzle to initialise each solution
            _moveHistory = [];
        }

        public Solution Solution { get; private set; } = null!;

        public int TotalMoves { get; private set; }
        
        public TimeSpan TimeTaken { get; private set; }

        public void TryAndSolve()
        {
            _currentSolution = new(_origPuzzle);
            if (!_currentSolution.Puzzle.CheckIsValid() || _currentSolution.Puzzle.IsSolved)
            {
                Solution = _currentSolution;
                return;
            }

            ApplyAvailableMoves();
        }

        private void ApplyAvailableMoves()
        {
            var availableMoves = _currentSolution.Puzzle.GetAvailableMoves();
            var startTime = DateTime.Now;
            while (availableMoves.Count > 0 && !_currentSolution.IsSolved)
            {
                if (_moveHistory.Count >= _minNoOfMoves - 1)
                {
                    BackTrack();
                    availableMoves = BackTrack();
                    continue; // No point continuing if we have already found a quicker solution
                }
                
                var remainingMoves = availableMoves[1..];
                if (HistoryContainsSameMoves(remainingMoves))
                {
                    availableMoves = BackTrack(); // If this results in a layout we have already seen don't continue.
                    continue;
                }
                
                var move = availableMoves.First();
                if (_moveHistory.Any(x => x.Move == move))
                {
                    availableMoves = BackTrack(); // If cycling round and repeating a move then back track.
                    continue;
                }

                _moveHistory.Add((move, availableMoves[1..]));

                MoveColour(move);
                TotalMoves++;

                if (_currentSolution.IsSolved)
                {
                    if (_currentSolution.Moves.Count < _minNoOfMoves)
                    {
                        Solution = _currentSolution.Clone();
                        _minNoOfMoves = _currentSolution.Moves.Count;
                        OnSolutionFound(new SolutionFoundEventArgs(_minNoOfMoves, DateTime.Now - startTime, TotalMoves));
                    }

                    BackTrack();
                    availableMoves = BackTrack();
                    continue;
                }
                
                availableMoves = _currentSolution.Puzzle.GetAvailableMoves(move);
                if (availableMoves.Count == 0)
                {
                    availableMoves = BackTrack();
                }
            }

            // No solution found so return the best solution found so far
            Solution ??= _currentSolution.Clone();
            TimeTaken = DateTime.Now - startTime;
        }

        private bool HistoryContainsSameMoves(List<Move> remainingMoves)
        {
            // Ignore empty collections
            if (remainingMoves.Count == 0) return false;
            return _moveHistory.Any(historyEntry => remainingMoves.SequenceEqual(historyEntry.Moves));
        }

        private List<Move> BackTrack()
        {
            if (_moveHistory.Count == 0) return [];

            var moves = PopLastMoves();
            _currentSolution.RevertLastMove();
            while (moves.Count == 0 && _moveHistory.Count > 0)
            {
                moves = PopLastMoves();
                _currentSolution.RevertLastMove();
            }
            return moves;
        }

        private List<Move> PopLastMoves()
        {
            var moves = _moveHistory[^1].Moves;
            _moveHistory.RemoveAt(_moveHistory.Count - 1);
            return moves;
        }

        private void MoveColour(Move move)
        {
            _currentSolution.Puzzle.MoveColour(move);
            _currentSolution.Moves.Add(move);
        }


        protected virtual void OnSolutionFound(SolutionFoundEventArgs e)
        {
            SolutionFound?.Invoke(this, e);
        }
    }
}
