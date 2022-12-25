using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Zio;

namespace SoftTouch.Assets.Importers.GLTF;

public class GLTFImageImporter : AssetImporter<ImageAsset>
{
    static readonly string[] extensions = {".gltf",".glb"};
    public override string[] Extensions => extensions;

    public override ImageAsset ImportAsset(UPath path, AssetManager assetManager)
    {
        var image = Image.Load<Rgba32>(assetManager.FileSystem.OpenFile(path,FileMode.Open, FileAccess.Read));
        return new ImageAsset(image,new());
    }
}