using SoftTouch.Graphics;

namespace SoftTouch.Graphics;

public sealed class RenderBundleEncoder : GraphicsBaseObject<Silk.NET.WebGPU.RenderBundleEncoder>
{

    internal unsafe RenderBundleEncoder(Silk.NET.WebGPU.RenderBundleEncoder* handle) : base(handle)
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