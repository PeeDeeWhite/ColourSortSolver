using System.Drawing;

namespace ColourSortSolver;

/// <summary>
/// Represents a move in a <see cref="Solution"/>> to solve a Colour Sort puzzle. A move involves transferring a specified number of colours
/// from a source container to a destination container.
/// </summary>
public class Move
{
    public Move(KnownColor colour, Container source, int sourceIndex, Container destination, int destinationIndex, int noOfColours)
    {
        Colour = colour;
        Source = source.Clone();
        SourceIndex = sourceIndex;
        Destination = destination.Clone();
        DestinationIndex = destinationIndex;
        NoOfColours = noOfColours;
    }

    public Container Source { get; }
    public int SourceIndex { get; }
    public Container Destination { get; }
    public int DestinationIndex { get; }
    public KnownColor Colour { get; }

    public int NoOfColours { get; }
}