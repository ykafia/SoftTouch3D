namespace SoftTouch.Graphics.SilkWrappers;

public abstract class GraphicsBaseObject<T> : IDisposable
    where T : unmanaged
{
    public unsafe T* Handle { get; init; }
    protected GraphicsState Graphics => GraphicsState.GetOrCreate();
    protected Silk.NET.WebGPU.WebGPU Api => Graphics.Api;
    protected Silk.NET.WebGPU.Extensions.Disposal.WebGPUDisposal Disposal => Graphics.Disposal;

    internal unsafe GraphicsBaseObject(T* handle)
    {
        Handle = handle;
    }

    public abstract void Dispose();
}