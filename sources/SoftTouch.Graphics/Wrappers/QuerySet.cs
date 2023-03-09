using SoftTouch.Graphics;
using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.SilkWrappers;
public readonly struct QuerySet : IGraphicsObject
{
    public unsafe Silk.NET.WebGPU.QuerySet* Handle { get; init; }
    public GraphicsState Graphics => GraphicsState.GetOrCreate();
    public WebGPU Api => Graphics.Api;

    internal unsafe QuerySet(Silk.NET.WebGPU.QuerySet* handle)
    {
        Handle = handle;
    }
    public unsafe static implicit operator Silk.NET.WebGPU.QuerySet*(QuerySet a) => a.Handle;

    public void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}