using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.SilkWrappers;

public sealed class Buffer : GraphicsBaseObject<Silk.NET.WebGPU.Buffer>
{

    internal unsafe Buffer(Silk.NET.WebGPU.Buffer* handle) : base(handle)
    {
    }
    internal unsafe Silk.NET.WebGPU.ImageCopyBuffer GetCopyBuffer(Silk.NET.WebGPU.TextureDataLayout layout, uint mipLevel, Silk.NET.WebGPU.Origin3D origin, )
    {
        return new Silk.NET.WebGPU.ImageCopyBuffer()
        {
            Buffer = Handle,
            Layout = layout,            
        };
    }

    public override void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}