using System.Drawing;

namespace ColourSortSolver;

public class Move
{
    public Move(KnownColor colour, ColourContainer source, int sourceIndex, ColourContainer destination, int destinationIndex, int noOfColours)
    {
        Colour = colour;
        Source = source;
        SourceIndex = sourceIndex;
        Destination = destination;
        DestinationIndex = destinationIndex;
        NoOfColours = noOfColours;
    }

    public ColourContainer Source { get; }
    public int SourceIndex { get; }
    public ColourContainer Destination { get; }
    public int DestinationIndex { get; }
    public KnownColor Colour { get; }

    public int NoOfColours { get; }
}