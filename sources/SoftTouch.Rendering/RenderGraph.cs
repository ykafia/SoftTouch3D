using System;
using System.Collections.Generic;
using SoftTouch.Graphics;
using WGPU.NET;

namespace SoftTouch.Rendering;


public class RenderGraph
{
    SortedList<string, RenderPass> passes;
    SortedList<string, Source> globalSources;
    TrivaxyGraphicsState Graphics {get;}

    public RenderGraph(TrivaxyGraphicsState graphics)
    {
        passes = new();
        globalSources = new();
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
                        globalSources.Add(source.Name,source);
                        sink.Bind(source);
                    }
                }
            }
        }
    }
}

