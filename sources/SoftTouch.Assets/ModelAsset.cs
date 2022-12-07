using System;
using System.Collections.Generic;
using System.IO;
using SoftTouch.Rendering.Renderables;
using WGPU.NET;
using Zio;

namespace SoftTouch.Assets;

public class ModelAsset : IAsset<ModelAsset>
{
    public readonly List<MeshDraw> Meshes = new();
    public readonly List<VertexBufferLayout> Layouts = new();

    public static ModelAsset Load(in UPath path, IFileSystem fs)
    {
        Importers.MeshImporter.LoadGltf(path, fs, out var model);
        return model;
    }

    public static void Unload(ModelAsset asset)
    {
        foreach(var m in asset.Meshes)
        {
            // m.VertexBuffer.DestroyResource();
            // m.IndexBuffer.DestroyResource();
            // m.VertexBuffer.FreeHandle();
            // m.IndexBuffer.FreeHandle();
        }
    }

    public void Unload()
    {
        Unload(this);
    }
}



