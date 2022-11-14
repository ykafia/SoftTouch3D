using Zio;

namespace SoftTouch.Assets;

public class ShaderAsset : IAsset<ShaderAsset>
{
    public required string Code {get; init;}
    public static ShaderAsset Load(in UPath path, IFileSystem fs)
    {
        if(fs.FileExists(path) && path.GetExtensionWithDot() == "wgsl")
            return new ShaderAsset{ Code = fs.ReadAllText(path)};
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