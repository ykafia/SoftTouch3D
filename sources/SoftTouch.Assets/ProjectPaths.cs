using System.Runtime.Serialization;
using MemoryPack;
using Zio;

namespace SoftTouch.Assets;

[MemoryPackable]
public sealed partial class ProjectPaths
{
    [MemoryPackInclude]
    public List<string> ResourcesFolders = new();
    
    [MemoryPackInclude]
    public List<string> AssetsFolders = new();
    
    [MemoryPackInclude]
    public List<string> ShadersFolders = new();


    public ProjectPaths()
    {
        
    }
    [MemoryPackConstructor]
    public ProjectPaths(List<string> resourcesFolders, List<string> assetsFolders, List<string> shadersFolders)
    {
        ResourcesFolders.AddRange(resourcesFolders);
        AssetsFolders.AddRange(assetsFolders);
        ShadersFolders.AddRange(shadersFolders);
    }
    public ProjectPaths(string resourcef, string assetf, string shaderf)
    {
        ResourcesFolders.Add(resourcef);
        AssetsFolders.Add(assetf);
        ShadersFolders.Add(shaderf);
    }
}