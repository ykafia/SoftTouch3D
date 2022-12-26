using Zio;

namespace SoftTouch.Assets.Importers;


public abstract class AssetImporter
{
    public abstract string[] Extensions {get;}
    public abstract IEnumerable<AssetItem> Import(UPath path);
}

public abstract class AssetImporter<T> : AssetImporter
    where T : AssetItem
{
    public abstract IEnumerable<T> ImportAsset(UPath path);
    public override IEnumerable<AssetItem> Import(UPath path)
    {
        return ImportAsset(path);
    }
}