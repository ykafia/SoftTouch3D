using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Silk.NET.WebGPU;
using Zio;
using MemoryPack;
using VYaml.Annotations;

namespace SoftTouch.Assets;

[YamlObject]
public partial class ModelAsset : IAssetItem, IEnumerable<IAssetItem>
{
    public string Extension { get; set; } = "model";

    private MaterialAsset? Material { get; set; }

    public Guid ID { get; set; }

    public string AssetPath { get; set; }
    public string Path { get; set; }

    [YamlIgnore]
    public string? Name => new UPath(Path).GetNameWithoutExtension();


    [YamlConstructor]
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



