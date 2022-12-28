using SoftTouch.Assets.FileSystems;
using Zio;

namespace SoftTouch.Assets.Importers.GLTF;

public partial class GLTFModelImporter : AssetImporter<ModelAsset>
{
    static readonly string[] extensions = {".gltf",".glb"};
    public override string[] Extensions => extensions;

    public override IEnumerable<ModelAsset> ImportAsset(UPath assetPath, UPath path)
    {
        yield return new ModelAsset(assetPath);
    }
}