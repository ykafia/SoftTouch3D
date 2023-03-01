using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Graphics.SilkWrappers;

public class Instance
{
    public unsafe Silk.NET.WebGPU.Instance* Handle { get; init; }
    unsafe Instance(Silk.NET.WebGPU.Instance* instance)
    {
        Handle = instance;
    }
}
