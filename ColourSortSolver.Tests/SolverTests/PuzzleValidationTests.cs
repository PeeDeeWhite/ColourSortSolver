using System.Drawing;
using FluentAssertions;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.SolverTests;

[TestSubject(typeof(Solver))]
public class PuzzleValidationTests
{
    [Fact]
    public void NullPuzzleThrowsException()
    {
        // ReSharper disable once ObjectCreationAsStatement
        var action = new Action(() => new Solver(null!));

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void NoContainersThenInvalid()
    {
        var solver = new Solver(new Puzzle());

        var solution = solver.TryAndSolve();

        solution.Puzzle.IsValid.Should().BeFalse();
    }

    [Fact]
    public void ContainersEmptyThenInvalid()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new ColourContainer(4, 0));
        puzzle.Containers.Add(new ColourContainer(4, 1));

        var solver = new Solver(puzzle);

        var solution = solver.TryAndSolve();

        solution.IsSolved.Should().BeFalse();
        solution.Puzzle.IsValid.Should().BeFalse();
    }

    [Fact]
    public void ContainersOfVaryingSizeThenInvalid()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new ColourContainer(4, 0, new List<KnownColor> { KnownColor.Green, KnownColor.Blue, KnownColor.Crimson }));
        puzzle.Containers.Add(new ColourContainer(3, 1, new List<KnownColor> { KnownColor.Green, KnownColor.Blue }));

        var solver = new Solver(puzzle);

        var solution = solver.TryAndSolve();

        solution.Puzzle.IsValid.Should().BeFalse();
    }

    [Fact]
    public void ColoursLessThanContainerSizeThenInvalid()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new ColourContainer(4, 0, new List<KnownColor> { KnownColor.Green, KnownColor.Crimson, KnownColor.Yellow }));
        puzzle.Containers.Add(new ColourContainer(4, 1, new List<KnownColor> { KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow }));
        puzzle.Containers.Add(new ColourContainer(4, 2, new List<KnownColor> { KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow }));
        puzzle.Containers.Add(new ColourContainer(4, 3));

        var solver = new Solver(puzzle);

        var solution = solver.TryAndSolve();

        solution.Puzzle.IsValid.Should().BeFalse();
    }

    [Fact]
    public void ColoursGreaterThanContainerSizeThenInvalid()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new ColourContainer(4, 0, new List<KnownColor> { KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow }));
        puzzle.Containers.Add(new ColourContainer(4, 1, new List<KnownColor> { KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow, KnownColor.Aqua }));
        puzzle.Containers.Add(new ColourContainer(4, 2, new List<KnownColor> { KnownColor.Green, KnownColor.Blue, KnownColor.Crimson, KnownColor.Yellow }));
        puzzle.Containers.Add(new ColourContainer(4, 3));

        var solver = new Solver(puzzle);

        var solution = solver.TryAndSolve();

        solution.Puzzle.IsValid.Should().BeFalse();
    }

    [Fact]
    public void ContainersFilledWithCorrectColoursThenValid()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new ColourContainer(3, 0, new List<KnownColor> { KnownColor.Green, KnownColor.Green }));
        puzzle.Containers.Add(new ColourContainer(3, 1, new List<KnownColor> { KnownColor.Yellow, KnownColor.Yellow, KnownColor.Yellow }));
        puzzle.Containers.Add(new ColourContainer(3, 2, new List<KnownColor> { KnownColor.Crimson, KnownColor.Crimson, KnownColor.Crimson }));
        puzzle.Containers.Add(new ColourContainer(3, 3, new List<KnownColor> { KnownColor.Green}));

        var solver = new Solver(puzzle);

        var solution = solver.TryAndSolve();

        solution.Puzzle.IsValid.Should().BeTrue();
        solution.IsSolved.Should().BeFalse();
    }

    [Fact]
    public void ContainersFilledWithCorrectColoursInCorrectPositionThenValidAndSolved()
    {
        var puzzle = new Puzzle();
        puzzle.Containers.Add(new ColourContainer(3, 0, new List<KnownColor> { KnownColor.Green, KnownColor.Green, KnownColor.Green }));
        puzzle.Containers.Add(new ColourContainer(3, 1, new List<KnownColor> { KnownColor.Yellow, KnownColor.Yellow, KnownColor.Yellow }));
        puzzle.Containers.Add(new ColourContainer(3, 2, new List<KnownColor> { KnownColor.Crimson, KnownColor.Crimson, KnownColor.Crimson }));
        puzzle.Containers.Add(new ColourContainer(3, 3, new List<KnownColor> { KnownColor.Blue, KnownColor.Blue, KnownColor.Blue }));
        puzzle.Containers.Add(new ColourContainer(3, 4));
        puzzle.Containers.Add(new ColourContainer(3, 5));

        var solver = new Solver(puzzle);

        var solution = solver.TryAndSolve();

        solution.Puzzle.IsValid.Should().BeTrue();
        solution.IsSolved.Should().BeTrue();
    }
    
}