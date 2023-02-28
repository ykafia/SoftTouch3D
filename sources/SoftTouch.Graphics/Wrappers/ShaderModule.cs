using SoftTouch.Graphics;

namespace SoftTouch.Graphics;
public sealed class ShaderModule : GraphicsBaseObject<Silk.NET.WebGPU.ShaderModule>
{

    internal unsafe ShaderModule(Silk.NET.WebGPU.ShaderModule* handle) : base(handle)
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