namespace ColourSortSolver.Console;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string value)
    {
        System.Console.WriteLine(value);
    }
}