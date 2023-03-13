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
public partial class ImageAsset : AssetItem
{
    public override string Extension { get; init; } = "image";

    public TextureFormat Format {get; set;}

    public ImageAsset() { }
    public ImageAsset(string path) : base(path) { }

    [YamlConstructor]
    public ImageAsset(string assetPath, string path, string subpath) : base(assetPath, path, subpath)
    {
        var desc = new TextureDescriptor
        {
            Dimension = TextureDimension.TextureDimension2D,
            Format = Format,
            Label = null,
            MipLevelCount = 1,
            NextInChain = null,
            SampleCount = 1,
            Size = new (0,0,0),
            Usage = TextureUsage.CopySrc,
            ViewFormatCount = 0,
            ViewFormats = null
        };
    }

}