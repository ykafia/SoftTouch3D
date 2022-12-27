using SoftTouch.Graphics.WebGPU;
using WGPU.NET;
using Zio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using MemoryPack;

namespace SoftTouch.Assets;

[MemoryPackable]
public partial class ImageAsset : AssetItem
{
    public override string Extension { get; init; } = "image";

    public ImageAsset() { }
    
    [MemoryPackConstructor]
    public ImageAsset(UPath path, UPath subpath) : base(path, subpath)
    {

    }

}