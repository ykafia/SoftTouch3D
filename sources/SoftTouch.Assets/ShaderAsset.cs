using MemoryPack;
using SoftTouch.Graphics.WebGPU;
using Zio;

namespace SoftTouch.Assets;

[MemoryPackable]
public partial class ShaderAsset : AssetItem
{
    public override string Extension { get; init; } = "sdsl";

    [MemoryPackConstructor]
    public ShaderAsset() { }

    public ShaderAsset(UPath path, UPath subpath) : base(path,subpath)
    {
    }
    // public required string Module {get; init;}
    // public static ShaderAsset Load(in UPath path, IFileSystem fs)
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