using MemoryPack;
using SoftTouch.Graphics;
using VYaml.Annotations;
using Zio;

namespace SoftTouch.Assets;

[YamlObject]
public partial class ShaderAsset : AssetItem
{
    public override string Extension { get; init; } = "sdsl";

    public ShaderAsset() { }

    [YamlConstructor]
    public ShaderAsset(string assetPath, string path, string subpath) : base(assetPath, path,subpath)
    {
    }
    // public required string Module {get; init;}
    // public static ShaderAsset Load(in string path, IFileSystem fs)
    // {
    //     if(fs.FileExists(path) && path.GetExtensionWithDot() == ".wgsl")
    //         return new ShaderAsset{ Module = fs.ReadAllText(path)};
    //     else
    //         throw new Exception("Not a wgsl file");
    // }

    // public void Load(WGPUGraphics gfx)
    // {
    //     throw new NotImplementedException();
    // }

    // public void Unload()
    // {
    //     throw new NotImplementedException();
    // }
    
}