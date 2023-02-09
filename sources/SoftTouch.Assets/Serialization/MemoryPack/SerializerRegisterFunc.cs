using System;
using System.Collections.Generic;
using MemoryPack;
using MemoryPack.Formatters;
using Silk.NET.Maths;
using SoftTouch.Assets.Serialization.MemoryPack;
using Zio;

namespace SoftTouch.Assets;

public class SerializerRegisterFunc 
{
    public static void RegisterSoftTouchSerializers()
    {
        MemoryPackFormatterProvider.Register(new Vector2DFormatter<byte>());
        MemoryPackFormatterProvider.Register(new Vector2DFormatter<sbyte>());
        MemoryPackFormatterProvider.Register(new Vector2DFormatter<short>());
        MemoryPackFormatterProvider.Register(new Vector2DFormatter<ushort>());
        MemoryPackFormatterProvider.Register(new Vector2DFormatter<Half>());
        MemoryPackFormatterProvider.Register(new Vector2DFormatter<float>());
        MemoryPackFormatterProvider.Register(new Vector2DFormatter<uint>());
        MemoryPackFormatterProvider.Register(new Vector2DFormatter<int>());
        MemoryPackFormatterProvider.Register(new Vector2DFormatter<long>());
        MemoryPackFormatterProvider.Register(new Vector2DFormatter<ulong>());
        MemoryPackFormatterProvider.Register(new Vector2DFormatter<double>());

        MemoryPackFormatterProvider.Register(new Vector3DFormatter<byte>());
        MemoryPackFormatterProvider.Register(new Vector3DFormatter<sbyte>());
        MemoryPackFormatterProvider.Register(new Vector3DFormatter<short>());
        MemoryPackFormatterProvider.Register(new Vector3DFormatter<ushort>());
        MemoryPackFormatterProvider.Register(new Vector3DFormatter<Half>());
        MemoryPackFormatterProvider.Register(new Vector3DFormatter<float>());
        MemoryPackFormatterProvider.Register(new Vector3DFormatter<uint>());
        MemoryPackFormatterProvider.Register(new Vector3DFormatter<int>());
        MemoryPackFormatterProvider.Register(new Vector3DFormatter<long>());
        MemoryPackFormatterProvider.Register(new Vector3DFormatter<ulong>());
        MemoryPackFormatterProvider.Register(new Vector3DFormatter<double>());

        MemoryPackFormatterProvider.Register(new Vector4DFormatter<byte>());
        MemoryPackFormatterProvider.Register(new Vector4DFormatter<sbyte>());
        MemoryPackFormatterProvider.Register(new Vector4DFormatter<short>());
        MemoryPackFormatterProvider.Register(new Vector4DFormatter<ushort>());
        MemoryPackFormatterProvider.Register(new Vector4DFormatter<Half>());
        MemoryPackFormatterProvider.Register(new Vector4DFormatter<float>());
        MemoryPackFormatterProvider.Register(new Vector4DFormatter<uint>());
        MemoryPackFormatterProvider.Register(new Vector4DFormatter<int>());
        MemoryPackFormatterProvider.Register(new Vector4DFormatter<long>());
        MemoryPackFormatterProvider.Register(new Vector4DFormatter<ulong>());
        MemoryPackFormatterProvider.Register(new Vector4DFormatter<double>());

        MemoryPackFormatterProvider.Register(new UPathFormatter());


    }

}