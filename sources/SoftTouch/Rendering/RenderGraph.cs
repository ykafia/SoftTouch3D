using System;
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

    public void AddEdge(RenderNode origin, RenderNode destination)
    {
        if (nodes.TryGetValue(origin, out var destinations))
        {
            if (destinations is null)
                destinations = new();
            destinations.Add(destination);
        }
        else
            nodes.Add(origin,new(){destination});
    }
}

public abstract class RenderNode 
{
    public List<IGraphicResource> Inputs {get;set;}
    public ShaderModule Module {get;set;}
    public List<IGraphicResource> Outputs {get;set;}

    public abstract void Execute();
    public abstract void Reset();
    

}

public class GraphicsNode : RenderNode
{
    public VertexState VertexState {get;set;}
    public FragmentState FragmentState {get;set;}

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }

    public override void Reset()
    {
        throw new NotImplementedException();
    }
}
public class ComputeNode : RenderNode
{
    public override void Execute()
    {
        throw new NotImplementedException();
    }

    public override void Reset()
    {
        throw new NotImplementedException();
    }
}