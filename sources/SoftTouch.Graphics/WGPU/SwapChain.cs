using SoftTouch.Graphics;
using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.WGPU;
public readonly struct SwapChain : IGraphicsObject
{
    public unsafe Silk.NET.WebGPU.SwapChain* Handle { get; init; }

    public GraphicsState Graphics => GraphicsState.GetOrCreate();

    public WebGPU Api => Graphics.Api;

    internal unsafe SwapChain(Silk.NET.WebGPU.SwapChain* handle)
    {
        Handle = handle;
    }
    public unsafe static implicit operator Silk.NET.WebGPU.SwapChain*(SwapChain a) => a.Handle;


    public void Dispose()
    {
        unsafe
        {
            //Graphics.Disposal.Dispose(Handle);
        }
    }
}