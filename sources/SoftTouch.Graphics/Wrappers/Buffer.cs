using Silk.NET.WebGPU;
namespace SoftTouch.Graphics.SilkWrappers;

public readonly struct Buffer : IGraphicsObject
{
    public unsafe Silk.NET.WebGPU.Buffer* Handle { get; init; }
    public GraphicsState Graphics => GraphicsState.GetOrCreate();
    public WebGPU Api => Graphics.Api;

    internal unsafe Buffer(Silk.NET.WebGPU.Buffer* handle)
    {
        Handle = handle;
    }
    internal unsafe ImageCopyBuffer GetCopyBuffer(Silk.NET.WebGPU.TextureDataLayout layout, uint mipLevel, Silk.NET.WebGPU.Origin3D origin)
    {
        return new ImageCopyBuffer()
        {
            Buffer = Handle,
            Layout = layout,            
        };
    }
    public unsafe static implicit operator Silk.NET.WebGPU.Buffer*(Buffer a) => a.Handle;


    public void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}