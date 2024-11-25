using ColourSortSolver.Properties;
using FluentAssertions;

namespace ColourSortSolver.Tests.PuzzleLoaderTests;

public class ParseFilenameTests
{
    [Fact]
    public void EmptyArguments_ThrowsException()
    {
        Action act = () => PuzzleLoader.ParseFilenameFromArgs([]);
        act.Should().Throw<ApplicationException>().WithMessage(Resources.InvalidFilename);
    }

    [Fact]
    public void MultipleArguments_ThrowsException()
    {
        Action act = () => PuzzleLoader.ParseFilenameFromArgs(["File", "Extra"]);
        act.Should().Throw<ApplicationException>().WithMessage(Resources.InvalidFilename);
    }


    [Fact]
    public void FirstArgumentEmpty_ThrowsException()
    {
        Action act = () => PuzzleLoader.ParseFilenameFromArgs([""]);
        act.Should().Throw<ApplicationException>().WithMessage(Resources.InvalidFilename);
    }

    [Fact]
    public void FirstArgumentWhitespace_ThrowsException()
    {
        Action act = () => PuzzleLoader.ParseFilenameFromArgs([" "]);
        act.Should().Throw<ApplicationException>().WithMessage(Resources.InvalidFilename);
    }

    [Fact]
    public void FirstArgumentNull_ThrowsException()
    {
        Action act = () => PuzzleLoader.ParseFilenameFromArgs([null!]);
        act.Should().Throw<ApplicationException>().WithMessage(Resources.InvalidFilename);
    }

    [Fact]
    public void SingleValidArgument_ReturnsArgument()
    {
        PuzzleLoader.ParseFilenameFromArgs(["filename"]).Should().Be("filename");
    }
}