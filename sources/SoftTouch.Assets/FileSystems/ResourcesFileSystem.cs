/*
 * Copyright (c) 2022 Youness Kafia
 */
using Zio;
using Zio.FileSystems;

namespace SoftTouch.Assets.FileSystems;

public class ResourcesFileSystem : AggregateFileSystem
{
    public override void AddFileSystem(IFileSystem fs)
    {
        base.AddFileSystem(fs);
    }
    protected override IEnumerable<UPath> EnumeratePathsImpl(UPath path, string searchPattern, SearchOption searchOption, SearchTarget searchTarget)
    {
        SearchPattern.Parse(ref path, ref searchPattern);

        var entries = new SortedSet<UPath>();
        var fileSystems = new List<IFileSystem>();
        var assetFiles = new List<CompositeAssetFileSystem>();

        if (Fallback != null)
        {
            fileSystems.Add(Fallback);
        }

        // Query all filesystems, separating gltf ones.
        fileSystems.AddRange(GetFileSystems().Where(x => x is not CompositeAssetFileSystem));
        assetFiles.AddRange(GetFileSystems().OfType<CompositeAssetFileSystem>().Where(x => path.IsInDirectory(x.FilePath, true)));
        
        if (assetFiles.Any())
        {
            var fs = assetFiles.First();
            var gltfFSPath = new UPath(string.Join('/', path.Split().Except(fs.FilePath.Split()))).ToAbsolute();
            foreach (var item in fs.EnumeratePaths(path, searchPattern, searchOption, searchTarget))
            {
                if (entries.Contains(item)) continue;
                entries.Add(item);
            }
        }
        else
        {
            for (var i = fileSystems.Count - 1; i >= 0; i--)
            {
                var fileSystem = fileSystems[i];

                if (!fileSystem.DirectoryExists(path))
                    continue;

                foreach (var item in fileSystem.EnumeratePaths(path, searchPattern, searchOption, searchTarget))
                {
                    if (entries.Contains(item)) continue;
                    entries.Add(item);
                }
            }
        }

        // Return entries
        foreach (var entry in entries)
        {
            yield return entry;
        }
    }
}