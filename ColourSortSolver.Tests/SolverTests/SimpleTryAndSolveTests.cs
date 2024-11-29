using System.Drawing;
using FluentAssertions;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.SolverTests;

[TestSubject(typeof(Solver))]
public class SimpleTryAndSolveTests
{
    [Fact] public void OneMoveToSolve_SolvedInOneMove()
    {
        var puzzle = TestHelpers.CreatePuzzleOneMoveToComplete();
        var solver = new Solver(puzzle);

        solver.TryAndSolve();

        solver.Solution.IsSolved.Should().BeTrue();
        solver.Solution.Moves.Should().BeEquivalentTo([
            new Move(KnownColor.Green, 2, 0, 1, 3, 1)
        ]);
        solver.Solution.Puzzle.Errors.Should().BeEmpty();
    }

    [Fact]
    public void MultipleMoves_SolvedMinMoves()
    {
        var puzzle = TestHelpers.CreateSimplePuzzleMultipleMovesToComplete();
        var solver = new Solver(puzzle);

        solver.TryAndSolve();

        solver.Solution.IsSolved.Should().BeTrue();
        solver.Solution.Moves.Count.Should().Be(3);
        solver.Solution.Puzzle.Errors.Should().BeEmpty();
    }

    [Fact]
    public void ThreeColourPuzzleMultipleSolutions_SolvedMinMoves()
    {
        var puzzle = new Puzzle();

        puzzle.Containers.Add(new(3, 0, [KnownColor.Purple, KnownColor.Yellow, KnownColor.Crimson]));
        puzzle.Containers.Add(new(3, 1, [KnownColor.Yellow, KnownColor.Crimson, KnownColor.Purple]));
        puzzle.Containers.Add(new(3, 2, [KnownColor.Yellow, KnownColor.Crimson, KnownColor.Purple]));
        puzzle.Containers.Add(new(3, 3));
        puzzle.Containers.Add(new(3, 4));


        var solver = new Solver(puzzle);

        solver.TryAndSolve();

        solver.Solution.Puzzle.Errors.Should().BeEmpty();
        solver.Solution.IsSolved.Should().BeTrue();
    }
    
    [Fact]
    public void FourColourPuzzleMultipleSolutions_SolvedMinMoves()
    {
        var puzzle = new Puzzle();

        puzzle.Containers.Add(new(4, 0, [KnownColor.Purple, KnownColor.Purple, KnownColor.Green, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 1, [KnownColor.Green, KnownColor.Yellow, KnownColor.Crimson, KnownColor.Crimson]));
        puzzle.Containers.Add(new(4, 2, [KnownColor.Yellow, KnownColor.Yellow, KnownColor.Green, KnownColor.Purple]));
        puzzle.Containers.Add(new(4, 3, [KnownColor.Crimson, KnownColor.Crimson, KnownColor.Purple, KnownColor.Green]));
        puzzle.Containers.Add(new(4, 4));
        puzzle.Containers.Add(new(4, 5));

        var solver = new Solver(puzzle);

        solver.TryAndSolve();

        solver.Solution.Puzzle.Errors.Should().BeEmpty();
        solver.Solution.IsSolved.Should().BeTrue();
        solver.Solution.Moves.Count.Should().Be(9);
    }
}