namespace SoftTouch.Graphics;

public abstract class GraphicsBaseObject<T> : IDisposable
    where T : unmanaged
{
    public unsafe T* Handle { get; init; }
    protected GraphicsState Graphics => GraphicsState.Instance;
    protected Silk.NET.WebGPU.WebGPU Api => Graphics.Api;

    internal unsafe GraphicsBaseObject(T* handle)
    {
        Handle = handle;
    }

    public abstract void Dispose();
}