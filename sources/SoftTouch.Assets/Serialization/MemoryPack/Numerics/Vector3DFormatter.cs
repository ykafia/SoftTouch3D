using MemoryPack;
using Silk.NET.Maths;
using System.Runtime.InteropServices;

namespace SoftTouch.Assets.Serialization.MemoryPack;

[MemoryPackable]
[StructLayout(LayoutKind.Auto)]
public readonly partial struct SerializableVector3D<T>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    [MemoryPackIgnore]
    public readonly Vector3D<T> Vector = Vector3D<T>.Zero;

    [MemoryPackInclude]
    public T X => Vector.X;
    
    [MemoryPackInclude]
    public T Y => Vector.Y;
    
    [MemoryPackInclude]
    public T Z => Vector.Z;
    
    public SerializableVector3D(T x, T y, T z)
    {
        Vector = new(x,y,z);
    }

    public SerializableVector3D(Vector3D<T>? vector)
    {
        Vector = vector ?? Vector3D<T>.Zero;
    }
}


public class Vector3DFormatter<T> : SFTMemoryPackFormatter<Vector3D<T>?>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    
    public override void Deserialize(ref MemoryPackReader reader, scoped ref Vector3D<T>? value)
    {
        if(reader.PeekIsNull())
        {
            value = null;
            return;
        }
        var wrapped = reader.ReadPackable<SerializableVector3D<T>>();
        value = wrapped.Vector;
    }

    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref Vector3D<T>? value)
    {
        if(value is null)
        {
            writer.WriteNullObjectHeader();
            return;
        }
        writer.WritePackable(new SerializableVector3D<T>(value));
    }
}