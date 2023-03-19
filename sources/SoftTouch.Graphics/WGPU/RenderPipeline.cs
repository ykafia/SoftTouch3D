using SoftTouch.Graphics;
using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.WGPU;
public readonly struct RenderPipeline : IGraphicsObject
{

    public unsafe Silk.NET.WebGPU.RenderPipeline* Handle { get; init; }
    public GraphicsState Graphics => GraphicsState.GetOrCreate();
    public WebGPU Api => Graphics.Api;

    internal unsafe RenderPipeline(Silk.NET.WebGPU.RenderPipeline* handle)
    {
        Handle = handle;
    }
    public unsafe static implicit operator Silk.NET.WebGPU.RenderPipeline*(RenderPipeline a) => a.Handle;

    public void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}