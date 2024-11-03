using System.Text.Json;

namespace ColourSortSolver;

public class PuzzleLoader
{
    public static Puzzle LoadFromJsonFile(string? path)
    {
        var json = File.ReadAllText(ValidatedPath(path));

        return JsonSerializer.Deserialize<Puzzle>(json) ?? new Puzzle();
    }

    private static string ValidatedPath(string? path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (!File.Exists(path))
        {
            throw new FileNotFoundException("The file does not exist.", path);
        }
        
        return path;
    }
}