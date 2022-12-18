using System;
using System.Collections.Generic;
using System.IO;
using SoftTouch.Rendering.Materials;
using SoftTouch.Rendering.Renderables;
using WGPU.NET;
using Zio;

namespace SoftTouch.Assets;

public class ModelAsset : IAsset<ModelAsset>
{
    public readonly List<MeshDraw> Meshes = new();
    public readonly List<VertexBufferLayout> Layouts = new();
    public MaterialAsset? Material;

    public UPath Path { get; set;}
    public string Name { get; set;}

    public static ModelAsset Load(in UPath path, IFileSystem fs)
    {
        Importers.GLTF.MeshImporter.LoadGltf(path, fs, out var model);
        return model;
    }

    public static void Unload(ModelAsset asset)
    {
        foreach(var m in asset.Meshes)
        {
            m.VertexBufferBinding.VertexBuffer.DestroyResource();
            m.IndexBufferBinding?.IndexBuffer.DestroyResource();
            m.VertexBufferBinding.VertexBuffer.FreeHandle();
            m.IndexBufferBinding?.IndexBuffer.FreeHandle();
        }
    }

    public void Unload()
    {
        Unload(this);
    }
}



