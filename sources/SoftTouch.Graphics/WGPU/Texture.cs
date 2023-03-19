using Silk.NET.Maths;
using SoftTouch.Graphics;
using Silk.NET.WebGPU;
using System.Runtime.CompilerServices;

namespace SoftTouch.Graphics.WGPU;

public readonly struct Texture : IGraphicsObject
{
    public static GPUResources<Texture> Textures { get; } = new();

    public unsafe Silk.NET.WebGPU.Texture* Handle { get; init; }

    public GraphicsState Graphics => GraphicsState.GetOrCreate();

    public WebGPU Api => Graphics.Api;

    internal unsafe Texture(Silk.NET.WebGPU.Texture* handle)
    {
        Handle = handle;
    }
    public unsafe static implicit operator Silk.NET.WebGPU.Texture*(Texture a) => a.Handle;


    internal unsafe ImageCopyTexture GetCopyTexture(Silk.NET.WebGPU.TextureAspect aspect, uint mipLevel, Silk.NET.WebGPU.Origin3D origin)
    {
        return new ImageCopyTexture()
        {
            Aspect = aspect,
            MipLevel = mipLevel,
            Origin = origin,
            Texture = Handle
        };
    }

    public void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}