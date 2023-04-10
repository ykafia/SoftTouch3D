using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VYaml;
using VYaml.Annotations;

namespace SoftTouch.Core.Assets;

[YamlObject]
public partial struct AssetReference
{
    public Guid ID { get; set; }

    public TAsset Get<TAsset>() => (TAsset)AssetManager.GetOrCreate().LoadedAssets[ID];
}


[YamlObject]
public partial struct AssetReference<TAsset>
    where TAsset : IAssetItem
{
    public Guid ID { get; set; }

    [YamlIgnore]
    public TAsset Asset => (TAsset)AssetManager.GetOrCreate().LoadedAssets[ID];
}
