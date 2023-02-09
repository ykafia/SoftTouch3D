using System.Collections.Generic;
using SoftTouch.Graphics.WebGPU;

namespace SoftTouch.Rendering;

public abstract class RenderPass
{
    public string Name { get; set; }
    public SortedList<string, Sink> Sinks { get; set; } = new(4);
    public SortedList<string, Source> Sources { get; set; } = new(4);


    public RenderPass(string name)
    {
        Name = name;
    }

    public virtual void RegisterSink(Sink sink)
    {
        Sinks.Add(sink.Name,sink);
    }
    public virtual void RegisterSource(Source source)
    {
        Sources.Add(source.Name,source);
    }

    public abstract void Execute();
    public abstract void Reset();
}