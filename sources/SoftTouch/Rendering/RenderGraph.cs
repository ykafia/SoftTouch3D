using System.Collections.Generic;
using WGPU.NET;

namespace SoftTouch.Rendering;


public class RenderGraph
{
    readonly Dictionary<RenderNode, List<RenderNode>> nodes;

    public RenderGraph()
    {
        nodes = new();
    }

    public void AddEdge(RenderNode a, RenderNode b)
    {
        if (nodes.TryGetValue(a, out var links))
        {
            if (links is null)
                links = new();
            links.Add(b);
        }
        else
            nodes.Add(a,new(){b});
    }
}

public abstract class RenderNode 
{
    public List<IGraphicResource> Inputs {get;set;}
    public List<IGraphicResource> Outputs {get;set;}

}