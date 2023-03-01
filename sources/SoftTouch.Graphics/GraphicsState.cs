using Silk.NET.Windowing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WGPU.NET;

namespace SoftTouch.Graphics;

public class GraphicsState
{
    static GraphicsState? gfxState;
    public static GraphicsState GetOrCreate(IWindow? window)
    {
        if (gfxState is not null)
            return gfxState;
        gfxState = new GraphicsState(window ?? throw new Exception("window is null"));
        return gfxState;
    }


    Adapter Adapter { get; set; } = null!;
    Instance Instance { get; set; } = null!;
    Surface Surface { get; set; } = null!;
    Device Device { get; set; } = default!;


    GraphicsState(IWindow window)
    {
        Instance = new();
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            var inst = window.Native?.Win32?.HInstance ?? 0;
            var hwnd = window.Native?.Win32?.Hwnd ?? 0;
            if (inst == 0 || hwnd == 0)
                throw new NullReferenceException("No window hwnd or instance");
            Surface = Instance.CreateSurfaceFromWindowsHWND(inst, hwnd);
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            Surface = Instance.CreateSurfaceFromXlibWindow(window.Native?.X11?.Display ?? 0, (uint)(window.Native?.X11?.Window ?? 0));
        }
        else
        {
            Surface = Instance.CreateSurfaceFromMetalLayer(window.Native?.Cocoa ?? 0);
        }
        Instance.RequestAdapter(Surface, default, default, (s, a, m) => Adapter = a, Wgpu.BackendType.Vulkan);

        Adapter.GetProperties(out Wgpu.AdapterProperties properties);



        Adapter.GetLimits(out var supportedLimits);

        Adapter.RequestDevice((s, d, m) => Device = d,
                limits: supportedLimits.limits,
            label: "Device",
            nativeFeatures: Array.Empty<Wgpu.NativeFeature>()
            );
        Device.SetUncapturedErrorCallback(ErrorCallback);
    }
    public static void ErrorCallback(Wgpu.ErrorType type, string message)
    {
        var _message = message.Replace("\\r\\n", "\n");

        Console.WriteLine($"{type}: {_message}");

        Debugger.Break();
    }
}
