using SoftTouch.Graphics.WGPU;
using WGPU.NET;
using Zio;

namespace SoftTouch.Assets;

public class ShaderAsset : IGraphicsAsset<ShaderAsset>
{
    public required ShaderModule Module {get; init;}
    public static ShaderAsset Load(in UPath path, IFileSystem fs, WGPUGraphics graphics)
    {
        if(fs.FileExists(path) && path.GetExtensionWithDot() == "wgsl")
            return new ShaderAsset{ Module = graphics.Device.CreateWgslShaderModule("shader",fs.ReadAllText(path))};
        else
            throw new System.Exception("Not a wgsl file");
    }

    public static void Unload(ShaderAsset asset)
    {
        //throw new System.NotImplementedException();
    }

    public void Unload()
    {
        //throw new System.NotImplementedException();
    }
}