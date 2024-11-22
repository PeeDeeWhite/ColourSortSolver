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
                while (Puzzle.CanMakeValidMove())
                {
                    MoveColour();
                }
            }
            return Solution;
        }

        private void MoveColour()
        {
            var sourceContainer = Puzzle.Containers.FirstOrDefault(c => c.Slots.Distinct().Count() > 1);
            if (sourceContainer == null) throw new InvalidOperationException("No valid source container found for moving colour.");

            var colourToMove = sourceContainer.Slots.GroupBy(c => c).OrderByDescending(g => g.Count()).First().Key;
            var destinationContainer = Puzzle.Containers.FirstOrDefault(c => c.Slots.Count < c.Size && (c.Slots.Count == 0 || c.Slots.All(s => s == colourToMove)));
            if (destinationContainer == null) throw new InvalidOperationException("No valid destination container found for moving colour.");

            var sourceIndex = sourceContainer.Slots.ToList().FindIndex(c => c == colourToMove);
            var destinationIndex = destinationContainer.Slots.Count;

            sourceContainer.Slots.Remove(colourToMove);
            destinationContainer.Slots.Add(colourToMove);

            Solution.Moves.Add(new Move(colourToMove, sourceContainer.Clone(), sourceIndex, destinationContainer, destinationIndex, 1));
        }
    }
}
