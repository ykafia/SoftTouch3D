using System.Collections.Generic;
using System.Linq;
using ECSharp;
using SoftTouch.Processors;

namespace SoftTouch.Rendering;

public class GameWorld : World
{
    public List<RenderProcessor> Renderers = new();
    public ArchetypeList RenderStorage = new();

    public override void Update()
    {
        var timer = GetResource<WorldTimer>();
        timer.Start();
        base.Update();
        ComputeVisibility();
        timer.StopAndUpdate();
    }
    
    public void Render()
    {
        foreach(var r in Renderers)
        {
            r.Update();
        }
    }
    public void Extract()
    {
        // extract + convert
    }
    public void ComputeVisibility()
    {
        // Compute visibility of each 
    }
}