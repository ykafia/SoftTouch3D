using SoftTouch.Graphics;


namespace SoftTouch.Graphics;

public sealed class Texture : GraphicsBaseObject<Silk.NET.WebGPU.Texture>
{

    internal unsafe Texture(Silk.NET.WebGPU.Texture* handle) : base(handle)
    {
    }

    public override void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}