using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SoftTouch.Core.Assets;
using SoftTouch.Graphics.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zio;

namespace SoftTouch.Assets.Importers;

public class ImageImporter : IAssetImporter<TextureAsset>
{
    static readonly string[] extensions = { ".png" };
    public string[] Extensions => extensions;

    public AssetManager AssetManager => AssetManager.GetOrCreate();

    public void Import(string path, string outputPath, out TextureAsset asset)
    {
        asset = new(path, outputPath);
    }
}
