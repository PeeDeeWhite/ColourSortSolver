using FluentAssertions;
using JetBrains.Annotations;
using System.Drawing;

namespace ColourSortSolver.Tests.MoveTests;

[TestSubject(typeof(Move))]
public class EqualityTests
{
    private readonly Move _move1 = new(KnownColor.Red, 3, 1, 3, 2, 0);

    [Fact]
    public void CompareNull_ReturnsFalse()
    {
        _move1.Equals(null).Should().BeFalse();
    }

    [Fact]
    public void SameReference_ReturnsTrue()
    {
        var move2 = _move1;
        _move1.Equals(move2).Should().BeTrue();
    }

    [Fact]
    public void SameValues_ReturnsTrue()
    {
        var move2 = new Move(KnownColor.Red, 3, 1, 3, 2, 0);

        _move1.Equals(move2).Should().BeTrue();
    }

    [Fact]
    public void DifferentValues_ReturnsFalse()
    {
        var move2 = new Move(KnownColor.Blue, 3, 1, 3, 2, 0);

        _move1.Equals(move2).Should().BeFalse();
    }
    
    [Fact]
    public void EqualsOperatorNull_ReturnsFalse()
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        (_move1 == null).Should().BeFalse();
    }

    [Fact]
    public void EqualsOperatorSameReference_ReturnsTrue()
    {
        var move2 = _move1;
        (_move1 == move2).Should().BeTrue();
    }

    [Fact]
    public void EqualsOperatorSameValues_ReturnsTrue()
    {
        var move2 = new Move(KnownColor.Red, 3, 1, 3, 2, 0);

        (_move1 == move2).Should().BeTrue();
    }

    [Fact]
    public void EqualsOperatorDifferentValues_ReturnsFalse()
    {
        var move2 = new Move(KnownColor.Blue, 3, 1, 3, 2, 0);

        (_move1 == move2).Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperatorNull_ReturnsFalse()
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        (_move1 != null).Should().BeTrue();
    }

    [Fact]
    public void NotEqualsOperatorSameReference_ReturnsFalse()
    {
        var move2 = _move1;
        (_move1 != move2).Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperatorSameValues_ReturnsFalse()
    {
        var move2 = new Move(KnownColor.Red, 3, 1, 3, 2, 0);

        (_move1 != move2).Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperatorDifferentValues_ReturnsTrue()
    {
        var move2 = new Move(KnownColor.Blue, 3, 1, 3, 2, 0);

        (_move1 != move2).Should().BeTrue();
    }

    [Fact]
    public void ObjectCompareNull_ReturnsFalse()
    {
        _move1.Equals((object)null!).Should().BeFalse();
    }

    [Fact]
    public void ObjectDifferentType_ReturnsFalse()
    {
        // ReSharper disable once SuspiciousTypeConversion.Global
        _move1.Equals("Not a Move Object").Should().BeFalse();
    }

    [Fact]
    public void ObjectSameReference_ReturnsTrue()
    {
        object move2 = _move1;
        _move1.Equals(move2).Should().BeTrue();
    }

    [Fact]
    public void ObjectSameValues_ReturnsTrue()
    {
        object move2 = new Move(KnownColor.Red, 3, 1, 3, 2, 0);

        _move1.Equals(move2).Should().BeTrue();
    }

    [Fact]
    public void ObjectDifferentValues_ReturnsFalse()
    {
        object move2 = new Move(KnownColor.Blue, 3, 1, 3, 2, 0);

        _move1.Equals(move2).Should().BeFalse();
    }

}