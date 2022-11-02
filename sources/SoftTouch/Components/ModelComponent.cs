using WGPU.NET;
using System.Linq;
using System.Collections.Generic;
using SoftTouch.Assets;

namespace SoftTouch.Components;

public readonly struct ModelComponent
{
    readonly Model model;
    public readonly List<MeshPrimitive> Primitives => model.Primitives;
    public readonly List<VertexBufferLayout> Layouts => model.Layouts;

    public ModelComponent(Model model)
    {
        this.model = model;
    }

    
}