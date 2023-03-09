using MemoryPack;
using Silk.NET.Maths;
using System.Runtime.InteropServices;

namespace SoftTouch.Assets.Serialization.MemoryPack;

[MemoryPackable]
[StructLayout(LayoutKind.Auto)]
public readonly partial struct SerializableMatrix4X3<T>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    [MemoryPackIgnore]
    public readonly Matrix4X3<T> Matrix = Matrix4X3<T>.Identity;

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
    [MemoryPackInclude]
    public T M31 => Matrix.M31;
    [MemoryPackInclude]
    public T M32 => Matrix.M32;
    [MemoryPackInclude]
    public T M33 => Matrix.M33;
    [MemoryPackInclude]
    public T M41 => Matrix.M41;
    [MemoryPackInclude]
    public T M42 => Matrix.M42;
    [MemoryPackInclude]
    public T M43 => Matrix.M43;

    public SerializableMatrix4X3(
        T m11, T m12, T m13,
        T m21, T m22, T m23,
        T m31, T m32, T m33,
        T m41, T m42, T m43
        )
    {
        Matrix = new(
            m11, m12, m13,
            m21, m22, m23,
            m31, m32, m33,
            m41, m42, m43
        );
    }

    public SerializableMatrix4X3(Matrix4X3<T>? matrix)
    {
        Matrix = matrix ?? Matrix4X3<T>.Identity;
    }
}


public class Matrix4X3Formatter<T> : MemoryPackFormatter<Matrix4X3<T>?>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    static Matrix4X3Formatter()
    {
        MemoryPackFormatterProvider.Register(new Matrix4X3Formatter<byte>());
        MemoryPackFormatterProvider.Register(new Matrix4X3Formatter<sbyte>());
        MemoryPackFormatterProvider.Register(new Matrix4X3Formatter<ushort>());
        MemoryPackFormatterProvider.Register(new Matrix4X3Formatter<short>());
        MemoryPackFormatterProvider.Register(new Matrix4X3Formatter<uint>());
        MemoryPackFormatterProvider.Register(new Matrix4X3Formatter<int>());
        MemoryPackFormatterProvider.Register(new Matrix4X3Formatter<ulong>());
        MemoryPackFormatterProvider.Register(new Matrix4X3Formatter<long>());
        MemoryPackFormatterProvider.Register(new Matrix4X3Formatter<Half>());
        MemoryPackFormatterProvider.Register(new Matrix4X3Formatter<float>());
        MemoryPackFormatterProvider.Register(new Matrix4X3Formatter<double>());
    }
    public override void Deserialize(ref MemoryPackReader reader, scoped ref Matrix4X3<T>? value)
    {
        if (reader.PeekIsNull())
        {
            value = null;
            return;
        }
        var wrapped = reader.ReadPackable<SerializableMatrix4X3<T>>();
        value = wrapped.Matrix;
    }

    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref Matrix4X3<T>? value)
    {
        if (value is null)
        {
            writer.WriteNullObjectHeader();
            return;
        }
        writer.WritePackable(new SerializableMatrix4X3<T>(value));
    }
}