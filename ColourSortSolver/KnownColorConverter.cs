using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ColourSortSolver;

/// <summary>
/// Converts KnownColor values to and from JSON.
/// </summary>
public class KnownColorConverter : JsonConverter<KnownColor>
{
    public override KnownColor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var colorName = reader.GetString();
        return (KnownColor) Enum.Parse(typeof(KnownColor), colorName ?? throw new InvalidOperationException(Properties.Resources.Unknowncolour));
    }

    public override void Write(Utf8JsonWriter writer, KnownColor value, JsonSerializerOptions options)
    {
        if (Enum.IsDefined(typeof(KnownColor), value))
        {
            writer.WriteStringValue(value.ToString());
            return;
        }

        throw new ArgumentException(nameof(value));
    }
}