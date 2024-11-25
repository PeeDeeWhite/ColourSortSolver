using System.Drawing;
using FluentAssertions;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.ContainerTests;

[TestSubject(typeof(Container))]
public class MoveableColoursTests
{
    [Fact]
    public void EmptyContainer_ReturnsEmptyList()
    {
        var container = new Container(3, 1);
        container.MoveableColours.Should().BeEmpty();
    }

    [Fact]
    public void ContainerWithOneTopColour_ReturnOneColour()
    {
        var container = new Container(3, 1, [KnownColor.Aqua,  KnownColor.Red]);
        container.MoveableColours.Should().BeEquivalentTo((List<KnownColor>) [KnownColor.Red]);
    }

    [Fact]
    public void ContainerWithMultipleTopColours_ReturnThoseColours()
    {
        var container = new Container(3, 1, [KnownColor.Aqua, KnownColor.Red, KnownColor.Red]);
        container.MoveableColours.Should().BeEquivalentTo((List<KnownColor>)[KnownColor.Red, KnownColor.Red]);
    }

    [Fact]
    public void ContainerWithAllOneTopColours_ReturnAllColours()
    {
        var container = new Container(3, 1, [KnownColor.Red, KnownColor.Red, KnownColor.Red]);
        container.MoveableColours.Should().BeEquivalentTo((List<KnownColor>)[KnownColor.Red, KnownColor.Red, KnownColor.Red]);
    }
}