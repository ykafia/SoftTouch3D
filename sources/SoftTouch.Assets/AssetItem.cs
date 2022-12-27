using System;
using MemoryPack;
using SoftTouch.Graphics.WebGPU;
using Zio;

namespace SoftTouch.Assets;

// [Union(0, typeof(ModelAsset))]
// [Union(1, typeof(ImageAsset))]
// [Union(1, typeof(MaterialAsset))]
[MemoryPackable]
[MemoryPackUnion(0,typeof(ModelAsset))]
[MemoryPackUnion(1, typeof(ImageAsset))]
[MemoryPackUnion(2, typeof(MaterialAsset))]
[MemoryPackUnion(3, typeof(ShaderAsset))]
public abstract partial class AssetItem
{
    [MemoryPackIgnore]
    public abstract string Extension { get; init; }
    [MemoryPackIgnore]
    public UPath Path { get; private set; }
    [MemoryPackIgnore]
    public string? Name => Path.GetNameWithoutExtension();
    
    [MemoryPackIgnore]
    public UPath SubPath { get; private set; }

    [MemoryPackIgnore]
    public bool IsEmbedded => SubPath.IsEmpty;
    
    [MemoryPackConstructor]
    public AssetItem()
    {
        
    }
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