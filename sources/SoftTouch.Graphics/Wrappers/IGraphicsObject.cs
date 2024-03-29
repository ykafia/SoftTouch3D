﻿using Silk.NET.WebGPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Graphics.SilkWrappers;

public interface IGraphicsObject : IDisposable
    where T : unmanaged
{
    public GraphicsState Graphics { get; }
    public WebGPU Api { get; }

}
