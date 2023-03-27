using SoftTouch.Core.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Assets.Importers;

public interface IAssetImporter
{
    AssetManager AssetManager { get; }
}

public interface IAssetImporter<TAsset> : IAssetImporter
    where TAsset : IAssetItem
{
    void Import(string path, string name, out TAsset asset);
}


public class GLTFImporter : IAssetImporter<ImageAsset>, IAssetImporter<MaterialAsset>
{
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