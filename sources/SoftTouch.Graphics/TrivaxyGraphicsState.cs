using Silk.NET.Windowing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SoftTouch.WGPU.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WGPU.NET;

namespace SoftTouch.Graphics;

[Obsolete]
public class TrivaxyGraphicsState
{
    static TrivaxyGraphicsState? gfxState;
    public static TrivaxyGraphicsState GetOrCreate(IWindow? window = null)
    {
        if (gfxState is not null)
            return gfxState;
        gfxState = new TrivaxyGraphicsState(window ?? throw new Exception("window is null"));
        return gfxState;
    }


    public Adapter Adapter { get; private set; } = null!;
    public Instance Instance { get; private set; } = null!;
    public Surface Surface { get; private set; } = null!;
    public Device Device { get; private set; } = default!;


    TrivaxyGraphicsState(IWindow window)
    {
        Silk.NET.WebGPU.WebGPU.GetApi();
        //Instance = new();
        //if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        //{
        //    var inst = window.Native?.Win32?.HInstance ?? 0;
        //    var hwnd = window.Native?.Win32?.Hwnd ?? 0;
        //    if (inst == 0 || hwnd == 0)
        //        throw new NullReferenceException("No window hwnd or instance");
        //    Surface = Instance.CreateSurfaceFromWindowsHWND(inst, hwnd);
        //}
        //else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        //{
        //    Surface = Instance.CreateSurfaceFromXlibWindow(window.Native?.X11?.Display ?? 0, (uint)(window.Native?.X11?.Window ?? 0));
        //}
        //else
        //{
        //    Surface = Instance.CreateSurfaceFromMetalLayer(window.Native?.Cocoa ?? 0);
        //}
        //Instance.RequestAdapter(Surface, default, default, (s, a, m) => Adapter = a, Wgpu.BackendType.Vulkan);

        //Adapter.GetProperties(out Wgpu.AdapterProperties properties);



        //Adapter.GetLimits(out var supportedLimits);

        //Adapter.RequestDevice((s, d, m) => Device = d,
        //        limits: supportedLimits.limits,
        //    label: "Device",
        //    nativeFeatures: Array.Empty<Wgpu.NativeFeature>()
        //    );
        //Device.SetUncapturedErrorCallback(ErrorCallback);

        //var image = new Image<Rgba32>(256, 256, Rgba32.ParseHex("#00FFFFFF"));

        //// Define WTexture size
        //var imageSize = new Wgpu.Extent3D
        //{
        //    width = (uint)image.Width,
        //    height = (uint)image.Height,
        //    depthOrArrayLayers = 1
        //};

        //// Instantiate in gpu
        //var imageTexture = Device.CreateTexture(
        //    label: "Image",
        //    usage: Wgpu.TextureUsage.TextureBinding | Wgpu.TextureUsage.CopySrc | Wgpu.TextureUsage.CopyDst,
        //    dimension: Wgpu.TextureDimension.TwoDimensions,
        //    size: imageSize,
        //    format: Wgpu.TextureFormat.RGBA8Unorm,
        //    mipLevelCount: 1,
        //    sampleCount: 1
        //);

        //{
        //    // Send data to gpu
        //    Span<Rgba32> pixels = new Rgba32[image.Width * image.Height];

        //    image.CopyPixelDataTo(pixels);

        //    Device.GetQueue().WriteTexture<Rgba32>(
        //        destination: new ImageCopyTexture
        //        {
        //            Aspect = Wgpu.TextureAspect.All,
        //            MipLevel = 0,
        //            Origin = default,
        //            Texture = imageTexture
        //        },
        //        data: pixels,
        //        dataLayout: new Wgpu.TextureDataLayout
        //        {
        //            bytesPerRow = (uint)(Marshal.SizeOf<Rgba32>() * image.Width),
        //            offset = 0,
        //            rowsPerImage = (uint)image.Height
        //        },
        //        writeSize: imageSize
        //    );
        //}
        //var encoder = Device.CreateCommandEncoder(null);
        //var stagingBuffer = Device.CreateBuffer(null, false, (uint)(Marshal.SizeOf<Rgba32>() * image.Width * image.Height), Wgpu.BufferUsage.MapRead | Wgpu.BufferUsage.CopyDst);
        //var copyTex = new ImageCopyTexture() { Texture = imageTexture, MipLevel = 0 };
        //var copyBuf = new ImageCopyBuffer() { Buffer = stagingBuffer, Layout = new() { bytesPerRow = (uint)(Marshal.SizeOf<Rgba32>() * image.Width), rowsPerImage = (uint)image.Height } };
        //encoder.CopyTexureToBuffer(copyTex, in copyBuf, imageTexture.Size);
        ////var callback = new BufferMapCallback((s) => { });
        ////stagingBuffer.MapAsync(Wgpu.MapMode.Read, 0, stagingBuffer.SizeInBytes, callback);
        //this.Device.GetQueue().Submit(new CommandBuffer[] { encoder.Finish("copy data")});
        //stagingBuffer.MapAsync(Wgpu.MapMode.Read, 0, 256 * 256 * 4, (s) => { });
        //stagingBuffer.GetMappedRange<byte>(0, 256 * 256 * 4);
        
        //var x = 0;
    }
    public static void ErrorCallback(Wgpu.ErrorType type, string message)
    {
        var _message = message.Replace("\\r\\n", "\n");

        Console.WriteLine($"{type}: {_message}");

        Debugger.Break();
    }
}
