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

namespace SoftTouch.Assets;

[YamlObject]
public partial class MaterialAsset : IAssetItem, IEnumerable<IAssetItem>
{
    public string Extension { get; set; } = "mat";

    public Guid ID { get; set; }

    public string AssetPath { get; set; }
    public string Path {  get;set; }



    [YamlIgnore]
    public string? Name => new UPath(Path).GetNameWithoutExtension();

    [YamlConstructor]
    public MaterialAsset(string assetPath, string path)
    {
        ID = Guid.NewGuid();
        AssetPath = assetPath;
        Path = path;
    }

    public IEnumerator<IAssetItem> GetEnumerator()
    {

        yield return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
