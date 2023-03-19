using Silk.NET.WebGPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Graphics.WGPU;

public interface IGraphicsObject : IDisposable
{
    public GraphicsState Graphics { get; }
    public WebGPU Api { get; }

}
