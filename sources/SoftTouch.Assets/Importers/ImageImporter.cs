using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SoftTouch.Core.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zio;

namespace SoftTouch.Assets.Importers;

public class ImageImporter : IAssetImporter<ImageAsset>
{
    static readonly string[] extensions = { ".png" };
    public string[] Extensions => extensions;

    public AssetManager AssetManager => AssetManager.GetOrCreate();

    public void Import(string path, string name, out ImageAsset asset)
    {
        var image = Image.Load(path);
    }
}
