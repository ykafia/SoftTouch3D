using Zio;

namespace SoftTouch.Assets.Importers;


public abstract class AssetImporter
{
    public abstract string[] Extensions {get;}
    public abstract IEnumerable<AssetItem> Import(UPath assetPath, UPath path);
}

public abstract class AssetImporter<T> : AssetImporter
    where T : AssetItem
{
    public abstract T ImportAsset(UPath assetPath, UPath path);
    public override IEnumerable<AssetItem> Import(UPath assetPath, UPath path)
    {
        yield return ImportAsset(assetPath, path);
    }
}
public abstract class MultiAssetImporter<T> : AssetImporter
    where T : IEnumerable<AssetItem>
{
    public abstract T ImportAsset(UPath assetPath, UPath path);
    public override IEnumerable<AssetItem> Import(UPath assetPath, UPath path)
    {
        return ImportAsset(assetPath, path);
    }
}