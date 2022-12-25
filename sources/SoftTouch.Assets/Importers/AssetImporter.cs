using Zio;

namespace SoftTouch.Assets.Importers;


public abstract class AssetImporter
{
    public abstract string[] Extensions {get;}
    public abstract IAsset Import(UPath path, AssetManager assetManager);
}

public abstract class AssetImporter<T> : AssetImporter
    where T : class, IAsset
{
    public abstract T ImportAsset(UPath path, AssetManager assetManager);
    public override IAsset Import(UPath path, AssetManager assetManager)
    {
        return ImportAsset(path,assetManager);
    }
}