using SoftTouch.Graphics;
using Silk.NET.WebGPU;
using Zio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using SharpGLTF.Schema2;
using System.Collections;
using MemoryPack;
using VYaml.Annotations;
using SoftTouch.Core.Serialization;
using SoftTouch.Core.Assets;

namespace SoftTouch.Assets;

[YamlObject]
public partial class MaterialAsset : IAssetItem, IEnumerable<IAssetItem>
{
    [YamlIgnore]
    public string Extension { get; init; } = "mat";

    public Guid ID { get; init; }

    public string AssetPath { get; init; }
    public string Path {  get; init; }

    public AssetReference DiffuseTexture;
 

    [YamlIgnore]
    public string? Name => new UPath(Path).GetNameWithoutExtension();

    public MaterialAsset()
    { }

    public MaterialAsset(string assetPath, string path)
    {
        ID = Guid.NewGuid();
        AssetPath = assetPath;
        Path = path;
    }

    public IEnumerator<IAssetItem> GetEnumerator()
    {
        yield return DiffuseTexture.Get<MaterialAsset>();
        yield return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
