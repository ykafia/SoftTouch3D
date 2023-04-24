namespace SoftTouch.Core.Assets;

public interface IAssetItem
{
    public abstract string Extension { get; }

    public Guid ID { get; init; }

    public string AssetPath { get; init; }

    public string? Name { get; }

}


public interface IAssetData<T> : IAssetItem
{
    public T data { get; set; }
}
 
public interface IAssetResource : IAssetItem
{
    public string Path { get; init; }
}