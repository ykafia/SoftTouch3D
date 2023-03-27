namespace SoftTouch.Core.Assets;


public partial interface IAssetItem
{
    public abstract string Extension { get; }

    public Guid ID { get; init; }

    public string AssetPath { get; init; }

    public string Path { get; init; }
    public string? Name { get; }

}