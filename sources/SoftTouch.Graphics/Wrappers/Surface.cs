using Silk.NET.WebGPU;
using Silk.NET.Windowing;
using SoftTouch.Graphics;

namespace SoftTouch.Graphics.SilkWrappers;
public sealed class Surface : GraphicsBaseObject<Silk.NET.WebGPU.Surface>
{
    internal unsafe Surface(Silk.NET.WebGPU.Surface* hdl) : base(hdl)
    {}

    public override void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}