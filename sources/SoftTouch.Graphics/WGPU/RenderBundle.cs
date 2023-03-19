using SoftTouch.Graphics;
using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.WGPU;
public readonly struct RenderBundle : IGraphicsObject
{
    public unsafe Silk.NET.WebGPU.RenderBundle* Handle { get; init; }
    public GraphicsState Graphics => GraphicsState.GetOrCreate();
    public WebGPU Api => Graphics.Api;

    internal unsafe RenderBundle(Silk.NET.WebGPU.RenderBundle* handle)
    {
        Handle = handle;
    }
    public unsafe static implicit operator Silk.NET.WebGPU.RenderBundle*(RenderBundle a) => a.Handle;

    public void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}