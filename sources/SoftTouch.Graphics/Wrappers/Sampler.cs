using SoftTouch.Graphics;
using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.SilkWrappers;
public readonly struct Sampler : IGraphicsObject
{
    public static GPUResources<Sampler> Samplers { get; } = new();

    public unsafe Silk.NET.WebGPU.Sampler* Handle { get; init; }

    public GraphicsState Graphics => GraphicsState.GetOrCreate();

    public WebGPU Api => Graphics.Api;


    internal unsafe Sampler(Silk.NET.WebGPU.Sampler* handle)
    {
        Handle = handle;
    }
    public unsafe static implicit operator Silk.NET.WebGPU.Sampler*(Sampler a) => a.Handle;



    public void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}