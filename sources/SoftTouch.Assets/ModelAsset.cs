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

namespace SoftTouch.Assets;

public class ModelAsset : IAsset, IEnumerable<IAsset>
{
    public readonly List<MeshDraw> Meshes = new();
    public readonly List<VertexBufferLayout> Layouts = new();
    public MaterialAsset Material;

    public IEnumerator<IAsset> GetEnumerator()
    {
        foreach(var a in Material)
            yield return a;
        yield return this;
    }

    public void Load(WGPUGraphics gfx)
    {
        throw new NotImplementedException();
    }

    public void Unload()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}



