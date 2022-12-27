using System.Runtime.Serialization;
using MemoryPack;
using Zio;

namespace SoftTouch.Assets;

[MemoryPackable]
public sealed partial class PackaginConfig
{
    [MemoryPackInclude]
    public List<string>? ResourcesFolders = new();
    
    [MemoryPackInclude]
    public List<string>? AssetsFolders = new();
    
    [MemoryPackInclude]
    public List<string>? ShadersFolders = new();


    public PackaginConfig()
    {
        
    }
    [MemoryPackConstructor]
    public PackaginConfig(List<string> resourcesFolders, List<string> assetsFolders, List<string> shadersFolders)
    {
        ResourcesFolders.AddRange(resourcesFolders);
        AssetsFolders.AddRange(assetsFolders);
        ShadersFolders.AddRange(shadersFolders);
    }
    public PackaginConfig(string resourcef, string assetf, string shaderf)
    {
        ResourcesFolders.Add(resourcef);
        AssetsFolders.Add(assetf);
        ShadersFolders.Add(shaderf);
    }
}