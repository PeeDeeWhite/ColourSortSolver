using FluentAssertions;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.SolutionTests;

[TestSubject(typeof(Solution))]
public class ConstructorTests
{
    [Fact]
    public void PropertiesInitialized()
    {
        var puzzle = new Puzzle();
        
        var solution = new Solution(puzzle);

        solution.Puzzle.Should().BeSameAs(puzzle);
        solution.Moves.Should().BeEmpty();
    }
}