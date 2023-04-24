using SoftTouch.Graphics;
using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.WGPU;
public readonly struct ShaderModule : IGraphicsObject
{
    public unsafe Silk.NET.WebGPU.ShaderModule* Handle { get; init; }
    public GraphicsState Graphics => GraphicsState.GetOrCreate();
    public WebGPU Api => Graphics.Api;
    internal unsafe ShaderModule(Silk.NET.WebGPU.ShaderModule* handle)
    {
        Handle = handle;
    }
    public unsafe static implicit operator Silk.NET.WebGPU.ShaderModule*(ShaderModule a) => a.Handle;

    public void GetCompilationInfo(PfnCompilationInfoCallback callback)
    {
        unsafe
        {
            Api.ShaderModuleGetCompilationInfo(this, callback, null);
        }
    }


    public void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}