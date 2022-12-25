using SoftTouch.Graphics.WebGPU;
using WGPU.NET;
using Zio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using SharpGLTF.Schema2;
using System.Collections;

namespace SoftTouch.Assets;

public class MaterialAsset : IAsset, IEnumerable<IAsset>
{
    public ImageAsset DiffuseMap {get;set;}

    public IEnumerator<IAsset> GetEnumerator()
    {
        yield return DiffuseMap;
        yield return this;
    }

    public void Load(WGPUGraphics gfx)
    {
        throw new NotImplementedException();
    }

    public void Unload()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

internal static class SharpGLTFExtensions
{
    public static (Wgpu.FilterMode, Wgpu.MipmapFilterMode) ToWebGPU(this TextureMipMapFilter filter)
    {
        return filter switch
        {
            TextureMipMapFilter.LINEAR => (Wgpu.FilterMode.Linear, Wgpu.MipmapFilterMode.Force32),
            TextureMipMapFilter.LINEAR_MIPMAP_LINEAR => (Wgpu.FilterMode.Linear, Wgpu.MipmapFilterMode.Linear),
            TextureMipMapFilter.LINEAR_MIPMAP_NEAREST => (Wgpu.FilterMode.Linear, Wgpu.MipmapFilterMode.Nearest),
            TextureMipMapFilter.NEAREST => (Wgpu.FilterMode.Nearest, Wgpu.MipmapFilterMode.Force32),
            TextureMipMapFilter.NEAREST_MIPMAP_LINEAR => (Wgpu.FilterMode.Nearest, Wgpu.MipmapFilterMode.Linear),
            TextureMipMapFilter.NEAREST_MIPMAP_NEAREST => (Wgpu.FilterMode.Nearest, Wgpu.MipmapFilterMode.Nearest),
            _ => throw new NotImplementedException()
        };
    }
    public static Wgpu.FilterMode ToWebGPU(this TextureInterpolationFilter filter)
    {
        return filter switch
        {
            TextureInterpolationFilter.NEAREST => Wgpu.FilterMode.Nearest,
            TextureInterpolationFilter.LINEAR => Wgpu.FilterMode.Linear,
            _ => Wgpu.FilterMode.Force32
        };
    }

}