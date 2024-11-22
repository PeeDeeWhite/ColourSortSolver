using FluentAssertions;

namespace ColourSortSolver.Tests.SolutionTests;

public class ConstructorTests
{
    [Fact]
    public void ConstructorShouldInitializeProperties()
    {
        var puzzle = new Puzzle();
        
        var solution = new Solution(puzzle);
        
        solution.Puzzle.Should().Be(puzzle);
        solution.Moves.Should().BeEmpty();
    }


}