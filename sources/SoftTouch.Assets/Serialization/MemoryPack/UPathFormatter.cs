using System.Runtime.InteropServices;
using System.Text;
using MemoryPack;
using Zio;

namespace SoftTouch.Assets.Serialization.MemoryPack;

[MemoryPackable]
public readonly partial struct SerializableUPath
{
    [MemoryPackIgnore]
    public readonly UPath Path = UPath.Empty;

    [MemoryPackInclude]
    public string FullName => Path.FullName;

    [MemoryPackConstructor]
    SerializableUPath(string fullName)
    {
        Path = new(fullName);
    }

    public SerializableUPath(UPath? path)
    {
        Path = path ?? UPath.Empty;
    }
}

public class UPathFormatter : MemoryPackFormatter<UPath?>
{
    public override void Deserialize(ref MemoryPackReader reader, scoped ref UPath? value)
    {
        if (reader.PeekIsNull())
        {
            value = null;
            return;
        }
        var wrapped = reader.ReadPackable<SerializableUPath>();
        value = wrapped.Path;
    }

    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref UPath? value)
    {
        if (value is null)
        {
            writer.WriteNullObjectHeader();
            return;
        }
        writer.WritePackable(new SerializableUPath(value));
    }
}