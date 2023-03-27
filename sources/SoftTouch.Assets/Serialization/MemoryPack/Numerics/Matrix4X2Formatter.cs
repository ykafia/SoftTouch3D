using MemoryPack;
using Silk.NET.Maths;
using System.Runtime.InteropServices;

namespace SoftTouch.Assets.Serialization.MemoryPack;

[MemoryPackable]
[StructLayout(LayoutKind.Auto)]
public readonly partial struct SerializableMatrix4X2<T>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    [MemoryPackIgnore]
    public readonly Matrix4X2<T> Matrix = Matrix4X2<T>.Identity;

    [MemoryPackInclude]
    public T M11 => Matrix.M11;

    [MemoryPackInclude]
    public T M12 => Matrix.M12;

    [MemoryPackInclude]
    public T M21 => Matrix.M21;

    [MemoryPackInclude]
    public T M22 => Matrix.M22;
    [MemoryPackInclude]
    public T M31 => Matrix.M31;
    [MemoryPackInclude]
    public T M32 => Matrix.M32;
    [MemoryPackInclude]
    public T M41 => Matrix.M41;
    [MemoryPackInclude]
    public T M42 => Matrix.M42;

    public SerializableMatrix4X2(
        T m11, T m12, 
        T m21, T m22, 
        T m31, T m32,
        T m41, T m42
        )
    {
        Matrix = new(
            m11, m12,
            m21, m22,
            m31, m32,
            m41, m42
        );
    }

    public SerializableMatrix4X2(Matrix4X2<T>? matrix)
    {
        Matrix = matrix ?? Matrix4X2<T>.Identity;
    }
}


public class Matrix4X2Formatter<T> : SFTMemoryPackFormatter<Matrix4X2<T>?>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    
    public override void Deserialize(ref MemoryPackReader reader, scoped ref Matrix4X2<T>? value)
    {
        if (reader.PeekIsNull())
        {
            value = null;
            return;
        }
        var wrapped = reader.ReadPackable<SerializableMatrix4X2<T>>();
        value = wrapped.Matrix;
    }

    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref Matrix4X2<T>? value)
    {
        if(value is null)
        {
            writer.WriteNullObjectHeader();
            return;
        }
        writer.WritePackable(new SerializableMatrix4X2<T>(value));
    }
}