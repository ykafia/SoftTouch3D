using SoftTouch.Core.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Assets.Assets.Compilers;

public class TextureAssetCompiler : IAssetCompiler<ImageAsset>
{
    public byte[] Compile(ImageAsset asset)
    {
        return Array.Empty<byte>();
    }
}
