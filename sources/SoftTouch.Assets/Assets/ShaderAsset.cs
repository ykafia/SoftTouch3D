using MemoryPack;
using SoftTouch.Graphics;
using VYaml.Annotations;
using Zio;

namespace SoftTouch.Assets;

[YamlObject]
public partial class ShaderAsset : IAssetItem
{
    public string Extension { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Guid ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string AssetPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Path { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    [YamlIgnore]
    public string? Name => throw new NotImplementedException();
}