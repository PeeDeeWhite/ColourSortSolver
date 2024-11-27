using System.Drawing;
using System.Text.Json.Serialization;

namespace ColourSortSolver;
/// <summary>
/// Represents a container used in a <see cref="Puzzle"/> to hold and manage colours.
/// </summary>
/// <param name="size">The size of the container, indicating the maximum number of colours it can hold.</param>
/// <param name="position">The position of the container within the Puzzle.</param>
public class Container(int size, int position)
{
    [JsonConstructor]
    public Container(int size, int position, IList<KnownColor> slots) : this(size, position)
    {
        if (slots != null)
        {
            Slots = slots;
        }
    }

    public int Size { get; } = size;
    public int Position { get; } = position;

    public IList<KnownColor> Slots { get; } = new List<KnownColor>(size);

    public bool IsFull => Slots.Count == Size;

    public bool IsEmpty => Slots.Count == 0;

    public bool IsSolved => IsFull && Slots.Distinct().Count() <= 1;

    public KnownColor? TopColour => IsEmpty ? null : Slots.Last();

    /// <summary>
    /// Gets all slots of the same colour from the top of the container if any.
    /// </summary>
    public List<KnownColor> MoveableColours => IsEmpty ? new List<KnownColor>() : Slots.GroupBy(x => x).Last().ToList();

    public bool CanAddColour(IList<KnownColor> colours)
    {
        return IsEmpty || (!IsFull && TopColour == colours.First() && colours.Count + Slots.Count <= Size);
    }
    
    public void AddColour(KnownColor colour)
    {
        if (!CanAddColour([colour])) return;
        Slots.Add(colour);
    }

    public Container Clone()
    {
        return new(Size, Position, new List<KnownColor>(Slots));
    }
}