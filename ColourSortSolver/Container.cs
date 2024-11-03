using System.Drawing;

namespace ColourSortSolver;

public class ColourContainer
{
    public ColourContainer(int size, int position)
    {
        Size = size;
        Position = position;
        Slots = new List<KnownColor>(size);
    }

    public ColourContainer(int size, int position, ICollection<KnownColor> initialColors) : this(size, position)
    {
        Slots = initialColors ?? new List<KnownColor>(size);
    }

    public int Size { get; }
    public int Position { get; }

    public ICollection<KnownColor> Slots { get; }

    public bool IsFull => Slots.Count == Size;

    public bool IsEmpty => Slots.Count == 0;

    public bool IsSolved => IsEmpty || (IsFull && Slots.Distinct().Count() <= 1);
    
    public bool CanAddColour(KnownColor colour)
    {
        return IsEmpty || (!IsFull && Slots.Last() == colour);
    }
    
    public void AddColour(KnownColor colour)
    {
        if (!CanAddColour(colour)) return;
        Slots.Add(colour);
    }

    public ColourContainer Clone()
    {
        return new ColourContainer(Size, Position, new List<KnownColor>(Slots));
    }
}