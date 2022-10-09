using System;
using System.Numerics;
using WGPU.NET;
using System.Diagnostics;
using Silk.NET.GLFW;
using System.Runtime.InteropServices;
using System.IO;
using Image = SixLabors.ImageSharp.Image;
using SixLabors.ImageSharp.PixelFormats;

namespace SoftTouch.Graphics.WGPU
{
    public class WGPUGame : IGame
    {
        Glfw window;
        WGPUGraphics Graphics = new();

        public WGPUGame()
        {
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