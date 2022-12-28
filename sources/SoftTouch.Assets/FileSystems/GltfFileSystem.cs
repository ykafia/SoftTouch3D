using System;
using System.Diagnostics;
using System.Collections.Generic;
using SharpGLTF.Schema2;
using Zio;
using Zio.FileSystems;

namespace SoftTouch.Assets.FileSystems;
[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "(),nq}")]
public class GltfFileSystem : ComposeFileSystem, ICompositeAssetFileSystem<Mesh, Image, Material>
{
    static readonly string[] extensions = {".gltf", ".glb"};
    public string[] Extensions => extensions;
    ModelRoot Model;
    /// <summary>
    /// Gets the sub path relative to the delegate <see cref="ComposeFileSystem.Fallback"/>
    /// </summary>
    public UPath SubPath { get; }
    public string FileName { get; set; }


    // internal UPath FullSubPath => ((SubFileSystem)FallbackSafe).SubPath / SubPath;

    /// <summary>
    /// Initializes a new instance of the <see cref="GltfFileSystem"/> class.
    /// </summary>
    /// <param name="fileSystem">The file system to create a view from.</param>
    /// <param name="gltfPath">The sub path view to create filesystem.</param>
    /// <param name="owned">True if <paramref name="fileSystem"/> should be disposed when this instance is disposed.</param>
    /// <exception cref="DirectoryNotFoundException">If the directory subPath does not exist in the delegate FileSystem</exception>
    public GltfFileSystem(IFileSystem fileSystem, UPath gltfPath, bool owned = false) : base(fileSystem, owned)
    {
        SubPath = gltfPath.AssertAbsolute(nameof(gltfPath));
        FileName = gltfPath.GetName();
        if (!fileSystem.FileExists(SubPath))
        {
            throw new Exception("Cannot find file");
        }
        else
            Model = ModelRoot.Load(fileSystem.ConvertPathToInternal(SubPath));
    }



    protected override string DebuggerDisplay()
    {
        return $"{base.DebuggerDisplay()} Path: {SubPath}";
    }

    /// <inheritdoc />
    protected override IFileSystemWatcher WatchImpl(UPath path)
    {
        var delegateWatcher = base.WatchImpl(path);
        return new Watcher(this, path, delegateWatcher);
    }

    private class Watcher : WrapFileSystemWatcher
    {
        private readonly GltfFileSystem _fileSystem;

        public Watcher(GltfFileSystem fileSystem, UPath path, IFileSystemWatcher watcher)
            : base(fileSystem, path, watcher)
        {
            _fileSystem = fileSystem;
        }

        protected override UPath? TryConvertPath(UPath pathFromEvent)
        {
            if (!pathFromEvent.IsInDirectory(_fileSystem.SubPath, true))
            {
                return null;
            }

            return _fileSystem.ConvertPathFromDelegate(pathFromEvent);
        }
    }
    /// <inheritdoc />
    protected override UPath ConvertPathToDelegate(UPath path)
    {
        var safePath = path.ToRelative();
        if (FallbackSafe is SubFileSystem sfs)
        {
            var p = sfs.SubPath / SubPath.ToRelative();
            if (safePath != UPath.Root && safePath != UPath.Empty)
                p /= safePath;
            return p;
        }
        return SubPath / safePath;
    }

    /// <inheritdoc />
    protected override UPath ConvertPathFromDelegate(UPath path)
    {
        var fullPath = path.FullName;
        if (!fullPath.StartsWith(SubPath.FullName) || (fullPath.Length > SubPath.FullName.Length && fullPath[SubPath.FullName.Length] != UPath.DirectorySeparator))
        {
            // More a safe guard, as it should never happen, but if a delegate filesystem doesn't respect its root path
            // we are throwing an exception here
            throw new InvalidOperationException($"The path `{path}` returned by the delegate filesystem is not rooted to the subpath `{SubPath}`");
        }

        var subPath = fullPath[SubPath.FullName.Length..];
        return subPath == string.Empty ? UPath.Root : subPath;
    }

    static readonly UPath[] folderNames = { "images", "meshes", "materials" };

    protected override IEnumerable<UPath> EnumeratePathsImpl(UPath path, string searchPattern, SearchOption searchOption, SearchTarget searchTarget)
    {
        var pattern = SearchPattern.Parse(ref path, ref searchPattern);
        var folders = folderNames.Select(x => ConvertPathToDelegate(path) / x);
        var images = Model.LogicalImages.Select(x => folderNames[0] / (x.Name ?? x.LogicalIndex.ToString())).Select(ConvertPathToDelegate);
        var meshes = Model.LogicalMeshes.Select(x => folderNames[1] / (x.Name ?? x.LogicalIndex.ToString())).Select(ConvertPathToDelegate);
        var materials = Model.LogicalMaterials.Select(x => folderNames[2] / (x.Name ?? x.LogicalIndex.ToString())).Select(ConvertPathToDelegate);

        var selection = Enumerable.Empty<UPath>();
        if (path == "/images/")
            selection = selection.Concat(images);
        else if (path == "/meshes/")
            selection = selection.Concat(meshes);
        else if (path == "/materials/")
            selection = selection.Concat(materials);
        else
            selection = images.Concat(meshes).Concat(materials);

        return (searchOption, searchTarget) switch
        {
            (_, SearchTarget.Directory) =>
                folders.Where(pattern.Match),
            (SearchOption.AllDirectories, SearchTarget.Both) =>
                folders.Concat(selection).Where(pattern.Match),
            (SearchOption.AllDirectories, SearchTarget.File) =>
                selection.Where(pattern.Match),
            _ => Enumerable.Empty<UPath>()
        };

    }
    protected override IEnumerable<FileSystemItem> EnumerateItemsImpl(UPath path, SearchOption searchOption, SearchPredicate? searchPredicate)
    {
        var folders = folderNames.Select(x => new FileSystemItem(FallbackSafe, ConvertPathToDelegate(x), true));
        var images = Model.LogicalImages.Select(x => new FileSystemItem(FallbackSafe, ConvertPathToDelegate(folderNames[0] / (x.Name ?? x.LogicalIndex.ToString())), false));
        var meshes = Model.LogicalMeshes.Select(x => new FileSystemItem(FallbackSafe, ConvertPathToDelegate(folderNames[1] / (x.Name ?? x.LogicalIndex.ToString())), false));
        var materials = Model.LogicalMaterials.Select(x => new FileSystemItem(FallbackSafe, ConvertPathToDelegate(folderNames[2] / (x.Name ?? x.LogicalIndex.ToString())), false));
        if (path == UPath.Root)
            return images.Concat(meshes).Concat(materials);
        else if (path.GetFirstDirectory(out UPath _) == "images")
            return images;
        else if (path.GetFirstDirectory(out UPath _) == "meshes")
            return meshes;
        else if (path.GetFirstDirectory(out UPath _) == "materials")
            return materials;
        else
            return Enumerable.Empty<FileSystemItem>();
    }

    protected override bool DirectoryExistsImpl(UPath path)
    {
        return
            path == new UPath("/meshes")
            || path == new UPath("/materials")
            || path == new UPath("/images");

    }

    protected override Stream OpenFileImpl(UPath path, FileMode mode, FileAccess access, FileShare share = FileShare.None)
    {
        throw new NotImplementedException();
    }

    public Mesh GetMesh(UPath path)
    {
        var folder = path.GetFirstDirectory(out var rest);
        if(folder != "meshes")
            throw new Exception($"Wrong folder {folder} for meshes");
        return Model.LogicalMeshes
            .First(x => 
                x.LogicalIndex.ToString() == (string)rest.ToRelative()
                || x.Name == (string)rest.ToRelative());
    }
    public Image GetImage(UPath path)
    {
        var folder = path.GetFirstDirectory(out var rest);
        if(folder != "images")
            throw new Exception($"Wrong folder {folder} for images");
        return Model.LogicalImages
            .First(x => 
                x.LogicalIndex.ToString() == (string)rest.ToRelative()
                || x.Name == (string)rest.ToRelative());
    }
    public Material GetMaterial(UPath path)
    {
        var folder = path.GetFirstDirectory(out var rest);
        if(folder != "materials")
            throw new Exception($"Wrong folder {folder} for materials");
        return Model.LogicalMaterials
            .First(x => 
                x.LogicalIndex.ToString() == (string)rest.ToRelative()
                || x.Name == (string)rest.ToRelative());
                
    }
}
