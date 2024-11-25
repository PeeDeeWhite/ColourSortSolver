using System.Drawing;

namespace ColourSortSolver;

/// <summary>
/// Represents a move in a <see cref="Solution"/>> to solve a Colour Sort puzzle. A move involves transferring a specified number of colours
/// from a source container to a destination container.
/// </summary>
public class Move
{
    public Move(KnownColor colour, int noOfColours, Container source, Container destination)
    {
        Colour = colour;
        Source = source.Clone();
        Destination = destination.Clone();
        NoOfColours = noOfColours;
    }

    public KnownColor Colour { get; }
    public Container Source { get; }
    public Container Destination { get; }

    public int NoOfColours { get; }
    
    public override string ToString()
    {
        return $"Move {NoOfColours} {Colour}(s) from container {Source.Position} to container {Destination.Position}.";
    }
}