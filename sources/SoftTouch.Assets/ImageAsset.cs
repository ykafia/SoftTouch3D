using SoftTouch.Graphics.WebGPU;
using WGPU.NET;
using Zio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using MemoryPack;
using System.Runtime.Serialization;
using VYaml.Annotations;

namespace SoftTouch.Assets;

[YamlObject]
public partial class ImageAsset : AssetItem
{

    [YamlIgnore]
    public override string Extension { get; init; } = "image";

    public ImageAsset() { }
    public ImageAsset(UPath path) : base(path) { }

    [YamlConstructor]
    public ImageAsset(UPath assetPath, UPath path, UPath subpath) : base(assetPath, path, subpath)
    {

    }

}