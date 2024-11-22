﻿using FluentAssertions;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.SolverTests;

[TestSubject(typeof(Solver))]
public class ConstructorTests
{
    [Fact]
    public void NullPuzzleThrowsException()
    {
        // ReSharper disable once ObjectCreationAsStatement
        var action = new Action(() => new Solver(null!));

        action.Should().Throw<ArgumentNullException>();
    }
}