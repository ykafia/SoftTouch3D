using System;
using Zio;

namespace SoftTouch.Assets;


public interface IAsset
{
    public UPath Path {get;set;}
    public string Name {get;set;}
    void Unload();
}

public interface IAsset<T> : IAsset
{
    static abstract T Load(in UPath path, IFileSystem fs);
    static abstract void Unload(T asset);
}

public interface IComposableAsset<T> : IAsset, IEnumerable<IAsset>
{
    public List<IAsset> Assets {get;set;}
    static abstract T Load(in UPath path, IFileSystem fs);
    static abstract void Unload(T asset);
}