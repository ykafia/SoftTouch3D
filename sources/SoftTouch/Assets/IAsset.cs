using System;
using System.IO;
using Zio;

namespace SoftTouch.Assets;

public interface IAsset
{
    static abstract IAsset Load(in UPath path, Stream s);
}