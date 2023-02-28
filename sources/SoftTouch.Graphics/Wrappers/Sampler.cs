using SoftTouch.Graphics;

namespace SoftTouch.Graphics;
public sealed class Sampler : GraphicsBaseObject<Silk.NET.WebGPU.Sampler>
{

    internal unsafe Sampler(Silk.NET.WebGPU.Sampler* handle) : base(handle)
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