using MemoryPack;
using SoftTouch.Core.Assets;
using SoftTouch.Core.Serialization;
using SoftTouch.Graphics;
using VYaml.Annotations;
using Zio;

namespace SoftTouch.Assets;

[YamlObject]
public partial class ShaderAsset : IAssetItem
{
    [YamlIgnore]
    public string Extension => throw new NotImplementedException();

    public Guid ID { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
    public string AssetPath { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
    public string Path { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
    [YamlIgnore]
    public string? Name => throw new NotImplementedException();
}