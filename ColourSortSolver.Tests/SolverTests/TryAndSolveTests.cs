﻿using System.Drawing;
using FluentAssertions;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.SolverTests;

[TestSubject(typeof(Solver))]
public class TryAndSolveTests
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
    
    [Fact]
    public void SmallPuzzleMultipleSolutions_SolvedMinMoves()
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
    public void MediumPuzzleMultipleSolutions_SolvedMinMoves()
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

    [Fact(Skip = "")] // Too Slow for Unit tests
    public void LargePuzzleMultipleSolutions_SolvedMinMoves()
    {
        var puzzle = new Puzzle();
        //puzzle.Containers.Add(new(4, 0, [KnownColor.Gray, KnownColor.Gray, KnownColor.Crimson, KnownColor.Yellow]));
        //puzzle.Containers.Add(new(4, 1, [KnownColor.Green, KnownColor.Crimson, KnownColor.Orange]));
        //puzzle.Containers.Add(new(4, 2, [KnownColor.Yellow, KnownColor.Crimson, KnownColor.Blue, KnownColor.Blue]));
        //puzzle.Containers.Add(new(4, 3, [KnownColor.Crimson, KnownColor.Orange, KnownColor.Blue, KnownColor.Aqua]));
        //puzzle.Containers.Add(new(4, 4, [KnownColor.Orange, KnownColor.Orange, KnownColor.Aqua, KnownColor.Gray]));
        //puzzle.Containers.Add(new(4, 5, [KnownColor.Blue, KnownColor.Aqua, KnownColor.Purple, KnownColor.Gray]));
        //puzzle.Containers.Add(new(4, 6, [KnownColor.Aqua, KnownColor.Purple, KnownColor.Purple, KnownColor.Green]));
        //puzzle.Containers.Add(new(4, 7, [KnownColor.Purple, KnownColor.Green, KnownColor.Green]));
        //puzzle.Containers.Add(new(4, 8, [ KnownColor.Yellow, KnownColor.Yellow]));
        //puzzle.Containers.Add(new(4, 9));
        puzzle.Containers.Add(new(4, 0, [KnownColor.Gray, KnownColor.Gray, KnownColor.Crimson, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 1, [KnownColor.Green, KnownColor.Crimson, KnownColor.Orange, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 2, [KnownColor.Yellow, KnownColor.Crimson, KnownColor.Blue, KnownColor.Blue]));
        puzzle.Containers.Add(new(4, 3, [KnownColor.Crimson, KnownColor.Orange, KnownColor.Blue, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 4, [KnownColor.Orange, KnownColor.Orange, KnownColor.Green, KnownColor.Gray]));
        puzzle.Containers.Add(new(4, 5, [KnownColor.Green, KnownColor.Green, KnownColor.Blue, KnownColor.Gray]));
        puzzle.Containers.Add(new(4, 6));
        puzzle.Containers.Add(new(4, 7));

        var solver = new Solver(puzzle);

        solver.TryAndSolve();

        solver.Solution.Puzzle.Errors.Should().BeEmpty();
        solver.Solution.IsSolved.Should().BeTrue();
    }
}