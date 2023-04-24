using Silk.NET.Maths;
using SoftTouch.Graphics;
using System.Runtime.CompilerServices;

namespace SoftTouch.Graphics.WGPU;

public readonly struct Texture : IGraphicsObject
{
    public static GPUResources<Texture> Textures { get; } = new();

    public unsafe Silk.NET.WebGPU.Texture* Handle { get; init; }

    public GraphicsState Graphics => GraphicsState.GetOrCreate();

    public Silk.NET.WebGPU.WebGPU Api => Graphics.Api;



    public uint DepthOrArrayLayers
    {
        get
        {
            unsafe
            {
                return Api.TextureGetDepthOrArrayLayers(this);
            }
        }
    }
    public Silk.NET.WebGPU.TextureDimension Dimension
    {
        get
        {
            unsafe
            {
                return Api.TextureGetDimension(this);
            }
        }
    }
    public Silk.NET.WebGPU.TextureFormat Format
    {
        get
        {
            unsafe
            {
                return Api.TextureGetFormat(this);
            }
        }
    }
    public uint Height
    {
        get
        {
            unsafe
            {
                return Api.TextureGetHeight(this);
            }
        }
    }

    public uint Width
    {
        get
        {
            unsafe
            {
                return Api.TextureGetWidth(this);
            }
        }
    }

    public uint MipLevelCount
    {
        get
        {
            unsafe
            {
                return Api.TextureGetMipLevelCount(this);
            }
        }
    }
    public uint SampleCount
    {
        get
        {
            unsafe
            {
                return Api.TextureGetSampleCount(this);
            }
        }
    }
    public Silk.NET.WebGPU.TextureUsage Usage
    {
        get
        {
            unsafe
            {
                return Api.TextureGetUsage(this);
            }
        }
    }



    internal unsafe Texture(Silk.NET.WebGPU.Texture* handle)
    {
        Handle = handle;
    }
    public unsafe static implicit operator Silk.NET.WebGPU.Texture*(Texture a) => a.Handle;


    internal unsafe Silk.NET.WebGPU.ImageCopyTexture GetCopyTexture(Silk.NET.WebGPU.TextureAspect aspect, uint mipLevel, Silk.NET.WebGPU.Origin3D origin)
    {
        return new Silk.NET.WebGPU.ImageCopyTexture()
        {
            Aspect = aspect,
            MipLevel = mipLevel,
            Origin = origin,
            Texture = Handle
        };
    }

    
    public TextureView CreateView(in Silk.NET.WebGPU.TextureViewDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.TextureCreateView(this,descriptor));
        }
    }

    public void Dispose()
    {
        unsafe
        {
            foreach(var (k,v) in Textures)
            {
                if (v.Handle == Handle)
                {
                    Textures.Remove(k);
                    break;
                }
            }
            Api.TextureDestroy(this);
            Graphics.Disposal.Dispose(Handle);
        }
    }
}