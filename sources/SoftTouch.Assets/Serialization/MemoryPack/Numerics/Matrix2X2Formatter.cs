using MemoryPack;
using Silk.NET.Maths;
using System.Runtime.InteropServices;

namespace SoftTouch.Assets.Serialization.MemoryPack;

[MemoryPackable]
[StructLayout(LayoutKind.Auto)]
public readonly partial struct SerializableMatrix2X2<T>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    [MemoryPackIgnore]
    public readonly Matrix2X2<T> Matrix = Matrix2X2<T>.Identity;

    [MemoryPackInclude]
    public T M11 => Matrix.M11;

    [MemoryPackInclude]
    public T M12 => Matrix.M12;

    [MemoryPackInclude]
    public T M21 => Matrix.M21;

    [MemoryPackInclude]
    public T M22 => Matrix.M22;

    public SerializableMatrix2X2(T m11, T m12, T m21, T m22)
    {
        Matrix = new(m11, m12, m21, m22);
    }

    public SerializableMatrix2X2(Matrix2X2<T>? matrix)
    {
        Matrix = matrix ?? Matrix2X2<T>.Identity;
    }
}


public class Matrix2X2Formatter<T> : SFTMemoryPackFormatter<Matrix2X2<T>?>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    public override void Deserialize(ref MemoryPackReader reader, scoped ref Matrix2X2<T>? value)
    {
        if (reader.PeekIsNull())
        {
            value = null;
            return;
        }
        var wrapped = reader.ReadPackable<SerializableMatrix2X2<T>>();
        value = wrapped.Matrix;
    }

    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref Matrix2X2<T>? value)
    {
        if(value is null)
        {
            writer.WriteNullObjectHeader();
            return;
        }
        writer.WritePackable(new SerializableMatrix2X2<T>(value));
    }
}