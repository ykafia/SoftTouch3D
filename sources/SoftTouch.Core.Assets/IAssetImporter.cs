using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Core.Assets;

public interface IAssetImporter
{
    public string[] Extensions { get; }
    AssetManager AssetManager { get; }
}

public interface IAssetImporter<TAsset> : IAssetImporter
    where TAsset : IAssetItem
{
    void Import(string path, string name, out TAsset asset);
}
