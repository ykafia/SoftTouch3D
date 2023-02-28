using Silk.NET.WebGPU;
using System.Reflection.Metadata;

namespace SoftTouch.Graphics;

public sealed class BindGroup : GraphicsBaseObject<Silk.NET.WebGPU.BindGroup>
{
    internal unsafe BindGroup(Silk.NET.WebGPU.BindGroup* handle) : base(handle)
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