using Silk.NET.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using VYaml.Serialization;

namespace SoftTouch.Assets.Serialization.Yaml;

public static class SoftYamlResolver
{
    public static void Init()
    {
        GeneratedResolver.Register(new Vector2DYFormatter<byte>());
        GeneratedResolver.Register(new Vector3DYFormatter<byte>());
        GeneratedResolver.Register(new Vector4DYFormatter<byte>());

        GeneratedResolver.Register(new Vector2DYFormatter<ushort>());
        GeneratedResolver.Register(new Vector3DYFormatter<ushort>());
        GeneratedResolver.Register(new Vector4DYFormatter<ushort>());

        GeneratedResolver.Register(new Vector2DYFormatter<uint>());
        GeneratedResolver.Register(new Vector3DYFormatter<uint>());
        GeneratedResolver.Register(new Vector4DYFormatter<uint>());

        GeneratedResolver.Register(new Vector2DYFormatter<ulong>());
        GeneratedResolver.Register(new Vector3DYFormatter<ulong>());
        GeneratedResolver.Register(new Vector4DYFormatter<ulong>());

        GeneratedResolver.Register(new Vector2DYFormatter<sbyte>());
        GeneratedResolver.Register(new Vector3DYFormatter<sbyte>());
        GeneratedResolver.Register(new Vector4DYFormatter<sbyte>());

        GeneratedResolver.Register(new Vector2DYFormatter<short>());
        GeneratedResolver.Register(new Vector3DYFormatter<short>());
        GeneratedResolver.Register(new Vector4DYFormatter<short>());

        GeneratedResolver.Register(new Vector2DYFormatter<int>());
        GeneratedResolver.Register(new Vector3DYFormatter<int>());
        GeneratedResolver.Register(new Vector4DYFormatter<int>());

        GeneratedResolver.Register(new Vector2DYFormatter<long>());
        GeneratedResolver.Register(new Vector3DYFormatter<long>());
        GeneratedResolver.Register(new Vector4DYFormatter<long>());


        GeneratedResolver.Register(new Vector2DYFormatter<Half>());
        GeneratedResolver.Register(new Vector3DYFormatter<Half>());
        GeneratedResolver.Register(new Vector4DYFormatter<Half>());

        GeneratedResolver.Register(new Vector2DYFormatter<float>());
        GeneratedResolver.Register(new Vector3DYFormatter<float>());
        GeneratedResolver.Register(new Vector4DYFormatter<float>());

        GeneratedResolver.Register(new Vector2DYFormatter<double>());
        GeneratedResolver.Register(new Vector3DYFormatter<double>());
        GeneratedResolver.Register(new Vector4DYFormatter<double>());

        GeneratedResolver.Register(new UPathYFormatter());
    }
}
