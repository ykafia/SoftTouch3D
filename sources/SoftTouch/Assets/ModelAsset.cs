using System.Collections.Generic;
using System.IO;
using WGPU.NET;
using Zio;

namespace SoftTouch.Assets;

public class ModelAsset : IAsset<ModelAsset>
{
    public readonly List<MeshPrimitive> Primitives = new();
    public readonly List<VertexBufferLayout> Layouts = new();

    public static ModelAsset Load(in UPath path, IFileSystem fs)
    {
        Util.GltfLoader.LoadGltf(path, fs, out var model);
        return model;
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
