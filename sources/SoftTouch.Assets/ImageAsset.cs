using SoftTouch.Graphics.WebGPU;
using WGPU.NET;
using Zio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;

namespace SoftTouch.Assets;

public class ImageAsset : IAsset
{
    public Image<Rgba32> ImageTexture { get; private set; }
    public Wgpu.SamplerDescriptor SamplerDesc { get; private set; }


    internal ImageAsset(Image<Rgba32> picture, Wgpu.SamplerDescriptor samplerDesc){
        ImageTexture = picture;
        SamplerDesc = samplerDesc;
        
    }

    public void Load(WGPUGraphics gfx)
    {
        throw new NotImplementedException();
    }

    public void Unload()
    {
        throw new NotImplementedException();
    }
}