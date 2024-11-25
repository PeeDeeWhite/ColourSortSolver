using System.Drawing;
using System.Text.Json;
using FluentAssertions;
using JetBrains.Annotations;

namespace ColourSortSolver.Tests.KnownColourConverterTests;

[TestSubject(typeof(KnownColorConverter))]
public class WriteTests
{
    private readonly JsonSerializerOptions _options = new()
    {
        Converters = { new KnownColorConverter() }
    };

    [Fact]
    public void ValidKnownColor_ReturnsJsonString()
    {
        var color = KnownColor.Blue;

        var json = JsonSerializer.Serialize(color, _options);

        json.Should().Be("\"Blue\"");
    }

    [Fact]
    public void InvalidKnownColor_ThrowsException()
    {
        var color = (KnownColor)999;

        Action act = () => JsonSerializer.Serialize(color, _options);

        act.Should().Throw<ArgumentException>();
    }
}