using System.Drawing;
using FluentAssertions;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.SolutionTests;

[TestSubject(typeof(Solution))]
public class CloneTests
{
    [Fact]
    public void IsCopyOfOriginal()
    {
        var puzzle = TestHelpers.CreatePuzzleOneMoveToComplete();
        var solution = new Solution(puzzle);
        var move = new Move(KnownColor.Green, 1, 3, 0);
        solution.Moves.Add(move);
        
        var clone = solution.Clone();
        clone.Should().NotBeSameAs(solution);
        clone.Puzzle.Should().NotBeSameAs(solution.Puzzle);
        clone.Puzzle.Should().BeEquivalentTo(solution.Puzzle);
        clone.Moves.Should().NotBeSameAs(solution.Moves);
        clone.Moves.Should().BeEquivalentTo(solution.Moves);

        //Ensure clone does not have a reference to original
        solution.Moves[0] = new Move(KnownColor.Red, 1, 3, 0);
        clone.Moves[0].Should().BeEquivalentTo(move);
    }

}