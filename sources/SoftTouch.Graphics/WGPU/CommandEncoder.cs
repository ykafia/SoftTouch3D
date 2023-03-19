using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.WGPU;
public readonly struct CommandEncoder : IGraphicsObject
{
    public unsafe Silk.NET.WebGPU.CommandEncoder* Handle { get; init; }
    public GraphicsState Graphics => GraphicsState.GetOrCreate();
    public WebGPU Api => Graphics.Api;

    internal unsafe CommandEncoder(Silk.NET.WebGPU.CommandEncoder* handle)
    {
        Handle = handle;
    }
    public unsafe static implicit operator Silk.NET.WebGPU.CommandEncoder*(CommandEncoder a) => a.Handle;


    public void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}