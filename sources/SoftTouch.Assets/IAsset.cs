using System;
using SoftTouch.Graphics.WebGPU;
using Zio;

namespace SoftTouch.Assets;


public interface IAsset
{
    void Load(WGPUGraphics gfx);
    void Unload();
}