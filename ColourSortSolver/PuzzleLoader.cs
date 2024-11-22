using System.Text.Json;
using ColourSortSolver.Properties;

namespace ColourSortSolver;

/// <summary>
/// Provides functionality to load Colour Sort puzzles from JSON files.
/// </summary>
public class PuzzleLoader
{
    private static readonly JsonSerializerOptions DefaultOptions = new()
    {
        Converters = { new KnownColorConverter() }
    };
    
    public static Puzzle LoadFromJsonFile(string? path)
    {
        var json = File.ReadAllText(ValidatedPath(path));

        return JsonSerializer.Deserialize<Puzzle>(json, DefaultOptions) ?? new Puzzle();
    }

    private static string ValidatedPath(string? path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (!File.Exists(path))
        {
            throw new FileNotFoundException(Resources.FileDoesNotExist, path);
        }
        
        return path;
    }

    public static string ParseFilenameFromArgs(string[] args)
    {
        if (args.Length != 1 || string.IsNullOrWhiteSpace(args[0]))
        {
            throw new ApplicationException(Resources.InvalidFilename);
        }

        return args[0];
    }
}