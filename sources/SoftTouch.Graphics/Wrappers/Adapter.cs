using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.SilkWrappers;

public struct Adapter : IGraphicsObject
{
    public unsafe Silk.NET.WebGPU.Adapter* Handle { get; init; }
    public GraphicsState Graphics => GraphicsState.GetOrCreate();
    public WebGPU Api => Graphics.Api;
    internal unsafe Adapter(Silk.NET.WebGPU.Adapter* adapter)
    {
        Handle = adapter;
    }

    public unsafe static implicit operator Silk.NET.WebGPU.Adapter*(Adapter a) => a.Handle;

    public void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}
