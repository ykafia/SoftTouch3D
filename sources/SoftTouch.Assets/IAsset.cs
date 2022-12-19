using System;
using SoftTouch.Graphics.WebGPU;
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
public interface IGfxAsset<T> : IAsset
{
    static abstract T Load(in UPath path, IFileSystem fs, WGPUGraphics gfx);
    static abstract void Unload(T asset);
}

public interface IGfxAssets<T> : IGfxAsset<T>, IEnumerable<IAsset>
{
    public Dictionary<string, IAsset> Assets {get;set;}
}