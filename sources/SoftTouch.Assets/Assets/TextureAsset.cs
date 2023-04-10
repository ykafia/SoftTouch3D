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
public partial struct TextureAsset : IAssetItem
{
    [YamlIgnore]
    public string Extension { get; init; } = "tex";

    public TextureFormat Format { get; init; }

    public Guid ID { get; init; }

    public string AssetPath { get; init; }
    public string Path { get; init; }
    [YamlIgnore]
    public string? Name => new UPath(Path).GetNameWithoutExtension();
    
    public TextureAsset() { }

    public TextureAsset(string path, string assetPath)
    {
        AssetPath = assetPath;
        Path = path;
        ID = Guid.NewGuid();
    }

}