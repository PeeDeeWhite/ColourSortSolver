using FluentAssertions;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.SolutionTests;

[TestSubject(typeof(Solution))]
public class IsSolvedTests
{
    [Fact]
    public void IsSolved_ShouldReturnPuzzleIsSolved()
    {
        var puzzle = new Puzzle();
        var solution = new Solution(puzzle);

        solution.IsSolved.Should().Be(puzzle.IsSolved);
    }
}