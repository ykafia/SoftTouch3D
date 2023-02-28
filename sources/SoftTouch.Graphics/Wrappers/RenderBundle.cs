using SoftTouch.Graphics;

namespace SoftTouch.Graphics;
public sealed class RenderBundle : GraphicsBaseObject<Silk.NET.WebGPU.RenderBundle>
{

    internal unsafe RenderBundle(Silk.NET.WebGPU.RenderBundle* handle) : base(handle)
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