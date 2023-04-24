using SoftTouch.Graphics;
using Zio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using MemoryPack;
using System.Runtime.Serialization;
using VYaml.Annotations;
using Silk.NET.WebGPU;
using SoftTouch.Core.Serialization;
using SoftTouch.Core.Assets;
using System.Numerics;
using Silk.NET.Maths;

namespace SoftTouch.Graphics.Assets;

public enum TextureType
{
    Grayscale,
    Color
}


[YamlObject]
public readonly partial struct TextureAsset : IAssetResource
{
    [YamlIgnore]
    public string Extension { get; init; } = "tex";

    public Vector3D<uint> Size { get; init; }

    public bool IsCompressed { get; init; }

    public TextureType TextureType { get; init; }


    public Guid ID { get; init; }

    [YamlIgnore]
    public string AssetPath { get; init; }

    public string Path { get; init; }

    [YamlIgnore]
    public string? Name => new UPath(AssetPath).GetNameWithoutExtension();

    public TextureAsset() { }

    public TextureAsset(string path, string assetPath)
    {
        AssetPath = assetPath;
        Path = path;
        ID = Guid.NewGuid();
    }

}