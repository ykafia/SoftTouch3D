using SharpGLTF.Schema2;
using Silk.NET.GLFW;
using Silk.NET.Windowing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Silk.NET.Maths;
using System.Runtime.InteropServices;
using System.Threading;
using Image = SixLabors.ImageSharp.Image;
using Silk.NET.WebGPU;
using Silk.NET.WebGPU.Extensions.Disposal;

namespace SoftTouch.Graphics;

public unsafe class GraphicsState
{
    static GraphicsState instance = new();
    public static GraphicsState Instance => instance;

    public WebGPU Api {get; private set;} = null!;
    public WebGPUDisposal Disposal {get;private set;} = null!;
    private IWindow? window;


    private Surface* surface;
    private Adapter* adapter;
    private Device* device;


    GraphicsState()
    {
        Api = WebGPU.GetApi();
        Disposal = new(Api);
    }

    public void Load(IWindow window)
    {
    }
}