using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Graphics.SilkWrappers;

public class CommandBuffer : GraphicsBaseObject<Silk.NET.WebGPU.CommandBuffer>
{
    internal unsafe CommandBuffer(Silk.NET.WebGPU.CommandBuffer* handle) : base(handle) { }
    public override void Dispose()
    {
        unsafe
        {
            Disposal.Dispose(Handle);
        }
    }
}
