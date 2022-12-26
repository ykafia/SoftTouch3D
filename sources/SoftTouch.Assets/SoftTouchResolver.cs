using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;
using Silk.NET.Maths;
using Zio;

namespace SoftTouch.Assets;

public class SoftTouchResolver : IFormatterResolver
{
    public static MessagePackSerializerOptions Options => MessagePackSerializerOptions.Standard.WithResolver(Instance);
    
    public static readonly IFormatterResolver Instance = new SoftTouchResolver();

    // configure your custom resolvers.
    private static readonly IFormatterResolver[] Resolvers = 
    {
        StandardResolver.Instance,
        Instance
    };

    static readonly Dictionary<Type, object> formatterMap = new()
    {
        {typeof(Vector3D<float>), new Vector3DFloatFormatter()},
        {typeof(Quaternion<float>), new QuaternionFloatFormatter()},
        {typeof(UPath), new UPathFormatter()}
    };

    private SoftTouchResolver() { }

    public IMessagePackFormatter<T> GetFormatter<T>()
    {
        return Cache<T>.Formatter;
    }

    private static class Cache<T>
    {
        public static IMessagePackFormatter<T> Formatter;

        static Cache()
        {
            if (formatterMap.TryGetValue(typeof(T), out var formatter))
            {
                Formatter = (IMessagePackFormatter<T>)formatter;
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