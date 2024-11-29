using System.Drawing;
using FluentAssertions;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.SolverTests;

[TestSubject(typeof(Solver))]
public class NotSolvedTests
{
    [Fact]
    public void EmptyPuzzle_ReportsErrors()
    {
        var solver = new Solver(TestHelpers.CreatePuzzleEmptyContainers());

        solver.TryAndSolve();

        solver.Solution.IsSolved.Should().BeFalse();
        solver.Solution.Moves.Should().BeEmpty();
        solver.Solution.Puzzle.Errors.Should().NotBeEmpty();
    }

    [Fact]
    public void InvalidPuzzle_ReportsErrors()
    {
        var solver = new Solver(TestHelpers.CreatePuzzleMismatchedContainers());

        solver.TryAndSolve();

        solver.Solution.IsSolved.Should().BeFalse();
        solver.Solution.Moves.Should().BeEmpty();
        solver.Solution.Puzzle.Errors.Should().NotBeEmpty();
    }

    [Fact]
    public void AlreadySolved_NoMovesRemainsSolved()
    {
        var solver = new Solver(TestHelpers.CreateValidSolvedPuzzle());

        solver.TryAndSolve();

        solver.Solution.IsSolved.Should().BeTrue();
        solver.Solution.Moves.Should().BeEmpty();
        solver.Solution.Puzzle.Errors.Should().BeEmpty();
    }

    [Fact]
    public void ValidPuzzleNoAvailableMoves_FailToSolve()
    {
        var puzzle = TestHelpers.CreatePuzzleNoAvailableMoves();
        var solver = new Solver(puzzle);

        solver.TryAndSolve();

        solver.Solution.IsSolved.Should().BeFalse();
        solver.Solution.Moves.Should().BeEmpty();
        solver.Solution.Puzzle.Errors.Should().BeEmpty();
    }

    [Fact]
    public void PuzzleNoSolutions_FailToSolve()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new(4, 0, [KnownColor.Gray, KnownColor.Gray, KnownColor.Crimson, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 1, [KnownColor.Green, KnownColor.Crimson, KnownColor.Orange, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 2, [KnownColor.Yellow, KnownColor.Crimson, KnownColor.Blue, KnownColor.Blue]));
        puzzle.Containers.Add(new(4, 3, [KnownColor.Crimson, KnownColor.Orange, KnownColor.Blue, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 4, [KnownColor.Orange, KnownColor.Orange, KnownColor.Green, KnownColor.Gray]));
        puzzle.Containers.Add(new(4, 5, [KnownColor.Green, KnownColor.Green, KnownColor.Blue, KnownColor.Gray]));
        puzzle.Containers.Add(new(4, 6));

        var solver = new Solver(puzzle);

        solver.TryAndSolve();

        solver.Solution.Puzzle.Errors.Should().BeEmpty();
        solver.Solution.IsSolved.Should().BeFalse();
    }
   
}