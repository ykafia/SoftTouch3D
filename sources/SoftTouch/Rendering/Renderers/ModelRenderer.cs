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
        Sinks.Add("fox_swapchain", new DirectTextureSink{Name = "fox_swapchain", PassName = Name, OutputName = "swapchain"});
        Sources.Add("fox_swapchain_out", new DirectTextureSource{Name = "fox_swapchain_out"});
    }

    public FoxRenderer(string name) : base(name){}
    public FoxRenderer(string name, ShaderModule module) : base(name, module){}

    public override void Execute()
    {
        throw new NotImplementedException();
    }

    public override void Reset()
    {
        throw new NotImplementedException();
    }
}