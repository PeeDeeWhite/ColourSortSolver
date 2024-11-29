using FluentAssertions;
using JetBrains.Annotations;
using System.Drawing;
using Xunit.Abstractions;

namespace ColourSortSolver.Tests.SolverTests;

[TestSubject(typeof(Solver))]
public class FourSlotPuzzlesTryAndSolveTests(ITestOutputHelper testOutputHelper)
{
    // Comment out to enable tests
     private class FactAttribute : Attribute { }

    /// <summary>
    /// 4 colours, 4 containers, 1 empty
    /// Example output:
    /// Solution found with 19 moves in 00:00:00.0027418. Total moves: 19
    /// Solution found with 18 moves in 00:00:00.0047498. Total moves: 25
    /// Solution found with 17 moves in 00:00:00.0055710. Total moves: 72
    /// Solution found with 16 moves in 00:00:00.8894127. Total moves: 83814
    /// Solved in 00:03:40.5865358 using 31760751 moves
    /// </summary>
    [Fact] 
    public void SixColoursEightContainersTwoEmpty_SolvedMinMoves()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new(4, 0, [KnownColor.Gray, KnownColor.Gray, KnownColor.Crimson, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 1, [KnownColor.Green, KnownColor.Crimson, KnownColor.Orange, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 2, [KnownColor.Yellow, KnownColor.Crimson, KnownColor.Blue, KnownColor.Blue]));
        puzzle.Containers.Add(new(4, 3, [KnownColor.Crimson, KnownColor.Orange, KnownColor.Blue, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 4, [KnownColor.Orange, KnownColor.Orange, KnownColor.Green, KnownColor.Gray]));
        puzzle.Containers.Add(new(4, 5, [KnownColor.Green, KnownColor.Green, KnownColor.Blue, KnownColor.Gray]));
        puzzle.Containers.Add(new(4, 6));
        puzzle.Containers.Add(new(4, 7));

        CheckPuzzleSolved(puzzle);
    }

    /// <summary>
    /// 8 colours, 10 containers, 1 empty
    /// Example output:
    /// Solution found with 21 moves in 00:00:00.0030551. Total moves: 25
    /// Solution found with 20 moves in 00:00:00.0044679. Total moves: 28
    /// Solution found with 19 moves in 00:00:00.0046731. Total moves: 37
    /// Solved in 00:00:40.5909083 using 4613135 moves
    /// </summary>
    [Fact]
    public void EightColoursTenContainersOneEmpty_SolvedMinMoves()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new(4, 0, [KnownColor.Gray, KnownColor.Gray, KnownColor.Crimson, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 1, [KnownColor.Green, KnownColor.Crimson, KnownColor.Orange]));
        puzzle.Containers.Add(new(4, 2, [KnownColor.Yellow, KnownColor.Crimson, KnownColor.Blue, KnownColor.Blue]));
        puzzle.Containers.Add(new(4, 3, [KnownColor.Crimson, KnownColor.Orange, KnownColor.Blue, KnownColor.Aqua]));
        puzzle.Containers.Add(new(4, 4, [KnownColor.Orange, KnownColor.Orange, KnownColor.Aqua, KnownColor.Gray]));
        puzzle.Containers.Add(new(4, 5, [KnownColor.Blue, KnownColor.Aqua, KnownColor.Purple, KnownColor.Gray]));
        puzzle.Containers.Add(new(4, 6, [KnownColor.Aqua, KnownColor.Purple, KnownColor.Purple, KnownColor.Green]));
        puzzle.Containers.Add(new(4, 7, [KnownColor.Purple, KnownColor.Green, KnownColor.Green]));
        puzzle.Containers.Add(new(4, 8, [KnownColor.Yellow, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 9));

        CheckPuzzleSolved(puzzle);
    }

    /// <summary>
    /// 10 colours, 12 containers, none empty.
    /// Example output:
    /// Solution found with 30 moves in 00:00:00.0036225. Total moves: 34
    /// Solution found with 29 moves in 00:00:00.0051806. Total moves: 37
    /// Solution found with 28 moves in 00:00:00.0054271. Total moves: 45
    /// Solution found with 27 moves in 00:00:00.0069671. Total moves: 107
    /// Solution found with 26 moves in 00:00:00.2887871. Total moves: 13084
    /// Solution found with 25 moves in 00:00:03.3297421. Total moves: 341879
    /// Solution found with 24 moves in 00:00:05.6627204. Total moves: 590176
    ///
    /// NOTE: not left it running long enough to complete
    /// </summary>
    [Fact]
    public void TenColoursTwelveContainersNoneEmpty_SolvedMinMoves()
    {

        var puzzle = new Puzzle();
        puzzle.Containers.Add(new(4,  0, [KnownColor.Orange, KnownColor.Pink, KnownColor.White, KnownColor.Blue]));
        puzzle.Containers.Add(new(4,  1, [KnownColor.Lime, KnownColor.Yellow, KnownColor.Yellow,]));
        puzzle.Containers.Add(new(4,  2, [KnownColor.Green, KnownColor.Pink]));
        puzzle.Containers.Add(new(4,  3, [KnownColor.Gray, KnownColor.Gray, KnownColor.Gray]));
        puzzle.Containers.Add(new(4,  4, [KnownColor.Crimson, KnownColor.Orange, KnownColor.Lime]));
        puzzle.Containers.Add(new(4,  5, [KnownColor.White, KnownColor.White, KnownColor.Purple]));
        puzzle.Containers.Add(new(4,  6, [KnownColor.Blue, KnownColor.Blue, KnownColor.Crimson, KnownColor.Pink]));
        puzzle.Containers.Add(new(4,  7, [KnownColor.Crimson, KnownColor.Green, KnownColor.Blue, KnownColor.Green]));
        puzzle.Containers.Add(new(4,  8, [KnownColor.Orange, KnownColor.Gray, KnownColor.Lime, KnownColor.Purple]));
        puzzle.Containers.Add(new(4,  9, [KnownColor.Purple, KnownColor.Lime, KnownColor.Orange]));
        puzzle.Containers.Add(new(4, 10, [KnownColor.Purple, KnownColor.Crimson, KnownColor.Green]));
        puzzle.Containers.Add(new(4, 11, [KnownColor.Yellow, KnownColor.Yellow, KnownColor.White, KnownColor.Pink]));

        CheckPuzzleSolved(puzzle);
    }


    /// <summary>
    /// 12 colours, 14 containers, two empty.
    /// Example output:
    /// Solution found with 37 moves in 00:00:00.0049737. Total moves: 64
    /// Solution found with 36 moves in 00:00:00.0069768. Total moves: 92
    /// Solution found with 35 moves in 00:00:01.9289434. Total moves: 164677
    /// Solution found with 34 moves in 00:00:11.8343303. Total moves: 1065579
    ///
    /// NOTE: not left it running long enough to complete
    /// </summary>
    [Fact]
    public void TwelveColoursFourteenContainersTwoEmpty_SolvedMinMoves()
    {

        var puzzle = new Puzzle();
        puzzle.Containers.Add(new(4, 0, [KnownColor.Orange, KnownColor.Pink, KnownColor.White, KnownColor.Blue]));
        puzzle.Containers.Add(new(4, 1, [KnownColor.Pink, KnownColor.Aqua, KnownColor.Lime, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 2, [KnownColor.Aqua, KnownColor.Green, KnownColor.Yellow, KnownColor.Gray]));
        puzzle.Containers.Add(new(4, 3, [KnownColor.Gray, KnownColor.Aqua, KnownColor.Gray, KnownColor.Aqua]));
        puzzle.Containers.Add(new(4, 4, [KnownColor.Crimson, KnownColor.Orange, KnownColor.Lime, KnownColor.Salmon]));
        puzzle.Containers.Add(new(4, 5, [KnownColor.Salmon, KnownColor.White, KnownColor.White, KnownColor.Purple]));
        puzzle.Containers.Add(new(4, 6, [KnownColor.Blue, KnownColor.Blue, KnownColor.Crimson, KnownColor.Pink]));
        puzzle.Containers.Add(new(4, 7, [KnownColor.Crimson, KnownColor.Green, KnownColor.Blue, KnownColor.Green]));
        puzzle.Containers.Add(new(4, 8, [KnownColor.Orange, KnownColor.Gray, KnownColor.Lime, KnownColor.Purple]));
        puzzle.Containers.Add(new(4, 9, [KnownColor.Purple, KnownColor.Lime, KnownColor.Salmon, KnownColor.Orange]));
        puzzle.Containers.Add(new(4, 10, [KnownColor.Salmon, KnownColor.Purple, KnownColor.Crimson, KnownColor.Green]));
        puzzle.Containers.Add(new(4, 11, [KnownColor.Yellow, KnownColor.Yellow, KnownColor.White, KnownColor.Pink]));
        puzzle.Containers.Add(new(4, 12));
        puzzle.Containers.Add(new(4, 13));

        CheckPuzzleSolved(puzzle);
    }

    private void CheckPuzzleSolved(Puzzle puzzle)
    {
        var solver = new Solver(puzzle);
        solver.SolutionFound += OnSolutionFound;

        solver.TryAndSolve();

        testOutputHelper.WriteLine($"Solved in {solver.TimeTaken} using {solver.TotalMoves} moves");

        solver.Solution.Puzzle.Errors.Should().BeEmpty();
        solver.Solution.IsSolved.Should().BeTrue();
    }

    private void OnSolutionFound(object? sender, SolutionFoundEventArgs e)
    {
        testOutputHelper.WriteLine($"Solution found with {e.Moves} moves in {e.TimeTaken}. Total moves: {e.TotalMoves}");
    }
}