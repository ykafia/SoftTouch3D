using Silk.NET.Maths;
using SoftTouch.Graphics;
using System.Runtime.CompilerServices;

namespace SoftTouch.Graphics.SilkWrappers;

public sealed class Texture : GraphicsBaseObject<Silk.NET.WebGPU.Texture>
{

    internal unsafe Texture(Silk.NET.WebGPU.Texture* handle) : base(handle)
    {
    }

    public unsafe internal Silk.NET.WebGPU.ImageCopyTexture GetCopyTexture(Silk.NET.WebGPU.TextureAspect aspect, uint mipLevel, Silk.NET.WebGPU.Origin3D origin, )
    {
        return new Silk.NET.WebGPU.ImageCopyTexture()
        {
            Aspect = aspect,
            MipLevel = mipLevel,
            Origin = origin,
            Texture = Handle
        };
    }

    public override void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}