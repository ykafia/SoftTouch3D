using Silk.NET.WebGPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Graphics.WGPU;

public struct TextureView : IGraphicsObject
{
    public GraphicsState Graphics => GraphicsState.GetOrCreate();

    public WebGPU Api => Graphics.Api;

    public unsafe Silk.NET.WebGPU.TextureView* Handle { get; init; }


    internal unsafe TextureView(Silk.NET.WebGPU.TextureView* handle)
    {
        Handle = handle;
    }

    public unsafe static implicit operator Silk.NET.WebGPU.TextureView*(TextureView a) => a.Handle;

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
