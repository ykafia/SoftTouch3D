using ECSharp;
using SoftTouch.Components;
using SoftTouch.Graphics.WGPU;
using System;
using System.Linq;
using System.Numerics;
using WGPU.NET;

namespace SoftTouch.Processors;

public class FoxMeshProcessor : Processor<Query<Transform, GlobalTransform, ModelComponent>, Query<Camera, GlobalTransform>>
{
    WGPU.NET.Buffer vertexBuffer;
    WGPU.NET.Buffer indexBuffer;
    WGPU.NET.Buffer uniformBuffer;
    Matrix4x4 WorldMatrix;
    WGPUGraphics graphics;

    public FoxMeshProcessor(WGPUGraphics graphics)
    {
        this.graphics = graphics;
    }

    public override void Update()
    {
        (var camera, var cameraPos) = query2.QueriedArchetypes.First()[0].Get<Camera, GlobalTransform>();
        (var pos, var worldPos, var model) = query1.QueriedArchetypes.First()[0].Get<Transform, GlobalTransform, ModelComponent>();
        cameraPos.ToMatrix(out var cameraWMat);
        worldPos.ToMatrix(out var meshWMat);

        if (vertexBuffer == null && indexBuffer == null)
        {
            vertexBuffer = graphics.Device.CreateBuffer("foxMesh", true, (ulong)model.Primitives[0].Vertices.Length, Wgpu.BufferUsage.Vertex);
            {
                // Fill the vertex buffer
                Span<byte> mapped = vertexBuffer.GetMappedRange<byte>(0, model.Primitives[0].Vertices.Length);
                model.Primitives[0].Vertices.CopyTo(mapped);
                vertexBuffer.Unmap();
            }

            indexBuffer = graphics.Device.CreateBuffer("foxMesh", true, (ulong)model.Primitives[0].Indices.Length * sizeof(uint), Wgpu.BufferUsage.Index);
            {
                // Fill the vertex buffer
                Span<uint> mapped = indexBuffer.GetMappedRange<uint>(0, model.Primitives[0].Indices.Length);
                model.Primitives[0].Indices.CopyTo(mapped);
                indexBuffer.Unmap();
            }

            var uniformBufferData = new UniformBuffer
            {
                Transform = meshWMat
            };
            unsafe
            {
                uniformBuffer = graphics.Device.CreateBuffer("UniformBuffer", false, (ulong)sizeof(UniformBuffer), Wgpu.BufferUsage.Uniform | Wgpu.BufferUsage.CopyDst);
            }

        }

    }
}