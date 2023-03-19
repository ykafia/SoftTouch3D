using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.WGPU;
public readonly struct PipelineLayout : IGraphicsObject
{
    public unsafe Silk.NET.WebGPU.PipelineLayout* Handle { get; init; }
    public GraphicsState Graphics => GraphicsState.GetOrCreate();
    public WebGPU Api => Graphics.Api;

    internal unsafe PipelineLayout(Silk.NET.WebGPU.PipelineLayout* handle)
    {
        Handle = handle;
    }
    public unsafe static implicit operator Silk.NET.WebGPU.PipelineLayout*(PipelineLayout a) => a.Handle;

    public void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}