using MemoryPack;
using Silk.NET.Maths;
using System.Runtime.InteropServices;

namespace SoftTouch.Assets.Serialization.MemoryPack;

[MemoryPackable]
[StructLayout(LayoutKind.Auto)]
public readonly partial struct SerializableQuaternion<T>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    [MemoryPackIgnore]
    public readonly Quaternion<T> Quaternion = Quaternion<T>.Identity;

    [MemoryPackInclude]
    public T X => Quaternion.X;

    [MemoryPackInclude]
    public T Y => Quaternion.Y;

    [MemoryPackInclude]
    public T Z => Quaternion.Z;

    [MemoryPackInclude]
    public T W => Quaternion.W;

    public SerializableQuaternion(T x, T y, T z, T w)
    {
        Quaternion = new(x, y, z, w);
    }

    public SerializableQuaternion(Quaternion<T>? quaternion)
    {
        Quaternion = quaternion ?? Quaternion<T>.Identity;
    }
}


public class QuaternionFormatter<T> : SFTMemoryPackFormatter<Quaternion<T>?>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    
    public override void Deserialize(ref MemoryPackReader reader, scoped ref Quaternion<T>? value)
    {
        if (reader.PeekIsNull())
        {
            value = null;
            return;
        }
        var wrapped = reader.ReadPackable<SerializableQuaternion<T>>();
        value = wrapped.Quaternion;
    }

    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref Quaternion<T>? value)
    {
        if(value is null)
        {
            writer.WriteNullObjectHeader();
            return;
        }
        writer.WritePackable(new SerializableQuaternion<T>(value));
    }
}