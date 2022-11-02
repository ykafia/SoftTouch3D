using System;
using System.Collections.Generic;
using SoftTouch.Graphics.WGPU;
using WGPU.NET;

namespace SoftTouch.Rendering;


public class RenderGraph
{
    SortedList<string, RenderPass> passes;
    SortedList<string, Source> globalSources;
    WGPUGraphics Graphics {get;}

    public RenderGraph(WGPUGraphics graphics)
    {
        passes = new();
        Graphics = graphics;
    }

    public void AddPass(RenderPass pass)
    {
        foreach (var sink in pass.Sinks.Values)
        {
            if (globalSources.TryGetValue(sink.Name, out var gsource))
            {
                sink.Bind(gsource);
            }
            else
            {
                foreach (var p in passes.Values)
                {
                    if (p.Sources.TryGetValue(sink.Name, out var source))
                    {
                        sink.Bind(source);
                    }
                }
            }
        }
    }
}

public abstract class RenderPass
{
    public string Name { get; set; }
    public SortedList<string, Sink> Sinks { get; set; } = new(4);
    public SortedList<string, Source> Sources { get; set; } = new(4);

    public ShaderModule Module { get; set; }

    public RenderPass(string name)
    {
        Name = name;
    }

    public RenderPass(string name, ShaderModule module)
    {
        Name = name;
        Module = module;
    }

    public abstract void Execute();
    public abstract void Reset();
}