using System.Drawing;
using System.Text.Json;
using FluentAssertions;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.KnownColourConverterTests;

[TestSubject(typeof(KnownColorConverter))]
public class ReadTests
{
    private readonly JsonSerializerOptions _options = new()
    {
        Converters = { new KnownColorConverter() }
    };

    [Fact]
    public void ValidColorName_ReturnsKnownColor()
    {
        var json = "\"Red\"";

        var color = JsonSerializer.Deserialize<KnownColor>(json, _options);

        color.Should().Be(KnownColor.Red);
    }

    [Fact]
    public void InvalidColorName_ThrowsException()
    {
        var json = "\"InvalidColor\"";

        Action act = () => JsonSerializer.Deserialize<KnownColor>(json, _options);

        act.Should().Throw<ArgumentException>();
    }
}