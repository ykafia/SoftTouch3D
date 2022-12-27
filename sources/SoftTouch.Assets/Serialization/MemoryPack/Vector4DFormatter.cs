using MemoryPack;
using Silk.NET.Maths;

namespace SoftTouch.Assets.Serialization.MemoryPack;

[MemoryPackable]
public readonly partial struct SerializableVector4D<T>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    [MemoryPackIgnore]
    public readonly Vector4D<T> Vector = Vector4D<T>.Zero;

    [MemoryPackInclude]
    public T X => Vector.X;

    [MemoryPackInclude]
    public T Y => Vector.Y;

    [MemoryPackInclude]
    public T Z => Vector.Z;

    [MemoryPackInclude]
    public T W => Vector.W;


    [MemoryPackConstructor]
    SerializableVector4D(T x, T y, T z, T w)
    {
        Vector = new(x, y, z, w);
    }

    public SerializableVector4D(Vector4D<T>? vector)
    {
        Vector = vector ?? Vector4D<T>.Zero;
    }
}


public class Vector4DFormatter<T> : MemoryPackFormatter<Vector4D<T>?>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    public override void Deserialize(ref MemoryPackReader reader, scoped ref Vector4D<T>? value)
    {
        if (reader.PeekIsNull())
        {
            value = null;
            return;
        }
        var wrapped = reader.ReadPackable<SerializableVector4D<T>>();
        value = wrapped.Vector;
    }

    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref Vector4D<T>? value)
    {
        if(value is null)
        {
            writer.WriteNullObjectHeader();
            return;
        }
        writer.WritePackable(new SerializableVector4D<T>(value));
    }
}