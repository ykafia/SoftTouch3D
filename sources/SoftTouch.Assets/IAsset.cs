using System;
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