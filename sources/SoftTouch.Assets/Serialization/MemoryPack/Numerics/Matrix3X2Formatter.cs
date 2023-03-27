using MemoryPack;
using Silk.NET.Maths;
using System.Runtime.InteropServices;

namespace SoftTouch.Assets.Serialization.MemoryPack;

[MemoryPackable]
[StructLayout(LayoutKind.Auto)]
public readonly partial struct SerializableMatrix3X2<T>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    [MemoryPackIgnore]
    public readonly Matrix3X2<T> Matrix = Matrix3X2<T>.Identity;

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

    public SerializableMatrix3X2(T m11, T m12, T m21, T m22, T m31, T m32)
    {
        Matrix = new(m11, m12, m21, m22, m31, m32);
    }

    public SerializableMatrix3X2(Matrix3X2<T>? matrix)
    {
        Matrix = matrix ?? Matrix3X2<T>.Identity;
    }
}


public class Matrix3X2Formatter<T> : SFTMemoryPackFormatter<Matrix3X2<T>?>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    public override void Deserialize(ref MemoryPackReader reader, scoped ref Matrix3X2<T>? value)
    {
        if (reader.PeekIsNull())
        {
            value = null;
            return;
        }
        var wrapped = reader.ReadPackable<SerializableMatrix3X2<T>>();
        value = wrapped.Matrix;
    }

    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref Matrix3X2<T>? value)
    {
        if(value is null)
        {
            writer.WriteNullObjectHeader();
            return;
        }
        writer.WritePackable(new SerializableMatrix3X2<T>(value));
    }
}