using Utf8Json;
using Utf8Json.Formatters;
using System.Globalization;
using Zio;

namespace SoftTouch.Assets.Serialization.JSON;

public class UPathStringFormatter : IJsonFormatter<UPath>
{
    public UPath Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
    {
        return new UPath(reader.ReadString());
    }

    public void Serialize(ref JsonWriter writer, UPath value, IJsonFormatterResolver formatterResolver)
    {
        writer.WriteString(value.FullName);
    }
}