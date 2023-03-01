using Silk.NET.WebGPU;
using Silk.NET.Windowing;
using SoftTouch.Graphics;

namespace SoftTouch.Graphics.SilkWrappers;
public sealed class Surface
{
    public unsafe Silk.NET.WebGPU.Surface* Handle { get; init; }
    internal unsafe Surface(Silk.NET.WebGPU.Surface* hdl)
    {
        Handle = hdl;
    }
}