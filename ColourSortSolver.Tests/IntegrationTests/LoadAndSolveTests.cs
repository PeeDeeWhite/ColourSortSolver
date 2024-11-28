using ColourSortSolver.Console;
using ColourSortSolver.Tests.SolutionTests;
using FluentAssertions;

namespace ColourSortSolver.Tests.IntegrationTests;

/// <summary>
/// Test loading of puzzle.json, validating, solving and outputting results
/// </summary>
public class LoadAndSolveTests
{
    private readonly TestResultsWriter _resultsWriter;

    public LoadAndSolveTests()
    {
        _resultsWriter = new TestResultsWriter();
    }

    [Fact]
    public void EmptyPuzzle_ReportsErrors()
    {
        var solver = LoadAndSolve(["emptypuzzle.json"]);
        solver.Solution.IsSolved.Should().BeFalse();
        _resultsWriter.Contains(Properties.Resources.PuzzleIsEmpty).Should().BeTrue();
    }

    [Fact]
    public void InvalidPuzzle_ReportsErrors()
    {
        var solver = LoadAndSolve(["invalidpuzzle.json"]);
        solver.Solution.IsSolved.Should().BeFalse();
        _resultsWriter.Contains(Properties.Resources.PuzzleContainersVaryingSizes).Should().BeTrue();
        _resultsWriter.Contains(Properties.Resources.PuzzleContainersPositionNotSequential).Should().BeTrue();
        _resultsWriter.Contains(string.Format(Properties.Resources.WrongNumberOfColours, 3)).Should().BeTrue();
    }

    [Fact]
    public void PuzzleNoAvailableMoves_ReportsFailure()
    {
        var solver = LoadAndSolve(["nomovespuzzle.json"]);
        solver.Solution.IsSolved.Should().BeFalse();
        _resultsWriter.Contains(Properties.Resources.PuzzleFailedToSolve).Should().BeTrue();
    }

    [Fact]
    public void ValidPuzzle_ReportsSuccess()
    {
        var solver = LoadAndSolve(["validpuzzle.json"]);
        solver.Solution.IsSolved.Should().BeTrue();
        _resultsWriter.Contains(Properties.Resources.PuzzleValid).Should().BeTrue();
        _resultsWriter.Contains(string.Format(Properties.Resources.PuzzleSolvedMoves, true, 5)).Should().BeTrue();
    }

    private Solver LoadAndSolve(string[] args)
    {
        var puzzle = PuzzleLoader.LoadFromJsonFile(PuzzleLoader.ParseFilenameFromArgs(args));
        var solver = new Solver(puzzle);
        solver.TryAndSolve();
        solver.Solution.OutputResults(_resultsWriter);
        return solver;
    }
}