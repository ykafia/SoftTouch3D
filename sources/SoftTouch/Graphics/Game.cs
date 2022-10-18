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

namespace SoftTouch.Graphics.WGPU
{
    public class Game : IGame
    {
        Glfw window;
        WGPUGraphics Graphics = new();
        World world;

        public Game()
        {
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
            Graphics.LoadWindow();
        }
    }
}