using System;
using System.Diagnostics;
using System.Collections.Generic;
using SharpGLTF.Schema2;
using Zio;
using Zio.FileSystems;
using System.Diagnostics.CodeAnalysis;

namespace SoftTouch.Assets.FileSystems;
public class GltfFileSystem : CompositeAssetFileSystem<Mesh, Image, Material>
{
    static readonly string[] extensions = { ".gltf", ".glb" };
    public static string[] Extensions => extensions;
    public UPath FullPath => Parent.ConvertPathToInternal(FilePath);

    ModelRoot Root;

    public GltfFileSystem([NotNull]IFileSystem parent, UPath filePath) : base(parent,filePath)
    {
        Root = SharpGLTF.Schema2.ModelRoot.Load(parent.ConvertPathToInternal(filePath));
    }

    public override Mesh? GetMesh(UPath path)
    {
        if(path.Split()[^2] != "meshes")
            return null;
        var meshPath = EnumeratePaths(path.GetDirectory(),path.GetName(),SearchOption.AllDirectories,SearchTarget.File).FirstOrDefault();
        if(meshPath.IsNull)
            return null;
        return Root.LogicalMeshes.First(x => x.Name == meshPath.GetName() || x.LogicalIndex.ToString() == meshPath.GetName());
    }

    public override Material? GetMaterial(UPath path)
    {
        if(path.Split()[^2] != "materials")
            return null;
        var meshPath = EnumeratePaths(path.GetDirectory(),path.GetName(),SearchOption.AllDirectories,SearchTarget.File).FirstOrDefault();
        if(meshPath.IsNull)
            return null;
        return Root.LogicalMaterials.First(x => x.Name == meshPath.GetName() || x.LogicalIndex.ToString() == meshPath.GetName());
    }

    public override Image? GetImage(UPath path)
    {
        if(path.Split()[^2] != "images")
            return null;
        var meshPath = EnumeratePaths(path.GetDirectory(),path.GetName(),SearchOption.AllDirectories,SearchTarget.File).FirstOrDefault();
        if(meshPath.IsNull)
            return null;
        return Root.LogicalImages.First(x => x.Name == meshPath.GetName() || x.LogicalIndex.ToString() == meshPath.GetName());
    }


    public override bool DirectoryExists(UPath path)
    {
        return 
            EnumeratePaths("/","*",SearchOption.AllDirectories,SearchTarget.Directory)
            .Any(x => x == path);  
    }

    public override IEnumerable<UPath> EnumeratePaths(UPath path, string searchPattern, SearchOption searchOption, SearchTarget searchTarget)
    {
        var pattern = SearchPattern.Parse(ref path, ref searchPattern);

        var fd = Folders.Select(x => new UPath(x).ToAbsolute());

        var meshes = Root.LogicalMeshes.Select(
            x => FilePath / "meshes" / (x.Name ?? x.LogicalIndex.ToString())
        );
        var materials = Root.LogicalMaterials.Select(
            x => FilePath / "materials" / (x.Name ?? x.LogicalIndex.ToString())
        );
        var textures = Root.LogicalTextures.Select(
            x => FilePath / "textures" / (x.Name ?? x.LogicalIndex.ToString())
        );
        var animations = Root.LogicalAnimations.Select(
            x => FilePath / "animations" / (x.Name ?? x.LogicalIndex.ToString())
        );
        var all =
            meshes
            .Concat(materials)
            .Concat(textures)
            .Concat(animations);

        var toCheck =
            searchTarget switch
            {
                SearchTarget.Directory => fd,
                SearchTarget.File => all,
                SearchTarget.Both => fd.Concat(all),
                _ => throw new NotImplementedException()
            };


        return toCheck.Where(x => pattern.Match(x));
    }

    public override IEnumerable<FileSystemItem> EnumerateItems(UPath path, SearchOption searchOption, SearchPredicate? searchPredicate = null)
    {
        return
            EnumeratePaths(path, "*", searchOption, SearchTarget.File)
            .Select(x => new FileSystemItem(this, path, false));
    }
}
