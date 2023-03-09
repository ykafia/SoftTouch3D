using MemoryPack;
using Silk.NET.Maths;
using System.Runtime.InteropServices;

namespace SoftTouch.Assets.Serialization.MemoryPack;

[MemoryPackable]
[StructLayout(LayoutKind.Auto)]
public readonly partial struct SerializableMatrix2X4<T>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    [MemoryPackIgnore]
    public readonly Matrix2X4<T> Matrix = Matrix2X4<T>.Identity;

    [MemoryPackInclude]
    public T M11 => Matrix.M11;

    [MemoryPackInclude]
    public T M12 => Matrix.M12;
    [MemoryPackInclude]
    public T M13 => Matrix.M13;
    [MemoryPackInclude]
    public T M14 => Matrix.M14;

    [MemoryPackInclude]
    public T M21 => Matrix.M21;

    [MemoryPackInclude]
    public T M22 => Matrix.M22;
    
    [MemoryPackInclude]
    public T M23 => Matrix.M23;
    [MemoryPackInclude]
    public T M24 => Matrix.M24;

    public SerializableMatrix2X4(T m11, T m12, T m13, T m14, T m21, T m22, T m23, T m24)
    {
        Matrix = new(m11,m12,m13,m14,m21,m22,m23,m24);
    }

    public SerializableMatrix2X4(Matrix2X4<T>? matrix)
    {
        Matrix = matrix ?? Matrix2X4<T>.Identity;
    }
}


public class Matrix2X4Formatter<T> : MemoryPackFormatter<Matrix2X4<T>?>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    static Matrix2X4Formatter()
    {
        MemoryPackFormatterProvider.Register(new Matrix2X4Formatter<byte>());
        MemoryPackFormatterProvider.Register(new Matrix2X4Formatter<sbyte>());
        MemoryPackFormatterProvider.Register(new Matrix2X4Formatter<ushort>());
        MemoryPackFormatterProvider.Register(new Matrix2X4Formatter<short>());
        MemoryPackFormatterProvider.Register(new Matrix2X4Formatter<uint>());
        MemoryPackFormatterProvider.Register(new Matrix2X4Formatter<int>());
        MemoryPackFormatterProvider.Register(new Matrix2X4Formatter<ulong>());
        MemoryPackFormatterProvider.Register(new Matrix2X4Formatter<long>());
        MemoryPackFormatterProvider.Register(new Matrix2X4Formatter<Half>());
        MemoryPackFormatterProvider.Register(new Matrix2X4Formatter<float>());
        MemoryPackFormatterProvider.Register(new Matrix2X4Formatter<double>());
    }
    public override void Deserialize(ref MemoryPackReader reader, scoped ref Matrix2X4<T>? value)
    {
        if (reader.PeekIsNull())
        {
            value = null;
            return;
        }
        var wrapped = reader.ReadPackable<SerializableMatrix2X4<T>>();
        value = wrapped.Matrix;
    }

    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref Matrix2X4<T>? value)
    {
        if(value is null)
        {
            writer.WriteNullObjectHeader();
            return;
        }
        writer.WritePackable(new SerializableMatrix2X4<T>(value));
    }
}