using System;
using SoftTouch.ECS;
using SoftTouch.Assets;
using SoftTouch.Components;
using SoftTouch.Graphics;
using SoftTouch.Assets.Importers;
using SoftTouch.ECS.Processors;

namespace SoftTouch.Processors;


public class Startup : Processor
{
    public override void Update()
    {
        // GltfLoader.LoadGltf("../../assets/models/Fox.glb", out var model);
        // var graphics = World.GetResource<WGPUGraphics>();
        // var model = World.GetResource<AssetManager>().Load<ModelAsset>("/models/fox.glb");
        // World.Spawn(
        //     .With(new ModelComponent((ModelAsset)model))
        //     .WithBundle(new TransformBundle(default, default));
        World.Commands.Spawn(default(Camera));
        World.AddProcessor<FoxMeshProcessor>();
    }

    
}