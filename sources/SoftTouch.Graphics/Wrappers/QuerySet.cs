using SoftTouch.Graphics;

namespace SoftTouch.Graphics;
public sealed class QuerySet : GraphicsBaseObject<Silk.NET.WebGPU.QuerySet>
{

    internal unsafe QuerySet(Silk.NET.WebGPU.QuerySet* handle) : base(handle)
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