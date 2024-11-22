using FluentAssertions;
using JetBrains.Annotations;
using System.Drawing;

namespace ColourSortSolver.Tests.SolutionTests;

[TestSubject(typeof(Solution))]
public class OutputResultsTests
{
    [Fact]
    public void EmptyPuzzleShouldOutputError()
    {
        var solution = new Solution(new Puzzle());
        solution.Puzzle.CheckIsValid();

        var resultsWriter = new TestResultsWriter();
        solution.OutputResults(resultsWriter);

        resultsWriter.Contains(Properties.Resources.PuzzleIsEmpty).Should().BeTrue();
    }

    [Fact]
    public void PuzzleVaryingContainerSizeShouldOutputError()
    {
        var solution = new Solution(new Puzzle(new List<Container>
        {
            new Container(2, 0),
            new Container(3, 1)
        }));
        solution.Puzzle.CheckIsValid();

        var resultsWriter = new TestResultsWriter();
        solution.OutputResults(resultsWriter);

        resultsWriter.Contains(Properties.Resources.PuzzleContainersVaryingSizes).Should().BeTrue();
    }

    [Fact]
    public void PuzzleContainerLessMinSizeShouldOutputError()
    {
        var solution = new Solution(new Puzzle(new List<Container>
        {
            new Container(0, 0),
            new Container(2, 1)
        }));
        solution.Puzzle.CheckIsValid();

        var resultsWriter = new TestResultsWriter();
        solution.OutputResults(resultsWriter);

        resultsWriter.Contains(Properties.Resources.PuzzleContainerMinimumSize).Should().BeTrue();
    }

    [Fact]
    public void PuzzleContainerAreEmptyShouldOutputError()
    {
        var solution = new Solution(new Puzzle(new List<Container>
        {
            new Container(2, 0),
            new Container(2, 1)
        }));
        solution.Puzzle.CheckIsValid();

        var resultsWriter = new TestResultsWriter();
        solution.OutputResults(resultsWriter);

        resultsWriter.Contains(Properties.Resources.PuzzleContainersAreEmpty).Should().BeTrue();
    }

    [Fact]
    public void PuzzleWrongNoOfColoursShouldOutputError()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new Container(4, 0, new List<KnownColor> { KnownColor.Green, KnownColor.Crimson, KnownColor.Yellow }));
        puzzle.Containers.Add(new Container(4, 1, new List<KnownColor> { KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow }));
        puzzle.Containers.Add(new Container(4, 2, new List<KnownColor> { KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow }));
        puzzle.Containers.Add(new Container(4, 3));

        var solution = new Solution(puzzle);
        solution.Puzzle.CheckIsValid();

        var resultsWriter = new TestResultsWriter();
        solution.OutputResults(resultsWriter);

        resultsWriter.Contains(string.Format(Properties.Resources.WrongNumberOfColours, 4)).Should().BeTrue();
    }
}

public class TestResultsWriter : IWriter
{
    public List<string> Lines { get; } = new List<string>();
    
    public void WriteLine(string value)
    {
        Lines.Add(value);
    }
    
    public bool Contains(string message)
    {
        return Lines.Any(line => line.Contains(message));
    }
}