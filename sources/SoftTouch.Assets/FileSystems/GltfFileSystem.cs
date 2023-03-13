using System;
using System.Diagnostics;
using System.Collections.Generic;
using SharpGLTF.Schema2;
using Zio;
using Zio.FileSystems;
using System.Diagnostics.CodeAnalysis;

namespace SoftTouch.Assets.FileSystems;
public class GltfFileSystem : ICompositeAssetFileSystem<GltfFileSystem, Mesh, Image, Material>
{
    static string[] folders = { "meshes", "textures", "materials", "animations" };
    static readonly string[] extensions = { ".gltf", ".glb" };
    public string[] Extensions => extensions;

    public IFileSystem Parent {get; init;}

    public UPath FilePath { get; init; }
    public UPath FullPath => Parent.ConvertPathToInternal(FilePath);

    ModelRoot Root;

    public static GltfFileSystem Create(IFileSystem parent, UPath assetPath)
    {
        return new GltfFileSystem(parent,assetPath);
    }

    public GltfFileSystem([NotNull]IFileSystem parent, UPath filePath)
    {
        FilePath = filePath;
        Parent = parent;
        Root = SharpGLTF.Schema2.ModelRoot.Load(parent.ConvertPathToInternal(filePath));
    }

    public Mesh? GetMesh(UPath path)
    {
        if(path.Split()[^2] != "meshes")
            return null;
        var meshPath = EnumeratePaths(path.GetDirectory(),path.GetName(),SearchOption.AllDirectories,SearchTarget.File).FirstOrDefault();
        if(meshPath.IsNull)
            return null;
        return Root.LogicalMeshes.First(x => x.Name == meshPath.GetName() || x.LogicalIndex.ToString() == meshPath.GetName());
    }

    public Material? GetMaterial(UPath path)
    {
        if(path.Split()[^2] != "materials")
            return null;
        var meshPath = EnumeratePaths(path.GetDirectory(),path.GetName(),SearchOption.AllDirectories,SearchTarget.File).FirstOrDefault();
        if(meshPath.IsNull)
            return null;
        return Root.LogicalMaterials.First(x => x.Name == meshPath.GetName() || x.LogicalIndex.ToString() == meshPath.GetName());
    }

    public Image? GetImage(UPath path)
    {
        if(path.Split()[^2] != "images")
            return null;
        var meshPath = EnumeratePaths(path.GetDirectory(),path.GetName(),SearchOption.AllDirectories,SearchTarget.File).FirstOrDefault();
        if(meshPath.IsNull)
            return null;
        return Root.LogicalImages.First(x => x.Name == meshPath.GetName() || x.LogicalIndex.ToString() == meshPath.GetName());
    }

    public void CreateDirectory(UPath path)
    {
        throw new NotSupportedException();
    }

    public bool DirectoryExists(UPath path)
    {
        return path.Split().Count == 1 && folders.Contains(path.GetName());
    }



    public IEnumerable<UPath> EnumeratePaths(UPath path, string searchPattern, SearchOption searchOption, SearchTarget searchTarget)
    {
        var pattern = SearchPattern.Parse(ref path, ref searchPattern);

        var fd = folders.Select(x => new UPath(x).ToAbsolute());

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

    public IEnumerable<FileSystemItem> EnumerateItems(UPath path, SearchOption searchOption, SearchPredicate? searchPredicate = null)
    {
        return
            EnumeratePaths(path, "*", searchOption, SearchTarget.File)
            .Select(x => new FileSystemItem(this, path, false));
    }
    public UPath ConvertPathFromInternal(string systemPath)
    {
        throw new NotImplementedException();
    }

    public void MoveDirectory(UPath srcPath, UPath destPath)
    {
        throw new NotSupportedException();
    }

    public void DeleteDirectory(UPath path, bool isRecursive)
    {
        throw new NotSupportedException();
    }

    public void CopyFile(UPath srcPath, UPath destPath, bool overwrite)
    {
        throw new NotSupportedException();
    }

    public void ReplaceFile(UPath srcPath, UPath destPath, UPath destBackupPath, bool ignoreMetadataErrors)
    {
        throw new NotSupportedException();
    }

    public long GetFileLength(UPath path)
    {
        throw new NotImplementedException();
    }

    public bool FileExists(UPath path)
    {
        throw new NotImplementedException();
    }

    public void MoveFile(UPath srcPath, UPath destPath)
    {
        throw new NotSupportedException();
    }

    public void DeleteFile(UPath path)
    {
        throw new NotSupportedException();
    }

    public Stream OpenFile(UPath path, FileMode mode, FileAccess access, FileShare share = FileShare.None)
    {
        throw new NotImplementedException();
    }

    public FileAttributes GetAttributes(UPath path)
    {
        throw new NotSupportedException();
    }

    public void SetAttributes(UPath path, FileAttributes attributes)
    {
        throw new NotSupportedException();
    }

    public DateTime GetCreationTime(UPath path)
    {
        throw new NotSupportedException();
    }

    public void SetCreationTime(UPath path, DateTime time)
    {
        throw new NotSupportedException();
    }

    public DateTime GetLastAccessTime(UPath path)
    {
        throw new NotSupportedException();
    }

    public void SetLastAccessTime(UPath path, DateTime time)
    {
        throw new NotSupportedException();
    }

    public DateTime GetLastWriteTime(UPath path)
    {
        throw new NotSupportedException();
    }

    public void SetLastWriteTime(UPath path, DateTime time)
    {
        throw new NotSupportedException();
    }

    public bool CanWatch(UPath _) => false;

    public IFileSystemWatcher Watch(UPath path)
    {
        throw new NotImplementedException();
    }

    public string ConvertPathToInternal(UPath path)
    {
        throw new NotImplementedException();
    }



    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
