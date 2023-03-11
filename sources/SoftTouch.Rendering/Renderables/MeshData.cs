using System.Collections.Generic;
using Silk.NET.WebGPU;

namespace SoftTouch.Graphics;


public readonly struct MeshData
{
    public uint[]? Indices { get; init; }
    public byte[] Vertices { get; init; }
    public ulong Stride { get; init; }
    public ulong Offset { get; init; }
    public PrimitiveTopology Topology { get; init; }
    public VertexBufferLayout Layout { get; init; }
    public ulong VertexCount { get; init; }

    public bool IsNonIndexed => Indices is null;


}
