using ECSharp;
using SoftTouch.Components;

namespace SoftTouch.Processors;

public class MeshProcessor : Processor<Query<Transform, GlobalTransform,ModelComponent>>
{
    public override void Update()
    {
        foreach(var arch in query1.QueriedArchetypes)
        {
            // Generate render node ?
        }
    }
}