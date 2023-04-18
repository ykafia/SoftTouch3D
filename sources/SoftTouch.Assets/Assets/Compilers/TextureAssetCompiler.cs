using SoftTouch.Core.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;

namespace SoftTouch.Assets.Assets.Compilers;

public class TextureAssetCompiler : AssetCompiler<TextureAsset>
{
    public override byte[] Compile(TextureAsset asset)
    {
        var manager = AssetManager.GetOrCreate();
        var realPath = manager.ResourceFileSystem.ConvertPathToInternal(asset.Path);
        var image = Image.Load(realPath);

        throw new NotImplementedException();
    }
}
