using SoftTouch.Graphics;

namespace SoftTouch.Graphics;
public sealed class SwapChain : GraphicsBaseObject<Silk.NET.WebGPU.SwapChain>
{

    internal unsafe SwapChain(Silk.NET.WebGPU.SwapChain* handle) : base(handle)
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