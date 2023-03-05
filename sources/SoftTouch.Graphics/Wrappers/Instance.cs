using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Graphics.SilkWrappers;

public class Instance
{
    static Silk.NET.WebGPU.WebGPU Api => GraphicsState.GetOrCreate().Api;
    public unsafe Silk.NET.WebGPU.Instance* Handle { get; init; }

    internal unsafe Instance(Silk.NET.WebGPU.Instance* instance)
    {
        Handle = instance;
    }
}
