using System;
using ECSharp;
using SoftTouch.Components;
using SoftTouch.Util;

namespace SoftTouch.Processors;


public class Startup : Processor
{
    public override void Update()
    {
        GltfLoader.LoadGltf("../../assets/models/Fox.glb", out var model);
        World.CreateEntity()
            .With(model)
            .WithBundle(new TransformBundle(default, default));
        World.CreateEntity()
            .With(default(Camera));

        World.Add(
            new SimpleProcessor<GlobalTransform,ModelComponent>()
            {
                Updater = (World w, ref GlobalTransform t, ref ModelComponent m) => 
                {
                    t.Position.Y = (float)Math.Sin(w.GetResource<WorldTimer>().Elapsed.TotalSeconds);
                }
            }
        );
        
    }
}