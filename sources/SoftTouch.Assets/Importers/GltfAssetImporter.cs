using SoftTouch.Core.Assets;
using SoftTouch.Graphics.Assets;
using SoftTouch.Rendering.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Assets.Importers;

public class GLTFImporter : IAssetImporter<MaterialAsset>, IAssetImporter<TextureAsset>, IAssetImporter<ModelAsset>
{
    public string[] Extensions => throw new NotImplementedException();

    public AssetManager AssetManager => throw new NotImplementedException();

    public void Import(string path, string outputPath, out TextureAsset asset)
    {
        asset = new(path, outputPath);
    }

    public void Import(string path, string outputPath, out MaterialAsset asset)
    {
        throw new NotImplementedException();
    }

    public void Import(string path, string outputPath, out ModelAsset asset)
    {
        throw new NotImplementedException();
    }
}