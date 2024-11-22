using System.Text.Json.Serialization;
using ColourSortSolver.Properties;

namespace ColourSortSolver;

/// <summary>
/// Represents a Colour Sort puzzle which needs solving. Consists of multiple containers, each containing slots for colors.
/// </summary>
public class Puzzle
{
    private bool _isValidated;

    public Puzzle()
    {
        Containers = new List<Container>();
    }

    [JsonConstructor]
    public Puzzle(ICollection<Container> containers)
    {
        Containers = containers ?? new List<Container>();
    }
    
    public ICollection<Container> Containers { get; }

    public bool IsValid => _isValidated && Errors.Count == 0;
    
    public bool IsSolved => IsValid && Containers.All(x => x.IsSolved);
    
    public ICollection<Exception> Errors { get; } = new List<Exception>();

    public bool CheckIsValid()
    {
        if (_isValidated) return IsValid;
        
        _isValidated = true;
        
        if (Containers.Count == 0)
        {
            Errors.Add(new PuzzleException(Resources.PuzzleIsEmpty, this));
            return IsValid;
        }

        if (Containers.Any(x => x.Size < 1))
        {
            Errors.Add(new PuzzleException(Resources.PuzzleContainerMinimumSize, this));
        }

        var containerSizes = Containers.Select(x => x.Size).Distinct().ToArray();
        if (containerSizes.Length != 1)
        {
            Errors.Add(new PuzzleException(Resources.PuzzleContainersVaryingSizes, this));
        }

        var colours = Containers.SelectMany(x => x.Slots).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

        if (colours.All(x => x.Value == 0))
        {
            Errors.Add(new PuzzleException(Resources.PuzzleContainersAreEmpty, this));
        }

        if (colours.Any(x => x.Value != containerSizes[0]))
        {
            Errors.Add(new PuzzleException(string.Format(Resources.WrongNumberOfColours, containerSizes[0]), this));
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