using MemoryPack;
using SoftTouch.Rendering.Materials.Futures;

namespace SoftTouch.Rendering.Materials;

public class Material
{
    public IMaterialDiffuseFeature DiffuseMap { get; set; }

    public Material(IMaterialDiffuseFeature diffuseMap)
    {
        DiffuseMap = diffuseMap;
    }
}