using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.WGPU;
public readonly struct ComputePipeline : IGraphicsObject
{
    public unsafe Silk.NET.WebGPU.ComputePipeline* Handle { get; init; }
    public GraphicsState Graphics => GraphicsState.GetOrCreate();
    public WebGPU Api => Graphics.Api;

    internal unsafe ComputePipeline(Silk.NET.WebGPU.ComputePipeline* handle)
    {
        Handle = handle;
    }

    public unsafe static implicit operator Silk.NET.WebGPU.ComputePipeline*(ComputePipeline a) => a.Handle;


    public BindGroupLayout GetBindGroupLayout(uint groupIndex)
    {
        unsafe
        {
            return new(Api.ComputePipelineGetBindGroupLayout(Handle, groupIndex));
        }
    }

    public void Dispose()
    {
        //Api.ComputePipelineGetBindGroupLayout()
        //Api.ComputePipelineSetLabel()
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}