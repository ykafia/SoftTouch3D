using SoftTouch.Graphics;
using Zio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using MemoryPack;
using System.Runtime.Serialization;
using VYaml.Annotations;
using Silk.NET.WebGPU;

namespace SoftTouch.Assets;

[YamlObject]
public partial class ImageAsset : IAssetItem
{
    [YamlIgnore]
    public string Extension { get; init; } = "image";

    public TextureFormat Format { get; init; }

    public Guid ID { get; init; }

    public string AssetPath { get; init; }
    public string Path { get; init; }
    [YamlIgnore]
    public string? Name => new UPath(Path).GetNameWithoutExtension();
    
    public ImageAsset() { }

    public ImageAsset(string assetPath, string path)
    {
        AssetPath = assetPath;
        Path = path;
        ID = Guid.NewGuid();
    }

}