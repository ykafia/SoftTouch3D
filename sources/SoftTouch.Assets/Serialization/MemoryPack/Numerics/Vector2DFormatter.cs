using MemoryPack;
using Silk.NET.Maths;
using System.Runtime.InteropServices;

namespace SoftTouch.Assets.Serialization.MemoryPack;

[MemoryPackable]
[StructLayout(LayoutKind.Auto)]
public readonly partial struct SerializableVector2D<T>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    [MemoryPackIgnore]
    public readonly Vector2D<T> Vector = Vector2D<T>.Zero;

    [MemoryPackInclude]
    public T X => Vector.X;
    
    [MemoryPackInclude]
    public T Y => Vector.Y;

    public SerializableVector2D(T x, T y)
    {
        Vector = new(x,y);
    }

    public SerializableVector2D(Vector2D<T>? vector)
    {
        Vector = vector ?? Vector2D<T>.Zero;
    }
}

public class Vector2DFormatter<T> : MemoryPackFormatter<Vector2D<T>?>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    public override void Deserialize(ref MemoryPackReader reader, scoped ref Vector2D<T>? value)
    {
        if(reader.PeekIsNull())
        {
            value = null;
            return;
        }
        var wrapped = reader.ReadPackable<SerializableVector2D<T>>();
        value = wrapped.Vector;
    }

    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref Vector2D<T>? value)
    {
        if(value is null)
        {
            writer.WriteNullObjectHeader();
            return;
        }
        writer.WritePackable(new SerializableVector2D<T>(value));
    }
}