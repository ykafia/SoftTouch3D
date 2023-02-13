using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zio;

namespace SoftTouch.Assets.Importers;

public class ImageImporter : AssetImporter<ImageAsset>
{
    static readonly string[] extensions = { ".png" };
    public override string[] Extensions => extensions;

    public override ImageAsset ImportAsset(UPath assetPath, UPath path)
    {
        return new ImageAsset(assetPath, path,UPath.Empty);
    }
}
