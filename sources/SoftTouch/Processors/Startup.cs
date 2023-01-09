using System;
using SoftTouch.ECS;
using SoftTouch.Assets;
using SoftTouch.Components;
using SoftTouch.Graphics.WebGPU;
using SoftTouch.Assets.Importers;

namespace SoftTouch.Processors;


public class Startup : Processor
{
    public override void Update()
    {
        // GltfLoader.LoadGltf("../../assets/models/Fox.glb", out var model);
        // var graphics = World.GetResource<WGPUGraphics>();
        // var model = World.GetResource<AssetManager>().Load<ModelAsset>("/models/fox.glb");
        // World.CreateEntity()
        //     .With(new ModelComponent((ModelAsset)model))
        //     .WithBundle(new TransformBundle(default, default));
        World.CreateEntity()
            .With(default(Camera));
        World.Add<FoxMeshProcessor>();
    }

    
}