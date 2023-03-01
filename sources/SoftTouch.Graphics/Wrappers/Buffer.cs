using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.SilkWrappers;

public sealed class Buffer : GraphicsBaseObject<Silk.NET.WebGPU.Buffer>
{

    internal unsafe Buffer(Silk.NET.WebGPU.Buffer* handle) : base(handle)
    {
    }

    public override void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}