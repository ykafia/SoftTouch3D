using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.SilkWrappers;


public readonly struct BindGroupLayout : IGraphicsObject
{
    public unsafe Silk.NET.WebGPU.BindGroupLayout* Handle { get; init; }
    public GraphicsState Graphics => GraphicsState.GetOrCreate();
    public WebGPU Api => Graphics.Api;
    internal unsafe BindGroupLayout(Silk.NET.WebGPU.BindGroupLayout* handle)
    {
        Handle = handle;
    }

    public unsafe static implicit operator Silk.NET.WebGPU.BindGroupLayout*(BindGroupLayout a) => a.Handle;


    public void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}