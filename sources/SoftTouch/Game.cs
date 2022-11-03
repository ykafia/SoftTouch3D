using System;
using System.Numerics;
using WGPU.NET;
using System.Diagnostics;
using Silk.NET.GLFW;
using System.Runtime.InteropServices;
using System.IO;
using Image = SixLabors.ImageSharp.Image;
using SixLabors.ImageSharp.PixelFormats;
using ECSharp;
using Silk.NET.Windowing;
using SoftTouch.Graphics.WGPU;
using SoftTouch.Assets;
using Zio.FileSystems;

namespace SoftTouch;

public class Game : IGame
{
    IWindow window;
    WGPUGraphics Graphics = new();
    World world;
    World? renderWorld;
    AssetManager assetManager;

    public Game()
    {
        window = Window.Create(WindowOptions.Default);
        window.Initialize();

        world = new();
        var fs = new PhysicalFileSystem();
        var ss = new SubFileSystem(fs,fs.ConvertPathFromInternal("../../assets"));
        assetManager = new(ss);

        world.AddStartup<Processors.Startup>();
        OnLoad();
    }
    public void Run()
    {
        // Graphics.Render();
    }

    public void OnLoad()
    {
        Graphics.LoadWindow(window);
    }
}
