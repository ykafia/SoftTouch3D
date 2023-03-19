using Silk.NET.WebGPU;
using System.Reflection.Metadata;

namespace SoftTouch.Graphics.WGPU;

public readonly struct BindGroup : IGraphicsObject
{
    public unsafe Silk.NET.WebGPU.BindGroup* Handle { get; init; }
    public GraphicsState Graphics => GraphicsState.GetOrCreate();
    public WebGPU Api => Graphics.Api;
    internal unsafe BindGroup(Silk.NET.WebGPU.BindGroup* handle)
    {
        Handle = handle;
    }
    public unsafe static implicit operator Silk.NET.WebGPU.BindGroup*(BindGroup a) => a.Handle;


    public void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}