using System.Linq;
using ECSharp;

namespace SoftTouch.Rendering;

public class RenderWorld : World
{
    public void CopyFrom(World w)
    {
        Archetypes.Clear();
        foreach(var arch in w.Archetypes.Values)
        {
            var newArch = new Archetype(arch.Storage.Values.Select(x => x.Clone()), this);
            Archetypes[newArch.ID] = newArch;
        }
        // BuildGraph();
    }
}