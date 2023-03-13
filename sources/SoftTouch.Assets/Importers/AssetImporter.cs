using Zio;

namespace SoftTouch.Assets.Importers;


public abstract class AssetImporter
{
    public abstract string[] Extensions {get;}
    public abstract IEnumerable<AssetItem> Import(string assetPath, string path);
}

public abstract class AssetImporter<T> : AssetImporter
    where T : AssetItem
{
    public abstract T ImportAsset(string assetPath, string path);
    public override IEnumerable<AssetItem> Import(string assetPath, string subpath)
    {
        yield return ImportAsset(assetPath, subpath);
    }
}
public abstract class MultiAssetImporter<T> : AssetImporter
    where T : IEnumerable<AssetItem>
{
    public abstract T ImportAsset(string assetPath, string path);
    public override IEnumerable<AssetItem> Import(string assetPath, string subpath)
    {
        return ImportAsset(assetPath, subpath);
    }
}