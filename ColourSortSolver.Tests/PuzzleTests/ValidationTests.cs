using System.Drawing;
using FluentAssertions;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.PuzzleTests;

[TestSubject(typeof(Solver))]
public class ValidationTests
{
    [Fact]
    public void NoContainersThenInvalid()
    {
        var puzzle = new Puzzle();

        puzzle.CheckIsValid();

        CheckForError(puzzle, Properties.Resources.PuzzleIsEmpty);
    }

    [Fact]
    public void ContainersEmptyThenInvalid()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new Container(4, 0));
        puzzle.Containers.Add(new Container(4, 1));

        puzzle.CheckIsValid();

        CheckForError(puzzle, Properties.Resources.PuzzleContainersAreEmpty);
    }

    [Fact]
    public void ContainersOfVaryingSizeThenInvalid()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new Container(4, 0, new List<KnownColor> { KnownColor.Green, KnownColor.Blue, KnownColor.Crimson }));
        puzzle.Containers.Add(new Container(3, 1, new List<KnownColor> { KnownColor.Green, KnownColor.Blue }));

        puzzle.CheckIsValid();

        CheckForError(puzzle, Properties.Resources.PuzzleContainersVaryingSizes);
    }

    [Fact]
    public void ColoursLessThanContainerSizeThenInvalid()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new Container(4, 0, new List<KnownColor> { KnownColor.Green, KnownColor.Crimson, KnownColor.Yellow }));
        puzzle.Containers.Add(new Container(4, 1, new List<KnownColor> { KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow }));
        puzzle.Containers.Add(new Container(4, 2, new List<KnownColor> { KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow }));
        puzzle.Containers.Add(new Container(4, 3));

        puzzle.CheckIsValid();

        CheckForError(puzzle, string.Format(Properties.Resources.WrongNumberOfColours, 4));
    }

    [Fact]
    public void ColoursGreaterThanContainerSizeThenInvalid()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new Container(4, 0, new List<KnownColor> { KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow }));
        puzzle.Containers.Add(new Container(4, 1, new List<KnownColor> { KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow, KnownColor.Aqua }));
        puzzle.Containers.Add(new Container(4, 2, new List<KnownColor> { KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow }));
        puzzle.Containers.Add(new Container(4, 3));

        puzzle.CheckIsValid();

        CheckForError(puzzle, string.Format(Properties.Resources.WrongNumberOfColours, 4));
    }

    [Fact]
    public void ContainersFilledWithCorrectColoursThenValid()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new Container(3, 0, new List<KnownColor> { KnownColor.Green, KnownColor.Green }));
        puzzle.Containers.Add(new Container(3, 1, new List<KnownColor> { KnownColor.Yellow, KnownColor.Yellow, KnownColor.Yellow }));
        puzzle.Containers.Add(new Container(3, 2, new List<KnownColor> { KnownColor.Crimson, KnownColor.Crimson, KnownColor.Crimson }));
        puzzle.Containers.Add(new Container(3, 3, new List<KnownColor> { KnownColor.Green}));

        puzzle.CheckIsValid();

        puzzle.IsValid.Should().BeTrue();
        puzzle.IsSolved.Should().BeFalse();
    }

    [Fact]
    public void ContainersFilledWithCorrectColoursInCorrectPositionThenValidAndSolved()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new Container(3, 0, new List<KnownColor> { KnownColor.Green, KnownColor.Green, KnownColor.Green }));
        puzzle.Containers.Add(new Container(3, 1, new List<KnownColor> { KnownColor.Yellow, KnownColor.Yellow, KnownColor.Yellow }));
        puzzle.Containers.Add(new Container(3, 2, new List<KnownColor> { KnownColor.Crimson, KnownColor.Crimson, KnownColor.Crimson }));
        puzzle.Containers.Add(new Container(3, 3, new List<KnownColor> { KnownColor.Blue, KnownColor.Blue, KnownColor.Blue }));
        puzzle.Containers.Add(new Container(3, 4));
        puzzle.Containers.Add(new Container(3, 5));

        puzzle.CheckIsValid();
        
        puzzle.IsValid.Should().BeTrue();
        puzzle.IsSolved.Should().BeTrue();
    }

    private void CheckForError(Puzzle puzzle, string message)
    {
        puzzle.IsValid.Should().BeFalse();
        puzzle.Errors.Should().ContainSingle(e => e is PuzzleException && e.Message.Contains(message));
    }
}