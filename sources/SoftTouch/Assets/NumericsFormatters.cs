using System;
using System.Collections.Generic;
using System.Numerics;
using MessagePack;
using MessagePack.Formatters;

namespace SoftTouch.Assets;

public class Vector2Formatter : IMessagePackFormatter<Vector2>
{
    public void Serialize(
      ref MessagePackWriter writer, Vector2 value, MessagePackSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNil();
            return;
        }

        writer.Write(value.X);
        writer.Write(value.Y);
    }

    public Vector2 Deserialize(
      ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.TryReadNil())
        {
            return Vector2.Zero;
        }

        options.Security.DepthStep(ref reader);

        var x = reader.ReadSingle();
        var y = reader.ReadSingle();
        reader.Depth--;

        return new Vector2(x,y);
    }
}

public class Vector3Formatter : IMessagePackFormatter<Vector3>
{
    public void Serialize(
      ref MessagePackWriter writer, Vector3 value, MessagePackSerializerOptions options)
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

    public Vector3 Deserialize(
      ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.TryReadNil())
        {
            return Vector3.Zero;
        }

        options.Security.DepthStep(ref reader);

        var x = reader.ReadSingle();
        var y = reader.ReadSingle();
        var z = reader.ReadSingle();
        reader.Depth--;

        return new Vector3(x,y,z);
    }
}
public class QuaternionFormatter : IMessagePackFormatter<Quaternion>
{
    public void Serialize(
      ref MessagePackWriter writer, Quaternion value, MessagePackSerializerOptions options)
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

    public Quaternion Deserialize(
      ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.TryReadNil())
        {
            return Quaternion.Zero;
        }

        options.Security.DepthStep(ref reader);

        var x = reader.ReadSingle();
        var y = reader.ReadSingle();
        var z = reader.ReadSingle();
        var w = reader.ReadSingle();
        reader.Depth--;

        return new Quaternion(x,y,z,w);
    }
}

public class Vector4Formatter : IMessagePackFormatter<Vector4>
{
    public void Serialize(
      ref MessagePackWriter writer, Vector4 value, MessagePackSerializerOptions options)
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

    public Vector4 Deserialize(
      ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.TryReadNil())
        {
            return Vector4.Zero;
        }

        options.Security.DepthStep(ref reader);

        var x = reader.ReadSingle();
        var y = reader.ReadSingle();
        var z = reader.ReadSingle();
        var w = reader.ReadSingle();
        reader.Depth--;

        return new Vector4(x,y,z,w);
    }
}
public class Matrix4x4Formatter : IMessagePackFormatter<Matrix4x4>
{
    public void Serialize(
      ref MessagePackWriter writer, Matrix4x4 value, MessagePackSerializerOptions options)
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

    public Matrix4x4 Deserialize(
      ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.TryReadNil())
        {
            return Matrix4x4.Identity;
        }

        options.Security.DepthStep(ref reader);
        var m = new Matrix4x4();
        for(int i = 0; i < 4; i++)
        for(int j = 0; j < 4; j++)
            m[i,j] = reader.ReadSingle();
        reader.Depth--;
        return m;
    }
}

