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
        private readonly Stack<(Move Move, List<Move> Moves)> _moveHistory;
        private int _minNoOfMoves = int.MaxValue;

        public Solver(Puzzle puzzle)
        {
            if (puzzle == null) throw new ArgumentNullException(nameof(puzzle));
            
            _origPuzzle = puzzle.Clone(); // store copy of original puzzle to initialise each solution
            _moveHistory = new();
        }

        public Solution Solution { get; private set; } = null!;

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
            while (availableMoves.Any() && !_currentSolution.IsSolved)
            {
                if (_moveHistory.Count >= _minNoOfMoves - 1)
                {
                    BackTrack();
                    availableMoves = BackTrack();
                    continue; // No point continuing if we have already found a quicker solution
                }
                
                var move = availableMoves.First();
                if (_moveHistory.Any(x => x.Move == move))
                {
                    availableMoves = BackTrack(); // If cycling round and repeating a move then back track.
                    continue;
                }

                _moveHistory.Push((move, availableMoves[1..]));

                MoveColour(move);

                if (_currentSolution.IsSolved)
                {
                    if (_currentSolution.Moves.Count < _minNoOfMoves)
                    {
                        Solution = _currentSolution.Clone();
                        _minNoOfMoves = _currentSolution.Moves.Count;
                    }

                    BackTrack();
                    availableMoves = BackTrack();
                    continue;
                }
                
                availableMoves = _currentSolution.Puzzle.GetAvailableMoves(move);
                if (availableMoves.Count == 0)
                {
                    availableMoves = BackTrack(); // If cycling round and repeating a move then back track.
                }
            }
        }

        private List<Move> BackTrack()
        {
            if (!_moveHistory.Any()) return new List<Move>();
            
            var (_, moves) = _moveHistory.Pop();
            _currentSolution.RevertLastMove();
            while (moves.Count == 0 && _moveHistory.Count > 0)
            {
                (_, moves) = _moveHistory.Pop();
                _currentSolution.RevertLastMove();
            }
            return moves;
        }


        private void MoveColour(Move move)
        {
            _currentSolution.Puzzle.MoveColour(move);
            _currentSolution.Moves.Add(move);
        }
    }
}
