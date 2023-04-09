using System;
using System.Diagnostics;
using System.Collections.Generic;
using SharpGLTF.Schema2;
using Zio;
using Zio.FileSystems;
using System.Diagnostics.CodeAnalysis;
using SoftTouch.Core.Assets;

namespace SoftTouch.Assets.FileSystems;
public class GltfAssetReader : CompositeAssetReader
{
    static readonly string[] extensions = { ".gltf", ".glb" };
    public override string[] Extensions => extensions;
    
    ModelRoot Root;

    public GltfAssetReader([NotNull]IFileSystem fs, UPath filePath) : base(fs,filePath)
    {
        Root = SharpGLTF.Schema2.ModelRoot.Load(fs.ConvertPathToInternal(filePath));
    }

    public override Mesh? GetMesh(string name)
    {
        return Root.LogicalMeshes.First(x => x.Name == name || x.LogicalIndex.ToString() == name);
    }

    public override Material? GetMaterial(string name)
    {
        return Root.LogicalMaterials.First(x => x.Name == name || x.LogicalIndex.ToString() == name);
    }

    public override Image? GetImage(string name)
    {
        return Root.LogicalImages.First(x => x.Name == name || x.LogicalIndex.ToString() == name);
    }
}
