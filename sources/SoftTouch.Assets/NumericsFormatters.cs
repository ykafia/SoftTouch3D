using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;
using Silk.NET.Maths;

namespace SoftTouch.Assets;

public class Vector2DFloatFormatter : IMessagePackFormatter<Vector2D<float>>
{
    public void Serialize(
      ref MessagePackWriter writer, Vector2D<float> value, MessagePackSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNil();
            return;
        }

        writer.Write(value.X);
        writer.Write(value.Y);
    }

    public Vector2D<float> Deserialize(
      ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.TryReadNil())
        {
            return Vector2D<float>.Zero;
        }

        options.Security.DepthStep(ref reader);

        var x = reader.ReadSingle();
        var y = reader.ReadSingle();
        reader.Depth--;

        return new Vector2D<float>(x,y);
    }
}

public class Vector3DFloatFormatter : IMessagePackFormatter<Vector3D<float>>
{
    public void Serialize(
      ref MessagePackWriter writer, Vector3D<float> value, MessagePackSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNil();
            return;
        }

        writer.Write(value.X);
        writer.Write(value.Y);
        writer.Write(value.Z);
    }

    public Vector3D<float> Deserialize(
      ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.TryReadNil())
        {
            return Vector3D<float>.Zero;
        }

        options.Security.DepthStep(ref reader);

        var x = reader.ReadSingle();
        var y = reader.ReadSingle();
        var z = reader.ReadSingle();
        reader.Depth--;

        return new Vector3D<float>(x,y,z);
    }
}
public class QuaternionFloatFormatter : IMessagePackFormatter<Quaternion<float>>
{
    public void Serialize(
      ref MessagePackWriter writer, Quaternion<float> value, MessagePackSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNil();
            return;
        }

        writer.Write(value.X);
        writer.Write(value.Y);
        writer.Write(value.Z);
        writer.Write(value.W);
    }

    public Quaternion<float> Deserialize(
      ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.TryReadNil())
        {
            return Quaternion<float>.Identity;
        }

        options.Security.DepthStep(ref reader);

        var x = reader.ReadSingle();
        var y = reader.ReadSingle();
        var z = reader.ReadSingle();
        var w = reader.ReadSingle();
        reader.Depth--;

        return new Quaternion<float>(x,y,z,w);
    }
}

public class Vector4DFloatFormatter : IMessagePackFormatter<Vector4D<float>>
{
    public void Serialize(
      ref MessagePackWriter writer, Vector4D<float> value, MessagePackSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNil();
            return;
        }

        writer.Write(value.X);
        writer.Write(value.Y);
        writer.Write(value.Z);
        writer.Write(value.W);
    }

    public Vector4D<float> Deserialize(
      ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.TryReadNil())
        {
            return Vector4D<float>.Zero;
        }

        options.Security.DepthStep(ref reader);

        var x = reader.ReadSingle();
        var y = reader.ReadSingle();
        var z = reader.ReadSingle();
        var w = reader.ReadSingle();
        reader.Depth--;

        return new Vector4D<float>(x,y,z,w);
    }
}
public class Matrix4X4FloatFormatter : IMessagePackFormatter<Matrix4X4<float>>
{
    public void Serialize(
      ref MessagePackWriter writer, Matrix4X4<float> value, MessagePackSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNil();
            return;
        }
        for(int i = 0; i < 4; i++)
        for(int j = 0; j < 4; j++)
            writer.Write(value[i,j]);
    }

    public Matrix4X4<float> Deserialize(
      ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.TryReadNil())
        {
            return Matrix4X4<float>.Identity;
        }

        options.Security.DepthStep(ref reader);
        var m = new Matrix4X4<float>
        {
            M11 = reader.ReadSingle(),
            M12 = reader.ReadSingle(),
            M13 = reader.ReadSingle(),
            M14 = reader.ReadSingle(),

            M21 = reader.ReadSingle(),
            M22 = reader.ReadSingle(),
            M23 = reader.ReadSingle(),
            M24 = reader.ReadSingle(),

            M31 = reader.ReadSingle(),
            M32 = reader.ReadSingle(),
            M33 = reader.ReadSingle(),
            M34 = reader.ReadSingle(),

            M41 = reader.ReadSingle(),
            M42 = reader.ReadSingle(),
            M43 = reader.ReadSingle(),
            M44 = reader.ReadSingle()
        };

        reader.Depth--;
        return m;
    }
}

