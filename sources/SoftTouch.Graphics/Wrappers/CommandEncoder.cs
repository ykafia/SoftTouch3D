using SoftTouch.Graphics;
namespace SoftTouch.Graphics.SilkWrappers;
public sealed class CommandEncoder : GraphicsBaseObject<Silk.NET.WebGPU.CommandEncoder>
{

    internal unsafe CommandEncoder(Silk.NET.WebGPU.CommandEncoder* handle) : base(handle)
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