using SoftTouch.Assets.FileSystems;
using Zio;

namespace SoftTouch.Assets.Importers.GLTF;

public partial class GLTFModelImporter : AssetImporter<ModelAsset>
{
    static readonly string[] extensions = {".gltf",".glb"};
    public override string[] Extensions => extensions;

    public override ModelAsset ImportAsset(UPath path, AssetManager assetManager)
    {
        var fs = 
            assetManager
            .FileSystem
            .GetFileSystems()
            .OfType<GltfFileSystem>()
            .First(x => path.IsInDirectory(x.SubPath,true));
        
        var realPath = (UPath)((string)path).Split(fs.FileName)[1];

        return Convert(fs.GetMesh(realPath));
    }
}