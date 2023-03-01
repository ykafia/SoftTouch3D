﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Graphics.SilkWrappers;

public class Adapter
{
    public unsafe Silk.NET.WebGPU.Adapter* Handle { get; init; }
    internal unsafe Adapter(Silk.NET.WebGPU.Adapter* adapter)
    {
        Handle = adapter;
    }
}