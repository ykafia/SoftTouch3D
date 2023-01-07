using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SoftTouch.Graphics.WebGPU;
using SoftTouch.Rendering.Materials;
using SoftTouch.Rendering.Renderables;
using WGPU.NET;
using Zio;
using MemoryPack;

namespace SoftTouch.Assets;

[MemoryPackable]
public partial class ModelAsset : AssetItem, IEnumerable<AssetItem>
{
    public override string Extension { get; init; } = "model";

    public MaterialAsset? Material { get; set; }

    public ModelAsset()
    {

    }
    public ModelAsset(UPath path) : base(path)
    {}
    [MemoryPackConstructor]
    public ModelAsset(UPath assetPath, UPath path, UPath subpath) : base(assetPath, path, subpath)
    {}

    public IEnumerator<AssetItem> GetEnumerator()
    {
        yield return this;
        if(Material is not null)
            yield return Material;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}



