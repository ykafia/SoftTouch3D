﻿using Silk.NET.Maths;
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

public class Vector2DYFormatter<T> : IYamlFormatter<Vector2D<T>>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    static Vector2DYFormatter()
    {
        GeneratedResolver.Register(new Vector2DYFormatter<byte>());
        GeneratedResolver.Register(new Vector2DYFormatter<sbyte>());
        GeneratedResolver.Register(new Vector2DYFormatter<ushort>());
        GeneratedResolver.Register(new Vector2DYFormatter<short>());
        GeneratedResolver.Register(new Vector2DYFormatter<uint>());
        GeneratedResolver.Register(new Vector2DYFormatter<int>());
        GeneratedResolver.Register(new Vector2DYFormatter<ulong>());
        GeneratedResolver.Register(new Vector2DYFormatter<long>());
    }
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

public class Vector3DYFormatter<T> : IYamlFormatter<Vector3D<T>>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    static Vector3DYFormatter()
    {
        GeneratedResolver.Register(new Vector3DYFormatter<byte>());
        GeneratedResolver.Register(new Vector3DYFormatter<sbyte>());
        GeneratedResolver.Register(new Vector3DYFormatter<ushort>());
        GeneratedResolver.Register(new Vector3DYFormatter<short>());
        GeneratedResolver.Register(new Vector3DYFormatter<uint>());
        GeneratedResolver.Register(new Vector3DYFormatter<int>());
        GeneratedResolver.Register(new Vector3DYFormatter<ulong>());
        GeneratedResolver.Register(new Vector3DYFormatter<long>());
    }
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

public class Vector4DYFormatter<T> : IYamlFormatter<Vector4D<T>>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    static Vector4DYFormatter()
    {
        GeneratedResolver.Register(new Vector4DYFormatter<byte>());
        GeneratedResolver.Register(new Vector4DYFormatter<sbyte>());
        GeneratedResolver.Register(new Vector4DYFormatter<ushort>());
        GeneratedResolver.Register(new Vector4DYFormatter<short>());
        GeneratedResolver.Register(new Vector4DYFormatter<uint>());
        GeneratedResolver.Register(new Vector4DYFormatter<int>());
        GeneratedResolver.Register(new Vector4DYFormatter<ulong>());
        GeneratedResolver.Register(new Vector4DYFormatter<long>());
    }
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