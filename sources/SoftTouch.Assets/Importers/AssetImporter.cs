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
    public abstract IEnumerable<T> ImportAsset(UPath assetPath, UPath path);
    public override IEnumerable<AssetItem> Import(UPath assetPath, UPath path)
    {
        return ImportAsset(assetPath, path);
    }
}