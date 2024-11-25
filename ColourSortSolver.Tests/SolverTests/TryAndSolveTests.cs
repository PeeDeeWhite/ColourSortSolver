using System.Drawing;
using FluentAssertions;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.SolverTests;

[TestSubject(typeof(Solver))]
public class TryAndSolveTests
{

    [Fact]
    public void InvalidPuzzle_ReportsErrors()
    {
        var solver = new Solver(TestHelpers.CreatePuzzleEmptyContainers());

        solver.TryAndSolve();

        solver.Solution.IsSolved.Should().BeFalse();
        solver.Solution.Moves.Should().BeEmpty();
        solver.Solution.Puzzle.Errors.Should().NotBeEmpty();
    }

    [Fact]
    public void SolvedPuzzle_NoMovesRemainsSolved()
    {
        var solver = new Solver(TestHelpers.CreateValidSolvedPuzzle());

        solver.TryAndSolve();

        solver.Solution.IsSolved.Should().BeTrue();
        solver.Solution.Moves.Should().BeEmpty();
        solver.Solution.Puzzle.Errors.Should().BeEmpty();
    }

    [Fact] public void ValidPuzzleOneMoveToSolve_SolvedInOneMove()
    {
        var puzzle = TestHelpers.CreatePuzzleOneMoveToComplete();
        var solver = new Solver(puzzle);

        solver.TryAndSolve();

        solver.Solution.IsSolved.Should().BeTrue();
        solver.Solution.Moves.Should().BeEquivalentTo([
            new Move(KnownColor.Green, 2, 0, 3)
        ]);
        solver.Solution.Puzzle.Errors.Should().BeEmpty();
    }

}