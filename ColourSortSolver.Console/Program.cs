namespace ColourSortSolver.Console
{
    using System;

    internal class Program
    {

        static void Main(string[] args)
        {
            var solution = TrySolvePuzzle(args);
            WriteToConsole(solution);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        private static Solution TrySolvePuzzle(string[] args)
        {
            var puzzle = PuzzleLoader.LoadFromJsonFile(ParseFileNameFromArgs(args));
            var solver = new Solver(puzzle);
            return solver.TryAndSolve();
        }

        private static string ParseFileNameFromArgs(string[] args)
        {
            if (args.Length != 1 || string.IsNullOrWhiteSpace(args[0]))
            {
                throw new ApplicationException("Please provide a valid file name as an argument.");
            }
            
            return args[0];
        }

        private static void WriteToConsole(Solution solution)
        {
            if (!solution.Puzzle.IsValid)
            {
                Console.WriteLine("Puzzle is invalid due to the following errors:");
                foreach (var error in solution.Puzzle.Errors)
                {
                    Console.WriteLine($"- {error.Message}");
                }

                return;
            }

            Console.WriteLine("Puzzle is valid.");
            Console.WriteLine($"Puzzle solved: {solution.IsSolved} in {solution.Moves.Count}");
            Console.WriteLine("Moves:");

            foreach (var move in solution.Moves)
            {
                Console.WriteLine($"Move {move.NoOfColours} {move.Colour}(s) from container {move.SourceIndex} to container {move.DestinationIndex}.");
            }
        }
    }
}
