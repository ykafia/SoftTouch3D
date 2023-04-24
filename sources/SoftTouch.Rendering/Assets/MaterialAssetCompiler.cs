using SoftTouch.Core.Assets;
using SoftTouch.Rendering.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Rendering.Assets;

public class MaterialAssetCompiler : AssetCompiler<MaterialAsset, Material>
{
    public override byte[] Compile(MaterialAsset asset)
    {
        throw new NotImplementedException();
    }
}
