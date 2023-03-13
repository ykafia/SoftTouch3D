using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Zio;

namespace SoftTouch.Assets.Importers.GLTF;

public class GLTFImageImporter : AssetImporter<ImageAsset>
{
    static readonly string[] extensions = {".gltf",".glb"};
    public override string[] Extensions => extensions;
    public override ImageAsset ImportAsset(string assetPath, string subpath)
    {
        return null;   
    }
}