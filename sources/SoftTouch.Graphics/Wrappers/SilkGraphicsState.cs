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
using Silk.NET.WebGPU.Extensions.Disposal;
using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.SilkWrappers;

public unsafe class SilkGraphicsState
{
    static SilkGraphicsState instance = null!;
    public static SilkGraphicsState GetOrCreate(IWindow? window = null)
    {
        if (instance is not null)
            return instance;
        instance = new SilkGraphicsState(window ?? throw new Exception("window is null"));
        return instance;
    }

    public Silk.NET.WebGPU.WebGPU Api {get; private set;} = null!;
    public WebGPUDisposal Disposal {get;private set;} = null!;
    public Adapter Adapter { get; private set; } = null!;

    //private Surface* surface;


    SilkGraphicsState(IWindow window)
    {
        Api = Silk.NET.WebGPU.WebGPU.GetApi();
        Disposal = new(Api);
        // Get Surface
        Surface surface  = new(window.CreateWebGPUSurface(Api));


        { //Get adapter
            var requestAdapterOptions = new RequestAdapterOptions
            {
                CompatibleSurface = surface.Handle
            };

            Api.InstanceRequestAdapter
            (
                null,
                requestAdapterOptions,
                new PfnRequestAdapterCallback((_, adapter1, _, _) => Adapter = new(adapter1)),
                null
            );

            Console.WriteLine($"Got adapter {(nuint)Adapter.Handle:X}");
        } //Get adapter
    }

    public void Load(IWindow window)
    {
    }
}