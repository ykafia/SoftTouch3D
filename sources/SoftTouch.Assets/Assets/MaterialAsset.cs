using SoftTouch.Graphics;
using Silk.NET.WebGPU;
using Zio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using SharpGLTF.Schema2;
using System.Collections;
using MemoryPack;
using VYaml.Annotations;

namespace SoftTouch.Assets;

[YamlObject]
public partial class MaterialAsset : AssetItem
{
    public override string Extension { get; init; } = "mat";

    public MaterialAsset() { }

    [YamlConstructor]
    public MaterialAsset(UPath assetPath, UPath path, UPath subpath) : base(assetPath, path,subpath)
    {
    }
}

internal static class SharpGLTFExtensions
{
    public static (FilterMode, MipmapFilterMode) ToWebGPU(this TextureMipMapFilter filter)
    {
        return filter switch
        {
            TextureMipMapFilter.LINEAR => (FilterMode.Linear, MipmapFilterMode.Force32),
            TextureMipMapFilter.LINEAR_MIPMAP_LINEAR => (FilterMode.Linear, MipmapFilterMode.Linear),
            TextureMipMapFilter.LINEAR_MIPMAP_NEAREST => (FilterMode.Linear, MipmapFilterMode.Nearest),
            TextureMipMapFilter.NEAREST => (FilterMode.Nearest, MipmapFilterMode.Force32),
            TextureMipMapFilter.NEAREST_MIPMAP_LINEAR => (FilterMode.Nearest, MipmapFilterMode.Linear),
            TextureMipMapFilter.NEAREST_MIPMAP_NEAREST => (FilterMode.Nearest, MipmapFilterMode.Nearest),
            _ => throw new NotImplementedException()
        };
    }
    public static FilterMode ToWebGPU(this TextureInterpolationFilter filter)
    {
        return filter switch
        {
            TextureInterpolationFilter.NEAREST => FilterMode.Nearest,
            TextureInterpolationFilter.LINEAR => FilterMode.Linear,
            _ => FilterMode.Force32
        };
    }

}