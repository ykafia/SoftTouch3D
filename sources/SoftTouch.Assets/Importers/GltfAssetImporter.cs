using SoftTouch.Core.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Assets.Importers;

public class GLTFImporter : IAssetImporter<MaterialAsset>, IAssetImporter<ImageAsset>
{
    public string[] Extensions => throw new NotImplementedException();

    public AssetManager AssetManager => throw new NotImplementedException();

    public void Import(string path, string name, out ImageAsset asset)
    {
        throw new NotImplementedException();
    }

    public void Import(string path, string name, out MaterialAsset asset)
    {
        throw new NotImplementedException();
    }
}