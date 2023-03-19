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
    public string Extension { get; set; } = "image";

    public TextureFormat Format { get; set; }

    public Guid ID { get; set; }

    public string AssetPath { get; set; }
    public string Path { get; set; }
    [YamlIgnore]
    public string? Name => new UPath(Path).GetNameWithoutExtension();

    [YamlConstructor]
    public ImageAsset(string assetPath, string path)
    {
        AssetPath = assetPath;
        Path = path;
        ID = Guid.NewGuid();
    }

}