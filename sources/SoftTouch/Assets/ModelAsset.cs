using System;
using System.Collections.Generic;
using System.IO;
using SoftTouch.Graphics.WGPU;
using WGPU.NET;
using Zio;

namespace SoftTouch.Assets;

public class ModelAsset : IGraphicsAsset<ModelAsset>
{
    public readonly List<MeshDraw> Meshes = new();
    public Texture Diffuse {get;set;}
    public Sampler Sampler {get;set;}
    public readonly List<VertexBufferLayout> Layouts = new();

    public static ModelAsset Load(in UPath path, IFileSystem fs, WGPUGraphics graphics)
    {
        Util.GltfLoader.LoadGltf(path, fs, graphics, out var model);
        return model;
    }

    public static void Unload(ModelAsset asset)
    {
        foreach(var m in asset.Meshes)
        {
            m.VertexBuffer.DestroyResource();
            m.IndexBuffer.DestroyResource();
            m.VertexBuffer.FreeHandle();
            m.IndexBuffer.FreeHandle();
        }
    }

    public void Unload()
    {
        Unload(this);
    }
}

public class MeshDraw
{
    public WGPU.NET.Buffer VertexBuffer {get;}
    public WGPU.NET.Buffer IndexBuffer {get;}
    // public Texture Diffuse {get;}

    public MeshDraw(MeshPrimitive primitive, WGPUGraphics graphics)
    {
        VertexBuffer = graphics.Device.CreateBuffer("VertexBuffer", true, (ulong)primitive.Vertices.Length, Wgpu.BufferUsage.Vertex);
        {
            // Fill the vertex buffer
            Span<byte> mapped = VertexBuffer.GetMappedRange<byte>(0, primitive.Vertices.Length);

            primitive.Vertices.CopyTo(mapped);

            VertexBuffer.Unmap();
        }
        IndexBuffer = graphics.Device.CreateBuffer("IndexBuffer", true, (ulong)(primitive.Indices.Length * sizeof(uint)), Wgpu.BufferUsage.Index);
        {
            // Fill the index buffer
            Span<uint> mapped = IndexBuffer.GetMappedRange<uint>(0, primitive.Indices.Length);

            primitive.Indices.CopyTo(mapped);

            IndexBuffer.Unmap();
        }
    }
}

public struct MeshPrimitive
{
    public uint[]? Indices;
    public byte[] Vertices;
    public Wgpu.PrimitiveTopology Topology;
    public List<string> LayoutOrder;
    public ulong VertexCount;

    public bool IsNonIndexed => Indices is null;
}
