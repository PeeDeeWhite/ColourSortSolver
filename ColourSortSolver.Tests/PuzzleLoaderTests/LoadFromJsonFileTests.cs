using JetBrains.Annotations;
using FluentAssertions;

namespace ColourSortSolver.Tests.PuzzleLoaderTests
{
    [TestSubject(typeof(PuzzleLoader))]
    public class LoadFromJsonFileTests
    {
        [Theory]
#pragma warning disable xUnit1012
        [InlineData(null)]
#pragma warning restore xUnit1012
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\t")]
        public void InvalidPathShouldThrowArgumentNullException(string path)
        {
            Action act = () => PuzzleLoader.LoadFromJsonFile(path);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FileDoesNotExistShouldThrowFileNotFoundException()
        {
            Action act = () => PuzzleLoader.LoadFromJsonFile(".\\nonexistentfile.json");
            act.Should().Throw<FileNotFoundException>();
        }

        [Fact]
        public void InvalidJsonShouldReturnEmptyPuzzle()
        {
            var puzzle = PuzzleLoader.LoadFromJsonFile(".\\PuzzleLoaderTests\\invalidpuzzle.json");

            puzzle.Should().NotBeNull();
            puzzle.Containers.Should().BeEmpty();
            puzzle.Errors.Should().BeEmpty();
        }

        [Fact]
        public void ValidFileShouldReturnPuzzle()
        {
            //var newPuzzle = new Puzzle(new List<Container> {new Container(4, 0, new List<KnownColor> {KnownColor.Aqua, KnownColor.Beige})});

            //File.WriteAllText(".\\PuzzleLoaderTests\\puzzle.json", JsonSerializer.Serialize(newPuzzle, new JsonSerializerOptions() { Converters = { new KnownColorConverter() } }));
            
            var puzzle = PuzzleLoader.LoadFromJsonFile(".\\PuzzleLoaderTests\\validpuzzle.json");

            puzzle.Should().NotBeNull();
            puzzle.Containers.Should().NotBeEmpty();
            puzzle.Errors.Should().BeEmpty();
        }
    }
}