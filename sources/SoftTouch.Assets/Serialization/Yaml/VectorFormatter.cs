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
using SoftTouch.Core.Serialization;

namespace SoftTouch.Assets.Serialization.Yaml;

public class Vector2DYFormatter<T> : IYamlNumericsFormatter<Vector2D<T>>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    public Vector2D<T> Deserialize(ref YamlParser parser, YamlDeserializationContext context)
    {
        parser.SkipAfter(ParseEventType.MappingStart);
        context.DeserializeWithAlias<string>(ref parser);
        var x = context.DeserializeWithAlias<T>(ref parser);
        context.DeserializeWithAlias<string>(ref parser);
        var y = context.DeserializeWithAlias<T>(ref parser);
        return new(x, y);
    }

    public void Serialize(ref Utf8YamlEmitter emitter, Vector2D<T> value, YamlSerializationContext context)
    {
        emitter.BeginMapping();
        context.Serialize(ref emitter, "X");
        context.Serialize(ref emitter, value.X);
        context.Serialize(ref emitter, "Y");
        context.Serialize(ref emitter, value.Y);
        emitter.EndMapping();
    }
}

public class Vector3DYFormatter<T> : IYamlNumericsFormatter<Vector3D<T>>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    public Vector3D<T> Deserialize(ref YamlParser parser, YamlDeserializationContext context)
    {
        parser.SkipAfter(ParseEventType.MappingStart);
        context.DeserializeWithAlias<string>(ref parser);
        var x = context.DeserializeWithAlias<T>(ref parser);
        context.DeserializeWithAlias<string>(ref parser);
        var y = context.DeserializeWithAlias<T>(ref parser);
        context.DeserializeWithAlias<string>(ref parser);
        var z = context.DeserializeWithAlias<T>(ref parser);
        return new(x, y, z);
    }

    public void Serialize(ref Utf8YamlEmitter emitter, Vector3D<T> value, YamlSerializationContext context)
    {
        emitter.BeginMapping();
        context.Serialize(ref emitter, "X");
        context.Serialize(ref emitter, value.X);
        context.Serialize(ref emitter, "Y");
        context.Serialize(ref emitter, value.Y);
        context.Serialize(ref emitter, "Z");
        context.Serialize(ref emitter, value.Z);
        emitter.EndMapping();
    }
}

public class Vector4DYFormatter<T> : IYamlNumericsFormatter<Vector4D<T>>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    public Vector4D<T> Deserialize(ref YamlParser parser, YamlDeserializationContext context)
    {
        parser.SkipAfter(ParseEventType.MappingStart);
        context.DeserializeWithAlias<string>(ref parser);
        var x = context.DeserializeWithAlias<T>(ref parser);
        context.DeserializeWithAlias<string>(ref parser);
        var y = context.DeserializeWithAlias<T>(ref parser);
        context.DeserializeWithAlias<string>(ref parser);
        var z= context.DeserializeWithAlias<T>(ref parser); 
        context.DeserializeWithAlias<string>(ref parser);
        var w = context.DeserializeWithAlias<T>(ref parser);
        return new(x, y, z, w);
    }

    public void Serialize(ref Utf8YamlEmitter emitter, Vector4D<T> value, YamlSerializationContext context)
    {
        emitter.BeginMapping();
        context.Serialize(ref emitter, "X");
        context.Serialize(ref emitter, value.X);
        context.Serialize(ref emitter, "Y");
        context.Serialize(ref emitter, value.Y);
        context.Serialize(ref emitter, "Z");
        context.Serialize(ref emitter, value.Z);
        context.Serialize(ref emitter, "W");
        context.Serialize(ref emitter, value.W);
        emitter.EndMapping();
    }
}