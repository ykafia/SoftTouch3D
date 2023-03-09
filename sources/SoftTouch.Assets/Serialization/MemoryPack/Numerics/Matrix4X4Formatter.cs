using MemoryPack;
using Silk.NET.Maths;
using System.Runtime.InteropServices;

namespace SoftTouch.Assets.Serialization.MemoryPack;

[MemoryPackable]
[StructLayout(LayoutKind.Auto)]
public readonly partial struct SerializableMatrix4X4<T>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    [MemoryPackIgnore]
    public readonly Matrix4X4<T> Matrix = Matrix4X4<T>.Identity;

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
    public T M23=> Matrix.M23;
    [MemoryPackInclude]
    public T M24 => Matrix.M24;
    [MemoryPackInclude]
    public T M31 => Matrix.M31;
    [MemoryPackInclude]
    public T M32 => Matrix.M32;
    [MemoryPackInclude]
    public T M33 => Matrix.M33;
    [MemoryPackInclude]
    public T M34 => Matrix.M34;
    [MemoryPackInclude]
    public T M41 => Matrix.M41;
    [MemoryPackInclude]
    public T M42 => Matrix.M42;
    [MemoryPackInclude]
    public T M43 => Matrix.M43;
    [MemoryPackInclude]
    public T M44 => Matrix.M44;

    public SerializableMatrix4X4(
        T m11, T m12, T m13, T m14, 
        T m21, T m22, T m23, T m24, 
        T m31, T m32, T m33, T m34,
        T m41, T m42, T m43, T m44
        )
    {
        Matrix = new(
            m11, m12, m13, m14,
            m21, m22, m23, m24,
            m31, m32, m33, m34,
            m41, m42, m43, m44
        );
    }

    public SerializableMatrix4X4(Matrix4X4<T>? matrix)
    {
        Matrix = matrix ?? Matrix4X4<T>.Identity;
    }
}


public class Matrix4X4Formatter<T> : MemoryPackFormatter<Matrix4X4<T>?>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    static Matrix4X4Formatter()
    {
        MemoryPackFormatterProvider.Register(new Matrix4X4Formatter<byte>());
        MemoryPackFormatterProvider.Register(new Matrix4X4Formatter<sbyte>());
        MemoryPackFormatterProvider.Register(new Matrix4X4Formatter<ushort>());
        MemoryPackFormatterProvider.Register(new Matrix4X4Formatter<short>());
        MemoryPackFormatterProvider.Register(new Matrix4X4Formatter<uint>());
        MemoryPackFormatterProvider.Register(new Matrix4X4Formatter<int>());
        MemoryPackFormatterProvider.Register(new Matrix4X4Formatter<ulong>());
        MemoryPackFormatterProvider.Register(new Matrix4X4Formatter<long>());
        MemoryPackFormatterProvider.Register(new Matrix4X4Formatter<Half>());
        MemoryPackFormatterProvider.Register(new Matrix4X4Formatter<float>());
        MemoryPackFormatterProvider.Register(new Matrix4X4Formatter<double>());
    }
    public override void Deserialize(ref MemoryPackReader reader, scoped ref Matrix4X4<T>? value)
    {
        if (reader.PeekIsNull())
        {
            value = null;
            return;
        }
        var wrapped = reader.ReadPackable<SerializableMatrix4X4<T>>();
        value = wrapped.Matrix;
    }

    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref Matrix4X4<T>? value)
    {
        if(value is null)
        {
            writer.WriteNullObjectHeader();
            return;
        }
        writer.WritePackable(new SerializableMatrix4X4<T>(value));
    }
}