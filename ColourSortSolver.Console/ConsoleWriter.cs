using System.Diagnostics.CodeAnalysis;

namespace ColourSortSolver.Console;

[ExcludeFromCodeCoverage]
public class ConsoleWriter : IWriter
{
    public void WriteLine(string value)
    {
        System.Console.WriteLine(value);
    }

    public void WriteLine(string value, params object[] args)
    {
        System.Console.WriteLine(value, args);
    }
}