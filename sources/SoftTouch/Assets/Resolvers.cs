using System;
using System.Collections.Generic;
using System.Numerics;
using MessagePack;
using MessagePack.Formatters;

namespace SoftTouch.Assets;

public class SoftTouchResolver : IFormatterResolver
{
    public static readonly IFormatterResolver Instance = new SoftTouchResolver();

    // configure your custom resolvers.
    private static readonly IFormatterResolver[] Resolvers = new IFormatterResolver[]
    {
    };

    static readonly Dictionary<Type, object> formatterMap = new Dictionary<Type, object>()
    {
        {typeof(Vector3), new Vector3Formatter()},
        {typeof(Quaternion), new QuaternionFormatter()}
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
            if(formatterMap.TryGetValue(typeof(T), out var formatter))
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