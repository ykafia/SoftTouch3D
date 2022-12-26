using System.Runtime.Serialization;
using MessagePack;
using Zio;

namespace SoftTouch.Assets;

[MessagePackObject]
public sealed class PackaginConfig
{
    [Key(0)]
    public List<string>? ResourcesFolders = new();
    
    [Key(1)]
    public List<string>? AssetsFolders = new();
    
    [Key(2)]
    public List<string>? ShadersFolders = new();

    public PackaginConfig()
    {
        
    }
    public PackaginConfig(string resourcef, string assetf, string shaderf)
    {
        ResourcesFolders.Add(resourcef);
        AssetsFolders.Add(assetf);
        ShadersFolders.Add(shaderf);
    }
}