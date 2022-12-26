using System;
using MessagePack;
using SoftTouch.Graphics.WebGPU;
using Zio;

namespace SoftTouch.Assets;

// [Union(0, typeof(ModelAsset))]
// [Union(1, typeof(ImageAsset))]
// [Union(1, typeof(MaterialAsset))]
[MessagePackObject]
public abstract class AssetItem
{
    [Key(0)]
    public UPath Path { get; private set; }
    [Key(1)]
    public string? Name => Path.GetNameWithoutExtension();
    [Key(2)]
    public UPath SubPath { get; private set; }
    [Key(3)]
    public bool IsEmbedded => SubPath.IsEmpty;

    public AssetItem(UPath path)
    {
        Path = path;
        SubPath = UPath.Empty;
    }
    public AssetItem(UPath path, UPath subpath)
    {
        Path = path;
        SubPath = subpath;
    }
}