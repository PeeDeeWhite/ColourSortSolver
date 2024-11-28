using FluentAssertions;
using JetBrains.Annotations;
using System.Drawing;

namespace ColourSortSolver.Tests.SolutionTests;

[TestSubject(typeof(Solution))]
public class OutputResultsTests
{
    [Fact]
    public void EmptyPuzzle_OutputError()
    {
        var solution = new Solution(new());
        solution.Puzzle.CheckIsValid();

        var resultsWriter = new TestResultsWriter();
        solution.OutputResults(resultsWriter);

        resultsWriter.Contains(Properties.Resources.PuzzleIsEmpty).Should().BeTrue();
    }

    [Fact]
    public void PuzzleVaryingContainerSize_OutputError()
    {
        var solution = new Solution(new(
        [
            new(2, 0),
            new(3, 1)
        ]));
        solution.Puzzle.CheckIsValid();

        var resultsWriter = new TestResultsWriter();
        solution.OutputResults(resultsWriter);

        resultsWriter.Contains(Properties.Resources.PuzzleContainersVaryingSizes).Should().BeTrue();
    }

    [Fact]
    public void PuzzleContainerLessMinSize_OutputError()
    {
        var solution = new Solution(new(
        [
            new(0, 0),
            new(2, 1)
        ]));
        solution.Puzzle.CheckIsValid();

        var resultsWriter = new TestResultsWriter();
        solution.OutputResults(resultsWriter);

        resultsWriter.Contains(Properties.Resources.PuzzleContainerMinimumSize).Should().BeTrue();
    }

    [Fact]
    public void PuzzleContainerAreEmpty_OutputError()
    {
        var solution = new Solution(new(
        [
            new (2, 0),
            new (2, 1)
        ]));
        solution.Puzzle.CheckIsValid();

        var resultsWriter = new TestResultsWriter();
        solution.OutputResults(resultsWriter);

        resultsWriter.Contains(Properties.Resources.PuzzleContainersAreEmpty).Should().BeTrue();
    }

    [Fact]
    public void PuzzleWrongNoOfColours_OutputError()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new(4, 0, [KnownColor.Green, KnownColor.Crimson, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 1, [KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 2, [KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 3));

        var solution = new Solution(puzzle);
        solution.Puzzle.CheckIsValid();

        var resultsWriter = new TestResultsWriter();
        solution.OutputResults(resultsWriter);

        resultsWriter.Contains(string.Format(Properties.Resources.WrongNumberOfColours, 4)).Should().BeTrue();
    }

    [Fact]
    public void ValidPuzzle_OutputResults()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new(4, 0, [KnownColor.Yellow, KnownColor.Green, KnownColor.Crimson, KnownColor.Blue]));
        puzzle.Containers.Add(new(4, 1, [KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 2, [KnownColor.Blue, KnownColor.Green, KnownColor.Yellow, KnownColor.Crimson]));
        puzzle.Containers.Add(new(4, 3, [KnownColor.Crimson, KnownColor.Green, KnownColor.Blue, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 4));

        var solution = new Solution(puzzle);
        solution.Puzzle.CheckIsValid();

        var resultsWriter = new TestResultsWriter();
        solution.OutputResults(resultsWriter);

        resultsWriter.Contains(Properties.Resources.PuzzleValid).Should().BeTrue();
        resultsWriter.Contains(string.Format(Properties.Resources.PuzzleFailedToSolve)).Should().BeTrue();
    }
}

public class TestResultsWriter : IWriter
{
    public List<string> Lines { get; } = [];
    
    public void WriteLine(string value)
    {
        Lines.Add(value);
    }

    public void WriteLine(string value, params object[] args)
    {
        Lines.Add(string.Format(value, args));
    }

    public bool Contains(string message)
    {
        return Lines.Any(line => line.Contains(message));
    }
}