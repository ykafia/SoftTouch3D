using System;
using System.IO;
using Zio;

namespace SoftTouch.Assets;


public interface IAsset{}

public interface IAsset<T> : IAsset
{
    static abstract T Load(in UPath path, IFileSystem fs);
}