using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace ColourSortSolver;

/// <summary>
/// Represents a move in a <see cref="Solution"/>> to solve a Colour Sort puzzle. A move involves transferring a specified number of colours
/// from a source container to a destination container.
/// </summary>
public class Move : IEquatable<Move>
{
    public Move(KnownColor colour, int noOfColours, int sourceIndex, int sourceSlots, int destinationIndex, int destinationSlots)
    {
        Colour = colour;
        NoOfColours = noOfColours;
        SourceIndex = sourceIndex;
        SourceSlots = sourceSlots;
        DestinationIndex = destinationIndex;
        DestinationSlots = destinationSlots;
    }

    public KnownColor Colour { get; }
    public int SourceIndex { get; }
    public int SourceSlots { get; }
    public int DestinationIndex { get; }
    public int DestinationSlots { get; }

    public int NoOfColours { get; }

    public override string ToString()
    {
        return $"Move {NoOfColours} {Colour}(s) from container {SourceIndex} to container {DestinationIndex}.";
    }

    public bool IsInverse(Move? other)
    {
        if (other is null) return false;
        return Colour == other.Colour && SourceIndex == other.DestinationIndex && DestinationIndex == other.SourceIndex && NoOfColours == other.NoOfColours;
    }

    public Move Invert()
    {
        return new Move(Colour, NoOfColours, DestinationIndex, DestinationSlots, SourceIndex, SourceSlots);
    }

    public bool Equals(Move? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Colour == other.Colour && SourceIndex ==other.SourceIndex && DestinationIndex == other.DestinationIndex && NoOfColours == other.NoOfColours;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Move) obj);
    }

    [ExcludeFromCodeCoverage]
    public override int GetHashCode()
    {
        return HashCode.Combine((int)Colour, SourceIndex, DestinationIndex, NoOfColours);
    }

    public static bool operator ==(Move? left, Move? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }
    public static bool operator !=(Move? left, Move? right)
    {
        return !(left == right);
    }
}