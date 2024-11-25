using System.Drawing;
using FluentAssertions;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.PuzzleTests;

[TestSubject(typeof(Puzzle))]
public class ValidationTests
{
    [Fact]
    public void NoContainers_ReportError()
    {
        var puzzle = new Puzzle();

        puzzle.CheckIsValid();

        CheckForError(puzzle, Properties.Resources.PuzzleIsEmpty);
    }

    [Fact]
    public void ContainersEmpty_ReportError()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new(4, 0));
        puzzle.Containers.Add(new(4, 1));

        puzzle.CheckIsValid();

        CheckForError(puzzle, Properties.Resources.PuzzleContainersAreEmpty);
    }

    [Fact]
    public void ContainersOfVaryingSize_ReportError()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new(4, 0,  [KnownColor.Green, KnownColor.Blue, KnownColor.Crimson]));
        puzzle.Containers.Add(new(3, 1,  [KnownColor.Green, KnownColor.Blue]));

        puzzle.CheckIsValid();

        CheckForError(puzzle, Properties.Resources.PuzzleContainersVaryingSizes);
    }

    [Fact]
    public void ColoursLessThanContainerSize_ReportError()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new(4, 0, [KnownColor.Green, KnownColor.Crimson, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 1, [KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 2, [KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 3));

        puzzle.CheckIsValid();

        CheckForError(puzzle, string.Format(Properties.Resources.WrongNumberOfColours, 4));
    }

    [Fact]
    public void ColoursGreaterThanContainerSize_ReportError()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new(4, 0, [KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 1, [KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow, KnownColor.Aqua]));
        puzzle.Containers.Add(new(4, 2, [KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow]));
        puzzle.Containers.Add(new(4, 3));

        puzzle.CheckIsValid();

        CheckForError(puzzle, string.Format(Properties.Resources.WrongNumberOfColours, 4));
    }

    [Fact]
    public void ContainersFilledWithCorrectColours_NoErrorsReported()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new(3, 0, [KnownColor.Green, KnownColor.Green]));
        puzzle.Containers.Add(new(3, 1, [KnownColor.Yellow, KnownColor.Yellow, KnownColor.Yellow]));
        puzzle.Containers.Add(new(3, 2, [KnownColor.Crimson, KnownColor.Crimson, KnownColor.Crimson]));
        puzzle.Containers.Add(new(3, 3, [KnownColor.Green]));

        puzzle.CheckIsValid();

        puzzle.IsValid.Should().BeTrue();
        puzzle.IsSolved.Should().BeFalse();
    }

    [Fact]
    public void ContainersFilledWithCorrectColoursInCorrectPosition_NoErrorsReportedAndIsSolvedTrue()
    {
        var puzzle = TestHelpers.CreateValidPuzzle();

        puzzle.CheckIsValid();
        
        puzzle.IsValid.Should().BeTrue();
        puzzle.IsSolved.Should().BeTrue();
    }

    [Fact]
    public void SecondCallToCheckIsValid_ReturnsInitialResult()
    {
        var puzzle = TestHelpers.CreateValidPuzzle();

        puzzle.IsValid.Should().BeFalse();
        puzzle.IsSolved.Should().BeFalse();
        puzzle.Errors.Should().BeEmpty();

        puzzle.CheckIsValid();

        puzzle.IsValid.Should().BeTrue();
        puzzle.IsSolved.Should().BeTrue();
        puzzle.Errors.Should().BeEmpty();

        puzzle.CheckIsValid();

        puzzle.IsValid.Should().BeTrue();
        puzzle.IsSolved.Should().BeTrue();
        puzzle.Errors.Should().BeEmpty();
    }

    private void CheckForError(Puzzle puzzle, string message)
    {
        puzzle.IsValid.Should().BeFalse();
        puzzle.Errors.Should().ContainSingle(e => e is PuzzleException && e.Message.Contains(message));
        puzzle.Errors.Select(x => ((PuzzleException) x).Puzzle).Should().AllBeEquivalentTo(puzzle);
        ((PuzzleException)puzzle.Errors.First()).Puzzle.Should().Be(puzzle);
    }
}