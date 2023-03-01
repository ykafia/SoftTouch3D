using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.SilkWrappers;

public sealed class BindGroupLayout : GraphicsBaseObject<Silk.NET.WebGPU.BindGroupLayout>
{
    internal unsafe BindGroupLayout(Silk.NET.WebGPU.BindGroupLayout* handle) : base(handle)
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