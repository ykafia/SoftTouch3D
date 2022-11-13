using System;
using ECSharp;
using SoftTouch.Assets;
using SoftTouch.Components;
using SoftTouch.Graphics.WGPU;
using SoftTouch.Util;

namespace SoftTouch.Processors;


public class Startup : Processor
{
    public override void Update()
    {
        // GltfLoader.LoadGltf("../../assets/models/Fox.glb", out var model);
        var graphics = World.GetResource<WGPUGraphics>();
        var model = World.GetResource<AssetManager>().Load<ModelAsset>("/models/fox.glb", graphics);
        World.CreateEntity()
            .With(new ModelComponent((ModelAsset)model))
            .WithBundle(new TransformBundle(default, default));
        World.CreateEntity()
            .With(default(Camera)); 
    }
}