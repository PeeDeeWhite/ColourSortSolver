﻿using JetBrains.Annotations;
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
        public void InvalidPaths_ThrowArgumentNullException(string path)
        {
            Action act = () => PuzzleLoader.LoadFromJsonFile(path);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FileNotExist_ThrowFileNotFoundException()
        {
            Action act = () => PuzzleLoader.LoadFromJsonFile(".\\nonexistentfile.json");
            act.Should().Throw<FileNotFoundException>();
        }

        [Fact]
        public void EmptyJson_ReturnsEmptyPuzzle()
        {
            var puzzle = PuzzleLoader.LoadFromJsonFile(".\\emptypuzzle.json");

            puzzle.Should().NotBeNull();
            puzzle.Containers.Should().BeEmpty();
            puzzle.Errors.Should().BeEmpty();
        }

        [Fact]
        public void ValidFile_ReturnsHydratedPuzzle()
        {
            var puzzle = PuzzleLoader.LoadFromJsonFile(".\\validpuzzle.json");

            puzzle.Should().NotBeNull();
            puzzle.Containers.Should().NotBeEmpty();
            puzzle.Errors.Should().BeEmpty();
            for (var index = 0; index < 3; index++)
            {
                var container = puzzle.Containers[index];
                container.IsFull.Should().BeTrue();
            }
            puzzle.Containers[3].Slots.Should().BeEmpty();
        }
    }
}