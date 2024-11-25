using System.Diagnostics.CodeAnalysis;

namespace ColourSortSolver.Console
{
    using System;

    [ExcludeFromCodeCoverage]
    internal class Program
    {

        static void Main(string[] args)
        {
            var solution = TrySolvePuzzle(PuzzleLoader.ParseFilenameFromArgs(args));
            solution.OutputResults(new ConsoleWriter());

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        private static Solution TrySolvePuzzle(string filename)
        {
            var puzzle = PuzzleLoader.LoadFromJsonFile(filename);
            var solver = new Solver(puzzle);
            solver.TryAndSolve();
            return solver.Solution;
        }
    }
}
