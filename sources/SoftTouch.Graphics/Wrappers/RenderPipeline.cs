using SoftTouch.Graphics;

namespace SoftTouch.Graphics;
public sealed class RenderPipeline : GraphicsBaseObject<Silk.NET.WebGPU.RenderPipeline>
{

    internal unsafe RenderPipeline(Silk.NET.WebGPU.RenderPipeline* handle) : base(handle)
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