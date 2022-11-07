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
    }
}