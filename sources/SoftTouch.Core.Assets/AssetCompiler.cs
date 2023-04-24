using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoryPack;

namespace SoftTouch.Core.Assets;

public abstract class AssetCompiler
{
    static Dictionary<Type, AssetCompiler> compilers = new();

    public static void Register<TAsset>(AssetCompiler<TAsset> compiler)
        where TAsset : IAssetItem
    {
        compilers.Add(typeof(TAsset), compiler);
    }

    public static byte[] Compile<TAsset>(TAsset asset)
        where TAsset : IAssetItem
    {
        return ((AssetCompiler<TAsset>)compilers[typeof(TAsset)]).Compile(asset);
    }

}
public abstract class AssetCompiler<TAsset> : AssetCompiler
    where TAsset : IAssetItem
{
    public abstract byte[] Compile(TAsset asset);

}

public abstract class AssetCompiler<TAsset,TData> : AssetCompiler<TAsset>
    where TAsset : IAssetItem
{
    public byte[] Serialize(in TData data)
    {
        return MemoryPackSerializer.Serialize(data);
    }
}