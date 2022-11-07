using WGPU.NET;
using System.Linq;
using System.Collections.Generic;
using SoftTouch.Assets;

namespace SoftTouch.Components;

public readonly struct ModelComponent
{
    readonly ModelAsset model;
    public readonly List<MeshPrimitive> Primitives => model.Primitives;
    public readonly List<VertexBufferLayout> Layouts => model.Layouts;

    public ModelComponent(ModelAsset model)
    {
        this.model = model;
    }

    
}