using System.Numerics;
using MessagePack;
using MessagePack.Formatters;

namespace SoftTouch.Components;

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

public class MyApplicationResolver : IFormatterResolver
{
    public static readonly IFormatterResolver Instance = new MyApplicationResolver();

    // configure your custom resolvers.
    private static readonly IFormatterResolver[] Resolvers = new IFormatterResolver[]
    {
    };

    private MyApplicationResolver() { }

    public IMessagePackFormatter<T> GetFormatter<T>()
    {
        return Cache<T>.Formatter;
    }

    private static class Cache<T>
    {
        public static IMessagePackFormatter<T> Formatter;

        static Cache()
        {
            // configure your custom formatters.
            if (typeof(T) == typeof(Vector3))
            {
                Formatter = (IMessagePackFormatter<T>)new Vector3Formatter();
                return;
            }
            else if (typeof(T) == typeof(Quaternion))
            {
                Formatter = (IMessagePackFormatter<T>)new QuaternionFormatter();
                return;
            }

            foreach (var resolver in Resolvers)
            {
                var f = resolver.GetFormatter<T>();
                if (f != null)
                {
                    Formatter = f;
                    return;
                }
            }
        }
    }
}