using System.Drawing;
using FluentAssertions;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.PuzzleTests;

[TestSubject(typeof(Puzzle))]
public class CloneTests
{
    [Fact]
    public void EmptyPuzzle_Cloned()
    {
        var originalPuzzle = new Puzzle();
        var clone = originalPuzzle.Clone();
        clone.Should().NotBeNull();
        clone.Should().NotBeSameAs(originalPuzzle);
        clone.Containers.Should().BeEmpty();
        clone.Errors.Should().BeEmpty();
        clone.IsSolved.Should().BeFalse();
        clone.IsValid.Should().BeFalse();

        //Ensure clone does not have a reference to original
        originalPuzzle.Containers.Add(new Container(0,1));
        clone.Containers.Should().BeEmpty();
    }

    [Fact]
    public void PuzzleEmptyContainers_Cloned()
    {
        var originalPuzzle = new Puzzle(new List<Container> { new Container(3, 0), new Container(3, 1), new Container(3, 2) });
        var clone = originalPuzzle.Clone();
        clone.Should().NotBeNull();
        clone.Should().NotBeSameAs(originalPuzzle);
        clone.Containers.Should().BeEquivalentTo(originalPuzzle.Containers);
        clone.Errors.Should().BeEmpty();
        clone.IsSolved.Should().BeFalse();
        clone.IsValid.Should().BeFalse();

        //Ensure clone does not have a reference to original
        originalPuzzle.Containers[0].Slots.Add(KnownColor.Red);
        clone.Containers[0].Slots.Should().BeEmpty();
    }


    [Fact]
    public void PuzzlePopulatedContainers_Cloned()
    {
        var originalPuzzle = new Puzzle(new List<Container> { new Container(3, 0), new Container(3, 1), new Container(3, 2) });
        var clone = originalPuzzle.Clone();
        clone.Should().NotBeNull();
        clone.Should().NotBeSameAs(originalPuzzle);
        clone.Containers.Should().BeEquivalentTo(originalPuzzle.Containers);
        clone.Errors.Should().BeEmpty();
        clone.IsSolved.Should().BeFalse();
        clone.IsValid.Should().BeFalse();

        //Ensure clone does not have a reference to original
        originalPuzzle.Containers[0].Slots.Add(KnownColor.Red);
        clone.Containers[0].Slots.Should().BeEmpty();
    }
}