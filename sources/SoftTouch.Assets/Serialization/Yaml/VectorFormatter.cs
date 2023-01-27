using Silk.NET.Maths;
using System;
using System.Buffers.Text;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VYaml;
using VYaml.Emitter;
using VYaml.Parser;
using VYaml.Serialization;

namespace SoftTouch.Assets.Serialization.Yaml;

public class VectorFormatter<T> : IYamlFormatter<Vector2D<T>>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    public Vector2D<T> Deserialize(ref YamlParser parser, YamlDeserializationContext context)
    {
        var x = context.DeserializeWithAlias<T>(ref parser);
        var y = context.DeserializeWithAlias<T>(ref parser);
        return new(x, y);
    }

    public void Serialize(ref Utf8YamlEmitter emitter, Vector2D<T> value, YamlSerializationContext context)
    {
        emitter.BeginSequence();
        context.Serialize(ref emitter, value.X);
        context.Serialize(ref emitter, value.Y);
        emitter.EndSequence();
    }
}
