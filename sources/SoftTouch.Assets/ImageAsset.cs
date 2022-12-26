using SoftTouch.Graphics.WebGPU;
using WGPU.NET;
using Zio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;

namespace SoftTouch.Assets;

public class ImageAsset : AssetItem
{
    public ImageAsset(UPath path) : base(path)
    {
    }
}