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

    
    public string AssetPath { get; init; }

    public string Path { get; init; }
    [YamlIgnore]
    public string? Name => new UPath(Path).GetNameWithoutExtension();

    public string SubPath { get; init; }

    [YamlIgnore]
    public bool IsEmbedded => !new UPath(SubPath).IsEmpty;
    
    
    public AssetItem()
    {
        
    }
    public AssetItem(string assetPath)
    {
        AssetPath = assetPath;
        Path = string.Empty;
        SubPath = string.Empty;
    }
    [MemoryPackConstructor]
    public AssetItem(string assetPath, string path, string subpath)
    {
        AssetPath = assetPath;
        Path = path;
        SubPath = subpath;
    }
}