using System;
using WGPU.NET;
using SoftTouch.Rendering;

namespace SoftTouch.Rendering.Renderer;

public class FoxRenderer : RenderPass
{
    public VertexState VertexState {get;set;}
    public FragmentState FragmentState {get;set;}

    public FoxRenderer() : base("fox_renderpass")
    {
        Sinks.Add("swapchain", new DirectTextureSink{Name = "swapchain", PassName = Name});
        Sinks.Add("fox_diffuse", new DirectTextureSink{Name = "fox_diffuse", PassName = Name});
        Sources.Add("swapchain", new DirectTextureSource{Name = "swapchain"});
    }

    public FoxRenderer(string name) : base(name){}
    // public FoxRenderer(string name, ShaderModule module) : base(name, module){}

    public override void Execute()
    {
        throw new NotImplementedException();
    }

    public override void Reset()
    {
        throw new NotImplementedException();
    }
}