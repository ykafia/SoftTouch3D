using SoftTouch.Graphics.WebGPU;
using WGPU.NET;
using Zio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using SharpGLTF.Schema2;
using System.Collections;

namespace SoftTouch.Assets;

public class MaterialAsset : IComposableAsset<MaterialAsset>
{
    public ImageAsset DiffuseTexture { get; private set; }
    public List<IAsset> Assets { get; set;} = new();
    public UPath Path { get; set;}
    public string Name { get; set;}

    internal MaterialAsset(Material material)
    {
        Name = material.Name ?? Guid.NewGuid().ToString();
        var image = SixLabors.ImageSharp.Image.Load<Rgba32>(material.FindChannel("BaseColor")?.Texture.PrimaryImage.Content.Content.ToArray());
        var samp = material.FindChannel("BaseColor")?.TextureSampler;
        var sdesc = new Wgpu.SamplerDescriptor();
        if(samp != null)
        {
            (var filterMode, var mipMode) = samp.MinFilter.ToWebGPU(); 
            sdesc.minFilter = filterMode;
            sdesc.mipmapFilter = mipMode;
            sdesc.magFilter = samp.MagFilter.ToWebGPU();
            sdesc.addressModeU = Wgpu.AddressMode.Repeat;
            sdesc.addressModeV = Wgpu.AddressMode.Repeat;
            sdesc.addressModeW = Wgpu.AddressMode.Repeat;
        };

        DiffuseTexture = new ImageAsset(
            image,
            sdesc
        );

    }


    public static MaterialAsset Load(in UPath path, IFileSystem fs)
    {
        if (fs.FileExists(path) && path.GetExtensionWithDot() == ".gltf")
        {
            throw new NotImplementedException();
            // var image = Image.Load<Rgba32>(fs.OpenFile(path,FileMode.Open,FileAccess.Read));
            // return new MaterialAsset(image);
        }
        else
            throw new Exception("Not an image file");
    }
    public static void Unload(MaterialAsset asset)
    {
        asset.Unload();
    }

    public void Unload()
    {
        DiffuseTexture.ImageTexture.Dispose();

    }

    public IEnumerator<IAsset> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
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