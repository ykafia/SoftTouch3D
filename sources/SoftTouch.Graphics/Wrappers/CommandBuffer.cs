using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.SilkWrappers;

public readonly struct CommandBuffer : IGraphicsObject
{
    public unsafe Silk.NET.WebGPU.CommandBuffer* Handle { get; init; }
    public GraphicsState Graphics => GraphicsState.GetOrCreate();
    public WebGPU Api => Graphics.Api;
    internal unsafe CommandBuffer(Silk.NET.WebGPU.CommandBuffer* handle)
    {
        Handle = handle;
    }
    public unsafe static implicit operator Silk.NET.WebGPU.CommandBuffer*(CommandBuffer a) => a.Handle;

    public void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}
