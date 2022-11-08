using System;
using System.IO;
using SoftTouch.Graphics.WGPU;
using Zio;

namespace SoftTouch.Assets;


public interface IAsset
{
    void Unload();
}

public interface IAsset<T> : IAsset
{
    static abstract T Load(in UPath path, IFileSystem fs);
    static abstract void Unload(T asset);
}

public interface IGraphicsAsset<T> : IAsset
{
    static abstract T Load(in UPath path, IFileSystem fs, WGPUGraphics graphics);
    static abstract void Unload(T asset);
}