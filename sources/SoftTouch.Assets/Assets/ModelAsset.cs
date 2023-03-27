using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Silk.NET.WebGPU;
using Zio;
using MemoryPack;
using VYaml.Annotations;
using SoftTouch.Core.Serialization;
using SoftTouch.Core.Assets;

namespace SoftTouch.Assets;

[YamlObject]
public partial class ModelAsset : IAssetItem, IEnumerable<IAssetItem>
{
    [YamlIgnore]
    public string Extension { get; } = "model";

    private MaterialAsset? Material { get; init; }

    public Guid ID { get; init; }

    public string AssetPath { get; init; }
    public string Path { get; init; }

    [YamlIgnore]
    public string? Name => new UPath(Path).GetNameWithoutExtension();

    public ModelAsset() { }
    public ModelAsset(string assetPath, string path)
    {
        ID = Guid.NewGuid();
        AssetPath = assetPath;
        Path = path;
        
    }

    public IEnumerator<IAssetItem> GetEnumerator()
    {
        yield return this;
        if (Material is not null)
            yield return Material;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}



