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

namespace SoftTouch.Graphics.WGPU
{
    public class Game : IGame
    {
        IWindow window;
        WGPUGraphics Graphics = new();
        World world;
        World renderWorld;

        public Game()
        {
            window = Window.Create(WindowOptions.Default);
            world = new();
            world.AddStartup<Processors.Startup>();
            OnLoad();
        }
        public void Run()
        {
            Graphics.Render();
        }

        public void OnLoad()
        {
            Graphics.LoadWindow(window);
        }
    }
}