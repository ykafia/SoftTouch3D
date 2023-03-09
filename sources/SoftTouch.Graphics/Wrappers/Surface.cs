using Silk.NET.WebGPU;
using Silk.NET.Windowing;
using SoftTouch.Graphics;

namespace SoftTouch.Graphics.SilkWrappers;
public readonly struct Surface : IDisposable
{
    static GraphicsState Gfx => GraphicsState.GetOrCreate();
    public unsafe Silk.NET.WebGPU.Surface* Handle { get; init; }
    internal unsafe Surface(Silk.NET.WebGPU.Surface* hdl)
    {
        Handle = hdl;
    }

    public unsafe static implicit operator Silk.NET.WebGPU.Surface*(Surface a) => a.Handle;

    public void Dispose()
    {
        unsafe
        {
            Gfx.Disposal.Dispose(Handle);
        }
    }
}