using SoftTouch.Graphics;
using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.SilkWrappers;

public readonly struct RenderBundleEncoder : IGraphicsObject
{
    
    public unsafe Silk.NET.WebGPU.RenderBundleEncoder* Handle { get; init; }
    public GraphicsState Graphics => GraphicsState.GetOrCreate();
    public WebGPU Api => Graphics.Api;


    internal unsafe RenderBundleEncoder(Silk.NET.WebGPU.RenderBundleEncoder* handle)
    {
        Handle = handle;
    }
    public unsafe static implicit operator Silk.NET.WebGPU.RenderBundleEncoder*(RenderBundleEncoder a) => a.Handle;

    public void Dispose()
    {
        unsafe
        {
            //Graphics.Disposal.Dispose(Handle);
        }
    }
}