using System.Runtime.InteropServices;
using System.Text;
using MessagePack;
using MessagePack.Formatters;
using Zio;

namespace SoftTouch.Assets;

public class UPathFormatter : IMessagePackFormatter<UPath>
{
    public void Serialize(
      ref MessagePackWriter writer, UPath value, MessagePackSerializerOptions options)
    {
        writer.Write(value.FullName);
    }

    public UPath Deserialize(
      ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.TryReadNil())
        {
            return UPath.Empty;
        }

        options.Security.DepthStep(ref reader);

        var path = reader.ReadString();
        reader.Depth--;

        return new UPath(path);
    }
}