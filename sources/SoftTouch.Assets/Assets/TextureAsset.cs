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

namespace SoftTouch.Assets;

[YamlObject]
public readonly partial struct TextureAsset : IAssetResource
{
    [YamlIgnore]
    public string Extension { get; init; } = "tex";

    public TextureDescriptor Descriptor { get; init; }

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