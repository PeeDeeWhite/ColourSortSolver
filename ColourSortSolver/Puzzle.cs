namespace ColourSortSolver;

public class Puzzle
{
    private bool _isValidated;

    public Puzzle()
    {
        Containers = new List<ColourContainer>();
        Errors = new List<Exception>();
    }

    public ICollection<ColourContainer> Containers { get; }

    public bool IsValid => _isValidated && Errors.Count == 0;
    
    public bool IsSolved => IsValid && Containers.All(x => x.IsSolved);
    
    public ICollection<Exception> Errors { get; }
    
    public bool CheckIsValid()
    {
        if (_isValidated) return IsValid;
        
        _isValidated = true;
        
        if (Containers.Count == 0)
        {
            Errors.Add(new PuzzleException("Puzzle is empty", this));
        }

        if (Containers.Any(x => x.Size < 1))
        {
            Errors.Add(new PuzzleException("Puzzle container must all have a minimum size of 1", this));
        }

        var containerSizes = Containers.Select(x => x.Size).Distinct().ToArray();
        if (containerSizes.Length != 1)
        {
            Errors.Add(new PuzzleException("Puzzle containers are of varying sizes", this));
        }

        var colours = Containers.SelectMany(x => x.Slots).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

        if (colours.All(x => x.Value == 0))
        {
            Errors.Add(new PuzzleException("All Puzzle slots are empty", this));
        }

        if (colours.Any(x => x.Value != containerSizes[0]))
        {
            Errors.Add(new PuzzleException($"Each colour must be present {containerSizes[0]} times", this));
        }

        return IsValid;
    }
    
    public bool CanMakeValidMove()
    { 
        if (IsSolved) return false;
            
        if (Containers.Any(x => x.Slots.Count == 0)) return true;

        return Containers
            .Where(x => x.Slots.Count == 0)
            .Any(container => Containers.Any(x => x != container && x.CanAddColour(container.Slots.Last())));
    }

}