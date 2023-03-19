using SoftTouch.Assets.FileSystems;
using Zio;

namespace SoftTouch.Assets.Importers.GLTF;

public partial class GLTFModelImporter : MultiAssetImporter<ModelAsset>
{
    static readonly string[] extensions = {".gltf",".glb"};
    public override string[] Extensions => extensions;

    public override ModelAsset ImportAsset(string assetPath, string path)
    {
        return new ModelAsset(assetPath,path);
    }
}