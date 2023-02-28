using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MemoryPack;
using Silk.NET.Core.Native;
using SoftTouch.Assets.Serialization.JSON;
using SoftTouch.Graphics;
using Utf8Json;
using VYaml.Annotations;
using Zio;

namespace SoftTouch.Assets;

[YamlObject]
[YamlObjectUnion("!model",typeof(ModelAsset))]
[YamlObjectUnion("!image", typeof(ImageAsset))]
[YamlObjectUnion("!material", typeof(MaterialAsset))]
[YamlObjectUnion("!shader", typeof(ShaderAsset))]
public abstract partial class AssetItem
{
    [YamlIgnore]
    public abstract string Extension { get; init; }

    [YamlIgnore]
    public Guid GuidValue = Guid.NewGuid();

    [YamlIgnore]
    public string FormattedGuid => 
        Convert.ToBase64String(GuidValue.ToByteArray())
        .Replace("/", "_")
        .Replace("+", "-")
        .Replace("=", "");

    
    public UPath AssetPath { get; init; }

    public UPath Path { get; init; }
    [YamlIgnore]
    public string? Name => Path.GetNameWithoutExtension();

    public UPath SubPath { get; init; }

    [YamlIgnore]
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