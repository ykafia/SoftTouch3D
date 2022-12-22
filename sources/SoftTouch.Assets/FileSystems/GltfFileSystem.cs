// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using SharpGLTF.Schema2;
using Zio;
using Zio.FileSystems;

namespace SoftTouch.Assets.FileSystems;
[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "(),nq}")]
public class GltfFileSystem : ComposeFileSystem
{
    ModelRoot Model;

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
        if (!fileSystem.FileExists(SubPath))
        {
            throw new Exception("Cannot find file");
        }
        else
            Model = ModelRoot.Load(fileSystem.ConvertPathToInternal(SubPath));
    }

    /// <summary>
    /// Gets the sub path relative to the delegate <see cref="ComposeFileSystem.Fallback"/>
    /// </summary>
    public UPath SubPath { get; }

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

    protected override UPath ConvertPathToDelegate(UPath path)
    {
        var safePath = path.ToRelative();
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

    static readonly string[] folderNames = {"images", "meshes", "materials"};
    
    
    protected override IEnumerable<FileSystemItem> EnumerateItemsImpl(UPath path, SearchOption searchOption, SearchPredicate? searchPredicate)
    {
        var folders = folderNames.Select(x => new FileSystemItem(FallbackSafe, ConvertPathToDelegate(path) / x, true));
        var images = Model.LogicalImages.Select(x => new FileSystemItem(FallbackSafe, ConvertPathToDelegate(path) / folderNames[0] / (x.Name ?? x.LogicalIndex.ToString()),false));
        var meshes = Model.LogicalMeshes.Select(x => new FileSystemItem(FallbackSafe, ConvertPathToDelegate(path) / folderNames[1] / (x.Name ?? x.LogicalIndex.ToString()),false));
        var materials = Model.LogicalMaterials.Select(x => new FileSystemItem(FallbackSafe, ConvertPathToDelegate(path) / folderNames[2] / (x.Name ?? x.LogicalIndex.ToString()),false));
        if(path == UPath.Root) 
            return images.Concat(meshes).Concat(materials).Concat(meshes);
        else if(path.GetFirstDirectory(out UPath _) == "images")
            return images;
        else if(path.GetFirstDirectory(out UPath _) == "meshes")
            return meshes;
        else if(path.GetFirstDirectory(out UPath _) == "materials")
            return materials;
        else 
            return Enumerable.Empty<FileSystemItem>();
    }

    
}
