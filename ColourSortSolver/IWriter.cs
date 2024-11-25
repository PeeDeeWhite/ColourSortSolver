namespace ColourSortSolver;

public interface IWriter
{
    void WriteLine(string value);
    void WriteLine(string value, params object[] args);
}
