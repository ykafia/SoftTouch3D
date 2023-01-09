using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MemoryPack;
using Silk.NET.Core.Native;
using SoftTouch.Assets.Serialization.JSON;
using SoftTouch.Graphics.WebGPU;
using Utf8Json;
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
    public Guid GuidValue = Guid.NewGuid();

    [MemoryPackIgnore]
    public string FormattedGuid => 
        Convert.ToBase64String(GuidValue.ToByteArray())
        .Replace("/", "_")
        .Replace("+", "-")
        .Replace("=", "");

    [MemoryPackInclude]
    [MemoryPackAllowSerialize]
    public UPath AssetPath { get; private set; }
    [MemoryPackInclude]
    [MemoryPackAllowSerialize]
    public UPath Path { get; private set; }
    [MemoryPackIgnore]
    public string? Name => Path.GetNameWithoutExtension();
    
    [MemoryPackInclude]
    [MemoryPackAllowSerialize]
    public UPath SubPath { get; private set; }

    [MemoryPackIgnore]
    public bool IsEmbedded => !SubPath.IsEmpty;
    
    
    public AssetItem()
    {
        
    }
    public AssetItem(UPath assetPath)
    {
        AssetPath = assetPath;
        Path = UPath.Empty;
        SubPath = UPath.Empty;
    }
    [MemoryPackConstructor]
    public AssetItem(UPath assetPath, UPath path, UPath subpath)
    {
        AssetPath = assetPath;
        Path = path;
        SubPath = subpath;
    }
}