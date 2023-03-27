using SoftTouch.Core.Assets;
using Zio;

namespace SoftTouch.Assets.Importers;


public abstract class AssetImporter
{
    public abstract string[] Extensions {get;}
    public abstract IEnumerable<IAssetItem> Import(string assetPath, string path);
}

public abstract class AssetImporter<T> : AssetImporter
    where T : IAssetItem
{
    public abstract T ImportAsset(string assetPath, string path);
    public override IEnumerable<IAssetItem> Import(string assetPath, string subpath)
    {
        yield return ImportAsset(assetPath, subpath);
    }
}
public abstract class MultiAssetImporter<T> : AssetImporter
    where T : IEnumerable<IAssetItem>
{
    public abstract T ImportAsset(string assetPath, string path);
    public override IEnumerable<IAssetItem> Import(string assetPath, string subpath)
    {
        return ImportAsset(assetPath, subpath);
    }
}