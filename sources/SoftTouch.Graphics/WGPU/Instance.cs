using Silk.NET.WebGPU;


namespace SoftTouch.Graphics.WGPU;

public readonly struct Instance : IGraphicsObject
{
    public unsafe Silk.NET.WebGPU.Instance* Handle { get; init; }
    public GraphicsState Graphics => GraphicsState.GetOrCreate();
    public WebGPU Api => Graphics.Api;
    internal unsafe Instance(Silk.NET.WebGPU.Instance* instance)
    {
        Handle = instance;
    }
    public unsafe static implicit operator Silk.NET.WebGPU.Instance*(Instance a) => a.Handle;

    public void Dispose()
    {
        unsafe
        {
            //Disposal.Dispose(Handle);
        }
    }
}
