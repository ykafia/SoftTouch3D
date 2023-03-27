using MemoryPack;
using Silk.NET.Maths;
using System.Runtime.InteropServices;

namespace SoftTouch.Assets.Serialization.MemoryPack;

[MemoryPackable]
[StructLayout(LayoutKind.Auto)]
public readonly partial struct SerializableMatrix2X3<T>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    [MemoryPackIgnore]
    public readonly Matrix2X3<T> Matrix = Matrix2X3<T>.Identity;

    [MemoryPackInclude]
    public T M11 => Matrix.M11;

    [MemoryPackInclude]
    public T M12 => Matrix.M12;
    [MemoryPackInclude]
    public T M13 => Matrix.M13;

    [MemoryPackInclude]
    public T M21 => Matrix.M21;

    [MemoryPackInclude]
    public T M22 => Matrix.M22;

    [MemoryPackInclude]
    public T M23 => Matrix.M23;

    public SerializableMatrix2X3(T m11, T m12, T m13, T m21, T m22, T m23)
    {
        Matrix = new(m11, m12, m13, m21, m22, m23);
    }

    public SerializableMatrix2X3(Matrix2X3<T>? matrix)
    {
        Matrix = matrix ?? Matrix2X3<T>.Identity;
    }
}


public class Matrix2X3Formatter<T> : SFTMemoryPackFormatter<Matrix2X3<T>?>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    static Matrix2X3Formatter()
    {
        MemoryPackFormatterProvider.Register(new Matrix2X3Formatter<byte>());
        MemoryPackFormatterProvider.Register(new Matrix2X3Formatter<sbyte>());
        MemoryPackFormatterProvider.Register(new Matrix2X3Formatter<ushort>());
        MemoryPackFormatterProvider.Register(new Matrix2X3Formatter<short>());
        MemoryPackFormatterProvider.Register(new Matrix2X3Formatter<uint>());
        MemoryPackFormatterProvider.Register(new Matrix2X3Formatter<int>());
        MemoryPackFormatterProvider.Register(new Matrix2X3Formatter<ulong>());
        MemoryPackFormatterProvider.Register(new Matrix2X3Formatter<long>());
        MemoryPackFormatterProvider.Register(new Matrix2X3Formatter<Half>());
        MemoryPackFormatterProvider.Register(new Matrix2X3Formatter<float>());
        MemoryPackFormatterProvider.Register(new Matrix2X3Formatter<double>());
    }
    public override void Deserialize(ref MemoryPackReader reader, scoped ref Matrix2X3<T>? value)
    {
        if (reader.PeekIsNull())
        {
            value = null;
            return;
        }
        var wrapped = reader.ReadPackable<SerializableMatrix2X3<T>>();
        value = wrapped.Matrix;
    }

    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref Matrix2X3<T>? value)
    {
        if (value is null)
        {
            writer.WriteNullObjectHeader();
            return;
        }
        writer.WritePackable(new SerializableMatrix2X3<T>(value));
    }
}