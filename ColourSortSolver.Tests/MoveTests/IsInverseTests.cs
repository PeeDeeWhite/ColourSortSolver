using FluentAssertions;
using JetBrains.Annotations;
using System.Drawing;

namespace ColourSortSolver.Tests.MoveTests;

[TestSubject(typeof(Move))]
public class IsInverseTests
{
    private readonly Move _move1 = new Move(KnownColor.Red, 3, 1, 3, 2, 0);
    [Fact]
    public void CompareNull_ReturnsFalse()
    {

        _move1.IsInverse(null).Should().BeFalse();
    }

    [Fact]
    public void NotInverseValues_ReturnsFalse()
    {
        var move2 = new Move(KnownColor.Blue, 3, 2, 0, 1, 3);

        _move1.IsInverse(move2).Should().BeFalse();
    }

    [Fact]
    public void InverseValues_ReturnsTrue()
    {
        var move2 = new Move(KnownColor.Red, 3, 2, 0, 1, 3);

        _move1.IsInverse(move2).Should().BeTrue();
    }


}