using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VYaml;
using VYaml.Annotations;
using VYaml.Emitter;
using VYaml.Parser;
using VYaml.Serialization;

namespace SoftTouch.Core.Assets;

[YamlObject]
public partial struct AssetReference
{
    public Guid ID { get; set; }

    public TAsset Get<TAsset>() => (TAsset)AssetManager.GetOrCreate().LoadedAssets[ID];
    public IAssetItem Get() => AssetManager.GetOrCreate().LoadedAssets[ID];
}