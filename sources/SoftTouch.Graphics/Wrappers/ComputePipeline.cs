using SoftTouch.Graphics;

namespace SoftTouch.Graphics.SilkWrappers;
public sealed class ComputePipeline : GraphicsBaseObject<Silk.NET.WebGPU.ComputePipeline>
{

    internal unsafe ComputePipeline(Silk.NET.WebGPU.ComputePipeline* handle) : base(handle)
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