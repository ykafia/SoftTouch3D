using SoftTouch.Graphics;

namespace SoftTouch.Graphics.SilkWrappers;
public sealed class PipelineLayout : GraphicsBaseObject<Silk.NET.WebGPU.PipelineLayout>
{

    internal unsafe PipelineLayout(Silk.NET.WebGPU.PipelineLayout* handle) : base(handle)
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