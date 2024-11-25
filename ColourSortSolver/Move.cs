using System.Drawing;

namespace ColourSortSolver;

/// <summary>
/// Represents a move in a <see cref="Solution"/>> to solve a Colour Sort puzzle. A move involves transferring a specified number of colours
/// from a source container to a destination container.
/// </summary>
public class Move : IEquatable<Move>
{
    public Move(KnownColor colour, int noOfColours, int sourceIndex, int destinationIndex)
    {
        Colour = colour;
        SourceIndex = sourceIndex;
        DestinationIndex = destinationIndex;
        NoOfColours = noOfColours;
    }

    public KnownColor Colour { get; }
    public int SourceIndex { get; }
    public int DestinationIndex { get; }

    public int NoOfColours { get; }

    public override string ToString()
    {
        return $"Move {NoOfColours} {Colour}(s) from container {SourceIndex} to container {DestinationIndex}.";
    }

    public bool Equals(Move? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Colour == other.Colour && SourceIndex.Equals(other.SourceIndex) && DestinationIndex.Equals(other.DestinationIndex) && NoOfColours == other.NoOfColours;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Move) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int) Colour, SourceIndex, DestinationIndex, NoOfColours);
    }
}