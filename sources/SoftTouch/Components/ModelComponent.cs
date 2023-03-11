using SoftTouch.Graphics.SilkWrappers;
using System.Linq;
using System.Collections.Generic;
using SoftTouch.Assets;
using SoftTouch.Rendering.Renderables;

namespace SoftTouch.Components;

public readonly struct ModelComponent
{
    // public ModelAsset Model {get;}
    public readonly List<MeshDraw> Meshes;// => Model.Meshes;
    public readonly List<Silk.NET.WebGPU.VertexBufferLayout> Layouts;// => Model.Layouts;

    // public ModelComponent(ModelAsset model)
    // {
    //     Model = model;
    // }

    
}