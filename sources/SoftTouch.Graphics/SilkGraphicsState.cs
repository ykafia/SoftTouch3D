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
using WGPU.NET;
using Silk.NET.Core.Native;

namespace SoftTouch.Graphics.SilkWrappers;

public unsafe class GraphicsState
{
    static GraphicsState gfxState = null!;
    public static GraphicsState GetOrCreate(IWindow? window = null)
    {
        if (gfxState is not null)
            return gfxState;
        gfxState = new GraphicsState(window ?? throw new Exception("window is null"));
        return gfxState;
    }

    public Silk.NET.WebGPU.WebGPU Api {get; private set;} = null!;
    public WebGPUDisposal Disposal {get;private set;} = null!;
    public Adapter Adapter { get; private set; } = null!;
    public Instance Instance { get; private set; } = null!;
    public Surface Surface { get; private set; } = null!;
    public Device Device { get; private set; } = null!;

     
    GraphicsState(IWindow window)
    {
        Api = Silk.NET.WebGPU.WebGPU.GetApi();
        Disposal = new(Api);
        var cs = new ChainedStruct();
        if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            cs.SType = SType.SurfaceDescriptorFromWindowsHwnd;
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            cs.SType = SType.SurfaceDescriptorFromXlibWindow;
        }
        var desc = new InstanceDescriptor() { NextInChain = &cs };
        Instance = new(Api.CreateInstance(desc));
        
        Surface surface = new(window.CreateWebGPUSurface(Api,Instance.Handle));
        {
            var requestAdapterOptions = new RequestAdapterOptions
            {
                CompatibleSurface = surface.Handle
            };

            Api.InstanceRequestAdapter
            (
                Instance.Handle,
                requestAdapterOptions,
                new PfnRequestAdapterCallback((_, adapter1, _, _) => Adapter = new(adapter1)),
                null
            );

            Console.WriteLine($"Got adapter {(nuint)Adapter.Handle:X}");
        }
        {


            var deviceDescriptor = new DeviceDescriptor
            {
                RequiredLimits = null,
                DefaultQueue = new QueueDescriptor(),
                RequiredFeatures = null
            };

            Api.AdapterRequestDevice
            (
                Adapter.Handle,
                deviceDescriptor,
                new PfnRequestDeviceCallback((_, device1, _, _) => Device = new(device1)),
                null
            );

            Console.WriteLine($"Got device {(nuint)Device.Handle:X}");
        } //Get device
        var features = stackalloc FeatureName[100];
        Api.DeviceEnumerateFeatures(Device.Handle, features);
        Api.DeviceSetUncapturedErrorCallback(Device.Handle, new PfnErrorCallback(UncapturedError), null);
        Api.DeviceSetDeviceLostCallback(Device.Handle, new PfnDeviceLostCallback(DeviceLost), null);

    }
    private static void DeviceLost(DeviceLostReason arg0, byte* arg1, void* arg2)
    {
        Console.WriteLine($"Device lost! Reason: {arg0} Message: {SilkMarshal.PtrToString((nint)arg1)}");
    }
    private static void UncapturedError(ErrorType arg0, byte* arg1, void* arg2)
    {
        Console.WriteLine($"{arg0}: {SilkMarshal.PtrToString((nint)arg1)}");
    }

    public void Load(IWindow window)
    {
    }
}